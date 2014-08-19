using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;
using System.Xml;
using System.Diagnostics;
using System.Reflection;
using System.Resources;

namespace Test
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.Run(new Form1());
        }
    }

    class Form1 : Form
    {
        PictureBox pb = new PictureBox();
        private int i = 1;
        Timer timer = new Timer();
        ResourceManager rm = new ResourceManager("pic", Assembly.GetExecutingAssembly());
        TextBox tb = new TextBox();
        Button btn = new Button();

        [DllImport("winmm.dll")]
        private static extern int mciSendString
            (
                string lpstrCommand,
                string lpstrReturnString,
                int uReturnLength,
                int hwndCallback
            );

        public Form1()
        {
            this.Controls.Add(tb);
	btn.Text = "输入密码！";
             btn.Width = 100;
             btn.Height = 24;
            this.Controls.Add(btn);
            btn.Click += new EventHandler(InputPwd);
        }

         void InputPwd(object sender, EventArgs e)
        {
            if(tb.Text=="0423"){
	 this.Controls.Remove(tb);
              this.Controls.Remove(btn);
	 Start();
            }
        }

        public void Start()
        {
            pb.Dock = System.Windows.Forms.DockStyle.Fill;
            pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Controls.Add(pb);
            timer.Tick += new EventHandler(timer_Tick);
            playSound();
            timer.Start();
        }

       

        System.Media.SoundPlayer player;

        private void playSound()
        {
            Stream st = rm.GetStream("music");
            player = new System.Media.SoundPlayer(st);
            player.Play();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            Play();
        }

        private void Play()
        {
            Bitmap cache = null;

            cache = (Bitmap)rm.GetObject(i + "");
            this.Text = i + "";
            this.pb.Image = cache;
            i++;

            if (cache == null)
            {
                player.Stop();
                i = 1;
                player.Play();
            }
        }
    }
}