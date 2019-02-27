using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Collections;

namespace DirectedGraph
{
    public class Answer
    {
        public float sum;
        public int[] visited;
        public string path;
        public int no;

        public Answer(float sum, int[] visited, string path, int no)
        {
            this.sum = sum;
            this.visited = (int[])visited.Clone();
            this.path = path;
            this.no = no;
        }

        
        public override string ToString()
        {
            return "[" + no + "]  " + path + "  (" + sum + ")";
        }
    }

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
            this.visited = new int[this.vertexno + 2];
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
            int vi = currentID;//当前顶点号
            int currenti = vi;
            int n = vertexno;//顶点的个数
            bool[] tag = new bool[n + 1];//存放顶点是否被加入选集
            float[] D = new float[n + 1];  //存放每个点到候选集的最小权值
            int nearest = 0;//最小值的点
            for (int i = 0; i <= n; i++)
            { tag[i] = false; }
            for (int i = 1; i <= n; i++)//清除原生成树的边
            { treeparent[i] = 0; }
            for (int i = 1; i <= n; i++)
            {
                D[i] = Edge(vi, i);
                visited[i] = 0;
                tag[i] = false;//都没有被访问
                if (D[i] == 0) treeparent[i] = 0;
                else treeparent[i] = vi;
            }
            tag[vi] = true;
            visited[1] = vi;//源点进入
            visited[0] = 1;//已经进了多少个
            while (visited[0] < n)
            {
                int judge;//不能全部联通控制输出
                for (judge = 1; judge <= n; judge++)//判断是否全部进入完
                {
                    if (tag[judge] == false && D[judge] != 0)
                    {
                        break;
                    }
                }
                if (judge == n + 1) break;
                float shorest = 1000;//初始化最小值
                for (int j = 1; j <= n; j++)//找到最小点
                {
                    if (tag[j] == false && D[j] != 0 && D[j] < shorest)
                    {
                        shorest = D[j];
                        nearest = j;
                    }
                }
                visited[0]++;//找到点进入
                visited[visited[0]] = nearest;
                tag[nearest] = true;
                for (int j = 1; j <= n; j++) //调整距离值
                {
                    if (tag[j] == false)
                    {
                        float temp = Edge(nearest, j);
                        if (temp != 0)
                        {
                            if (D[j] == 0 || temp < D[j])
                            {
                                D[j] = temp;
                                treeparent[j] = nearest;
                            }
                        }
                    }

                }
            }
        }
        public float[] Dijkstra() //图的单源最短路径,Dijkstra算法
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
            return dp;
        }
        public string GetDijkstraPath() //求图的Dijkstra算法得到的路径及路径长度
        {
            string str = "", tmp = "";
            float[] dp = Dijkstra();
            int vi = 0;

            for(int i = 1; i <= Getvertexno(); i++)
            {
                if(i == currentID || dp[i] >= 99999)
                    continue;
                str += "[  " + dp[i].ToString() + "  ]\t";

                vi = i;
                tmp = vi.ToString();
                while (true)
                {
                    vi = treeparent[vi];
                    if (vi == 0)
                        break;
                    tmp = vi.ToString() + "-> " + tmp;
                }
                str += tmp;

                str += "\r\n";
            }
            return str;
        }
        public bool CriticalPath() //图的关键路径
        { return true; }

        internal string GetAll()
        {
            string res = "";
            answer = new ArrayList();
            currentAnswerNo = 0;
            Array.Clear(visited, 0, Getvertexno());
            setVisited(currentID);
            axiba(currentID);
            foreach(Answer aaa in answer)
            {
                res += aaa + "\r\n";
            }
            return res;
        }

        internal void DrawPath(int num)
        {
            Array.Clear(treeparent, 0, Getvertexno());
            int[] list = ((Answer)answer[num]).visited;
            for(int i = 1; i < list.Length-1; i++)
            {
                treeparent[list[i+1]] = list[i];
            }
        }

        internal string GetTureAndSort()
        {
            string res = "";
            GetTure();
            Sort(answer);
            foreach (Answer aaa in answer)
            {
                res += aaa + "\r\n";
            }
            return res;
        }

        internal TreeNode answerToTree()
        {
            int[] list = null;
            TreeNode tree = new TreeNode(((Answer)answer[0]).visited[1].ToString());

            //foreach(Answer aaa in answer)
            {
                list = ((Answer)answer[0]).visited;
                CreateTree(tree, list, 2);
            }
            return tree;
        }

        private void CreateTree(TreeNode tree, int[] list, int num)
        {
            int i = num;
            if (i >= list[0])
                return;
aaa:
            TreeNode[] nodes = tree.Nodes.Find(list[i].ToString(), false);
            if (nodes.Length > 0)
            {
                CreateTree(nodes[0], list, num + 1);
            }
            else
            {
                tree.Nodes.Add(list[i].ToString());
                goto aaa;
            }
        }

        private void Sort(ArrayList list)
        {
            int len = list.Count;
            for (int i = 0; i < len - 1; i++)
            {
                for (int j = 0; j < len - i - 1; j++)
                {
                    if(((Answer)list[j]).sum > ((Answer)list[j + 1]).sum)
                    {
                        Answer tmp = (Answer)list[j];
                        list[j] = list[j + 1];
                        list[j + 1] = tmp;
                    }
                }
            }
        }

        public ArrayList answer;
        public int currentAnswerNo = 0;

        private void axiba(int vi)
        {
            if(visited[0] == Getvertexno())
            {
                answer.Add(new Answer(GetLength(visited), visited, printVisited(), ++currentAnswerNo));
                return;
            }
            int vk = 0;
            while (GetNextV(vi, vk) != 0)
            {
                vk = GetNextV(vi, vk);
                if (Array.IndexOf(visited, vk, 1) < 0)
                {
                    setVisited(vk);
                    axiba(vk);
                    dropVisited();
                }
            }
        }

        private float GetLength(int[] visited)
        {
            float sum = 0;
            for(int i = 1; i < visited[0]; i++)
            {
                sum += edge[visited[i]-1, visited[i + 1]-1];
            }
            return sum;
        }

        private void setVisited(int num)
        {
            visited[++visited[0]] = num;
        }

        private void dropVisited()
        {
            visited[visited[0]--] = 0;
        }

        internal string GetTure()
        {
            string res = "";
            answer = new ArrayList();
            currentAnswerNo = 0;
            Array.Clear(visited, 0, Getvertexno());
            setVisited(currentID);
            xjbTure(currentID);
            foreach (Answer aaa in answer)
            {
                res += aaa + "\r\n";
            }
            return res;
        }

        private void xjbTure(int vi)
        {
            if (visited[0] > 1 && visited[visited[0]] == visited[1])
            {
                answer.Add(new Answer(GetLength(visited),visited, printVisited(), ++currentAnswerNo));
                return;
            }
            int vk = 0;
            while (GetNextV(vi, vk) != 0)
            {
                vk = GetNextV(vi, vk);
                if (Array.IndexOf(visited, vk, 2) < 0)
                {
                    setVisited(vk);
                    xjbTure(vk);
                    dropVisited();
                }
            }
        }

    }
}