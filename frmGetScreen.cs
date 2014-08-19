using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Media;
using System.Runtime.InteropServices;
using System.Xml;
using System.Diagnostics;
using System.Resources;
using System.Reflection;
using System.Drawing.Imaging;

namespace 录屏软件1
{
    public partial class frmGetScreen : Form
    {
        #region 属性部分
        private SoundPlayer player;  //音频对象
        private string fileName = "data"; //临时文件夹
        private int i = 1; //迭代变量
        private int j = 1; //临时文件夹迭代量
        Screen screen = Screen.PrimaryScreen;
        Graphics myGraphics;
        Bitmap memoryImage;
        Graphics memoryGraphics;
        FileInfo fi;
        ImageCodecInfo myImageCodecInfo;
        System.Drawing.Imaging.Encoder myEncoder;
        EncoderParameter myEncoderParameter;
        EncoderParameters myEncoderParameters;
        public int x1 = 200, y1 = 150, w = 200, h = 200;
        #endregion

        #region 构造函数
        public frmGetScreen()
        {
            InitializeComponent();

            myGraphics = this.CreateGraphics();

            myImageCodecInfo = GetEncoderInfo("image/jpeg");
            myEncoder = System.Drawing.Imaging.Encoder.Quality;
            myEncoderParameters = new EncoderParameters(1);
            myEncoderParameter = new EncoderParameter(myEncoder, 100L);
            myEncoderParameters.Param[0] = myEncoderParameter;
        }
        #endregion

        #region 导入录音dll文件
        [DllImport("winmm.dll")]
        private static extern int mciSendString
            (
                string lpstrCommand,
                string lpstrReturnString,
                int uReturnLength,
                int hwndCallback
            );
        # endregion

        #region 窗体加载时
        private void Form1_Load(object sender, EventArgs e)
        {
            CreatePicFolder();
          
        }

       
        #endregion

        #region 创建文件夹
        /// <summary>
        /// 创建img文件夹,执行之前调用了DelData()
        /// </summary>
        public void CreatePicFolder()
        {
            try
            {
                DelData();
                if (!Directory.Exists(fileName))
                {
                    Directory.CreateDirectory(fileName);
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        #endregion

        #region 播放录音文件
        /// <summary>
        /// 播放录音文件
        /// </summary>
        private void PlaySound()
        {
            player = new System.Media.SoundPlayer(fileName + "//music.wav");
            try
            {
                player.Play();
            }
            catch (Exception ex)
            {
                ex.ToString();
                MessageBox.Show("没有要播放的视频，请您先录制！");
            }
        }
        #endregion

        #region 停止播放录音文件
        /// <summary>
        /// 停止播放录音文件
        /// </summary>
        private void StopSound()
        {
            player = new System.Media.SoundPlayer(fileName + "//music.wav");
            player.Stop();
        }
        #endregion

        # region 开始录音
        /// <summary>
        /// 开始录音
        /// </summary>
        private void Record()
        {
            mciSendString("close movie", "", 0, 0);
            mciSendString("open new type WAVEAudio alias movie", "", 0, 0);
            mciSendString("record movie", "", 0, 0);
        }
        # endregion

        #region 停止录音并保存
        /// <summary>
        /// 停止录音并保存,文件名默认为music.wav
        /// </summary>
        private void StopRecord()
        {
            mciSendString("stop movie", "", 0, 0);
            mciSendString("save movie " + fileName + "//music.wav", "", 0, 0);
            mciSendString("close movie", "", 0, 0);
        }
        #endregion

        # region 录制视频
        /// <summary>
        /// 录制视频:1.开始录音 2.并启动录制视频定时器
        /// </summary>
        public void GetMovie()
        {
            Record();
            this.GetMovieTimer.Start();
        }
        # endregion

        #region 录制视频定时器
        /// <summary>
        /// 录制视频定时器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GetMovieTimer_Tick(object sender, EventArgs e)
        {
            // memoryGraphics.CopyFromScreen(0, 0, 0, 0,
            // new Size(screen.Bounds.Width, screen.Bounds.Height));
            //memoryImage = new Bitmap(screen.Bounds.Width,
            //screen.Bounds.Height, myGraphics);
            memoryImage = new Bitmap(w, h, myGraphics);
            memoryGraphics = Graphics.FromImage(memoryImage);
            memoryGraphics.CopyFromScreen(x1, y1, 0, 0, new Size(w, h));
            this.pictureBox1.Image = memoryImage;
            Bitmap smallImage = new Bitmap(memoryImage, memoryImage.Width/2, memoryImage.Height/2);
            smallImage.Save(fileName + @"\" + i++ + ".jpg", myImageCodecInfo, myEncoderParameters);
        }
        #endregion

        #region 图片编码设置
        /// <summary>
        /// 图片编码设置
        /// </summary>
        /// <param name="mimeType"></param>
        /// <returns></returns>
        private static ImageCodecInfo GetEncoderInfo(String mimeType)
        {
            int j;
            ImageCodecInfo[] encoders;
            encoders = ImageCodecInfo.GetImageEncoders();
            for (j = 0; j < encoders.Length; ++j)
            {
                if (encoders[j].MimeType == mimeType)
                    return encoders[j];
            }
            return null;
        }
        # endregion

        # region 播放视频
        /// <summary>
        /// 播放视频
        /// </summary>
        private void PlayMovie()
        {
            PlaySound();
            this.PlayMovieTimer.Start();
        }
        #endregion

        #region 播放视频定时器
        /// <summary>
        /// 播放视频定时器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PlayMovieTimer_Tick(object sender, EventArgs e)
        {
            Bitmap cache = null;
            if (GetJpgFileCount() == 0) return;
            cache = new Bitmap(fileName + @"\" + i + ".jpg");
            this.pictureBox1.Image = cache;
            i++;
            if (i > GetJpgFileCount())
            {
                StopSound();
                i = 1;
                PlaySound();
            }
        }
        #endregion

        #region 获得jpg文件的个数
        /// <summary>
        /// 获得jpg文件的个数
        /// </summary>
        /// <returns></returns>
        private int GetJpgFileCount()
        {
            DirectoryInfo di = new DirectoryInfo(fileName);
            FileInfo[] fis = di.GetFiles("*.jpg");
            return fis.Length;
        }
        #endregion

        #region 关闭窗体时初始化
        /// <summary>
        /// 关闭窗体时初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Init(false);
        }
        #endregion

        # region 删除data文件夹
        /// <summary>
        /// 删除data文件夹
        /// </summary>
        private void DelData()
        {
            if (Directory.Exists("data"))
            {
                Directory.Delete("data", true);
            }
        }
        #endregion

        #region 录制事件
        /// <summary>
        /// 录制事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiGetMovie_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            SetSize();
        }
        #endregion

        #region 设置录制视频的尺寸
        /// <summary>
        /// 设置录制视频的尺寸
        /// </summary>
        private void SetSize()
        {
            FullScreen form = new FullScreen(this);
            form.TopMost = true;
            form.Show();
        }
        #endregion

        #region 播放事件
        /// <summary>
        /// 播放事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiPlayMovie_Click(object sender, EventArgs e)
        {
            Init(false);
            PlayMovie();
        }
        #endregion

        # region 初始化便于录制或播放
        /// <summary>
        /// 初始化便于录制或播放
        /// </summary>
        public void Init(Boolean isUpdateFileName)
        {
            StopSound();
            i = 1;
            this.PlayMovieTimer.Stop();
            this.GetMovieTimer.Stop();
            if (! new FileInfo("music.wav").Exists)
            {
                StopRecord();
            }
            if (isUpdateFileName)
            {
                fileName = @"data\" + j++;
            }
            if (!Directory.Exists(fileName))
            {
                Directory.CreateDirectory(fileName);
            }
        }
        #endregion

        # region 保存EXE格式视频
        /// <summary>
        /// 保存EXE格式视频
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiSaveEXEMovie_Click(object sender, EventArgs e)
        {
            this.progressBar1.Maximum = GetJpgFileCount() * 2;
            StopRecord();//这里为什么又要调一次，不太清楚？
            backgroundWorker1.RunWorkerAsync();
        }
        #endregion 保存EXE格式视频

        #region 生成EXE文件
        /// <summary>
        /// 生成EXE文件
        /// </summary>
        private void SetRes()
        {
            XmlDocument doc = new XmlDocument();
            string str = "<root>" +
            "<resheader name='resmimetype'>" +
            "<value>text/microsoft-resx</value>" +
            "</resheader>" +
            "<resheader name='version'>" +
            "<value>2.0</value>" +
            "</resheader>" +
            "<resheader name='reader'>" +
            "<value>System.Resources.ResXResourceReader, System.Windows.Forms, " +
            "Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089</value>" +
            "</resheader>" +
            "<resheader name='writer'>" +
            "<value>System.Resources.ResXResourceWriter, System.Windows.Forms," +
            "Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089</value>" +
            "</resheader>" +
            "<assembly alias='System.Windows.Forms' name='System.Windows.Forms, Version=4.0.0.0, " +
            "Culture=neutral, PublicKeyToken=b77a5c561934e089' />";

            for (int i = 1; i < GetJpgFileCount(); i++)
            {
                str += "<data name='" + i + "' type='System.Resources.ResXFileRef, System.Windows.Forms'>" +
                "<value>" + i + ".jpg;System.Drawing.Bitmap, System.Drawing, Version=4.0.0.0, Culture=neutral, " +
                " PublicKeyToken=b03f5f7f11d50a3a</value>" +
                "</data>";
                this.backgroundWorker1.ReportProgress(i);
            }

            str += "<data name='music' type='System.Resources.ResXFileRef, System.Windows.Forms'>" +
            "<value>music.wav;System.IO.MemoryStream, mscorlib, Version=4.0.0.0, Culture=neutral," +
            "PublicKeyToken=b77a5c561934e089</value>" +
            "</data>";

            str += "</root>";

            doc.LoadXml(str);
            doc.Save(fileName + @"\pic.resx");

            if (!File.Exists(fileName + @"\Program.cs"))
            {
                File.Copy("Program.cs", fileName + @"\Program.cs");
            }

            if (!File.Exists(fileName + @"\ResGen.exe"))
            {
                File.Copy("ResGen.exe", fileName + @"\ResGen.exe");
            }

            StringBuilder sBuilder = new StringBuilder();

            sBuilder.AppendLine("cd " + fileName);
            sBuilder.AppendLine("resgen pic.resx pic.resources");
            sBuilder.AppendLine(@"C:\WINDOWS\Microsoft.NET\Framework\v4.0.30319\csc /t:winexe /res:pic.resources Program.cs");
            sBuilder.AppendLine("exit");
            string strBatPath = fileName + @"\pic.bat";
            File.WriteAllText(strBatPath, sBuilder.ToString());

            Process pro = new Process();

            pro.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;

            pro.StartInfo.FileName = "cmd.exe";
            pro.StartInfo.Arguments = @"/k " + fileName + @"\pic.bat";
            pro.StartInfo.UseShellExecute = true;
            pro.StartInfo.CreateNoWindow = true;

            pro.Start();
            pro.WaitForExit();
            this.backgroundWorker1.ReportProgress(this.progressBar1.Maximum);

        }
        #endregion

        #region 保存EXE文件到文件夹
        /// <summary>
        /// 保存EXE文件到文件夹
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            fi.CopyTo(saveFileDialog1.FileName, true);
        }
        #endregion

        #region 使用后台线程生成EXE文件
        /// <summary>
        /// 使用后台线程生成EXE文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            Init(false);
            SetRes();
        }
        #endregion

        #region 显示后台线程的执行进度
        /// <summary>
        /// 显示后台线程的执行进度
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.progressBar1.Value = e.ProgressPercentage;
        }
        #endregion

        #region 后台线程执行结束后保存文件到文件夹
        /// <summary>
        /// 后台线程执行结束后保存文件到文件夹
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            fi = new FileInfo(fileName + @"\Program.exe");
            if (fi.Exists)
            {
                saveFileDialog1.FileName = "录像.exe";
                saveFileDialog1.ShowDialog();
            }
            else
            {
                MessageBox.Show("没有要保存的视频，请您先录制！");
            }
        }
        #endregion

        #region 打开资源文件夹
        /// <summary>
        /// 打开资源文件夹
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiOpenPicFolder_Click(object sender, EventArgs e)
        {
            if (new DirectoryInfo(fileName).Exists)
            {
                Process.Start(fileName);
            }
            else
            {
                MessageBox.Show("无法打开资源文件夹，请您先录制！");
            }
        }
        #endregion

        #region 存在的问题
        //1.生成文件过大，生成时间过长
        //2.线程进度显示是个问题
        //3.录制视频的尺寸问题基本解决，但仍有瑕疵
        //4.出现很多bug，已经解决了不少
        //如gdi错误，5.1录制后直接保存找不到Program.exe,
        //5.2 重新录制时，先前文件无法删除，只能录制一次，
        //再录制会出问题,已经使用临时文件名粗糙解决
        //5.3 保存文件时，播放停止问题
        //6.快捷键结束录制问题
        //7.生成的播放器优化问题
        #endregion
    }
}
