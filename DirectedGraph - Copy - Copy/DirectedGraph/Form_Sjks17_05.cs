using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;//读取文件所需的


namespace DirectedGraph
{
    public partial class Form_Sjks17_05 : Form
    {
        private CGraph_zzg m_graphm;
        Graphics myg = null;

        bool m_IsDrawTree = false;
        bool m_IsDraw = false;
        bool m_IsDrawing = false;


        int minx = 0, maxx = 0;
        int miny = 0, maxy = 0;
        int dx = 0;
        int dy = 0;
        int midx = 0;
        int midy = 0;
        //---------------------------------------------------------------------------------------------------------

        public Form_Sjks17_05()
        {
            InitializeComponent();
        }

        private void Form_Graph_Load(object sender, EventArgs e)
        {
            myg = this.CreateGraphics();

            dx = 10;
            minx = dx;
            maxx = Convert.ToInt32(Math.Floor((this.ClientSize.Width - dx) / 10.0) * 10) - 320;
            dy = 10;
            miny = dy;
            maxy = Convert.ToInt32(Math.Floor((this.ClientSize.Height - dy) / 10.0) * 10);
            midx = Convert.ToInt32(Math.Floor((minx + maxx) / 20.0) * 10);
            midy = Convert.ToInt32(Math.Floor((miny + maxy) / 20.0) * 10);

        }

        private void Form_Graph_Paint(object sender, PaintEventArgs e)
        {
            initdraw();
            if (m_IsDraw)
                DrawGraph();
        }
        public int GetIntData(string strdata, int k, out int outk)
        {
            int len = strdata.Length;
            int ks = k, data;
            string str;
            while ((ks < len) && ((strdata[ks] < '0') || (strdata[ks] > '9')))
                ks++;
            str = "";
            while ((ks < len) && ((strdata[ks] >= '0') && (strdata[ks] <= '9')))
                str = str + strdata[ks++];
            if (str != "")
                data = Convert.ToInt32(str);
            else
                data = 0;
            outk = ks;
            return (data);
        }
        public void ReadData(string graphstrin)
        {
            int know = 0;
            int directed = GetIntData(graphstrin, know, out know);//有向图无向图
            int n = GetIntData(graphstrin, know, out know);//结点个数
            int[,] dv = new int[n, 3];
            float[,] de = new float[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    dv[i, j] = GetIntData(graphstrin, know, out know);
                }
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    de[i, j] = GetIntData(graphstrin, know, out know);
                }
            }
            m_graphm = new CGraph_zzg();
            m_graphm.ReadData(directed, n, dv, de);
            m_IsDraw = true;
        }
        public void initdraw()
        {
            myg.Clear(Color.FromArgb(255, 224, 224, 224));
            Brush b0 = new SolidBrush(Color.FromArgb(255, 255, 255, 250));
            myg.FillRectangle(b0, minx, miny, maxx - minx, maxy - miny);

            Pen pen1 = new Pen(Color.Red, 1);
            myg.DrawLine(pen1, new Point(minx, miny), new Point(maxx, miny));
            //myg.DrawLine(pen1, new Point(minx, midy), new Point(maxx, midy));
            myg.DrawLine(pen1, new Point(minx, maxy), new Point(maxx, maxy));
            myg.DrawLine(pen1, new Point(minx, miny), new Point(minx, maxy));
            //myg.DrawLine(pen1, new Point(midx, miny), new Point(midx, maxy));
            myg.DrawLine(pen1, new Point(maxx, miny), new Point(maxx, maxy));
            Brush b1 = new SolidBrush(Color.Blue);
            //myg.FillEllipse(b1, midx - 5, midy - 5, 10, 10);

        }


        public void DrawGraph()
        {
            int n = m_graphm.Getvertexno();//点的个数
            if (n == 0)
                return;
            string str;
            int i, j, x1, y1, x2, y2;
            int R = 12;//点圈的半径
            int d1 = 6;//普通线的箭头长
            int LW = 1;//线宽

            //设置显示颜色

            Color BKColor, BKColor0, BKColor1, ArrowColor, TreeColor;
            Brush BKBrush, BKBrush0, BKBrush1, ArrowBrush;
            BKColor = Color.FromArgb(255, 255, 255, 255);
            BKBrush = new SolidBrush(BKColor);//背景色
            BKColor0 = Color.FromArgb(255, 125, 125, 125);
            BKBrush0 = new SolidBrush(BKColor0);//节点颜色
            BKColor1 = Color.FromArgb(255, 255, 255, 0);
            BKBrush1 = new SolidBrush(BKColor1);//当前节点颜色
            ArrowColor = Color.FromArgb(255, 255, 0, 0);
            ArrowBrush = new SolidBrush(ArrowColor);//箭头颜色
            TreeColor = Color.FromArgb(255, 255, 0, 255);//生成树的边的颜色

            Pen pen = new Pen(Color.FromArgb(255, 255, 255, 255), LW);
            Pen pen0 = new Pen(Color.FromArgb(255, 255, 0, 255), 1);//点的圆圈
            Pen PenLine = new Pen(ArrowColor, LW);//边
            Pen Pentree = new Pen(TreeColor, 5);//生成树的边

            System.Drawing.Drawing2D.AdjustableArrowCap lineCap = new System.Drawing.Drawing2D.AdjustableArrowCap(6, 6, true);
            Pen PenLineA = new Pen(ArrowColor, LW);
            PenLineA.CustomEndCap = lineCap;


            if (m_graphm.IsDirected())//有向图
            {
                cb_IsDirected.Checked = true;
                for (i = 1; i <= n; i++)//画线
                {
                    for (j = 1; j <= n; j++)
                    {
                        if ((m_graphm.Edge(i, j) != 0))
                        {
                            x1 = m_graphm.Vertex(i).x;
                            y1 = m_graphm.Vertex(i).y;
                            x2 = m_graphm.Vertex(j).x;
                            y2 = m_graphm.Vertex(j).y;
                            Point p0 = m_graphm.GetArrow(x1, y1, x2, y2, 2 * d1);
                            myg.DrawLine(PenLineA, new Point(x1, y1), p0);
                        }
                    }
                }
            }
            else//无向图
            {
                for (i = 1; i <= n; i++)//画线
                {
                    for (j = 1; j <= n; j++)
                    {
                        if ((m_graphm.Edge(i, j) != 0) && (m_graphm.Edge(j, i) != 0))
                        {
                            x1 = m_graphm.Vertex(i).x;
                            y1 = m_graphm.Vertex(i).y;
                            x2 = m_graphm.Vertex(j).x;
                            y2 = m_graphm.Vertex(j).y;
                            myg.DrawLine(PenLine, new Point(x1, y1), new Point(x2, y2));
                        }
                    }
                }
            }
            if (m_IsDrawTree)//画生成树的边
            {
                for (i = 1; i <= n; i++)//画线
                {
                    j = m_graphm.TreeParent(i);
                    if (j != 0)
                    {
                        x1 = m_graphm.Vertex(i).x;
                        y1 = m_graphm.Vertex(i).y;
                        x2 = m_graphm.Vertex(j).x;
                        y2 = m_graphm.Vertex(j).y;
                        myg.DrawLine(Pentree, new Point(x1, y1), new Point(x2, y2));
                    }
                }
            }
            if (cb_dispedge.Checked)//画边上的数据
            {
                Font font = new Font("Arial", 12);
                SolidBrush b1 = new SolidBrush(Color.Black);
                StringFormat sf1 = new StringFormat();
                if (m_graphm.IsDirected())//有向图
                {
                    for (i = 1; i <= n; i++)//画边的数据
                    {
                        for (j = i + 1; j <= n; j++)
                        {
                            x1 = m_graphm.Vertex(i).x;
                            y1 = m_graphm.Vertex(i).y;
                            x2 = m_graphm.Vertex(j).x;
                            y2 = m_graphm.Vertex(j).y;
                            if ((m_graphm.Edge(i, j) != 0) && (m_graphm.Edge(j, i) == 0))
                            {//只有小点到大点的边
                                str = "" + m_graphm.Edge(i, j);
                                myg.FillEllipse(BKBrush, (int)((x1 + 2 * x2) / 3 - 6), (int)((y1 + 2 * y2) / 3 - 6), 12, 12);
                                myg.DrawString(str, font, b1, (int)((x1 + 2 * x2) / 3 - 6), (int)((y1 + 2 * y2) / 3 - 6), sf1);
                            }
                            else if ((m_graphm.Edge(i, j) == 0) && (m_graphm.Edge(j, i) != 0))
                            {//只有大点到小点的边
                                str = "" + m_graphm.Edge(j, i);
                                myg.FillEllipse(BKBrush, (int)((2 * x1 + x2) / 3 - 6), (int)((2 * y1 + y2) / 3 - 6), 12, 12);
                                myg.DrawString(str, font, b1, (int)((2 * x1 + x2) / 3 - 6), (int)((2 * y1 + y2) / 3 - 6), sf1);
                            }
                            else if ((m_graphm.Edge(i, j) != 0) && (m_graphm.Edge(j, i) != 0))
                            {//有双向边
                                str = "" + m_graphm.Edge(i, j);
                                myg.FillEllipse(BKBrush, (int)((x1 + 2 * x2) / 3 - 6), (int)((y1 + 2 * y2) / 3 - 6), 12, 12);
                                myg.DrawString(str, font, b1, (int)((x1 + 2 * x2) / 3 - 6), (int)((y1 + 2 * y2) / 3 - 6), sf1);
                                str = "" + m_graphm.Edge(j, i);
                                myg.FillEllipse(BKBrush, (int)((2 * x1 + x2) / 3 - 6), (int)((2 * y1 + y2) / 3 - 6), 12, 12);
                                myg.DrawString(str, font, b1, (int)((2 * x1 + x2) / 3 - 6), (int)((2 * y1 + y2) / 3 - 6), sf1);
                            }
                            else
                            {//无边
                                continue;
                            }
                        }
                    }
                }
                else//无向图
                {
                    for (i = 1; i <= n; i++)//画边的数据
                    {
                        for (j = 1; j <= n; j++)
                        {
                            if ((m_graphm.Edge(i, j) != 0) && (m_graphm.Edge(j, i) != 0))
                            {
                                x1 = m_graphm.Vertex(i).x;
                                y1 = m_graphm.Vertex(i).y;
                                x2 = m_graphm.Vertex(j).x;
                                y2 = m_graphm.Vertex(j).y;
                                str = "" + m_graphm.Edge(i, j);
                                myg.DrawString(str, font, b1, (int)((x1 + x2) / 2 - 6), (int)((y1 + y2) / 2 - 6), sf1);
                            }
                        }
                    }
                }
            }

            for (i = 1; i <= n; i++)//画点
            {
                Font font = new Font("Arial", 10);
                SolidBrush b1 = new SolidBrush(Color.White);
                StringFormat sf1 = new StringFormat();
                x1 = m_graphm.Vertex(i).x;
                y1 = m_graphm.Vertex(i).y;
                str = "" + m_graphm.Vertex(i).no;
                myg.FillEllipse(BKBrush1, x1 - R, y1 - R, 2 * R, 2 * R);
                if (i == m_graphm.GetCurrentID())
                {
                    myg.FillEllipse(BKBrush1, x1 - R, y1 - R, 2 * R, 2 * R);
                    b1 = new SolidBrush(Color.Black);
                }
                else
                {
                    myg.FillEllipse(BKBrush0, x1 - R, y1 - R, 2 * R, 2 * R);
                    b1 = new SolidBrush(Color.White);
                }
                myg.DrawString(str, font, b1, (x1 - 5), (y1 - 8), sf1);
                myg.DrawEllipse(pen0, x1 - R, y1 - R, 2 * R, 2 * R);
            }
        }

        private void bt_creategraph_Click(object sender, EventArgs e)
        {
            ReadData(tb_graph_matrix.Text);
            this.Refresh();
        }

        private void cb_dispedge_CheckedChanged(object sender, EventArgs e)
        {
            this.Refresh();
        }

        private void rb_traversal0_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_traversal0.Checked)
            {
                m_IsDrawTree = false;
                tb_traversal.Text = "";
            }
            else
                m_IsDrawTree = true;
            if (rb_traversal1.Checked)
            {
                m_graphm.DFS();
                tb_traversal.Text = m_graphm.printVisited();
            }
            if (rb_traversal2.Checked)
            {
                m_graphm.BFS();
                tb_traversal.Text = m_graphm.printVisited();
            }
            if (rb_traversal3.Checked)
                m_graphm.Prim();
            if (rb_traversal4.Checked)
                tb_traversal.Text =  m_graphm.GetDijkstraPath();
            this.Refresh();
        }

        private void Form_Graph_MouseDown(object sender, MouseEventArgs e)
        {
            if (m_graphm == null)
                return;
            if (!m_IsDraw)
                return;
            int n = m_graphm.Getvertexno();
            if (n == 0)
                return;
            m_IsDrawing = true;
            int vi = m_graphm.GetCurrentID();
            for (int i = 1; i <= n; i++)
            {
                int x = m_graphm.Vertex(i).x;
                int y = m_graphm.Vertex(i).y;
                if ((e.X - x) * (e.X - x) + (e.Y - y) * (e.Y - y) <= 12 * 12)
                {
                    m_graphm.SetCurrentID(i);
                    if (vi != i)
                    {
                        rb_traversal0_CheckedChanged(sender, e);
                    }
                    break;
                }
            }
        }

        private void bt_opernfile_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            string str = "..\\..\\data\\";
            dlg.InitialDirectory = str;
            dlg.Filter = "数据文件（*.dat）|*.dat|文本文件（*.txt）|*.txt";
            dlg.Title = "打开图的数据文件";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                tb_fname.Text = dlg.FileName;
                StreamReader sr = new StreamReader(tb_fname.Text);
                string strdata = sr.ReadToEnd();
                sr.Close();
                tb_graph_matrix.Text = strdata;
            }
        }

        private void cb_IsDirected_CheckedChanged(object sender, EventArgs e)
        {
            //
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tb_traversal.Text =  m_graphm.GetAll();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tb_traversal.Text = m_graphm.GetTure();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            tb_traversal.Text = m_graphm.GetTureAndSort();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            m_IsDrawTree = true;
            int num = Convert.ToInt32(textBox1.Text);
            m_graphm.DrawPath(num + 1);
            this.Refresh();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            m_IsDrawTree = true;
            tb_traversal.Text = m_graphm.GetDijkstraPath();
            this.Refresh();
        }

        private void rb_traversal4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked == true)
            {
                treeView1.Nodes.Clear();
                treeView1.TopNode = m_graphm.answerToTree();
            }else
            {
                treeView1.Nodes.Clear();
            }
        }

        private void Form_Graph_MouseMove(object sender, MouseEventArgs e)
        {
            if (m_IsDrawing)
            {
                if (m_graphm != null)
                {
                    int n = m_graphm.Getvertexno();
                    if (n == 0)
                        return;
                }
                int i = m_graphm.GetCurrentID();
                if ((e.X >= 30) && (e.Y >= 30) && (e.X <= maxx - 30) && (e.Y <= maxy - 30))
                {
                    m_graphm.Vertex(i).x = e.X;
                    m_graphm.Vertex(i).y = e.Y;
                    initdraw();
                    DrawGraph();
                }
            }

        }

        private void Form_Graph_MouseUp(object sender, MouseEventArgs e)
        {
            m_IsDrawing = false;
        }


    }
}

