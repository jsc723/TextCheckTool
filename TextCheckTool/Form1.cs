using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace TextCheckTool
{

    public partial class Form1 : Form
    {
        private class SentenceComment : IComparable<SentenceComment>
        {
            int line;
            string sentence;
            string comments;
            public SentenceComment(int line, string sentence)
            {
                this.line = line;
                this.sentence = sentence;
                comments = "";
            }
            public void addComment(string comment)
            {
                if (comments.Length != 0)
                    comments += "; ";
                comments += comment;
            }
            public int CompareTo(SentenceComment sc)
            {
                return line - sc.line;
            }
            public override string ToString()
            {
                return String.Format("第{0}行\n原句：{1}\n{2}\n", line, sentence, comments);
            }
        }
        public const int WM_USER = 0x0400;
        public const int WM_UPDATELINE = WM_USER + 723;
        Dictionary<string, int> dic;
        Dictionary<string, double> scoreMap;
        List<string> text;
        List<SentenceComment> comments;
        string path;
        double totalScore, currentScore;
        OpenFileDialog openFileDialog;
        SaveFileDialog saveFileDialog;

        [DllImport("CheckText.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern uint GetCurrentLineNum();

        [DllImport("CheckText.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void SetWorking(bool w);

        [DllImport("CheckText.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void SetHandleGUI(IntPtr handle);


        public Form1(string[] args = null)
        {
            InitializeComponent();

            init();

            path = "";
            StringBuilder sb = new StringBuilder();
            if (args != null)
            {
                foreach (string s in args)
                {
                    if (sb.Length != 0)
                        sb.Append(" ");
                    sb.Append(s);
                }
                path = sb.ToString();
                readFile();
            }

        }
        public void outPutString(String s)
        {
            textBox1.Text = s;
        }
        private void init()
        {
            dic = new Dictionary<string, int>();
            foreach (var i in checkedListBox.Items)
            {
                dic.Add(i.ToString(), 0);
            }
            comments = new List<SentenceComment>();
            text = new List<string>();
            SetHandleGUI(Handle);
        }
        private void makeReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int slashIndex = path.LastIndexOf("\\");
            if (slashIndex < 0) slashIndex = path.Length;
            int dotIndex = path.LastIndexOf(".");
            saveFileDialog.InitialDirectory = path.Substring(0, slashIndex);
            saveFileDialog.FileName = path.Substring(slashIndex + 1, dotIndex - slashIndex - 1) + "(校对报告).txt";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;
                FileStream fs = new FileStream(filePath, FileMode.Create);
                StreamWriter sw = new StreamWriter(fs);
                sw.WriteLine("------------文本校对报告-----------\n");
                sw.WriteLine("被校对的文件名：{0}", path);
                sw.WriteLine("文本总行数：{0}", text.Count);
                sw.WriteLine("正确率估算：{0}%", 100 * currentScore / totalScore);
                sw.WriteLine("\n------------错误统计：------------\n");
                foreach (var i in dic)
                {
                    sw.WriteLine("{0}:{1}", i.Key, i.Value);
                }
                sw.WriteLine("\n------------详细报告-------------\n");
                comments.Sort();
                foreach (var comment in comments)
                    sw.WriteLine(comment);
                sw.Flush();
                sw.Close();
                fs.Close();
                System.Diagnostics.Process.Start(filePath);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int line = (int)GetCurrentLineNum();
            labelLine.Text = line.ToString();
            SentenceComment sc = new SentenceComment(line, text[line - 1]);
            foreach (var i in checkedListBox.CheckedItems)
            {
                string key = i.ToString();
                dic[key] += +1;
                sc.addComment(key);
                currentScore -= scoreMap[key];
            }
            comments.Add(sc);
            for (int i = 0; i < checkedListBox.Items.Count; i++)
            {
                checkedListBox.SetItemCheckState(i, CheckState.Unchecked);
            }
            checkedListBox.ClearSelected();
        }
        private void readFile()
        {
            addBtn.Enabled = true;
            text = new List<string>();
            StreamReader sr = new StreamReader(path, Encoding.Default);
            string line;
            int validLine = 0, headGuess = 14, nameMargin = 6;
            while ((line = sr.ReadLine()) != null)
            {
                text.Add(line);
                if (line.Length > 5 && line.Length < headGuess + 1)
                    headGuess--;
                if (line.Length > headGuess + nameMargin)
                    validLine++;
            }
            totalScore = 10 * 0.5 * validLine;
            currentScore = totalScore;
            outPutString(String.Format("共{0}行，需校对约{1}行", text.Count, validLine));
        }
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                path = openFileDialog.FileName;
                readFile();
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("确定关闭？", "确定关闭", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
            else
            {
                SetWorking(false);

                FileStream fs = new FileStream(System.Environment.CurrentDirectory + "TextCheckTool.dat", FileMode.Create);
                StreamWriter sw = new StreamWriter(fs, Encoding.UTF8);
                sw.WriteLine("ShowOutput={0}", textBox1.Visible);
                sw.WriteLine("ShowInput={0}", textBox2.Visible);
                sw.WriteLine("Opacity={0}", Opacity);
                sw.WriteLine("TopMost={0}", TopMost);
                sw.WriteLine("Choice");
                foreach (string s in checkedListBox.Items)
                {
                    sw.WriteLine("{0}={1}", s, scoreMap[s]);
                }
                sw.Flush();
                sw.Close();
                fs.Close();
            }
        }

        private void Form1_Activated(object sender, EventArgs e)
        {
            labelLine.Text = GetCurrentLineNum().ToString();
        }

        [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
        protected override void WndProc(ref Message m)
        {
            // Listen for operating system messages.
            switch (m.Msg)
            {
                case WM_UPDATELINE:
                    labelLine.Text = GetCurrentLineNum().ToString();
                    break;
            }
            base.WndProc(ref m);
        }

        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.All;
            else
                e.Effect = DragDropEffects.None;
        }

        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            path = ((Array)e.Data.GetData(DataFormats.FileDrop)).GetValue(0).ToString();
            readFile();
        }

        private void hideOutputBoxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Visible = !textBox1.Visible;
            if (!textBox1.Visible)
                textBox2.Visible = false;
            refreshHideInOutputText();
        }
        private void 隐藏输入框ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox2.Visible = !textBox2.Visible;
            if (textBox2.Visible)
                textBox1.Visible = true;
            refreshHideInOutputText();
        }
        private void refreshHideInOutputText()
        {
            int count = 0;
            if (textBox1.Visible)
            {
                count = 1;
                ((ToolStripMenuItem)menuStrip1.Items[1]).DropDownItems[1].Text = "隐藏输出框";
            }
            else
                ((ToolStripMenuItem)menuStrip1.Items[1]).DropDownItems[1].Text = "显示输出框";
            if (textBox2.Visible)
            {
                count = 2;
                ((ToolStripMenuItem)menuStrip1.Items[1]).DropDownItems[0].Text = "隐藏输入框";
            }
            else
                ((ToolStripMenuItem)menuStrip1.Items[1]).DropDownItems[0].Text = "显示输入框";
            checkedListBox.Height = 6 * 34 - count * 20;
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e) { this.Opacity = 0.25; }

        private void toolStripMenuItem3_Click(object sender, EventArgs e) { this.Opacity = 0.5; }

        private void toolStripMenuItem4_Click(object sender, EventArgs e) { this.Opacity = 0.75; }

        private void toolStripMenuItem5_Click(object sender, EventArgs e) { this.Opacity = 1; }

        private void 窗口置顶ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TopMost = !TopMost;
            refreshTopMostText();
        }
        private void refreshTopMostText()
        {
            if (TopMost)
                ((ToolStripMenuItem)menuStrip1.Items[1]).DropDownItems[3].Text = "取消窗口置顶";
            else
                ((ToolStripMenuItem)menuStrip1.Items[1]).DropDownItems[3].Text = "窗口置顶";
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            scoreMap = new Dictionary<string, double>();
            Width = 560;
            Height = 780;

            ShowIcon = false;
            string datPath = System.Environment.CurrentDirectory + "TextCheckTool.dat";
            FileStream fs = new FileStream(datPath, FileMode.OpenOrCreate, FileAccess.Read);
            StreamReader sr = new StreamReader(datPath, Encoding.UTF8);
            try
            {
                string line;
                string[] terms;
                while ((line = sr.ReadLine()) != null)
                {
                    if (line.Length == 0)
                        continue;
                    terms = line.Trim().Split('=');
                    if (terms[0] == "ShowOutput")
                        textBox1.Visible = Boolean.Parse(terms[1]);
                    else if (terms[0] == "ShowInput")
                    {
                        textBox2.Visible = Boolean.Parse(terms[1]);
                    }
                    else if (terms[0] == "Opacity")
                        Opacity = Double.Parse(terms[1]);
                    else if (terms[0] == "TopMost")
                        TopMost = Boolean.Parse(terms[1]);
                    else if (terms[0] == "Choice")
                        break;
                }
                if (line == null)
                    throw new Exception("no data, create new");
                while ((line = sr.ReadLine()) != null)
                {
                    terms = line.Trim().Split('=');
                    double score = Double.Parse(terms[1]);
                    checkedListBox.Items.Add(terms[0]);
                    scoreMap.Add(terms[0], score);
                }
            }
            catch
            {
                textBox1.Visible = true;
                Opacity = 0.75;
                TopMost = true;
                checkedListBox.Items.Add("润色（无错误）");
                checkedListBox.Items.Add("标点符号");
                checkedListBox.Items.Add("错别字、漏字、多字");
                checkedListBox.Items.Add("用词不恰当");
                checkedListBox.Items.Add("用词错误");
                checkedListBox.Items.Add("漏翻（少）");
                checkedListBox.Items.Add("漏翻（多）");
                checkedListBox.Items.Add("句子不通顺");
                checkedListBox.Items.Add("句子理解不恰当");
                checkedListBox.Items.Add("句子理解错误");
                double[] scores = { 0, 0.5, 1, 2, 5, 2, 6, 3, 5, 10 };
                int i = 0;
                foreach (string s in checkedListBox.Items)
                {
                    scoreMap.Add(s, scores[i++]);
                }
            }
            fs.Close();
            sr.Close();
            foreach (var i in checkedListBox.Items)
                dic.Add(i.ToString(), 0);
            refreshTopMostText();
            refreshHideInOutputText();
            openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = "C:\\";
            openFileDialog.Filter = "Txt文件(*.txt)|*.txt";
            openFileDialog.RestoreDirectory = false;
            openFileDialog.FilterIndex = 1;
            saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = "C:\\";
            saveFileDialog.Filter = "Txt文件(*.txt) | *.txt";
            saveFileDialog.RestoreDirectory = false;

        }
        private void processInput()
        {
            string commond = textBox2.Text.Trim();
            string[] cmds = commond.Split(' ');
            try
            {
                if (cmds[0] == "add")
                {
                    string term = cmds[1];
                    double score = Double.Parse(cmds[2]);
                    if (scoreMap.ContainsKey(term))
                    {
                        scoreMap[term] = score;
                    }
                    else if (cmds.Length == 3)
                    {
                        scoreMap.Add(term, score);
                        dic.Add(term, 0);
                        checkedListBox.Items.Add(term);
                    }
                    else if (cmds.Length == 5 && cmds[3] == "at")
                    {
                        int index = Int32.Parse(cmds[4]);
                        scoreMap.Add(term, score);
                        dic.Add(term, 0);
                        checkedListBox.Items.Insert(index, term);
                    }
                }
                else if (cmds[0] == "set" && cmds[2] == "to")
                {
                    int index = Int32.Parse(cmds[1]);
                    double score = Double.Parse(cmds[3]);
                    scoreMap[checkedListBox.Items[index].ToString()] = score;
                }
                else if (cmds[0] == "remove")
                {
                    int index = Int32.Parse(cmds[1]);
                    string key = checkedListBox.Items[index].ToString();
                    scoreMap.Remove(key);
                    dic.Remove(key);
                    checkedListBox.Items.RemoveAt(index);
                }
                else if (cmds[0] == "move" && cmds[2] == "to")
                {
                    int wantMove = Int32.Parse(cmds[1]);
                    int pos = Int32.Parse(cmds[3]);
                    string value = checkedListBox.Items[pos].ToString();
                    value = checkedListBox.Items[wantMove].ToString();
                    checkedListBox.Items.RemoveAt(wantMove);
                    checkedListBox.Items.Insert(pos, value);
                }
                else if (cmds[0] == "show")
                {
                    outPutString("");
                    if (cmds[1] == "score")
                    {
                        if (cmds[2] == "all")
                            foreach (string key in checkedListBox.Items)
                                textBox1.Text += String.Format("[{0},{1}]", key[0], scoreMap[key]);
                        else
                        {
                            int index = Int32.Parse(cmds[2]);
                            string key = checkedListBox.Items[index].ToString();
                            outPutString(String.Format("[{0},{1}]", key, scoreMap[key]));
                        }
                    }
                    else if (cmds[1] == "mistakes")
                    {
                        if (cmds[2] == "all")
                            foreach (string key in checkedListBox.Items)
                                textBox1.Text += String.Format("[{0},{1}]", key[0], dic[key]);
                        else
                        {
                            int index = Int32.Parse(cmds[2]);
                            string key = checkedListBox.Items[index].ToString();
                            outPutString(String.Format("[{0},{1}]", key, dic[key]));
                        }
                    }
                    else
                        throw new Exception("无法识别指令");
                }
                else
                {
                    throw new Exception("无法识别指令");
                }
                textBox2.Text = "";
            }
            catch (Exception err)
            {
                outPutString(err.Message);
            }
        }

        private void Form1_MouseHover(object sender, EventArgs e)
        {
            Size = MaximumSize;
            OnSizeChanged(e);
        }
        
        private void labelSizeChange_MouseClick(object sender, MouseEventArgs e)
        {
            Size = MinimumSize;
            OnSizeChanged(e);
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            if (Size == MinimumSize)
                labelSizeChange.Text = "▽";
            else
                labelSizeChange.Text = "△";
            
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                processInput();
            }
        }
    }
}
