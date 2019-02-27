using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace DirectedGraph
{
    public class vtype
    {
        public int no;//点的序号
		public string name;//存放点图的名字
		public int x,y;//点的坐标
	    public vtype()
	    { 
            no=0;x=y=0;name=""; 
        }
        public vtype(int no, int x, int y)
        {
            this.no = no;this.x = x;this.y = y;this.name = "";
        }
        public vtype(int no, int x, int y, string name)
	    {
            this.no = no;this.x = x;this.y = y;this.name = name;
	    }
    }
    public class EL
    { 
        public int e;         //最早开始时间
        public int l;         //最迟开始时间
        public EL(int e,int l)
        { this.e = e; this.l = l; }
    }
    public class CGraph_zzg
    {
        private vtype[] vertex;//存放顶点的数组
        private float[,] edge;//存放边的矩阵

        protected int directed;//图的类型(0:无向图,1:有向图)
        protected int vertexno;//顶点个数
        protected string fname;//创建图的文件名
        protected int currentID;//当前点的序号

        protected int[] visited;//存放某种顺序遍历时的顶点序列,visited[0]为遍历序列个数
        protected int[] treeparent;//存放生成树边的数组(存放双亲的顶点号)
        protected EL[] vertexc;//图的关键路径的顶点存放的e,l值
        protected EL[,] edgec;//图的关键路径的边存放的e,l值

        public CGraph_zzg(int ver)
        { vertexno = ver; }
        public CGraph_zzg()
        {
            vertex = null;
            edge = null;
            directed = 0;
            vertexno = 0;
            fname = "";
            currentID = 0;
            treeparent = null;
            visited = null;
            vertexc = null;
            edgec = null;
        }
	    public bool IsDirected()
	    { return directed==1; }
	    public int Getvertexno()//取顶点个数
	    { return vertexno; }
	    public int GetCurrentID()//取当前顶点的序号
	    { return currentID; }
	    public void SetCurrentID(int k)//设置当前顶点的序号
	    { currentID=k; }
	    public int Visited(int vi)
	    { return visited[vi]; }
        public void setVisited(int vi, int k)
        { visited[k] = vi; }
	    public int TreeParent(int vi)//取顶点vi在生成树中双亲的顶点号
	    { return treeparent[vi]; }
	    public EL Vertexc(int vi)//顶点vi的e,l值
	    { return vertexc[vi]; }
        public EL Edgec(int vi, int vj)//取边<vi,vj>的权值
        { return edgec[(vi - 1), (vj - 1)]; }
        public string printVisited()
        {
            String strout = "";
            for (int i = 1; i <= visited[0]; i++)
            {
                strout += " " + visited[i];
                if (i < visited[0])
                    strout += "->";
            }
            return strout;
        }
        public void DFS()//图的深度优先遍历
        {//图从当前顶点开始深度优先搜索,将顶点序列存入数组visited
            int vi = currentID;//当前顶点号
            int k = 0, currenti = vi, n, p, i;
            n = vertexno;//顶点的个数
            if ((vi < 1) || (vi > n)) return;
            CLinkStack<int> mstack = new CLinkStack<int>();   //存放遍历时顶点序号的栈
            bool[] tag = new bool[n + 1];//存放顶点是否被访问过
            for (i = 0; i <= n; i++)
            { tag[i] = false; }
            for (i = 1; i <= n; i++)//清除原生成树的边
            { treeparent[i] = 0; }
            tag[vi] = true; visited[0] = ++k; visited[k] = vi;//加入遍历序列 
            p = GetFirstV(vi);//求vi的第一个相邻顶点
            mstack.Push(vi);//顶点vi入栈
            while ((p != 0) || (!mstack.IsEmpty()))
            {
                while (p != 0)//存在相邻顶点
                {
                    if (tag[p] == false)//未访问过顶点p
                    {
                        tag[p] = true; //已访问过
                        treeparent[p] = currenti;
                        currenti = p;//这是当前被访问的顶点
                        visited[0] = ++k;
                        visited[k] = currenti;//顶点currenti加入遍历序列 
                        mstack.Push(currenti);//顶点currenti入栈
                        p = GetFirstV(currenti);//求第一个相邻顶点
                    }
                    else//已访问过顶点p
                    {
                        p = GetNextV(currenti, p);//求下一个相邻顶点   
                    }
                }
                    if (!mstack.IsEmpty())
                    {
                        currenti = mstack.Pop();//栈顶为当前顶点
                        p = GetFirstV(currenti);//再找currenti的相邻结点
                        while (p != 0)
                        {
                            if (tag[p] == false)//未访问过顶点p
                            {
                                break;
                            }
                            else//已访问过顶点p
                            {
                                p = GetNextV(currenti, p);//下一个相邻顶点   }
                            }
                        }
                        if (p != 0)//currenti还有相邻结点,再入栈
                        {
                            mstack.Push(currenti);//顶点currenti入栈   }
                        }
                    }
            }
                        return;
        }
        public void BFS()//图的广度优先遍历
        {//图从当前顶点开始广度优先搜索,将顶点序列存入数组visited
            int vi = currentID;//当前顶点号
            int k = 0, currenti = vi, n, p, i;
            n = vertexno;//顶点的个数
            if ((vi < 1) || (vi > n))
            {
                return;
            }
            CQueue<int> mqueue = new CQueue<int>();//队列
            bool[] tag = new bool[n + 1];//存放顶点是否被访问过
            for (i = 0; i <= n; i++)
            {
                tag[i] = false;
            }
            for (i = 1; i <= n; i++)//清除原生成树的边
            {
                treeparent[i] = 0;
            }
            tag[vi] = true;
            visited[0] = ++k; visited[k] = vi;//顶点vi加入遍历序列 
            p = GetFirstV(vi);//求vi的第一个相邻顶点
            mqueue.In(vi);//顶点vi入队
            while (!mqueue.IsEmpty())
            {
                currenti = mqueue.Out();//访问过的顶点出队
                p = GetFirstV(currenti);//求第一个相邻顶点
                while (p != 0)
                {
                    if (tag[p] == false)//未访问过
                    {
                        tag[p] = true;//已访问过
                        treeparent[p] = currenti;
                        visited[0] = ++k; visited[k] = p;//顶点p加入遍历序列 
                        mqueue.In(p);
                    }
                    p = GetNextV(currenti, p);//求顶点的下一个相邻顶点
                }
            }
            return;
        }

        public Point GetArrow(int x1, int y1, int x2, int y2, int R)
        //求箭头的坐标,点(x1,y1)到(x2,y2)的有向边,R:点圈的半径,d:箭头半长
        {
	        double k;//直线的斜率
            Point p0 = new Point(0, 0);
	        if(x1!=x2)
	        {
	            k=1.0*(y2-y1)/(x2-x1);
		        if(x1<x2)
		        {
                    p0.X = (int)(x2 - R / Math.Sqrt(1 + k * k) + 0.5);//直线(x1,y1)(x2,y2)与圆(x2,y2,R)的交点
                    p0.Y = (int)(y2 - k * R / Math.Sqrt(1 + k * k) + 0.5);
		        }
		        else //x1>x2
		        {
                    p0.X = (int)(x2 + R / Math.Sqrt(1 + k * k) + 0.5);
                    p0.Y = (int)(y2 + k * R / Math.Sqrt(1 + k * k) + 0.5);
		        }
	        }
	        else//x1==x2
	        {
		        if(y1<y2)
		        {
                    p0.X = x1;
                    p0.Y = y2 - R;
		        }
		        else if(y1>y2)
		        {
                    p0.X = x1;
                    p0.Y = y2 + R;
		        }
	        }
            return p0;
        }
        public void ReadData(int directed, int vertexno, int[,] vertex, float[,] edge)
        {
            int i,j;
            if (vertexno == 0)
            {
                this.vertexno = 0;
                return;
            }
            this.directed = directed;
            this.vertexno = vertexno;
            this.vertex = new vtype[this.vertexno + 1];
            this.edge = new float[this.vertexno, this.vertexno];
            this.visited = new int[this.vertexno + 1];
            this.treeparent = new int[this.vertexno + 1];
            this.vertexc = new EL[this.vertexno + 1];
            this.edgec = new EL[this.vertexno, this.vertexno];

            for (i = 1; i <= this.vertexno; i++)
            {
                this.vertex[i] = new vtype(vertex[i - 1, 0], vertex[i - 1, 1], vertex[i - 1, 2]);
                this.treeparent[i] = 0;
                this.vertexc[i] = new EL(-1, -1);
            }
            for (i = 0; i < this.vertexno; i++)
            {
                for (j = 0; j < this.vertexno; j++)
                {
                    this.edge[i, j] = edge[i, j];
                    this.edgec[i, j] = new EL(-1, -1);
                }
            }
            currentID = 1;
            this.visited[0] = 0;//遍历序列个数为0
        }
        public string Write()
        {
            string strout = "";
            strout += "" + directed + "\r\n";
            strout += "" + vertexno + "\r\n";
            for (int i = 1; i <= vertexno; i++)
            {
                strout += "" + vertex[i].no + "  ";
                strout += "" + vertex[i].x + "  ";
                strout += "" + vertex[i].y + "\r\n";
            }
            for (int i = 1; i <= vertexno; i++)
            {
                for (int j = 1; j <= vertexno; j++)
                {
                    strout += "" + Edge(i, j) + "\r\n";
                }
                strout += "" + "\r\n";
            }
            return strout;
        }
        public vtype Vertex(int vi)//顶点vi的值
		{ return vertex[vi]; }
        public float Edge(int vi, int vj)//取边<vi,vj>的值
        {
            return edge[(vi - 1), (vj - 1)];
        }
        public int GetFirstV(int vi)//取顶点vi的第一个邻接点
        {//取顶点vi的第一个邻接点
            for (int j = 1; j <= vertexno; j++)
            {
                if ((j != vi) && (!Edge(vi, j).Equals(0)))
                {
                    return j;  //返回顶点vi的第一个相邻结点
                }
            }
	        return 0;//顶点vi不存在相邻结点
        }
        public int GetNextV(int vi, int vk)//取顶点vi的从顶点vk后的第一个邻接点
        {//取顶点vi的邻接点vk的下一个邻接点
            for (int j = vk + 1; j <= vertexno; j++)
            {
                if ((j != vi) && (!Edge(vi, j).Equals(0)))
                {
                    return j;  //返回顶点vi的第一个相邻结点
                }
            }
	        return 0;//顶点vi不存在相邻结点
        }
        public void print(out string strout)
        { strout = ""; }
        public void Prim()//图的最小生成树,Prim算法
        {
            float[,] houxuan = new float[vertexno, vertexno];
            houxuan = edge;
            int i, j;
            int[] T = new int[vertexno];
            T[vertexno - 1] = 0;
            T[0] = 1;
            int num = 1;
            while (num != vertexno)
            {
                float min = 100;
                int m = 0, n = 0;
                for (int k = 0; k < num; k++)
                {
                    i = T[k];
                    for (int w = 1; w < vertexno + 1; w++)
                    {
                        if (houxuan[i - 1, w - 1] == 0)
                            continue;
                        bool ga = false;
                        for (j = 0; j < num; j++)
                        {
                            if (w == T[j])
                            {
                                ga = true;
                                break;
                            }


                        }
                        if (ga)
                            continue;
                        if (min > houxuan[i - 1, w - 1])
                        {
                            min = houxuan[i - 1, w - 1];
                            m = i;
                            n = w;
                        }
                    }
                }
                if (min == 100)
                    break;
                else
                {
                    treeparent[n] = m;
                    T[num++] = n;
                }
            }
            return;
        }
        public void Dijkstra() //图的单源最短路径,Dijkstra算法
        {
            float[] dp = new float[Getvertexno()+1], tmp;
            int vi = currentID, vk;
            CQueue<int> queue = new CQueue<int>();

            Array.Clear(treeparent, 1, Getvertexno());

            for (int i = 1; i <= Getvertexno(); i++)
            {
                dp[i] = 99999;
            }

            queue.In(vi);
            dp[vi] = 0;
            while(!queue.IsEmpty())
            {
                vi = queue.Out();
                tmp = dp;
                vk = 0;
                while (GetNextV(vi, vk) != 0)
                {
                    vk = GetNextV(vi, vk);
                    if (dp[vk] > tmp[vi] + Edge(vi, vk))
                    {
                        dp[vk] = tmp[vi] + Edge(vi, vk);
                        treeparent[vk] = vi;
                        queue.In(vk);
                    }
                }
            }
            return;
        }
        public string GetDijkstraPath() //求图的Dijkstra算法得到的路径及路径长度
        { return ""; }
        public bool CriticalPath() //图的关键路径
        { return true; }
    }
}