using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private pailiezuhe Pailiezuhe1 = new pailiezuhe();
        public Form1()
        {
            InitializeComponent();
        }

        private void zgs_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            int n = Convert.ToInt16(zgs.Text);
            int m = Convert.ToInt16(xgs.Text);
            if (n >= m)
            {
                if (digui.Checked == true)
                    Pailiezuhe1.Fun_Permute_Recursion(n, m, 1);
                else
                    Pailiezuhe1.Fun_Permute_Stack(n, m);
                richTextBox1.Text = Pailiezuhe1.getstrout();
                Pailiezuhe1.emptystr();
            }
            else
                richTextBox1.Text = "error";

        }

        private void button2_Click(object sender, EventArgs e)
        {

            int n = Convert.ToInt16(zgs.Text);
            int m = Convert.ToInt16(xgs.Text);
            if (n >= m)
            {
                if (digui.Checked == true)
                    Pailiezuhe1.Fun_combination_Recursion(n, m, 1);
                else
                    Pailiezuhe1.Fun_Combination_Stack(n, m);
                richTextBox1.Text = Pailiezuhe1.getstrout();
                Pailiezuhe1.emptystr();
            }
            else
                richTextBox1.Text = "error";


        }

        private void button3_Click(object sender, EventArgs e)
        {
            int n= Convert.ToInt16(miji.Text);
            richTextBox1.Text = Pailiezuhe1.power_set(n);
            Pailiezuhe1.emptystr();
        }
    }
}
