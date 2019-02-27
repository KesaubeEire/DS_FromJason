using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace ZZGMaze
{
    public partial class Form_Maze : Form
    {
        CMaze m_maze;
        string strmaze;
        bool isbnode;//是否右击开始节点
        bool issearch;//是否开始搜索
        //int timers;//计时器间隔
        //int searchlen;//搜索路径的长度
        bool IsPath;//是否画路径

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

            Rectangle sourceRectangle =
                new Rectangle(200, 200, imageList1.Images[0].Width, imageList1.Images[0].Height); //要放大的区域 
            //myg.DrawImage(imageList1.Images[0], sourceRectangle, sourceRectangle, GraphicsUnit.Pixel);
            //myg.DrawImageUnscaled(imageList1.Images[0], sourceRectangle);
        
        }

        public void DrawMaze(CMaze m_maze)
        {
            initdraw();
            Graphics myg = this.CreateGraphics();
            //Brush b0 = new SolidBrush(Color.White);
            Image image0 = System.Drawing.Image.FromFile("tile.bmp");
            Image image1 = System.Drawing.Image.FromFile("p01.bmp");
            Image image2 = System.Drawing.Image.FromFile("p02.bmp");
            int pw = image0.Width;
            int ph = image0.Height;

	        int m=m_maze.Getrows();
	        int n=m_maze.Getcols();

            Rectangle rt1,rt2;
            rt1 = new Rectangle(0, 0, pw, ph);

	        for(int i=0;i<=m+1;i++)
	        {
		        for(int j=0;j<=n+1;j++)
		        {
			        if(m_maze.Getelems(i,j) == 1)
			        {
                        rt2 = new Rectangle(j * (pw), i * (ph), pw, ph);
                        myg.DrawImage(image0, rt2, rt1, GraphicsUnit.Pixel);
			        }
                    else if (m_maze.Getelems(i, j) == 0)
			        {
			        }
                    else if (m_maze.Getelems(i, j) == -1)
			        {
				        if(IsPath)//画路径
				        {
                            //myg.FillRectangle(b0,j * pw, i * ph, pw, ph);
                        }
				        else
				        {
                            //myg.FillRectangle(b0,j * pw, i * ph, pw, ph);
                        }
			        }
		        }
	        }
        //画路径
	        DrawPath(m_maze);
        //画起点终点
            rt2 = new Rectangle(m_maze.Getbj() * pw, m_maze.Getbi() * ph, pw, ph);
            myg.DrawImage(image1, rt2, rt1, GraphicsUnit.Pixel);
            rt2 = new Rectangle(m_maze.Getej() * pw, m_maze.Getei() * ph, pw, ph);
            myg.DrawImage(image2, rt2, rt1, GraphicsUnit.Pixel);

            //myg.DrawImageUnscaled(imageList1.Images[1], m_maze.Getbj() * pw, m_maze.Getbi() * ph, pw, ph);
            //myg.DrawImageUnscaled(imageList1.Images[2], m_maze.Getej() * pw, m_maze.Getei() * ph, pw, ph);
        }
        ////////////////////////////////////////////////////////////
        public void DrawPath(CMaze m_maze)
        {
            Graphics myg = this.CreateGraphics();
            //创建画笔
            Pen pen1=new Pen(Color.FromArgb(255,255,0,0),10);
            Pen pen2=new Pen(Color.FromArgb(255,255,255,255),10);
            Pen pennow;
	        if(IsPath==true)
                pennow = pen1;
	        else
                pennow = pen2;
            Brush b0 = new SolidBrush(Color.Red);

        //从队尾向前查找走过的路径
            sqtype temp;
	        int j=m_maze.sq.Rear();
	        for(int i=m_maze.sq.Rear();i>=1;i--)
	        {
		        if(i==j)
		        { 
			        temp=m_maze.sq.Getdata(j);//1#点
                    int x1 = temp.y * 40 + 20;
                    int y1 = temp.x * 40 + 20;
			        j=temp.pre;
                    temp = m_maze.sq.Getdata(j);//2#点
                    int x2 = temp.y * 40 + 20;
                    int y2 = temp.x * 40 + 20;
                    if (j > 0)
                    {
                        myg.DrawLine(pennow, x1, y1, x2, y2);
                        myg.FillRectangle(b0, x1-5, y1-5, 10, 10);
                        myg.FillRectangle(b0, x2-5, y2-5, 10, 10);
                    }
		        }
	        }
        }
        ////////////////////////////////////////////////////////////
        public Form_Maze()
        {
            InitializeComponent();
        }

        private void Form_Maze_Load(object sender, EventArgs e)
        {
            //打开迷宫文件矩阵
            string fname = "maze03.dat";
            StreamReader sr = new StreamReader(fname);
            strmaze = sr.ReadToEnd();
            sr.Close();

            m_maze = new CMaze(strmaze);
            //右击开始节点
            isbnode = true;
            //清除迷宫矩阵中的路径标记
            m_maze.clear();
            //求迷宫的最短路径
            m_maze.ShortPath();
            //设置画路径
            IsPath = true;
        }

        private void Form_Maze_Paint(object sender, PaintEventArgs e)
        {
            DrawMaze(m_maze);
        }

        private void Form_Maze_MouseDown(object sender, MouseEventArgs e)
        {
            //自动搜索时不起作用
            if (issearch == true)
                return;
            //获取单击点的坐标
            int dj = e.X / 40;
            int di = e.Y / 40;
            //点中起点和终点时不起作用
            if ((di == m_maze.Getbi()) && (dj == m_maze.Getbj()))
                return;
            if ((di == m_maze.Getei()) && (dj == m_maze.Getej()))
                return;
            //修改迷宫矩阵的值
            int m = m_maze.Getrows();
            int n = m_maze.Getcols();
            if (e.Button == MouseButtons.Left)//按下鼠标左键
            {
                //设置迷宫节点的状态
                if ((di >= 1) && (di <= m) && (dj >= 1) && (dj <= n))
                {
                    if ((m_maze.Getelems(di, dj) == 0) || (m_maze.Getelems(di, dj) == -1))
                        m_maze.Setelems(di, dj, 1);
                    else
                        m_maze.Setelems(di, dj, 0);
                }
            }
            else//按下鼠标右键
            {
                if ((di >= 1) && (di <= m) && (dj >= 1) && (dj <= n))
                {
                    if (isbnode)//设置入口
                    {
                        m_maze.Setbi(di);
                        m_maze.Setbj(dj);
                    }
                    else//设置出口
                    {
                        m_maze.Setei(di);
                        m_maze.Setej(dj);
                    }
                    m_maze.Setelems(di, dj, 0);
                    isbnode = !isbnode;
                }
            }
            //清除迷宫矩阵中的路径标记
            m_maze.clear();
            //求迷宫的最短路径
            m_maze.ShortPath();
            DrawMaze(m_maze);
        }

        private void Form_Maze_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 's')
            { 
                DialogResult result = MessageBox.Show("确定"); 
            }
        }
    }
}