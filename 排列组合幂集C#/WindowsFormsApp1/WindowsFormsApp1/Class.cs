using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class pailiezuhe
    {
        int[] m_percom_temp = new int[12] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
        int num = 1;
        string m_strout;
        bool Power_Set = false;
        
        public string Getstr_percom_temp(int m)
        {
            string strout = "";
            if(Power_Set)
                strout += "(" + num + ")" + "\t{";
            else
                strout += "(" + num + ")" + "\t【";
            int i;
            for (i = 1; i < m; i++)
            {
                strout += m_percom_temp[i] + ",";
            }
            if(Power_Set)
                strout += m_percom_temp[i] + "}\n";
            else
                strout += m_percom_temp[i] + "】\n";
            num++;
            return strout;

        }
        public void Fun_Permute_Recursion(int n, int m, int k)
        {
            for (int i = 1; i <= n; i++)
            {
                bool tag = false;
                for (int j = 1; j <= k - 1; j++)
                {
                    if (i == m_percom_temp[j])
                    { tag = true; break; }
                }
                if (tag == false)
                {
                    m_percom_temp[k] = i;
                    if (k < m)
                        Fun_Permute_Recursion(n, m, k + 1);
                    else
                        m_strout += Getstr_percom_temp(m);
                }
            }
        }
        public void Fun_Permute_Stack(int n, int m)
        {
            int[] s_no = new int[m + 1]; //存放栈顶次数的栈
            bool[] s_tag = new bool[n + 1];
            //存放下标是否在栈中的标记
            int top = 0;
            //第一个进栈
            top++;
            m_percom_temp[top] = 1;
            s_no[top] = 1;
            s_tag[1] = true;//在栈中
            //栈不空时循环
            while (top > 0)
            {
                if (s_no[top] == 1) //查看栈顶标记
                {
                    s_no[top] = 2; //修改栈顶标记                    
                    if (top < m) //继续进栈
                    {
                        for (int i = 1; i <= n; i++)
                        {
                            if (s_tag[i] == false)
                            {
                                top++;
                                m_percom_temp[top] = i;
                                s_no[top] = 1;
                                s_tag[i] = true;//在栈中
                                break;
                            }
                        }
                    }
                    else
                        m_strout += Getstr_percom_temp(m);
                }
                else if (s_no[top] == 2) //查看栈顶标记
                {
                    s_tag[m_percom_temp[top]] = false;//不在栈中了
                    top--; //出栈
                           //下一个进栈
                    for (int i = m_percom_temp[top + 1] + 1; i <= n; i++)
                    {
                        if (s_tag[i] == false)
                        {
                            top++;
                            m_percom_temp[top] = i;
                            s_no[top] = 1;
                            s_tag[i] = true;//在栈中
                            break;
                        }
                    }
                }


            }
        }
        public void Fun_combination_Recursion(int n, int m, int k)
        {
            for (int i = m_percom_temp[k - 1]; i <= n; i++)
            {
                bool tag = false;
                for (int j = 1; j <= k - 1; j++)
                {
                    if (i == m_percom_temp[j])
                    { tag = true; break; }
                }
                if (tag == false)
                {
                    m_percom_temp[k] = i;
                    if (k < m)
                        Fun_combination_Recursion(n, m, k + 1);
                    else
                    {

                        m_strout += Getstr_percom_temp(m);
                    }
                }
            }

        }
        public void Fun_Combination_Stack(int n, int m)
        {
            int[] s_no = new int[m + 1]; //存放栈顶次数的栈
            bool[] s_tag = new bool[n + 1];
            //存放下标是否在栈中的标记
            int top = 0;
            //第一个进栈
            top++;
            m_percom_temp[top] = 1;
            s_no[top] = 1;
            s_tag[1] = true;//在栈中
            //栈不空时循环
            while (top > 0)
            {
                if (s_no[top] == 1) //查看栈顶标记
                {
                    s_no[top] = 2; //修改栈顶标记                    
                    if (top < m) //继续进栈
                    {
                        for (int i = m_percom_temp[top]; i <= n; i++)
                        {
                            if (s_tag[i] == false)
                            {
                                top++;
                                m_percom_temp[top] = i;
                                s_no[top] = 1;
                                s_tag[i] = true;//在栈中
                                break;
                            }
                        }
                    }
                    else
                        m_strout += Getstr_percom_temp(m);
                }
                else if (s_no[top] == 2) //查看栈顶标记
                {
                    s_tag[m_percom_temp[top]] = false;//不在栈中了
                    top--; //出栈
                           //下一个进栈
                    for (int i = m_percom_temp[top + 1] + 1; i <= n; i++)
                    {
                        if (s_tag[i] == false)
                        {
                            top++;
                            m_percom_temp[top] = i;
                            s_no[top] = 1;
                            s_tag[i] = true;//在栈中
                            break;
                        }
                    }
                }


            }
        }
        public string power_set(int n)
        {
            Power_Set = true;
            m_strout += "(" + num + ")\t" + "{Ø}\n";
                num++;
            for (int i=1;i<=n;i++)
            {
                Fun_Combination_Stack(n, i);

            }
            Power_Set = false;
            return m_strout;
        }

            public string getstrout()
        {
            return m_strout;
        }
        public void emptystr()
        {
            m_strout = "";
            num = 1;
            for (int i = 1; i < 11; i++)
                m_percom_temp[i] = 1;

        }
        

    }
}
