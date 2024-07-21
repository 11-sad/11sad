namespace BaiBaoCao
{
    partial class BFS
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
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCheckConnected = new System.Windows.Forms.Button();
            this.cboTo = new System.Windows.Forms.ComboBox();
            this.cboFrom = new System.Windows.Forms.ComboBox();
            this.btnClearEdge = new System.Windows.Forms.Button();
            this.btnDeleteLastestEdge = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnChangeNodeColor = new System.Windows.Forms.Button();
            this.btnDeleteNode = new System.Windows.Forms.Button();
            this.chkUndirectedGrapth = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnBFS = new System.Windows.Forms.Button();
            this.DeleteAll = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.graphUI1 = new BaiBaoCao.GraphUI();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 15);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 16);
            this.label1.TabIndex = 7;
            this.label1.Text = "Từ";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.Controls.Add(this.btnCheckConnected);
            this.panel1.Controls.Add(this.cboTo);
            this.panel1.Controls.Add(this.cboFrom);
            this.panel1.Controls.Add(this.btnClearEdge);
            this.panel1.Controls.Add(this.btnDeleteLastestEdge);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.chkUndirectedGrapth);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnBFS);
            this.panel1.Controls.Add(this.DeleteAll);
            this.panel1.Location = new System.Drawing.Point(16, 15);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(180, 576);
            this.panel1.TabIndex = 13;
            // 
            // btnCheckConnected
            // 
            this.btnCheckConnected.Location = new System.Drawing.Point(0, 73);
            this.btnCheckConnected.Name = "btnCheckConnected";
            this.btnCheckConnected.Size = new System.Drawing.Size(186, 28);
            this.btnCheckConnected.TabIndex = 13;
            this.btnCheckConnected.Text = "Kiểm tra tính liên thông";
            this.btnCheckConnected.UseVisualStyleBackColor = true;
            this.btnCheckConnected.Click += new System.EventHandler(this.btnCheckConnected_Click);
            // 
            // cboTo
            // 
            this.cboTo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTo.FormattingEnabled = true;
            this.cboTo.Location = new System.Drawing.Point(64, 42);
            this.cboTo.Margin = new System.Windows.Forms.Padding(4);
            this.cboTo.Name = "cboTo";
            this.cboTo.Size = new System.Drawing.Size(99, 24);
            this.cboTo.TabIndex = 12;
            // 
            // cboFrom
            // 
            this.cboFrom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFrom.FormattingEnabled = true;
            this.cboFrom.Location = new System.Drawing.Point(64, 11);
            this.cboFrom.Margin = new System.Windows.Forms.Padding(4);
            this.cboFrom.Name = "cboFrom";
            this.cboFrom.Size = new System.Drawing.Size(99, 24);
            this.cboFrom.TabIndex = 12;
            // 
            // btnClearEdge
            // 
            this.btnClearEdge.Location = new System.Drawing.Point(11, 182);
            this.btnClearEdge.Margin = new System.Windows.Forms.Padding(4);
            this.btnClearEdge.Name = "btnClearEdge";
            this.btnClearEdge.Size = new System.Drawing.Size(153, 39);
            this.btnClearEdge.TabIndex = 11;
            this.btnClearEdge.Text = "Xóa Tất Cả Cạnh";
            this.btnClearEdge.UseVisualStyleBackColor = true;
            this.btnClearEdge.Click += new System.EventHandler(this.btnClearEdge_Click);
            // 
            // btnDeleteLastestEdge
            // 
            this.btnDeleteLastestEdge.Location = new System.Drawing.Point(11, 144);
            this.btnDeleteLastestEdge.Margin = new System.Windows.Forms.Padding(4);
            this.btnDeleteLastestEdge.Name = "btnDeleteLastestEdge";
            this.btnDeleteLastestEdge.Size = new System.Drawing.Size(155, 36);
            this.btnDeleteLastestEdge.TabIndex = 10;
            this.btnDeleteLastestEdge.Text = "Xóa Cạnh Cuối";
            this.btnDeleteLastestEdge.UseVisualStyleBackColor = true;
            this.btnDeleteLastestEdge.Click += new System.EventHandler(this.btnDeleteLastestEdge_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnChangeNodeColor);
            this.groupBox1.Controls.Add(this.btnDeleteNode);
            this.groupBox1.Enabled = false;
            this.groupBox1.Location = new System.Drawing.Point(5, 351);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(169, 186);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Chọn";
            // 
            // btnChangeNodeColor
            // 
            this.btnChangeNodeColor.Location = new System.Drawing.Point(19, 82);
            this.btnChangeNodeColor.Margin = new System.Windows.Forms.Padding(4);
            this.btnChangeNodeColor.Name = "btnChangeNodeColor";
            this.btnChangeNodeColor.Size = new System.Drawing.Size(131, 31);
            this.btnChangeNodeColor.TabIndex = 1;
            this.btnChangeNodeColor.Text = "Thay Đổi Màu";
            this.btnChangeNodeColor.UseVisualStyleBackColor = true;
            this.btnChangeNodeColor.Click += new System.EventHandler(this.btnChangeNodeColor_Click);
            // 
            // btnDeleteNode
            // 
            this.btnDeleteNode.Location = new System.Drawing.Point(19, 23);
            this.btnDeleteNode.Margin = new System.Windows.Forms.Padding(4);
            this.btnDeleteNode.Name = "btnDeleteNode";
            this.btnDeleteNode.Size = new System.Drawing.Size(129, 31);
            this.btnDeleteNode.TabIndex = 0;
            this.btnDeleteNode.Text = "Xóa Nút";
            this.btnDeleteNode.UseVisualStyleBackColor = true;
            this.btnDeleteNode.Click += new System.EventHandler(this.btnDeleteNode_Click);
            // 
            // chkUndirectedGrapth
            // 
            this.chkUndirectedGrapth.Location = new System.Drawing.Point(11, 313);
            this.chkUndirectedGrapth.Margin = new System.Windows.Forms.Padding(4);
            this.chkUndirectedGrapth.Name = "chkUndirectedGrapth";
            this.chkUndirectedGrapth.Size = new System.Drawing.Size(157, 25);
            this.chkUndirectedGrapth.TabIndex = 8;
            this.chkUndirectedGrapth.Text = "Đồ Thị Vô Hướng ";
            this.chkUndirectedGrapth.UseVisualStyleBackColor = true;
            this.chkUndirectedGrapth.CheckedChanged += new System.EventHandler(this.chkUndirectedGrapth_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 47);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 16);
            this.label2.TabIndex = 7;
            this.label2.Text = "Đến";
            // 
            // btnBFS
            // 
            this.btnBFS.Location = new System.Drawing.Point(11, 108);
            this.btnBFS.Margin = new System.Windows.Forms.Padding(4);
            this.btnBFS.Name = "btnBFS";
            this.btnBFS.Size = new System.Drawing.Size(155, 34);
            this.btnBFS.TabIndex = 3;
            this.btnBFS.Text = "BFS";
            this.btnBFS.UseVisualStyleBackColor = true;
            this.btnBFS.Click += new System.EventHandler(this.btnBFS_Click);
            // 
            // DeleteAll
            // 
            this.DeleteAll.Location = new System.Drawing.Point(11, 224);
            this.DeleteAll.Margin = new System.Windows.Forms.Padding(4);
            this.DeleteAll.Name = "DeleteAll";
            this.DeleteAll.Size = new System.Drawing.Size(155, 36);
            this.DeleteAll.TabIndex = 4;
            this.DeleteAll.Text = "Xóa Tất Cả";
            this.DeleteAll.UseVisualStyleBackColor = true;
            this.DeleteAll.Click += new System.EventHandler(this.DeleteAll_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.toolStrip1);
            this.groupBox2.Location = new System.Drawing.Point(204, 527);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(591, 64);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Toolbox";
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2,
            this.toolStripButton3,
            this.toolStripButton4});
            this.toolStrip1.Location = new System.Drawing.Point(4, 19);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(583, 27);
            this.toolStrip1.TabIndex = 0;
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(108, 24);
            this.toolStripButton1.Tag = "0";
            this.toolStripButton1.Text = "Di Chuyển Nút";
            this.toolStripButton1.ToolTipText = "Move (1)";
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(65, 24);
            this.toolStripButton2.Tag = "1";
            this.toolStripButton2.Text = "Đặt Nút";
            this.toolStripButton2.ToolTipText = "Node (2)";
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(78, 24);
            this.toolStripButton3.Tag = "2";
            this.toolStripButton3.Text = "Đường Đi";
            this.toolStripButton3.ToolTipText = "Edge (3)";
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(67, 24);
            this.toolStripButton4.Tag = "3";
            this.toolStripButton4.Text = "Xóa Nút";
            this.toolStripButton4.ToolTipText = "Eraser (4)";
            // 
            // graphUI1
            // 
            this.graphUI1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.graphUI1.IsUndirectedGraph = false;
            this.graphUI1.Location = new System.Drawing.Point(208, 13);
            this.graphUI1.Name = "graphUI1";
            this.graphUI1.Size = new System.Drawing.Size(583, 507);
            this.graphUI1.TabIndex = 15;
            this.graphUI1.Text = "graphUI1";
            this.graphUI1.ContentChanged += new System.EventHandler(this.graphUI1_ContentChanged);
            this.graphUI1.SelectedNodeChanged += new System.EventHandler(this.graphUI1_SelectedNodeChanged);
            // 
            // BFS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(811, 604);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.graphUI1);
            this.Name = "BFS";
            this.Text = "BFS";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cboTo;
        private System.Windows.Forms.ComboBox cboFrom;
        private System.Windows.Forms.Button btnClearEdge;
        private System.Windows.Forms.Button btnDeleteLastestEdge;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnChangeNodeColor;
        private System.Windows.Forms.Button btnDeleteNode;
        private System.Windows.Forms.CheckBox chkUndirectedGrapth;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnBFS;
        private System.Windows.Forms.Button DeleteAll;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private GraphUI graphUI1;
        private System.Windows.Forms.Button btnCheckConnected;
    }
}