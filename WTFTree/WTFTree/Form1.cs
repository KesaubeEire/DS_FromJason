using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WTFTree
{
    public partial class Form1 : Form
    {
        private CBinaryTree XJBTree;
        public Form1()
        {
            InitializeComponent();
            XJBTree = new CBinaryTree();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            XJBTree.CreateTreeview_str(textBox1.Text.Trim(), treeView1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (treeView1.TopNode != null)
                treeView1.SelectedNode.Remove();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (treeView1.TopNode != null)
            {
                treeView1.SelectedNode.Nodes.Add(textBox2.Text.Trim());
                treeView1.ExpandAll();
            }
        }

        /// <summary>
        /// Fre Order
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            textBox3.Text = XJBTree.PreOrder(treeView1.TopNode);
        }

        /// <summary>
        /// Post Order
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button5_Click(object sender, EventArgs e)
        {
            textBox3.Text = XJBTree.PostOrder(treeView1.TopNode);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox3.Text = XJBTree.InOrder(treeView1.TopNode);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox3.Text = XJBTree.Search(treeView1.TopNode);
        }

        /// <summary>
        /// 复制
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button8_Click(object sender, EventArgs e)
        {
            treeView2.Nodes.Clear();
            treeView2.Nodes.Add(XJBTree.Copy(treeView1.TopNode));
            treeView2.ExpandAll();
        }

        /// <summary>
        /// 反转
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button9_Click(object sender, EventArgs e)
        {
            treeView2.Nodes.Clear();
            treeView2.Nodes.Add(XJBTree.Reverse(XJBTree.Copy(treeView1.TopNode)));
            treeView2.ExpandAll();
        }

        /// <summary>
        /// 编号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button10_Click(object sender, EventArgs e)
        {
            XJBTree.number(treeView1.TopNode, "");
        }

        /// <summary>
        /// 二叉
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button11_Click(object sender, EventArgs e)
        {
            XJBTree.binary(treeView1.TopNode);
            treeView1.ExpandAll();
        }
    }
}
