using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaiBaoCao
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void thuậtToánPrimToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Prim pr = new Prim();
            pr.TopLevel = false;
            pr.FormBorderStyle = FormBorderStyle.None;
            pr.Dock = DockStyle.Fill;
            this.panel1.Controls.Add(pr);
            this.panel1.Tag = pr;
            pr.BringToFront();
            pr.Show();
        }
    }
}
