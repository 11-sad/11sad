namespace BaiBaoCao
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
            this.câyKhungToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tìmĐườngĐiNgắnNhấtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kruscalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelmenu = new System.Windows.Forms.Panel();
            this.bFSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.câyKhungToolStripMenuItem,
            this.tìmĐườngĐiNgắnNhấtToolStripMenuItem,
            this.kruscalToolStripMenuItem,
            this.bFSToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(868, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // câyKhungToolStripMenuItem
            // 
            this.câyKhungToolStripMenuItem.Name = "câyKhungToolStripMenuItem";
            this.câyKhungToolStripMenuItem.Size = new System.Drawing.Size(97, 24);
            this.câyKhungToolStripMenuItem.Text = "Cây Khung ";
            this.câyKhungToolStripMenuItem.Click += new System.EventHandler(this.câyKhungToolStripMenuItem_Click);
            // 
            // tìmĐườngĐiNgắnNhấtToolStripMenuItem
            // 
            this.tìmĐườngĐiNgắnNhấtToolStripMenuItem.Name = "tìmĐườngĐiNgắnNhấtToolStripMenuItem";
            this.tìmĐườngĐiNgắnNhấtToolStripMenuItem.Size = new System.Drawing.Size(193, 24);
            this.tìmĐườngĐiNgắnNhấtToolStripMenuItem.Text = "Tìm Đường Đi Ngắn Nhất";
            this.tìmĐườngĐiNgắnNhấtToolStripMenuItem.Click += new System.EventHandler(this.tìmĐườngĐiNgắnNhấtToolStripMenuItem_Click);
            // 
            // kruscalToolStripMenuItem
            // 
            this.kruscalToolStripMenuItem.Name = "kruscalToolStripMenuItem";
            this.kruscalToolStripMenuItem.Size = new System.Drawing.Size(70, 24);
            this.kruscalToolStripMenuItem.Text = "Kruscal";
            this.kruscalToolStripMenuItem.Click += new System.EventHandler(this.kruscalToolStripMenuItem_Click);
            // 
            // panelmenu
            // 
            this.panelmenu.Location = new System.Drawing.Point(12, 42);
            this.panelmenu.Name = "panelmenu";
            this.panelmenu.Size = new System.Drawing.Size(829, 651);
            this.panelmenu.TabIndex = 2;
            // 
            // bFSToolStripMenuItem
            // 
            this.bFSToolStripMenuItem.Name = "bFSToolStripMenuItem";
            this.bFSToolStripMenuItem.Size = new System.Drawing.Size(47, 24);
            this.bFSToolStripMenuItem.Text = "BFS";
            this.bFSToolStripMenuItem.Click += new System.EventHandler(this.bFSToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(868, 714);
            this.Controls.Add(this.panelmenu);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem câyKhungToolStripMenuItem;
        private System.Windows.Forms.Panel panelmenu;
        private System.Windows.Forms.ToolStripMenuItem tìmĐườngĐiNgắnNhấtToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kruscalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bFSToolStripMenuItem;
    }
}