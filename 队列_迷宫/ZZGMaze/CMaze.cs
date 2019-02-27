using System;
using System.Collections.Generic;
using System.Text;
using System.IO;//读取文件所需的

namespace ZZGMaze
{
    public struct sqtype//队列的三元组说明,位置和回退下标
    {
        public int x, y, pre;
    }
    public struct M  //坐标增量表
    {
        public int x, y;
        public M(int mx, int my)
        {
            x = mx;y = my;
        }
    }
    public class CMaze
    {
        private int rows, cols;//迷宫矩阵的行列数
        private int bi, bj;//迷宫起点坐标
        private int ei, ej;//迷宫终点坐标
        private int[] elems;
        public CQueue<sqtype> sq;
        public static M[] move = new M[4] {
            new M(-1,0),new M(0,1),new M(1,0),new M(0,-1)
        };
        //--------------------------------------------------------------------------------
        public int Rows { get { return rows; } set { rows = value; } }
        public int Cols { get { return cols; } set { cols = value; } }
        public int Bi { get { return bi; } set { bi = value; } }
        public int Bj { get { return bj; } set { bj = value; } }
        public int Ei { get { return ei; } set { ei = value; } }
        public int Ej { get { return ej; } set { ej = value; } }

        public int Getelems(int row, int col) 
        { 
            return elems[row * (cols + 2) + col]; 
        }
        public void Setelems(int row, int col,int value)
        {
            elems[row * (cols + 2) + col] = value; 
        }
        public CQueue<sqtype> MazeQueue()
        { 
            return sq; 
        }

        ////////////////////////////////////////////////////////////
        public int GetIntData(string strdata,int k,out int outk)
        {
            int len=strdata.Length;
            int ks=k,data;
            string str;
	        while((ks<len)&&((strdata[ks]<'0')||(strdata[ks]>'9')))
		        ks++;
            str = "";
            while((ks<len)&&((strdata[ks]>='0')&&(strdata[ks]<='9')))    
                str=str+strdata[ks++];
	        if(str!="")
		        data=Convert.ToInt32(str);
	        else 
		        data=0;
            outk=ks;
            return(data);
        }
        public CMaze(string strmazedata)
        {
            int i,j,dd,know;
            sq = new CQueue<sqtype>();
            know = 0;
            if (strmazedata == "")
            {
                rows = cols = 0;
                return;
            }
            rows = GetIntData(strmazedata, know, out know);
            cols = GetIntData(strmazedata, know, out know);
            bi = GetIntData(strmazedata, know, out know);
            bj = GetIntData(strmazedata, know, out know);
            ei = GetIntData(strmazedata, know, out know);
            ej = GetIntData(strmazedata, know, out know);
            elems = new int[(rows + 2) * (cols + 2)];
            for (i = 1; i <= rows; i++)
            {
                for (j = 1; j <= cols; j++)
                {
                    dd = GetIntData(strmazedata, know, out know);
                    elems[i * (cols + 2) + j] = dd;
                }
            }
            for (i = 0; i <= rows+1; i++)
            {
                elems[i * (cols + 2) + 0] = 1;
                elems[i * (cols + 2) + cols + 1] = 1;
            }
            for (j = 0; j <= cols+1; j++)
            {
                elems[0 * (cols + 2) + j] = 1;
                elems[(rows + 1) * (cols + 2) + j] = 1;
            }
            elems[bi * (cols + 2) + bj] = 0;//起点
            elems[ei * (cols + 2) + ej] = 0;//终点
        }
        ////////////////////////////////////////////////////////////
        public int ShortPath()//最短路径
        {
            sq = new CQueue<sqtype>();//创建队列
            if (Rows == 0 || Cols == 0)
                return 0;
            sqtype temp = new sqtype();
            sqtype temp2 = new sqtype();
            temp.x = bi;temp.y = bj; temp.pre = 0; sq.In(temp); Setelems(1, 1, -1);//起点进队
            while (!sq.IsEmpty())//队不空时循环
            {
                temp = sq.Getfront();//取队头
                for (int k = 0; k < 4; k++)//查找4个方向
                {
                    int i = temp.x + move[k].x; int j = temp.y + move[k].y;
                    if (Getelems(i, j) == 0)//路通
                    {
                        temp2.x = i;temp2.y = j;temp2.pre = sq.Front()+1;
                        sq.In(temp2);
                        Setelems(i, j, -1);
                        Console.WriteLine(temp2.x + "," + temp2.y+","+temp2.pre);
                    }
                    if (i == ei && j == ej)
                    {
                        return 1;
                    }
                }
                sq.Out();//出队
            }
            return 0;
        }
        ////////////////////////////////////////////////////////////
        public void clear()
        {
            int i,j;
            for(i=1;i<=rows;i++)
	        {
		        for (j=1;j<=cols;j++)
		        {
                    if (Getelems(i, j) == -1)
                        Setelems(i, j, 0);
		        }
	        }
        }
        ////////////////////////////////////////////////////////////
   }
}
