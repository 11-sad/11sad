using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaiBaoCao
{
    public partial class Dijkstra : Form
    {
        private const string FILENAME = "data.bin";
        private const int V = 10;
        private const int INF = int.MaxValue;
        private int[,] graph = new int[V, V];

        public Dijkstra()
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
            graph[0, 1] = 10;
            graph[0, 2] = 5;
            // Add more edges as needed
        }

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            graphUI2.SaveGraph(FILENAME, cboFrom.SelectedIndex, cboTo.SelectedIndex);
            base.OnClosing(e);
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Delete:
                    graphUI2.DeleteSelectedNode();
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
            graphUI2.Reset();
        }

        private void chkUndirectedGrapth_CheckedChanged(object sender, EventArgs e)
        {
            graphUI2.IsUndirectedGraph = chkUndirectedGrapth.Checked;
        }

        private void graphUI1_SelectedNodeChanged(object sender, EventArgs e)
        {
            groupBox1.Enabled = sender != null;
        }

        private void btnDeleteNode_Click(object sender, EventArgs e)
        {
            graphUI2.DeleteSelectedNode();
        }

        private void btnChangeNodeColor_Click(object sender, EventArgs e)
        {
            Node node = graphUI2.SelectedNode;
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
            graphUI2.DeleteLastestEdge();
        }

        private void btnClearEdge_Click(object sender, EventArgs e)
        {
            graphUI2.ClearEdges();
        }

        private void toolStripButton_Click(object sender, EventArgs e)
        {
            ToolStripButton btn = (ToolStripButton)sender;
            DrawingTools tool = (DrawingTools)(int.Parse(btn.Tag.ToString()));
            graphUI2.Tool = tool;

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

            cboFrom.DataSource = graphUI2.NodeNames;
            cboTo.DataSource = graphUI2.NodeNames;

            if (cboFrom.Items.Count > f)
                cboFrom.SelectedIndex = f;
            if (cboTo.Items.Count > t)
                cboTo.SelectedIndex = t;
        }

        private void btnDijkstra_Click(object sender, EventArgs e)
        {
            int source = 0;
            List<(int, int)> shortestPaths = DijkstraAlgorithm(source);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Vertex \tDistance");
            foreach (var path in shortestPaths)
            {
                sb.AppendLine($"{path.Item1} \t{path.Item2}");
            }
            MessageBox.Show(sb.ToString(), "Dijkstra's Shortest Paths");
        }

        private List<(int, int)> DijkstraAlgorithm(int source)
        {
            int[] dist = new int[V];
            bool[] visited = new bool[V];

            for (int i = 0; i < V; i++)
            {
                dist[i] = INF;
                visited[i] = false;
            }

            dist[source] = 0;

            for (int count = 0; count < V - 1; count++)
            {
                int u = MinDist(dist, visited);
                visited[u] = true;

                for (int v = 0; v < V; v++)
                {
                    if (!visited[v] && graph[u, v] != 0 && dist[u] != INF && dist[u] + graph[u, v] < dist[v])
                    {
                        dist[v] = dist[u] + graph[u, v];
                    }
                }
            }

            List<(int, int)> shortestPaths = new List<(int, int)>();
            for (int i = 0; i < V; i++)
            {
                shortestPaths.Add((i, dist[i]));
            }

            return shortestPaths;
        }

        private int MinDist(int[] dist, bool[] visited)
        {
            int min = INF, minIndex = -1;

            for (int v = 0; v < V; v++)
            {
                if (!visited[v] && dist[v] <= min)
                {
                    min = dist[v];
                    minIndex = v;
                }
            }

            return minIndex;
        }
    }
}
