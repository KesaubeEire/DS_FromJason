using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;

namespace tree
{
    public interface ICStack<Type>//接口
    {
        bool IsEmpty();//判栈空
        bool IsFull();//判栈满
        void MakeEmpty();//清空
        bool Push(Type item);//入栈
        Type Pop();//出栈
        Type Gettop();//取栈顶
        string GetStackALLDate(string sname);
    }

    class CStacknode<Type>//链栈结点类
    {
        private Type data;
        private CStacknode<Type> next;
        //--------------------------------------------------------------------------------
        public CStacknode()
        {
            next = null;
        }
        public CStacknode(Type data)
        {
            this.data = data;
            next = null;
        }
        public CStacknode(Type data, CStacknode<Type> next)
        {
            this.data = data;
            this.next = next;
        }
        public Type Data
        {
            get { return data; }
            set { data = value; }
        }
        public CStacknode<Type> Next
        {
            get { return next; }
            set { next = value; }
        }
    }
    class CLinkStack<Type> : ICStack<Type>
    {
        private CStacknode<Type> top;
        //--------------------------------------------------------------------------------
        public void MakeEmpty() { top = null; }//清空
        public bool IsEmpty() { return top == null; }//判栈空
        public bool IsFull() { return false; }//判栈满

        public CLinkStack()
        {
            top = null;
        }
        public bool Push(Type item)//入栈
        {
            top = new CStacknode<Type>(item, top);
            return (true);
        }
        public Type Pop()//出栈
        {
            Type dt = top.Data;
            top = top.Next;
            return dt;
        }
        public Type Gettop()//取栈顶
        {
            if (top == null)
                return default(Type);
            else
                return top.Data;
        }
        public string GetStackALLDate(string sname)
        {
            string str = "  】";
            if (IsEmpty()) str = sname + " stack is null";
            CStacknode<Type> p = top;
            while (p != null)
            {
                str = p.Data + "    " + str;
                p = p.Next;
            }
            str = "【  " + str + "\r\n";
            str = str + "---------------------------------------" + "\r\n";
            return str;
        }
    }

    public class CSeqStack<Type> : ICStack<Type>
    {
        private int top;
        private Type[] elems;
        private int Maxsize = 100;
        //--------------------------------------------------------------------------------
        public void MakeEmpty() { top = -1; }//清空
        public bool IsEmpty() { return top == -1; }//判栈空
        public bool IsFull() { return top == Maxsize - 1; }//判栈满
        ///////////////////////////////////////////////////////////
        public Type this[int index]
        {
            get { return elems[index]; }
            set { elems[index] = value; }
        }
        public int Top
        {
            get { return top; }
        }

        public CSeqStack()
        {
            elems = new Type[Maxsize];
            top = -1;
        }
        public CSeqStack(int max)
        {
            Maxsize = max;
            elems = new Type[Maxsize];
            top = -1;
        }
        ///////////////////////////////////////////////////////////
        public bool Push(Type item)//入栈
        {
            if (!IsFull())
            {
                elems[++top] = item;
                return (true);
            }
            else
                return (false);
        }
        ///////////////////////////////////////////////////////////
        public Type Pop()//出栈
        {
            if (!IsEmpty())
                return elems[top--];
            else
                return elems[0];
        }
        ///////////////////////////////////////////////////////////
        public Type Gettop()//取栈顶
        {
            if (!IsEmpty())
                return elems[top];
            else
                return elems[0];
        }
        public string GetStackALLDate(string sname)
        {
            string str = "";
            if (IsEmpty()) str = sname + " stack is null";
            for (int i = 0; i <= top; i++)
            {
                str = str + "  " + elems[i].ToString() + "  ";
            }
            str = str + "\r\n";
            //str = str + "--------------------------------------------------" + "\r\n";
            return str;
        }
        ///////////////////////////////////////////////////////////
    }
    public class CQueue<Type>
    {
        private int front, rear;
        private Type[] elems;
        private const int Maxsize = 1000;
        //--------------------------------------------------------------------------------
        public void MakeEmpty() { front = rear = 0; }//清空
        public bool IsEmpty() { return front == rear; }//判队空
        public bool IsFull() { return (rear + 1) % Maxsize == front; }//判队满
        public int Front() { return front; }
        public int Rear() { return rear; }
        ///////////////////////////////////////////////////////////
        public CQueue()
        {
            elems = new Type[Maxsize];
            front = rear = 0;
        }
        ///////////////////////////////////////////////////////////
        public bool In(Type item)//入队
        {
            if (!IsFull())
            {
                rear = (rear + 1) % Maxsize;
                elems[rear] = item;
                return (true);
            }
            else
                return (false);
        }
        ///////////////////////////////////////////////////////////
        public Type Out()//出队
        {
            front = (front + 1) % Maxsize;
            return elems[front];
        }
        ///////////////////////////////////////////////////////////
        public Type Getfront()
        {
            return elems[(front + 1) % Maxsize];
        }
        ///////////////////////////////////////////////////////////
        public Type Getdata(int k)
        {
            return elems[k];
        }
        ///////////////////////////////////////////////////////////
    }
    public class drawbtreetype<Type>
    {
        public CBinaryTreenode<Type> pbtnode;
        public double px, py;
        public int level;
    };  //画二叉树图时的辅助表
    public class help<Type>
    {
        public int t1b, t2b, tln;//先序中开始位置,中序中开始位置,树长
        public CBinaryTreenode<Type> adr;
    }; //由先序序列,中序序列生成二叉树的帮助表
    public class CBinaryTreenode<Type>
    {
        public Type data;
        public bool isStepped = false;
        public CBinaryTreenode<Type> lchild, rchild;
        public CBinaryTreenode()
        {
            lchild = rchild = null;
        }
        public CBinaryTreenode(Type item)
        {
            data = item;
            lchild = rchild = null;
        }
        public CBinaryTreenode(Type item, CBinaryTreenode<Type> lc, CBinaryTreenode<Type> rc)
        {
            data = item;
            lchild = lc; rchild = rc;
        }

    }
    class CBinaryTree
    {
        public CBinaryTreenode<char> treeroot;
        public int depth()
        {
            return depth(treeroot);
        }
        private int depth(CBinaryTreenode<char> T)
        {
            if (T == null) return 0;
            int num1 = depth(T.lchild);
            int num2 = depth(T.rchild);

            return (num1 > num2 ? num1 : num2) + 1;
        }
        public int nodes()
        {
            return nodes(treeroot);
        }

        public int nodes(CBinaryTreenode<char> T)
        {
            if(T != null)
            {
                int num1 = nodes(T.lchild);
                int num2 = nodes(T.rchild);

                return num1 + num2 + 1;
            }
            return 0;
        }


        public void CreateBinTreestr(string bintreestr)//根据字符串生成二叉树表
        {
            if (treeroot != null)
                treeroot = null;
            string strt = "1234567890+-*/";
            char ch, chlr = ' ';
            CLinkStack<CBinaryTreenode<char>> mystack = new CLinkStack<CBinaryTreenode<char>>();
            CBinaryTreenode<char> stp, stpnew;//存放栈顶的返回值
            stpnew = null;
            int n = bintreestr.Length;
            for (int i = 0; i < n; i++)
            {
                ch = bintreestr[i];
                if (((ch >= 'A') && (ch <= 'Z')) || ((ch >= 'a') && (ch <= 'z')) || (strt.IndexOf(ch) >= 0))
                {
                    //取栈顶
                    stp = mystack.Gettop();
                    //创建节点并于栈顶链接
                    stpnew = new CBinaryTreenode<char>(ch);
                    if (stp == null)
                        treeroot = stpnew;
                    else
                    {
                        if (chlr == 'l')
                            stp.lchild = stpnew;
                        else
                            stp.rchild = stpnew;
                    }
                }
                else if (ch == '(')
                {
                    chlr = 'l';//设置左右
                    mystack.Push(stpnew);//当前点入栈
                }
                else if (ch == ',')
                    chlr = 'r';//设置左右
                else if (ch == ')')
                    mystack.Pop();//出栈
            }
        }
        public void Traversal(int k, out string m_strout)
        {
            m_strout = "";
            
            if (k == 0)
            {
                CQueue<CBinaryTreenode<char>> qtree = new CQueue<CBinaryTreenode<char>>();
                CBinaryTreenode<char> p;
                qtree.In(treeroot);
                if(treeroot!=null)
                    while (!qtree.IsEmpty())
                    {
                        p = qtree.Out();
                        if (p.lchild != null)
                            qtree.In(p.lchild);
                        if (p.rchild != null)
                            qtree.In(p.rchild);
                        m_strout += " " + p.data;
                    }

            }
            else
            {
                CLinkStack<CBinaryTreenode<char>> stree = new CLinkStack<CBinaryTreenode<char>>();
                CLinkStack<int> sno = new CLinkStack<int>();
                CBinaryTreenode<char> p;
                stree.Push(treeroot);
                int no;
                if (treeroot != null)
                { stree.Push(treeroot); sno.Push(1);sno.Push(1); }
                else
                {
                    m_strout = "空树!\r\n";
                            return;
                }
                while (!stree.IsEmpty())
                {
                    no = sno.Pop();
                    p = stree.Gettop();
                    if (p == null)
                    {
                        stree.Pop();
                        continue;
                    }
                    if (no == 1)
                    {
                        sno.Push(2);
                        stree.Push(p.lchild);
                        sno.Push(1);
                        if (k == 1)
                            m_strout += " " + p.data.ToString();
                    }
                    else if (no == 2)
                    {
                        sno.Push(3);
                        stree.Push(p.rchild); sno.Push(1);
                        if (k == 2)
                            m_strout += " " + p.data.ToString();
                    }
                    else if (no == 3)
                    {
                        stree.Pop();
                        if (k == 3)
                            m_strout += " " + p.data.ToString();
                    }
                }
            }
        }

        public void Find(string keyword, PictureBox picture)
        {
            Find(keyword, treeroot);
            DrawBTree(picture);
        }

        private void Find(string keyword, CBinaryTreenode<char> T)
        {
            if(T != null)
            {
                T.isStepped = false;

                Find(keyword, T.lchild);
                Find(keyword, T.rchild);

                if(keyword.IndexOf(T.data) >= 0)
                {
                    T.isStepped = true;
                }
            }
        }

        public void Reverse()
        {
            Reverse(treeroot);
        }
        
        private void Reverse(CBinaryTreenode<char> T)
        {
            if(T != null)
            {
                Reverse(T.lchild);
                Reverse(T.rchild);

                CBinaryTreenode<char> tmp;
                tmp = T.lchild;
                T.lchild = T.rchild;
                T.rchild = tmp;
            }
        }

        public void DrawBTree(PictureBox pb_bstree)
        {
            CLinkStack<drawbtreetype<char>> stree = new CLinkStack<drawbtreetype<char>>();
            drawbtreetype<char> sp, spt;
            CBinaryTreenode<char> pbtnode, pbtnodenow;
            if (treeroot == null)
                return;
            Graphics myg;
            int xmin = 0;
            int ymin = 0;
            int xmax, ymax;

            myg = pb_bstree.CreateGraphics();
            xmax = pb_bstree.Width;
            ymax = pb_bstree.Height;
            //设置显示颜色
            Color bkColor0;
            Brush bkBrush0;
            Brush bkBrush1;
            Brush bkbrush = new SolidBrush(Color.White);//背景色
            bkColor0 = Color.FromArgb(255, 0, 255, 255);
            bkBrush0 = new SolidBrush(bkColor0);
            bkBrush1 = new SolidBrush(Color.Black);
            Pen pen1 = new Pen(Color.Red, 2);
            //画背景
            myg.FillRectangle(bkbrush, xmin, ymin, xmax - xmin, ymax - ymin);
            string str;
            Font font = new Font("Arial", 10);
            SolidBrush b1 = new SolidBrush(Color.Blue);
            StringFormat sf1 = new StringFormat();

            //画图数据初始化
            double xx = xmax / 2;
            double yy = ymax - 50;
            int level = 1;
            double xnow;
            double ynow;
            double alpha;

            double len = 150;
            double lenbl = 0.8;
            double dw = 0;
            //画树根中心点
            spt = new drawbtreetype<char>();
            spt.pbtnode = treeroot;
            spt.px = xx;
            spt.py = yy;
            spt.level = level;
            stree.Push(spt);//树根入栈
            if(treeroot.isStepped == true)
                myg.FillEllipse(bkBrush1, (int)(xx - 12), (int)(ymax - yy - 12), 24, 24);
            else
                myg.FillEllipse(bkBrush0, (int)(xx - 12), (int)(ymax - yy - 12), 24, 24);

            myg.DrawEllipse(pen1, (int)(xx - 12), (int)(ymax - yy - 12), 24, 24);
            str = "" + treeroot.data;
            myg.DrawString(str, font, b1, (int)(xx - 5), (int)(ymax - yy - 8), sf1);
            while (!stree.IsEmpty())
            {
                sp = stree.Pop();
                pbtnode = sp.pbtnode;
                xx = sp.px;
                yy = sp.py;
                level = sp.level;
                //设置比例
                if (level == 0)
                { lenbl = 0; dw = 0; }
                else if (level == 1)
                { lenbl = 1; dw = 70; }
                else if (level == 2)
                { lenbl = 0.8; dw = 40; }
                else if (level == 3)
                { lenbl = 0.6; dw = 30; }
                else if (level == 4)
                { lenbl = 0.5; dw = 20; }
                else if (level == 5)
                { lenbl = 0.4; dw = 15; }
                else
                { lenbl = 0.3; dw = 15; }
                pbtnodenow = pbtnode.lchild;
                if (pbtnodenow != null)
                {
                    //设置转角
                    alpha = -90 - dw;
                    //求新点坐标
                    xnow = xx + len * lenbl * Math.Cos(alpha * 3.14 / 180.0);
                    ynow = yy + len * lenbl * Math.Sin(alpha * 3.14 / 180.0);
                    //画线
                    myg.DrawLine(pen1, (int)xx, (int)(ymax - yy), (int)xnow, (int)(ymax - ynow));
                    //画中心点
                    if (pbtnodenow.isStepped == true)
                        myg.FillEllipse(bkBrush1, (int)(xnow - 12), (int)(ymax - ynow - 12), 24, 24);
                    else
                        myg.FillEllipse(bkBrush0, (int)(xnow - 12), (int)(ymax - ynow - 12), 24, 24);

                    myg.DrawEllipse(pen1, (int)(xx - 12), (int)(ymax - yy - 12), 24, 24);
                    str = "" + pbtnode.data;
                    myg.DrawString(str, font, b1, (int)(xx - 5), (int)(ymax - yy - 8), sf1);

                    if(pbtnodenow.isStepped == true)
                        myg.FillEllipse(bkBrush1, (int)(xnow - 12), (int)(ymax - ynow - 12), 24, 24);
                    else
                        myg.FillEllipse(bkBrush0, (int)(xnow - 12), (int)(ymax - ynow - 12), 24, 24);

                    myg.DrawEllipse(pen1, (int)(xnow - 12), (int)(ymax - ynow - 12), 24, 24);
                    str = "" + pbtnodenow.data;
                    myg.DrawString(str, font, b1, (int)(xnow - 5), (int)(ymax - ynow - 8), sf1);

                    //左孩子结点入栈
                    spt = new drawbtreetype<char>();
                    spt.pbtnode = pbtnodenow;
                    spt.px = xnow;
                    spt.py = ynow;
                    spt.level = level + 1;
                    stree.Push(spt);
                }
                Thread.Sleep(100);
                pbtnodenow = pbtnode.rchild;
                if (pbtnodenow != null)
                {
                    //设置转角
                    alpha = -90 + dw;
                    //求新点坐标
                    xnow = xx + len * lenbl * Math.Cos(alpha * 3.14 / 180.0);
                    ynow = yy + len * lenbl * Math.Sin(alpha * 3.14 / 180.0);
                    //画线
                    myg.DrawLine(pen1, (int)xx, (int)(ymax - yy), (int)xnow, (int)(ymax - ynow));
                    //画中心点
                    if (pbtnodenow.isStepped == true)
                        myg.FillEllipse(bkBrush1, (int)(xnow - 12), (int)(ymax - ynow - 12), 24, 24);
                    else
                        myg.FillEllipse(bkBrush0, (int)(xnow - 12), (int)(ymax - ynow - 12), 24, 24);

                    myg.DrawEllipse(pen1, (int)(xx - 12), (int)(ymax - yy - 12), 24, 24);
                    str = "" + pbtnode.data;
                    myg.DrawString(str, font, b1, (int)(xx - 5), (int)(ymax - yy - 8), sf1);

                    if (pbtnodenow.isStepped == true)
                        myg.FillEllipse(bkBrush1, (int)(xnow - 12), (int)(ymax - ynow - 12), 24, 24);
                    else
                        myg.FillEllipse(bkBrush0, (int)(xnow - 12), (int)(ymax - ynow - 12), 24, 24);

                    myg.DrawEllipse(pen1, (int)(xnow - 12), (int)(ymax - ynow - 12), 24, 24);
                    str = "" + pbtnodenow.data;
                    myg.DrawString(str, font, b1, (int)(xnow - 5), (int)(ymax - ynow - 8), sf1);

                    //右孩子结点入栈
                    spt = new drawbtreetype<char>();
                    spt.pbtnode = pbtnodenow;
                    spt.px = xnow;
                    spt.py = ynow;
                    spt.level = level + 1;
                    stree.Push(spt);
                    Thread.Sleep(100);
                }
            }
        }
        public void StoBT(string t1, string t2)
        {
            //由先序序列,中序序列生成二叉树
            if (treeroot != null)
                treeroot = null;
            int len = t1.Length;
            if (len <= 0) return;
            int i;
            int t2r, lln, rln;//中序的根,左子树长,右子树长
            CQueue<help<char>> sq = new CQueue<help<char>>();
            help<char> sp = new help<char>();
            sp.t1b = sp.t2b = 1; sp.tln = len;
            sp.adr = new CBinaryTreenode<char>(t1[1 - 1]);
            treeroot = sp.adr;
            sq.In(sp);
            while (!sq.IsEmpty())
            {
                i = 1;
                sp = sq.Out();
                while (t2[i - 1] != t1[sp.t1b - 1])
                    i++; //在中序中找根
                t2r = i;
                lln = t2r - sp.t2b;   //左子树长
                rln = sp.tln - lln - 1; //右子树长
                if (lln > 0)  //左子树不空
                {
                    help<char> sr = new help<char>();
                    sr.t1b = sp.t1b + 1; //左子树在先序中的开始位置
                    sr.t2b = sp.t2b;   //左子树在中序中的开始位置
                    sr.tln = lln;
                    sr.adr = new CBinaryTreenode<char>(t1[sr.t1b - 1]);//左子树的根
                    sp.adr.lchild = sr.adr;
                    sq.In(sr);
                }
                if (rln > 0)  //右子树不空
                {
                    help<char> sr = new help<char>();
                    sr.t1b = sp.t1b + lln + 1; //右子树在先序中的开始位置
                    sr.t2b = t2r + 1;        //右子树在中序中的开始位置
                    sr.tln = rln;
                    sr.adr = new CBinaryTreenode<char>(t1[sr.t1b - 1]);//右子树的根
                    sp.adr.rchild = sr.adr;
                    sq.In(sr);
                }
            }
            return;
        }

    }
}
