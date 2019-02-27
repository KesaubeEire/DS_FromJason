namespace Graph
{
    partial class Form_Graph
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tb_traversal = new System.Windows.Forms.TextBox();
            this.rb_traversal4 = new System.Windows.Forms.RadioButton();
            this.rb_traversal3 = new System.Windows.Forms.RadioButton();
            this.rb_traversal2 = new System.Windows.Forms.RadioButton();
            this.rb_traversal1 = new System.Windows.Forms.RadioButton();
            this.rb_traversal0 = new System.Windows.Forms.RadioButton();
            this.cb_dispedge = new System.Windows.Forms.CheckBox();
            this.cb_IsDirected = new System.Windows.Forms.CheckBox();
            this.tb_graph_matrix = new System.Windows.Forms.TextBox();
            this.bt_creategraph = new System.Windows.Forms.Button();
            this.bt_openfile = new System.Windows.Forms.Button();
            this.tb_fname = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tb_traversal);
            this.groupBox1.Controls.Add(this.rb_traversal4);
            this.groupBox1.Controls.Add(this.rb_traversal3);
            this.groupBox1.Controls.Add(this.rb_traversal2);
            this.groupBox1.Controls.Add(this.rb_traversal1);
            this.groupBox1.Controls.Add(this.rb_traversal0);
            this.groupBox1.Controls.Add(this.cb_dispedge);
            this.groupBox1.Controls.Add(this.cb_IsDirected);
            this.groupBox1.Controls.Add(this.tb_graph_matrix);
            this.groupBox1.Controls.Add(this.bt_creategraph);
            this.groupBox1.Controls.Add(this.bt_openfile);
            this.groupBox1.Controls.Add(this.tb_fname);
            this.groupBox1.Location = new System.Drawing.Point(626, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(288, 702);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // tb_traversal
            // 
            this.tb_traversal.Location = new System.Drawing.Point(21, 500);
            this.tb_traversal.Name = "tb_traversal";
            this.tb_traversal.Size = new System.Drawing.Size(261, 21);
            this.tb_traversal.TabIndex = 11;
            // 
            // rb_traversal4
            // 
            this.rb_traversal4.AutoSize = true;
            this.rb_traversal4.Location = new System.Drawing.Point(21, 466);
            this.rb_traversal4.Name = "rb_traversal4";
            this.rb_traversal4.Size = new System.Drawing.Size(95, 16);
            this.rb_traversal4.TabIndex = 10;
            this.rb_traversal4.TabStop = true;
            this.rb_traversal4.Text = "radioButton5";
            this.rb_traversal4.UseVisualStyleBackColor = true;
            // 
            // rb_traversal3
            // 
            this.rb_traversal3.AutoSize = true;
            this.rb_traversal3.Location = new System.Drawing.Point(122, 444);
            this.rb_traversal3.Name = "rb_traversal3";
            this.rb_traversal3.Size = new System.Drawing.Size(95, 16);
            this.rb_traversal3.TabIndex = 9;
            this.rb_traversal3.TabStop = true;
            this.rb_traversal3.Text = "radioButton4";
            this.rb_traversal3.UseVisualStyleBackColor = true;
            // 
            // rb_traversal2
            // 
            this.rb_traversal2.AutoSize = true;
            this.rb_traversal2.Location = new System.Drawing.Point(21, 444);
            this.rb_traversal2.Name = "rb_traversal2";
            this.rb_traversal2.Size = new System.Drawing.Size(41, 16);
            this.rb_traversal2.TabIndex = 8;
            this.rb_traversal2.TabStop = true;
            this.rb_traversal2.Text = "BFS";
            this.rb_traversal2.UseVisualStyleBackColor = true;
            // 
            // rb_traversal1
            // 
            this.rb_traversal1.AutoSize = true;
            this.rb_traversal1.Location = new System.Drawing.Point(122, 422);
            this.rb_traversal1.Name = "rb_traversal1";
            this.rb_traversal1.Size = new System.Drawing.Size(41, 16);
            this.rb_traversal1.TabIndex = 7;
            this.rb_traversal1.TabStop = true;
            this.rb_traversal1.Text = "DFS";
            this.rb_traversal1.UseVisualStyleBackColor = true;
            // 
            // rb_traversal0
            // 
            this.rb_traversal0.AutoSize = true;
            this.rb_traversal0.Location = new System.Drawing.Point(21, 422);
            this.rb_traversal0.Name = "rb_traversal0";
            this.rb_traversal0.Size = new System.Drawing.Size(95, 16);
            this.rb_traversal0.TabIndex = 6;
            this.rb_traversal0.TabStop = true;
            this.rb_traversal0.Text = "radioButton1";
            this.rb_traversal0.UseVisualStyleBackColor = true;
            this.rb_traversal0.CheckedChanged += new System.EventHandler(this.rb_traversal0_CheckedChanged);
            // 
            // cb_dispedge
            // 
            this.cb_dispedge.AutoSize = true;
            this.cb_dispedge.Location = new System.Drawing.Point(137, 124);
            this.cb_dispedge.Name = "cb_dispedge";
            this.cb_dispedge.Size = new System.Drawing.Size(72, 16);
            this.cb_dispedge.TabIndex = 5;
            this.cb_dispedge.Text = "显示权值";
            this.cb_dispedge.UseVisualStyleBackColor = true;
            this.cb_dispedge.CheckedChanged += new System.EventHandler(this.cb_dispedge_CheckedChanged);
            // 
            // cb_IsDirected
            // 
            this.cb_IsDirected.AutoSize = true;
            this.cb_IsDirected.Location = new System.Drawing.Point(21, 124);
            this.cb_IsDirected.Name = "cb_IsDirected";
            this.cb_IsDirected.Size = new System.Drawing.Size(60, 16);
            this.cb_IsDirected.TabIndex = 4;
            this.cb_IsDirected.Text = "有向图";
            this.cb_IsDirected.UseVisualStyleBackColor = true;
            // 
            // tb_graph_matrix
            // 
            this.tb_graph_matrix.Location = new System.Drawing.Point(6, 146);
            this.tb_graph_matrix.Multiline = true;
            this.tb_graph_matrix.Name = "tb_graph_matrix";
            this.tb_graph_matrix.Size = new System.Drawing.Size(276, 248);
            this.tb_graph_matrix.TabIndex = 3;
            // 
            // bt_creategraph
            // 
            this.bt_creategraph.Location = new System.Drawing.Point(184, 57);
            this.bt_creategraph.Name = "bt_creategraph";
            this.bt_creategraph.Size = new System.Drawing.Size(98, 47);
            this.bt_creategraph.TabIndex = 2;
            this.bt_creategraph.Text = "生成图";
            this.bt_creategraph.UseVisualStyleBackColor = true;
            this.bt_creategraph.Click += new System.EventHandler(this.bt_creategraph_Click);
            // 
            // bt_openfile
            // 
            this.bt_openfile.Location = new System.Drawing.Point(6, 57);
            this.bt_openfile.Name = "bt_openfile";
            this.bt_openfile.Size = new System.Drawing.Size(172, 47);
            this.bt_openfile.TabIndex = 1;
            this.bt_openfile.Text = "选择图的文件";
            this.bt_openfile.UseVisualStyleBackColor = true;
            this.bt_openfile.Click += new System.EventHandler(this.bt_openfile_Click);
            // 
            // tb_fname
            // 
            this.tb_fname.Location = new System.Drawing.Point(6, 30);
            this.tb_fname.Name = "tb_fname";
            this.tb_fname.Size = new System.Drawing.Size(276, 21);
            this.tb_fname.TabIndex = 0;
            // 
            // Form_Graph
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(926, 726);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form_Graph";
            this.Text = "Graph";
            this.Load += new System.EventHandler(this.Form_Graph_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form_Graph_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form_Graph_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form_Graph_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form_Graph_MouseUp);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tb_fname;
        private System.Windows.Forms.CheckBox cb_dispedge;
        private System.Windows.Forms.CheckBox cb_IsDirected;
        private System.Windows.Forms.TextBox tb_graph_matrix;
        private System.Windows.Forms.Button bt_creategraph;
        private System.Windows.Forms.Button bt_openfile;
        private System.Windows.Forms.TextBox tb_traversal;
        private System.Windows.Forms.RadioButton rb_traversal4;
        private System.Windows.Forms.RadioButton rb_traversal3;
        private System.Windows.Forms.RadioButton rb_traversal2;
        private System.Windows.Forms.RadioButton rb_traversal1;
        private System.Windows.Forms.RadioButton rb_traversal0;
    }
}

