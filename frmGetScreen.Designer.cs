namespace 录屏软件1
{
    partial class frmGetScreen
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGetScreen));
            this.GetMovieTimer = new System.Windows.Forms.Timer(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiOpenPicFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tsmiGetMovie = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiPlayMovie = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSaveEXEMovie = new System.Windows.Forms.ToolStripMenuItem();
            this.PlayMovieTimer = new System.Windows.Forms.Timer(this.components);
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // GetMovieTimer
            // 
            this.GetMovieTimer.Tick += new System.EventHandler(this.GetMovieTimer_Tick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.ContextMenuStrip = this.contextMenuStrip1;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 28);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(389, 304);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiOpenPicFolder});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(214, 28);
            // 
            // tsmiOpenPicFolder
            // 
            this.tsmiOpenPicFolder.Name = "tsmiOpenPicFolder";
            this.tsmiOpenPicFolder.Size = new System.Drawing.Size(213, 24);
            this.tsmiOpenPicFolder.Text = "打开截图所在文件夹";
            this.tsmiOpenPicFolder.Click += new System.EventHandler(this.tsmiOpenPicFolder_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiGetMovie,
            this.tsmiPlayMovie,
            this.tsmiSaveEXEMovie});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(389, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tsmiGetMovie
            // 
            this.tsmiGetMovie.Name = "tsmiGetMovie";
            this.tsmiGetMovie.Size = new System.Drawing.Size(51, 24);
            this.tsmiGetMovie.Text = "录制";
            this.tsmiGetMovie.Click += new System.EventHandler(this.tsmiGetMovie_Click);
            // 
            // tsmiPlayMovie
            // 
            this.tsmiPlayMovie.Name = "tsmiPlayMovie";
            this.tsmiPlayMovie.Size = new System.Drawing.Size(51, 24);
            this.tsmiPlayMovie.Text = "播放";
            this.tsmiPlayMovie.Click += new System.EventHandler(this.tsmiPlayMovie_Click);
            // 
            // tsmiSaveEXEMovie
            // 
            this.tsmiSaveEXEMovie.Name = "tsmiSaveEXEMovie";
            this.tsmiSaveEXEMovie.Size = new System.Drawing.Size(137, 24);
            this.tsmiSaveEXEMovie.Text = "保存EXE格式视频";
            this.tsmiSaveEXEMovie.Click += new System.EventHandler(this.tsmiSaveEXEMovie_Click);
            // 
            // PlayMovieTimer
            // 
            this.PlayMovieTimer.Tick += new System.EventHandler(this.PlayMovieTimer_Tick);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog1_FileOk);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(256, 0);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(4);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(133, 29);
            this.progressBar1.TabIndex = 2;
            // 
            // frmGetScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(389, 332);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmGetScreen";
            this.Text = "录屏软件";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer GetMovieTimer;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Timer PlayMovieTimer;
        private System.Windows.Forms.ToolStripMenuItem tsmiGetMovie;
        private System.Windows.Forms.ToolStripMenuItem tsmiPlayMovie;
        private System.Windows.Forms.ToolStripMenuItem tsmiSaveEXEMovie;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmiOpenPicFolder;
    }
}

