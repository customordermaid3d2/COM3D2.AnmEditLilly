namespace COM3D2.AnmEditLilly
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.menuStrip3 = new System.Windows.Forms.MenuStrip();
            this.saveTop = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTextBoxTop0 = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripTextBoxTop1 = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripTextBoxTop2 = new System.Windows.Forms.ToolStripTextBox();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.saveBot = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTextBoxBot0 = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripTextBoxBot1 = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripTextBoxBot2 = new System.Windows.Forms.ToolStripTextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.menuStrip3.SuspendLayout();
            this.menuStrip2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.Font = new System.Drawing.Font("나눔고딕코딩", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textBox1.Location = new System.Drawing.Point(0, 27);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox1.Size = new System.Drawing.Size(837, 282);
            this.textBox1.TabIndex = 0;
            // 
            // textBox2
            // 
            this.textBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox2.Font = new System.Drawing.Font("나눔고딕코딩", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textBox2.Location = new System.Drawing.Point(0, 27);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox2.Size = new System.Drawing.Size(837, 307);
            this.textBox2.TabIndex = 1;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.textBox1);
            this.splitContainer1.Panel1.Controls.Add(this.menuStrip3);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.textBox2);
            this.splitContainer1.Panel2.Controls.Add(this.menuStrip2);
            this.splitContainer1.Size = new System.Drawing.Size(837, 647);
            this.splitContainer1.SplitterDistance = 309;
            this.splitContainer1.TabIndex = 2;
            // 
            // menuStrip3
            // 
            this.menuStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveTop,
            this.toolStripTextBoxTop0,
            this.toolStripTextBoxTop1,
            this.toolStripTextBoxTop2});
            this.menuStrip3.Location = new System.Drawing.Point(0, 0);
            this.menuStrip3.Name = "menuStrip3";
            this.menuStrip3.Size = new System.Drawing.Size(837, 27);
            this.menuStrip3.TabIndex = 1;
            this.menuStrip3.Text = "menuStrip3";
            // 
            // saveTop
            // 
            this.saveTop.Name = "saveTop";
            this.saveTop.Size = new System.Drawing.Size(42, 23);
            this.saveTop.Text = "save";
            this.saveTop.Click += new System.EventHandler(this.saveTop_Click_1);
            // 
            // toolStripTextBoxTop0
            // 
            this.toolStripTextBoxTop0.Name = "toolStripTextBoxTop0";
            this.toolStripTextBoxTop0.Size = new System.Drawing.Size(100, 23);
            this.toolStripTextBoxTop0.Text = "tan1";
            // 
            // toolStripTextBoxTop1
            // 
            this.toolStripTextBoxTop1.Name = "toolStripTextBoxTop1";
            this.toolStripTextBoxTop1.Size = new System.Drawing.Size(100, 23);
            this.toolStripTextBoxTop1.Text = "tan1";
            this.toolStripTextBoxTop1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.toolStripTextBox_KeyDown);
            this.toolStripTextBoxTop1.TextChanged += new System.EventHandler(this.toolStripTextBox_TextChanged);
            // 
            // toolStripTextBoxTop2
            // 
            this.toolStripTextBoxTop2.Name = "toolStripTextBoxTop2";
            this.toolStripTextBoxTop2.Size = new System.Drawing.Size(100, 23);
            this.toolStripTextBoxTop2.Text = "tan2";
            this.toolStripTextBoxTop2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.toolStripTextBox_KeyDown);
            this.toolStripTextBoxTop2.TextChanged += new System.EventHandler(this.toolStripTextBox_TextChanged);
            // 
            // menuStrip2
            // 
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveBot,
            this.toolStripTextBoxBot0,
            this.toolStripTextBoxBot1,
            this.toolStripTextBoxBot2});
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(837, 27);
            this.menuStrip2.TabIndex = 2;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // saveBot
            // 
            this.saveBot.Name = "saveBot";
            this.saveBot.Size = new System.Drawing.Size(42, 23);
            this.saveBot.Text = "save";
            this.saveBot.Click += new System.EventHandler(this.saveBot_Click);
            // 
            // toolStripTextBoxBot0
            // 
            this.toolStripTextBoxBot0.Name = "toolStripTextBoxBot0";
            this.toolStripTextBoxBot0.Size = new System.Drawing.Size(100, 23);
            // 
            // toolStripTextBoxBot1
            // 
            this.toolStripTextBoxBot1.Name = "toolStripTextBoxBot1";
            this.toolStripTextBoxBot1.Size = new System.Drawing.Size(100, 23);
            this.toolStripTextBoxBot1.Text = "tan1";
            this.toolStripTextBoxBot1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.toolStripTextBox_KeyDown);
            this.toolStripTextBoxBot1.TextChanged += new System.EventHandler(this.toolStripTextBox_TextChanged);
            // 
            // toolStripTextBoxBot2
            // 
            this.toolStripTextBoxBot2.Name = "toolStripTextBoxBot2";
            this.toolStripTextBoxBot2.Size = new System.Drawing.Size(100, 23);
            this.toolStripTextBoxBot2.Text = "tan2";
            this.toolStripTextBoxBot2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.toolStripTextBox_KeyDown);
            this.toolStripTextBoxBot2.TextChanged += new System.EventHandler(this.toolStripTextBox_TextChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(837, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.openToolStripMenuItem.Text = "open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(837, 671);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip2;
            this.Name = "Form1";
            this.Text = "Form1";
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Form1_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form1_DragEnter);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.menuStrip3.ResumeLayout(false);
            this.menuStrip3.PerformLayout();
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.MenuStrip menuStrip3;
        private System.Windows.Forms.ToolStripMenuItem saveTop;
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem saveBot;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBoxBot1;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBoxBot2;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBoxTop1;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBoxTop2;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBoxTop0;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBoxBot0;
    }
}

