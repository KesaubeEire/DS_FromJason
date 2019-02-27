using System;
using System.Collections.Generic;
using System.Text;

namespace ZZGMaze
{
    public class CStack<Type>
    {
        private int top;
		private Type[] elems;
		private const int Maxsize=100;
        //--------------------------------------------------------------------------------
		public void MakeEmpty() { top=-1; }//清空
		public bool IsEmpty() { return top==-1; }//判栈空
		public bool IsFull() { return top==Maxsize-1; }//判栈满
        ///////////////////////////////////////////////////////////
        public CStack()
        {
            elems=new Type[Maxsize];
            top = -1;
        }
        ///////////////////////////////////////////////////////////
        public bool Push(ref Type item)//入栈
        {
            if(!IsFull())
            {
                elems[++top]=item;
                return(true);
            }
            else
                return(false);
        }
        ///////////////////////////////////////////////////////////
        public Type Pop()//出栈
        {
            return elems[top--];
        }
        ///////////////////////////////////////////////////////////
        public Type Gettop()
        {
            return elems[top];
        }
        ///////////////////////////////////////////////////////////
    }
}
