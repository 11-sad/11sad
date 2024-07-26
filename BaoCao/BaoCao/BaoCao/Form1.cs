using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaoCao
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void primToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Prim prim = new Prim();
            prim.TopLevel = false;
            prim.FormBorderStyle = FormBorderStyle.None;
            prim.Dock = DockStyle.Fill;
            this.panelmenu.Controls.Add(prim);
            this.panelmenu.Tag = prim;
            prim.BringToFront();
            prim.Show();
        }

        private void kruscalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Kruscal kc = new Kruscal();
            kc.TopLevel = false;
            kc.FormBorderStyle = FormBorderStyle.None;
            kc.Dock = DockStyle.Fill;
            this.panelmenu.Controls.Add(kc);
            this.panelmenu.Tag = kc;
            kc.BringToFront();
            kc.Show();
        }

        private void dijkstraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dijkstra dtr = new Dijkstra();
            dtr.TopLevel = false;
            dtr.FormBorderStyle = FormBorderStyle.None;
            dtr.Dock = DockStyle.Fill;
            this.panelmenu.Controls.Add(dtr);
            this.panelmenu.Tag = dtr;
            dtr.BringToFront();
            dtr.Show();
        }

        private void dFSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DFS dfs = new DFS();
            dfs.TopLevel = false;
            dfs.FormBorderStyle = FormBorderStyle.None;
            dfs.Dock = DockStyle.Fill;
            this.panelmenu.Controls.Add(dfs);
            this.panelmenu.Tag = dfs;
            dfs.BringToFront();
            dfs.Show();
        }

        private void bFSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BFS bfs = new BFS();
            bfs.TopLevel = false;
            bfs.FormBorderStyle = FormBorderStyle.None;
            bfs.Dock = DockStyle.Fill;
            this.panelmenu.Controls.Add(bfs);
            this.panelmenu.Tag = bfs;
            bfs.BringToFront();
            bfs.Show();
        }
    }

}
