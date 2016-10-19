using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 录屏软件1
{
    public partial class FullScreen : Form
    {
        int x1, x2, y1, y2, w, h;
        bool isDown = false;
        Rectangle rec;
        Graphics myGraphics;
        frmGetScreen frm;

        public FullScreen(frmGetScreen frm)
        {
            this.frm = frm;
            InitializeComponent();
            this.Cursor = Cursors.Cross;
            myGraphics = this.CreateGraphics();
        }

        private void FullScreen_MouseDown(object sender, MouseEventArgs e)
        {
            x1 = e.X;
            y1 = e.Y;
            isDown = true;
        }

        private void FullScreen_MouseUp(object sender, MouseEventArgs e)
        {
            isDown = false;
            x2 = e.X;
            y2 = e.Y;
            w = x2 - x1;
            h = y2 - y1;

            DialogResult result =
            MessageBox.Show("确认", "确定吗？", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                frm.x1 = x1;
                frm.y1 = y1;
                frm.w = w;
                frm.h = h;

                frm.Init(true);
                frm.GetMovie();
                this.Close();
            }
            else if (result == DialogResult.Cancel)
            {
                this.Close();
            }
            else
            {
                myGraphics.Clear(Color.White);
            }
        }

        private void FullScreen_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDown)
            {
                myGraphics.Clear(Color.White);
                x2 = e.X;
                y2 = e.Y;
                w = x2 - x1;
                h = y2 - y1;
                rec = new Rectangle(x1, y1, w, h);
                Pen blackPen = new Pen(Color.Red, 2);
                myGraphics.DrawRectangle(blackPen, rec);   
                //
            }
        }

    }
}
