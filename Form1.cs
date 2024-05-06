using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace problem_21
{
    public class cImg
    {
        public int x, y, size;
        public Bitmap img;
        public int iFrame;
    }
    public partial class Form1 : Form
    {
        List<cImg> list = new List<cImg>();
        List<cImg> list2 = new List<cImg>();
        Random rr;
        Timer tt = new Timer();
        Timer tt2 = new Timer();
        Bitmap off;
        int fal = 0;
        public Form1()
        {
            this.WindowState = FormWindowState.Maximized;
            this.Paint += Form1_Paint;
            this.Load += Form1_Load;
            this.MouseDown += Form1_MouseDown;
            this.BackColor = Color.Black;
            tt.Interval = 100;
            tt.Tick += Tt_Tick;
            tt.Start();
            tt2.Interval = 100;
            tt2.Tick += Tt2_Tick;
            tt2.Start();
        }
        private void Tt2_Tick(object sender, EventArgs e)
        {
            if(fal==1)
            {
                for (int i = list2.Count-1; i >= 0; i--) 
                {
                    list2[i].size--;
                    if (list2[i].size==0)
                    {
                        list2.RemoveAt(i);
                    }
                }
            }
        }
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && list.Count > 0)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    if (e.X >= list[i].x && e.X <= list[i].x + list[i].img.Width &&
                       e.Y >= list[i].y && e.Y <= list[i].y + list[i].img.Height)
                    {
                        cImg pnn = new cImg();
                        pnn.x = list[i].x;
                        pnn.y = list[i].y;
                        pnn.size = list[i].img.Width;
                        pnn.img = new Bitmap("image_2.bmp");
                        list2.Add(pnn);
                        list.RemoveAt(i);
                        fal = 1;
                        break;
                    }
                }
            }
        }
        int ctTick = 0;
        private void Tt_Tick(object sender, EventArgs e)
        {
            if (ctTick % 12 == 0) 
            {
                drawImg();
            }
            ctTick++;
            drawDubb(this.CreateGraphics());

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            off = new Bitmap(this.ClientSize.Width, this.ClientSize.Height);
            drawImg();
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            drawDubb(e.Graphics);
        }
        void drawScene(Graphics g)
        {
            g.Clear(Color.Black);
            for(int i=0;i<list.Count;i++)
            {
                g.DrawImage(list[i].img, list[i].x, list[i].y, list[i].size, list[i].size);
            }
            for (int i = 0; i < list2.Count; i++)
            {
                g.DrawImage(list2[i].img, list2[i].x, list2[i].y, list2[i].size, list2[i].size);
            }
        }
        void drawDubb(Graphics g)
        {
            Graphics g2 = Graphics.FromImage(off);
            drawScene(g2);
            g.DrawImage(off, 0, 0);
        }
        void drawImg()
        {
            rr= new Random();
            cImg pnn = new cImg();
            pnn.x = rr.Next(0, 1200);
            pnn.y = rr.Next(0, 800);
            pnn.iFrame = 0;
            pnn.img = new Bitmap("image_1.bmp");
            if (pnn.img.Width < pnn.img.Height)
                pnn.size = pnn.img.Width;
            else
                pnn.size = pnn.img.Height;
            list.Add(pnn);
        }
    }
}
