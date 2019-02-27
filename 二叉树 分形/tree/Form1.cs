using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tree
{
    public partial class Form1 : Form
    {
        bool num1=true;
        int m_penwidth;
        int m_level;
        double m_langel;
        double m_rangel;
        double m_llen;
        double m_rlen;
        double m_length;
        double m_angel;
        int m_zby;
        Graphics myg;
        CBinaryTree tree = new CBinaryTree();

        public string strout = "";

        private void renew()
        {
            m_penwidth = Convert.ToInt32(width.Text);
            m_level = Convert.ToInt32(cengshu.Text);
            m_langel = Convert.ToDouble(zzqj.Text);
            m_rangel = Convert.ToDouble(yzqj.Text);
            m_llen = Convert.ToDouble(zcdb.Text);
            m_rlen = Convert.ToDouble(ycdb.Text);
            m_angel = Convert.ToDouble(sgqj.Text);
            m_length = Convert.ToDouble(sgcd.Text);
            m_zby = Convert.ToInt32(sqdy.Text);
            int xmin = 0;
            int ymin = 0;
            int xmax, ymax;

            myg = pictureBox1.CreateGraphics();
            xmax = pictureBox1.Width;
            ymax = pictureBox1.Height;
            //设置显示颜色
            Color bkColor0;
            Brush bkBrush0;
            Brush bkbrush = new SolidBrush(Color.White);//背景色
            bkColor0 = Color.FromArgb(255, 0, 255, 255);
            bkBrush0 = new SolidBrush(bkColor0);
            Pen pen1 = new Pen(Color.Red, 2);
            //画背景
            myg.FillRectangle(bkbrush, xmin, ymin, xmax - xmin, ymax - ymin);

        }
        private void DrawTree1(int n, double len, double arg, int x, int y)
        {
            Pen pen1 = null;
            pen1 = new Pen(Color.FromArgb(255, 255, 0, 0), m_penwidth);
            int xx, yy;
            xx = (int)(len * Math.Cos(arg)); yy = (int)(len * Math.Sin(arg));
            Point p1 = new Point(x, pictureBox1.Height - y);
            Point p2 = new Point(x + xx, pictureBox1.Height - (y + yy));
            myg.DrawLine(pen1, p1, p2);
            double lt = m_langel;
            double rt = m_rangel;
            if ((n < m_level)&& (len >= 1))
            {
                DrawTree1(n + 1, len * m_llen, arg + lt, x + xx, y + yy);
                DrawTree1(n + 1, len * m_rlen, arg - rt, x + xx, y + yy);

            }

        }

        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            tree.CreateBinTreestr(textBox1.Text);
            tree.DrawBTree(pictureBox1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (num1)
            {
                textBox1.Text = "ABHFDECKG";
                textBox2.Text = "HBDFAEKCG";
                num1 = false;
            }
            tree.StoBT(textBox1.Text, textBox2.Text);
            tree.DrawBTree(pictureBox1);
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            renew();
            DrawTree1(1, m_length, m_angel * 3.14 / 180.0, pictureBox1.Width / 2, m_zby);

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if(radioButton1.Checked == true)
            {
                string strout = "";
                tree.Traversal(0, out strout);
                label10.Text = strout;
            }
            else if (radioButton2.Checked == true)
            {
                string strout = "";
                tree.Traversal(1, out strout);
                label10.Text = strout;
            }
            else if (radioButton3.Checked == true)
            {
                string strout = "";
                tree.Traversal(2, out strout);
                label10.Text = strout;
            }
            else
            {
                string strout = "";
                tree.Traversal(3, out strout);
                label10.Text = strout;
            }

            label10.Visible = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            label10.Visible = false;
        }
    }
}
