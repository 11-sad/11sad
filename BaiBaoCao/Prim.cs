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
    public partial class Prim : Form
    {
        private const string FILENAME = "data.bin";
        private const int INF = int.MaxValue;
        private int[,] graph;
        private int V;

        public Prim()
        {
            InitializeComponent();
            this.Text = Application.ProductName + " " + Application.ProductVersion;

            foreach (ToolStripItem item in toolStrip1.Items)
            {
                item.Click += new EventHandler(toolStripButton_Click);
            }
            toolStripButton_Click(toolStripButton2, null);

            // Initialize the graph for testing
            InitializeGraph();
        }

        private void InitializeGraph()
        {
            // Example graph
            graph = new int[,]
            {
                { 0, 2, 0, 6, 0 },
                { 2, 0, 3, 8, 5 },
                { 0, 3, 0, 0, 7 },
                { 6, 8, 0, 0, 9 },
                { 0, 5, 7, 9, 0 }
            };

            V = graph.GetLength(0);
        }

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            graphUI1.SaveGraph(FILENAME, cboFrom.SelectedIndex, cboTo.SelectedIndex);
            base.OnClosing(e);
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Delete:
                    graphUI1.DeleteSelectedNode();
                    break;
                case Keys.D1:
                    toolStripButton_Click(toolStripButton1, null);
                    break;
                case Keys.D2:
                    toolStripButton_Click(toolStripButton2, null);
                    break;
                case Keys.D3:
                    toolStripButton_Click(toolStripButton3, null);
                    break;
                case Keys.D4:
                    toolStripButton_Click(toolStripButton4, null);
                    break;
                default:
                    break;
            }

            return base.ProcessDialogKey(keyData);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            graphUI1.Reset();
        }

        private void chkUndirectedGrapth_CheckedChanged(object sender, EventArgs e)
        {
            graphUI1.IsUndirectedGraph = chkUndirectedGrapth.Checked;
        }

        private void graphUI1_SelectedNodeChanged(object sender, EventArgs e)
        {
            groupBox1.Enabled = sender != null;
        }

        private void btnDeleteNode_Click(object sender, EventArgs e)
        {
            graphUI1.DeleteSelectedNode();
        }

        private void btnChangeNodeColor_Click(object sender, EventArgs e)
        {
            Node node = graphUI1.SelectedNode;
            if (node == null)
                return;
            ColorDialog dlg = new ColorDialog();
            dlg.Color = node.BackColor;

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                Color c = dlg.Color;
                node.BackColor = c;
                node.ForeColor = Color.FromArgb(255 - c.R, 255 - c.G, 255 - c.B);

                if (Math.Abs(c.ToArgb() - node.ForeColor.ToArgb()) < 100000)
                {
                    node.ForeColor = Color.Black;
                }
            }
        }

        private void btnDeleteLastestEdge_Click(object sender, EventArgs e)
        {
            graphUI1.DeleteLastestEdge();
        }

        private void btnClearEdge_Click(object sender, EventArgs e)
        {
            graphUI1.ClearEdges();
        }

        private void toolStripButton_Click(object sender, EventArgs e)
        {
            ToolStripButton btn = (ToolStripButton)sender;
            DrawingTools tool = (DrawingTools)(int.Parse(btn.Tag.ToString()));
            graphUI1.Tool = tool;

            foreach (ToolStripButton item in toolStrip1.Items)
            {
                item.Checked = false;
            }

            btn.Checked = true;
        }

        private void graphUI1_ContentChanged(object sender, EventArgs e)
        {
            int f = cboFrom.SelectedIndex;
            int t = cboTo.SelectedIndex;

            cboFrom.DataSource = graphUI1.NodeNames;
            cboTo.DataSource = graphUI1.NodeNames;

            if (cboFrom.Items.Count > f)
                cboFrom.SelectedIndex = f;
            if (cboTo.Items.Count > t)
                cboTo.SelectedIndex = t;
        }

        private void btnPrim_Click(object sender, EventArgs e)
        {
            List<(int, int, int)> mstEdges = PrimAlgorithm();
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Edge \tWeight");
            foreach (var edge in mstEdges)
            {
                sb.AppendLine($"{edge.Item1} - {edge.Item2} \t{edge.Item3}");
            }
            MessageBox.Show(sb.ToString(), "Prim's MST");
        }

        private List<(int, int, int)> PrimAlgorithm()
        {
            V = graph.GetLength(0);
            int[] parent = new int[V];
            int[] key = new int[V];
            bool[] mstSet = new bool[V];

            for (int i = 0; i < V; i++)
            {
                key[i] = INF;
                mstSet[i] = false;
            }

            key[0] = 0; // Bắt đầu từ đỉnh đầu tiên
            parent[0] = -1; // Nút đầu tiên là gốc của MST

            for (int count = 0; count < V - 1; count++)
            {
                int u = MinKey(key, mstSet);
                mstSet[u] = true;

                for (int v = 0; v < V; v++)
                {
                    if (graph[u, v] != 0 && !mstSet[v] && graph[u, v] < key[v])
                    {
                        parent[v] = u;
                        key[v] = graph[u, v];
                    }
                }
            }

            List<(int, int, int)> mstEdges = new List<(int, int, int)>();
            for (int i = 1; i < V; i++)
            {
                mstEdges.Add((parent[i], i, graph[i, parent[i]]));
            }

            return mstEdges;
        }

        private int MinKey(int[] key, bool[] mstSet)
        {
            int min = INF, minIndex = -1;

            for (int v = 0; v < V; v++)
            {
                if (!mstSet[v] && key[v] < min)
                {
                    min = key[v];
                    minIndex = v;
                }
            }

            return minIndex;
        }
    }
}
