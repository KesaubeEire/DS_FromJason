using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Graph
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
            return;
        }
        public void BFS()//图的广度优先遍历
        {//图从当前顶点开始广度优先搜索,将顶点序列存入数组visited
            int vi = currentID;//当前顶点号
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
            return;
        }
        public void Dijkstra() //图的单源最短路径,Dijkstra算法
        {
            return;
        }
        public string GetDijkstraPath() //求图的Dijkstra算法得到的路径及路径长度
        { return ""; }
        public bool CriticalPath() //图的关键路径
        { return true; }
    }
}