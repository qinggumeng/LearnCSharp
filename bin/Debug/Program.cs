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
            this.pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pb.Dock = System.Windows.Forms.DockStyle.Fill;
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