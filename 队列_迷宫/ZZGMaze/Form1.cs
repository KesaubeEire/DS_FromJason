using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ZZGMaze
{
    public partial class Form_Maze : Form
    {

        int minx=0,maxx = 0;
        int miny=0,maxy = 0;
        int dx, dy;

        void initdraw()
        {
            dx = 0;
            minx = dx;
            maxx = Convert.ToInt32(Math.Floor((this.Width - 2*dx) / 10.0) * 10);
            dy = 0;
            miny = dy;
            maxy = Convert.ToInt32(Math.Floor((this.Height - 2*dy) / 10.0) * 10);
            Graphics myg = this.CreateGraphics();
            Brush b0 = new SolidBrush(Color.White);
            //myg.Clear(Color.FromArgb(255,224,224,224));
            myg.FillRectangle(b0, minx, miny, maxx - minx, maxy - miny);
        }

        
        
        
        public Form_Maze()
        {
            InitializeComponent();
        }

        private void Form_Maze_Load(object sender, EventArgs e)
        {
        }

        private void Form_Maze_Paint(object sender, PaintEventArgs e)
        {
            initdraw();
        }
    }
}