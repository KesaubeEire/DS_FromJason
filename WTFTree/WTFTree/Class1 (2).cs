using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;

namespace WTFTree
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
        public CBinaryTreenode<int> treeroot;

        public void CreateTreeview_str(string treestr, TreeView treeView1)
        {
            CLinkStack<TreeNode> stnode = new CLinkStack<TreeNode>();//存放树节点的栈
            treeView1.Nodes.Clear();//清除原有树的结点
            TreeNode stp = null;
            TreeNode stpnew = null;

            string strt = "1234567890+-*/";
            char ch = ' ';
            int n = treestr.Length;
            for (int i = 0; i < n; i++)
            {
                ch = treestr[i];
                if (((ch >= 'A') && (ch <= 'Z')) || ((ch >= 'a') && (ch <= 'z')) || (strt.IndexOf(ch) >= 0))
                {
                    //取栈顶
                    stp = stnode.Gettop();
                    //创建节点并于栈顶链接
                    stpnew = new TreeNode();//创建新的树的结点
                    stpnew.Text = "" + ch;
                    if (stp == null)
                        treeView1.Nodes.Add(stpnew);//加为树的根节点
                    else
                        stp.Nodes.Add(stpnew);//加为树的根节点
                }
                else if (ch == '(')
                    stnode.Push(stpnew);//当前点入栈
                else if (ch == ')')
                    stnode.Pop();//出栈
            }

            //tb_treeno.Text = Convert.ToString(treeView1.GetNodeCount(true));
            treeView1.SelectedNode = treeView1.Nodes[0];
            treeView1.SelectedNode.ExpandAll();
            treeView1.Select();
        }

        public void DrawBTree(PictureBox pb_bstree)
        {
            CLinkStack<drawbtreetype<int>> stree = new CLinkStack<drawbtreetype<int>>();
            drawbtreetype<int> sp, spt;
            CBinaryTreenode<int> pbtnode, pbtnodenow;
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
            Brush bkbrush = new SolidBrush(Color.White);//背景色
            bkColor0 = Color.FromArgb(255, 0, 255, 255);
            bkBrush0 = new SolidBrush(bkColor0);
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
            spt = new drawbtreetype<int>();
            spt.pbtnode = treeroot;
            spt.px = xx;
            spt.py = yy;
            spt.level = level;
            stree.Push(spt);//树根入栈
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
                    myg.FillEllipse(bkBrush0, (int)(xnow - 12), (int)(ymax - ynow - 12), 24, 24);

                    myg.DrawEllipse(pen1, (int)(xx - 12), (int)(ymax - yy - 12), 24, 24);
                    str = "" + pbtnode.data;
                    myg.DrawString(str, font, b1, (int)(xx - 5), (int)(ymax - yy - 8), sf1);
                    
                    myg.FillEllipse(bkBrush0, (int)(xnow - 12), (int)(ymax - ynow - 12), 24, 24);

                    myg.DrawEllipse(pen1, (int)(xnow - 12), (int)(ymax - ynow - 12), 24, 24);
                    str = "" + pbtnodenow.data;
                    myg.DrawString(str, font, b1, (int)(xnow - 5), (int)(ymax - ynow - 8), sf1);

                    //左孩子结点入栈
                    spt = new drawbtreetype<int>();
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
                    myg.FillEllipse(bkBrush0, (int)(xnow - 12), (int)(ymax - ynow - 12), 24, 24);

                    myg.DrawEllipse(pen1, (int)(xx - 12), (int)(ymax - yy - 12), 24, 24);
                    str = "" + pbtnode.data;
                    myg.DrawString(str, font, b1, (int)(xx - 5), (int)(ymax - yy - 8), sf1);
                    
                    myg.FillEllipse(bkBrush0, (int)(xnow - 12), (int)(ymax - ynow - 12), 24, 24);

                    myg.DrawEllipse(pen1, (int)(xnow - 12), (int)(ymax - ynow - 12), 24, 24);
                    str = "" + pbtnodenow.data;
                    myg.DrawString(str, font, b1, (int)(xnow - 5), (int)(ymax - ynow - 8), sf1);

                    //右孩子结点入栈
                    spt = new drawbtreetype<int>();
                    spt.pbtnode = pbtnodenow;
                    spt.px = xnow;
                    spt.py = ynow;
                    spt.level = level + 1;
                    stree.Push(spt);
                    Thread.Sleep(100);
                }
            }
        }

        internal void CreateTree(int[] numbers)
        {
            var treeList = new List<CBinaryTreenode<int>>();
            treeList.AddRange(from n in numbers
                              group n by n into g
                              select new CBinaryTreenode<int> { data = g.Key });

            while (treeList.Count > 1)
            {
                var sel = from i in treeList
                          orderby i.data ascending
                          select i;
                var min = sel.Take(2).ToArray();

                treeList.Add(new CBinaryTreenode<int> {
                    data = min[0].data + min[1].data,
                    lchild = min[0],
                    rchild = min[1],
                });

                treeList.Remove(min[0]);
                treeList.Remove(min[1]);
            }

            treeroot = treeList[0];
        }

        internal string PostOrder(TreeNode tree)
        {
            string res = "";

            if (tree.Nodes.Count <= 0)
                return tree.Text + " ";

            foreach (TreeNode node in tree.Nodes)
            {
                res += PostOrder(node);
            }

            res += tree.Text + " ";
            return res;
        }

        internal string InOrder(TreeNode tree)
        {
            string res = "";

            if (tree.Nodes.Count <= 0)
            {
                res += tree.Text + " ";
                return res;
            }

            res += InOrder(tree.Nodes[0]);
            res += tree.Text + " ";
            res += InOrder(tree.Nodes[1]);

            return res;
        }

        internal string PreOrder(TreeNode tree)
        {
            string res = "";

            res += tree.Text + " ";
            if (tree.Nodes.Count <= 0)
            {
                return res;
            }

            foreach (TreeNode node in tree.Nodes)
            {
                res += PreOrder(node);
            }

            return res;
        }

        internal void ViewBTree(TreeView treeView)
        {
            treeView.Nodes.Add(xjbNodes(treeroot));
        }

        private TreeNode xjbNodes(CBinaryTreenode<int> root)
        {
            if (root == null)
            {
                return null;
            }
            TreeNode node = new TreeNode(root.data.ToString());
            TreeNode tmpNode;
            tmpNode = xjbNodes(root.lchild);
            if(tmpNode != null)
                node.Nodes.Add(tmpNode);
            tmpNode = xjbNodes(root.rchild);
            if(tmpNode != null)
                node.Nodes.Add(tmpNode);

            return node;
        }

        internal string Search(TreeNode topNode)
        {
            CQueue<TreeNode> xjbQueue = new CQueue<TreeNode>();

            TreeNode node;

            string res = "";

            xjbQueue.In(topNode);

            while (!xjbQueue.IsEmpty())
            {
                node = xjbQueue.Out();
                res += node.Text + " ";
                foreach(TreeNode n in node.Nodes)
                {
                    xjbQueue.In(n);
                }
            }
            return res;
        }
    }
}
