namespace DirectedGraph
{
    partial class Form_Sjks17_05
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.rb_traversal4 = new System.Windows.Forms.RadioButton();
            this.rb_traversal3 = new System.Windows.Forms.RadioButton();
            this.rb_traversal2 = new System.Windows.Forms.RadioButton();
            this.rb_traversal1 = new System.Windows.Forms.RadioButton();
            this.rb_traversal0 = new System.Windows.Forms.RadioButton();
            this.tb_traversal = new System.Windows.Forms.TextBox();
            this.tb_graph_matrix = new System.Windows.Forms.TextBox();
            this.cb_dispedge = new System.Windows.Forms.CheckBox();
            this.cb_IsDirected = new System.Windows.Forms.CheckBox();
            this.bt_creategraph = new System.Windows.Forms.Button();
            this.bt_opernfile = new System.Windows.Forms.Button();
            this.tb_fname = new System.Windows.Forms.TextBox();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.button5 = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.checkBox1);
            this.panel1.Controls.Add(this.button5);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.rb_traversal4);
            this.panel1.Controls.Add(this.rb_traversal3);
            this.panel1.Controls.Add(this.rb_traversal2);
            this.panel1.Controls.Add(this.rb_traversal1);
            this.panel1.Controls.Add(this.rb_traversal0);
            this.panel1.Controls.Add(this.tb_traversal);
            this.panel1.Controls.Add(this.tb_graph_matrix);
            this.panel1.Controls.Add(this.cb_dispedge);
            this.panel1.Controls.Add(this.cb_IsDirected);
            this.panel1.Controls.Add(this.bt_creategraph);
            this.panel1.Controls.Add(this.bt_opernfile);
            this.panel1.Controls.Add(this.tb_fname);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(846, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(285, 593);
            this.panel1.TabIndex = 1;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(204, 531);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(75, 21);
            this.textBox1.TabIndex = 16;
            this.textBox1.Text = "0";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(204, 558);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 15;
            this.button4.Text = "画路径";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(139, 531);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(59, 50);
            this.button3.TabIndex = 14;
            this.button3.Text = "排序";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(69, 531);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(64, 50);
            this.button2.TabIndex = 13;
            this.button2.Text = "回路";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(35, 531);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(28, 50);
            this.button1.TabIndex = 12;
            this.button1.Text = "全程";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // rb_traversal4
            // 
            this.rb_traversal4.AutoSize = true;
            this.rb_traversal4.Location = new System.Drawing.Point(113, 236);
            this.rb_traversal4.Name = "rb_traversal4";
            this.rb_traversal4.Size = new System.Drawing.Size(95, 16);
            this.rb_traversal4.TabIndex = 11;
            this.rb_traversal4.Text = "单源最短路径";
            this.rb_traversal4.UseVisualStyleBackColor = true;
            this.rb_traversal4.CheckedChanged += new System.EventHandler(this.rb_traversal4_CheckedChanged);
            // 
            // rb_traversal3
            // 
            this.rb_traversal3.AutoSize = true;
            this.rb_traversal3.Location = new System.Drawing.Point(113, 214);
            this.rb_traversal3.Name = "rb_traversal3";
            this.rb_traversal3.Size = new System.Drawing.Size(83, 16);
            this.rb_traversal3.TabIndex = 10;
            this.rb_traversal3.Text = "最小生成树";
            this.rb_traversal3.UseVisualStyleBackColor = true;
            // 
            // rb_traversal2
            // 
            this.rb_traversal2.AutoSize = true;
            this.rb_traversal2.Location = new System.Drawing.Point(3, 258);
            this.rb_traversal2.Name = "rb_traversal2";
            this.rb_traversal2.Size = new System.Drawing.Size(95, 16);
            this.rb_traversal2.TabIndex = 9;
            this.rb_traversal2.Text = "广度优先遍历";
            this.rb_traversal2.UseVisualStyleBackColor = true;
            // 
            // rb_traversal1
            // 
            this.rb_traversal1.AutoSize = true;
            this.rb_traversal1.Location = new System.Drawing.Point(3, 236);
            this.rb_traversal1.Name = "rb_traversal1";
            this.rb_traversal1.Size = new System.Drawing.Size(95, 16);
            this.rb_traversal1.TabIndex = 8;
            this.rb_traversal1.Text = "深度优先遍历";
            this.rb_traversal1.UseVisualStyleBackColor = true;
            // 
            // rb_traversal0
            // 
            this.rb_traversal0.AutoSize = true;
            this.rb_traversal0.Checked = true;
            this.rb_traversal0.Location = new System.Drawing.Point(3, 214);
            this.rb_traversal0.Name = "rb_traversal0";
            this.rb_traversal0.Size = new System.Drawing.Size(59, 16);
            this.rb_traversal0.TabIndex = 7;
            this.rb_traversal0.TabStop = true;
            this.rb_traversal0.Text = "不显示";
            this.rb_traversal0.UseVisualStyleBackColor = true;
            this.rb_traversal0.CheckedChanged += new System.EventHandler(this.rb_traversal0_CheckedChanged);
            // 
            // tb_traversal
            // 
            this.tb_traversal.Location = new System.Drawing.Point(0, 280);
            this.tb_traversal.Multiline = true;
            this.tb_traversal.Name = "tb_traversal";
            this.tb_traversal.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tb_traversal.Size = new System.Drawing.Size(279, 245);
            this.tb_traversal.TabIndex = 6;
            // 
            // tb_graph_matrix
            // 
            this.tb_graph_matrix.Location = new System.Drawing.Point(3, 81);
            this.tb_graph_matrix.Multiline = true;
            this.tb_graph_matrix.Name = "tb_graph_matrix";
            this.tb_graph_matrix.Size = new System.Drawing.Size(279, 126);
            this.tb_graph_matrix.TabIndex = 5;
            // 
            // cb_dispedge
            // 
            this.cb_dispedge.AutoSize = true;
            this.cb_dispedge.Location = new System.Drawing.Point(113, 59);
            this.cb_dispedge.Name = "cb_dispedge";
            this.cb_dispedge.Size = new System.Drawing.Size(72, 16);
            this.cb_dispedge.TabIndex = 4;
            this.cb_dispedge.Text = "显示数据";
            this.cb_dispedge.UseVisualStyleBackColor = true;
            this.cb_dispedge.CheckedChanged += new System.EventHandler(this.cb_dispedge_CheckedChanged);
            // 
            // cb_IsDirected
            // 
            this.cb_IsDirected.AutoSize = true;
            this.cb_IsDirected.Checked = true;
            this.cb_IsDirected.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_IsDirected.Enabled = false;
            this.cb_IsDirected.Location = new System.Drawing.Point(3, 59);
            this.cb_IsDirected.Name = "cb_IsDirected";
            this.cb_IsDirected.Size = new System.Drawing.Size(60, 16);
            this.cb_IsDirected.TabIndex = 3;
            this.cb_IsDirected.Text = "有向图";
            this.cb_IsDirected.UseVisualStyleBackColor = true;
            this.cb_IsDirected.CheckedChanged += new System.EventHandler(this.cb_IsDirected_CheckedChanged);
            // 
            // bt_creategraph
            // 
            this.bt_creategraph.Location = new System.Drawing.Point(165, 30);
            this.bt_creategraph.Name = "bt_creategraph";
            this.bt_creategraph.Size = new System.Drawing.Size(117, 23);
            this.bt_creategraph.TabIndex = 2;
            this.bt_creategraph.Text = "生成";
            this.bt_creategraph.UseVisualStyleBackColor = true;
            this.bt_creategraph.Click += new System.EventHandler(this.bt_creategraph_Click);
            // 
            // bt_opernfile
            // 
            this.bt_opernfile.Location = new System.Drawing.Point(3, 30);
            this.bt_opernfile.Name = "bt_opernfile";
            this.bt_opernfile.Size = new System.Drawing.Size(156, 23);
            this.bt_opernfile.TabIndex = 1;
            this.bt_opernfile.Text = "选择“图”的数据文件";
            this.bt_opernfile.UseVisualStyleBackColor = true;
            this.bt_opernfile.Click += new System.EventHandler(this.bt_opernfile_Click);
            // 
            // tb_fname
            // 
            this.tb_fname.Location = new System.Drawing.Point(3, 3);
            this.tb_fname.Name = "tb_fname";
            this.tb_fname.Size = new System.Drawing.Size(279, 21);
            this.tb_fname.TabIndex = 0;
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(668, 12);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(172, 282);
            this.treeView1.TabIndex = 2;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(3, 531);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(28, 50);
            this.button5.TabIndex = 17;
            this.button5.Text = "路径";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(191, 59);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(60, 16);
            this.checkBox1.TabIndex = 18;
            this.checkBox1.Text = "显示树";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // Form_Sjks17_05
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1131, 593);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.panel1);
            this.Name = "Form_Sjks17_05";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form_Graph_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form_Graph_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form_Graph_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form_Graph_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form_Graph_MouseUp);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rb_traversal4;
        private System.Windows.Forms.RadioButton rb_traversal3;
        private System.Windows.Forms.RadioButton rb_traversal2;
        private System.Windows.Forms.RadioButton rb_traversal1;
        private System.Windows.Forms.RadioButton rb_traversal0;
        private System.Windows.Forms.TextBox tb_traversal;
        private System.Windows.Forms.TextBox tb_graph_matrix;
        private System.Windows.Forms.CheckBox cb_dispedge;
        private System.Windows.Forms.CheckBox cb_IsDirected;
        private System.Windows.Forms.Button bt_creategraph;
        private System.Windows.Forms.Button bt_opernfile;
        private System.Windows.Forms.TextBox tb_fname;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}

