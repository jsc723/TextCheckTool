namespace TextCheckTool
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.makeReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.隐藏输入框ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hideOutputBoxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.透明度ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.窗口置顶ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkedListBox = new System.Windows.Forms.CheckedListBox();
            this.addBtn = new System.Windows.Forms.Button();
            this.lineNumLabel = new System.Windows.Forms.Label();
            this.labelLine = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.labelSizeChange = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(40, 40);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.configToolStripMenuItem});
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Name = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.makeReportToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            resources.ApplyResources(this.fileToolStripMenuItem, "fileToolStripMenuItem");
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            resources.ApplyResources(this.newToolStripMenuItem, "newToolStripMenuItem");
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // makeReportToolStripMenuItem
            // 
            this.makeReportToolStripMenuItem.Name = "makeReportToolStripMenuItem";
            resources.ApplyResources(this.makeReportToolStripMenuItem, "makeReportToolStripMenuItem");
            this.makeReportToolStripMenuItem.Click += new System.EventHandler(this.makeReportToolStripMenuItem_Click);
            // 
            // configToolStripMenuItem
            // 
            this.configToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.隐藏输入框ToolStripMenuItem,
            this.hideOutputBoxToolStripMenuItem,
            this.透明度ToolStripMenuItem,
            this.窗口置顶ToolStripMenuItem});
            this.configToolStripMenuItem.Name = "configToolStripMenuItem";
            resources.ApplyResources(this.configToolStripMenuItem, "configToolStripMenuItem");
            // 
            // 隐藏输入框ToolStripMenuItem
            // 
            this.隐藏输入框ToolStripMenuItem.Name = "隐藏输入框ToolStripMenuItem";
            resources.ApplyResources(this.隐藏输入框ToolStripMenuItem, "隐藏输入框ToolStripMenuItem");
            this.隐藏输入框ToolStripMenuItem.Click += new System.EventHandler(this.隐藏输入框ToolStripMenuItem_Click);
            // 
            // hideOutputBoxToolStripMenuItem
            // 
            this.hideOutputBoxToolStripMenuItem.Name = "hideOutputBoxToolStripMenuItem";
            resources.ApplyResources(this.hideOutputBoxToolStripMenuItem, "hideOutputBoxToolStripMenuItem");
            this.hideOutputBoxToolStripMenuItem.Click += new System.EventHandler(this.hideOutputBoxToolStripMenuItem_Click);
            // 
            // 透明度ToolStripMenuItem
            // 
            this.透明度ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.toolStripMenuItem3,
            this.toolStripMenuItem4,
            this.toolStripMenuItem5});
            this.透明度ToolStripMenuItem.Name = "透明度ToolStripMenuItem";
            resources.ApplyResources(this.透明度ToolStripMenuItem, "透明度ToolStripMenuItem");
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            resources.ApplyResources(this.toolStripMenuItem2, "toolStripMenuItem2");
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            resources.ApplyResources(this.toolStripMenuItem3, "toolStripMenuItem3");
            this.toolStripMenuItem3.Click += new System.EventHandler(this.toolStripMenuItem3_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            resources.ApplyResources(this.toolStripMenuItem4, "toolStripMenuItem4");
            this.toolStripMenuItem4.Click += new System.EventHandler(this.toolStripMenuItem4_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            resources.ApplyResources(this.toolStripMenuItem5, "toolStripMenuItem5");
            this.toolStripMenuItem5.Click += new System.EventHandler(this.toolStripMenuItem5_Click);
            // 
            // 窗口置顶ToolStripMenuItem
            // 
            this.窗口置顶ToolStripMenuItem.Name = "窗口置顶ToolStripMenuItem";
            resources.ApplyResources(this.窗口置顶ToolStripMenuItem, "窗口置顶ToolStripMenuItem");
            this.窗口置顶ToolStripMenuItem.Click += new System.EventHandler(this.窗口置顶ToolStripMenuItem_Click);
            // 
            // checkedListBox
            // 
            resources.ApplyResources(this.checkedListBox, "checkedListBox");
            this.checkedListBox.CheckOnClick = true;
            this.checkedListBox.FormattingEnabled = true;
            this.checkedListBox.Name = "checkedListBox";
            this.checkedListBox.MouseHover += new System.EventHandler(this.Form1_MouseHover);
            // 
            // addBtn
            // 
            resources.ApplyResources(this.addBtn, "addBtn");
            this.addBtn.Name = "addBtn";
            this.addBtn.UseVisualStyleBackColor = true;
            this.addBtn.Click += new System.EventHandler(this.button1_Click);
            this.addBtn.MouseHover += new System.EventHandler(this.Form1_MouseHover);
            // 
            // lineNumLabel
            // 
            resources.ApplyResources(this.lineNumLabel, "lineNumLabel");
            this.lineNumLabel.Name = "lineNumLabel";
            this.lineNumLabel.MouseHover += new System.EventHandler(this.Form1_MouseHover);
            // 
            // labelLine
            // 
            resources.ApplyResources(this.labelLine, "labelLine");
            this.labelLine.Name = "labelLine";
            this.labelLine.MouseHover += new System.EventHandler(this.Form1_MouseHover);
            // 
            // textBox1
            // 
            resources.ApplyResources(this.textBox1, "textBox1");
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.MouseHover += new System.EventHandler(this.Form1_MouseHover);
            // 
            // textBox2
            // 
            resources.ApplyResources(this.textBox2, "textBox2");
            this.textBox2.Name = "textBox2";
            this.textBox2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox2_KeyDown);
            this.textBox2.MouseHover += new System.EventHandler(this.Form1_MouseHover);
            // 
            // labelSizeChange
            // 
            resources.ApplyResources(this.labelSizeChange, "labelSizeChange");
            this.labelSizeChange.Name = "labelSizeChange";
            this.labelSizeChange.MouseClick += new System.Windows.Forms.MouseEventHandler(this.labelSizeChange_MouseClick);
            this.labelSizeChange.MouseHover += new System.EventHandler(this.Form1_MouseHover);
            // 
            // Form1
            // 
            this.AllowDrop = true;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelSizeChange);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.labelLine);
            this.Controls.Add(this.lineNumLabel);
            this.Controls.Add(this.addBtn);
            this.Controls.Add(this.checkedListBox);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Opacity = 0.75D;
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.TopMost = true;
            this.Activated += new System.EventHandler(this.Form1_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Form1_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form1_DragEnter);
            this.MouseHover += new System.EventHandler(this.Form1_MouseHover);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem makeReportToolStripMenuItem;
        private System.Windows.Forms.CheckedListBox checkedListBox;
        private System.Windows.Forms.Button addBtn;
        private System.Windows.Forms.Label lineNumLabel;
        private System.Windows.Forms.Label labelLine;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ToolStripMenuItem configToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hideOutputBoxToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 透明度ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem 窗口置顶ToolStripMenuItem;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.ToolStripMenuItem 隐藏输入框ToolStripMenuItem;
        private System.Windows.Forms.Label labelSizeChange;
    }
}

