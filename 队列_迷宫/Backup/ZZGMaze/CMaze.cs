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
    struct moved  //坐标增量表
    {
        public int x, y;
    }
    public class CMaze
    {
        private int rows, cols;//迷宫矩阵的行列数
        private int bi, bj;//迷宫起点坐标
        private int ei, ej;//迷宫终点坐标
        private int[] elems;
        public CQueue<sqtype> sq;
        static moved[] move = new moved[8];
        //--------------------------------------------------------------------------------
        public int Getrows(){ return rows; }
        public int Getcols(){ return cols; }
        public int Getbi() { return bi; }
        public int Getbj() { return bj; }
        public int Getei() { return ei; }
        public int Getej() { return ej; }
        public void Setbi(int bi) { this.bi = bi; }
        public void Setbj(int bj) { this.bj = bj; }
        public void Setei(int ei) { this.ei = ei; }
        public void Setej(int ej) { this.ej = ej; }
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
        public int ShortPath()
        {
        //初始化位置坐标增量
            move[0].x = 0; move[1].x = +1; move[2].x = 0; move[3].x = -1;
            move[0].y = +1; move[1].y = 0; move[2].y = -1; move[3].y = 0;
        //清除迷宫矩阵中的原有路径标记
	        clear();
        //清空队列
	        sq.MakeEmpty();
        //判断合理性
	        if(rows==0||cols==0)
		        return 0;
	        if((bi==ei)&&bj==ej)//起点与终点重合
		        return 1;
            int i,j,k,x,y;
        //定义临时三元组
            sqtype temp;
        //三元组初值为起点
            temp.x=bi;
	        temp.y=bj;
	        temp.pre=0;
            sq.In(temp);
        //起点走过
            Setelems(bi, bj,-1);
            Random ran = new Random();
            int kr = ran.Next(4);
        //队列不空时循环
            while(!sq.IsEmpty())
            {
	        //取队头
		        temp=sq.Getfront();
		        x=temp.x;y=temp.y;
	        //循环每个方向
                for (k = 0; k < 4; k++)
                {
                    //新的顶点坐标
                    kr = (kr + k) % 4;
                    i = x + move[kr].x;
                    j = y + move[kr].y;
                    //顶点可走时入队，并设置为走过
                    if (Getelems(i, j) == 0)
                    {
                        temp.x = i;
                        temp.y = j;
                        temp.pre = sq.Front() + 1;
                        sq.In(temp);
                        Setelems(i, j, -1);
                    }
                    //走到终点时
                    if (i == ei && j == ej)
                    {
                        //从队尾向前查找走过的路径
                        j = sq.Rear();
                        for (i = sq.Rear(); i >= 1; i--)
                        {
                            temp = sq.Getdata(i);
                            if (i == j)
                            {
                                Setelems(temp.x, temp.y, -1);
                                j = temp.pre;
                            }
                            else
                                Setelems(temp.x, temp.y, 0);
                        }
                        return 1;
                    }
                }
	        //处理过的顶点出队
		        sq.Out();
            }
	        clear();
	        sq.MakeEmpty();
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
