namespace BaoCao
{
    partial class Form1
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.primToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kruscalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dijkstraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bFSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dFSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.postmanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelmenu = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.primToolStripMenuItem,
            this.kruscalToolStripMenuItem,
            this.dijkstraToolStripMenuItem,
            this.bFSToolStripMenuItem,
            this.dFSToolStripMenuItem,
            this.postmanToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1569, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // primToolStripMenuItem
            // 
            this.primToolStripMenuItem.Name = "primToolStripMenuItem";
            this.primToolStripMenuItem.Size = new System.Drawing.Size(53, 24);
            this.primToolStripMenuItem.Text = "Prim";
            this.primToolStripMenuItem.Click += new System.EventHandler(this.primToolStripMenuItem_Click);
            // 
            // kruscalToolStripMenuItem
            // 
            this.kruscalToolStripMenuItem.Name = "kruscalToolStripMenuItem";
            this.kruscalToolStripMenuItem.Size = new System.Drawing.Size(70, 24);
            this.kruscalToolStripMenuItem.Text = "Kruscal";
            this.kruscalToolStripMenuItem.Click += new System.EventHandler(this.kruscalToolStripMenuItem_Click);
            // 
            // dijkstraToolStripMenuItem
            // 
            this.dijkstraToolStripMenuItem.Name = "dijkstraToolStripMenuItem";
            this.dijkstraToolStripMenuItem.Size = new System.Drawing.Size(73, 24);
            this.dijkstraToolStripMenuItem.Text = "Dijkstra";
            this.dijkstraToolStripMenuItem.Click += new System.EventHandler(this.dijkstraToolStripMenuItem_Click);
            // 
            // bFSToolStripMenuItem
            // 
            this.bFSToolStripMenuItem.Name = "bFSToolStripMenuItem";
            this.bFSToolStripMenuItem.Size = new System.Drawing.Size(47, 24);
            this.bFSToolStripMenuItem.Text = "BFS";
            this.bFSToolStripMenuItem.Click += new System.EventHandler(this.bFSToolStripMenuItem_Click);
            // 
            // dFSToolStripMenuItem
            // 
            this.dFSToolStripMenuItem.Name = "dFSToolStripMenuItem";
            this.dFSToolStripMenuItem.Size = new System.Drawing.Size(49, 24);
            this.dFSToolStripMenuItem.Text = "DFS";
            this.dFSToolStripMenuItem.Click += new System.EventHandler(this.dFSToolStripMenuItem_Click);
            // 
            // postmanToolStripMenuItem
            // 
            this.postmanToolStripMenuItem.Name = "postmanToolStripMenuItem";
            this.postmanToolStripMenuItem.Size = new System.Drawing.Size(79, 24);
            this.postmanToolStripMenuItem.Text = "Postman";
            // 
            // panelmenu
            // 
            this.panelmenu.Location = new System.Drawing.Point(12, 40);
            this.panelmenu.Name = "panelmenu";
            this.panelmenu.Size = new System.Drawing.Size(1545, 657);
            this.panelmenu.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1569, 709);
            this.Controls.Add(this.panelmenu);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Menu Các Yêu Cầu";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem primToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kruscalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dijkstraToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bFSToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dFSToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem postmanToolStripMenuItem;
        private System.Windows.Forms.Panel panelmenu;
    }
}

