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
    public partial class BFS : Form
    {
        private const string FILENAME = "data.bin";
        private const int INF = int.MaxValue;
        private int[,] graph;
        private int V;

        public BFS()
        {
            InitializeComponent();
            this.Text = Application.ProductName + " " + Application.ProductVersion;

            foreach (ToolStripItem item in toolStrip1.Items)
            {
                item.Click += new EventHandler(toolStripButton_Click);
            }
            toolStripButton_Click(toolStripButton2, null);

            InitializeGraph();
        }

        private void InitializeGraph()
        {
            // Khởi tạo đồ thị với số đỉnh V
            V = 5; // Ví dụ với 5 đỉnh
            graph = new int[V, V];
        }

        protected override void OnClosing(CancelEventArgs e)
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(cboFrom.Text) && !String.IsNullOrEmpty(cboTo.Text))
                graphUI1.FindShortestPath(cboFrom.Text[0] - 'A', cboTo.Text[0] - 'A');
        }

        private void button2_Click(object sender, EventArgs e)
        {
            graphUI1.Reset();
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

        private void chkUndirectedGrapth_CheckedChanged(object sender, EventArgs e)
        {
            graphUI1.IsUndirectedGraph = chkUndirectedGrapth.Checked;
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

        private void DeleteAll_Click(object sender, EventArgs e)
        {
            graphUI1.Reset();
        }

        // Phương thức BFS
        private List<int> PerformBFS(int start, bool[] visited)
        {
            List<int> result = new List<int>();
            Queue<int> queue = new Queue<int>();
            visited[start] = true;
            queue.Enqueue(start);

            while (queue.Count != 0)
            {
                int s = queue.Dequeue();
                result.Add(s);
                foreach (int next in GetAdjacentNodes(s))
                {
                    if (!visited[next])
                    {
                        visited[next] = true;
                        queue.Enqueue(next);
                    }
                }
            }
            return result;
        }

        // Phương thức kiểm tra tính liên thông
        private bool IsConnected()
        {
            bool[] visited = new bool[V];
            PerformBFS(0, visited);

            for (int i = 0; i < V; i++)
            {
                if (!visited[i])
                    return false;
            }
            return true;
        }

        // Lấy các đỉnh kề của một đỉnh
        private List<int> GetAdjacentNodes(int node)
        {
            List<int> adjacentNodes = new List<int>();
            for (int i = 0; i < V; i++)
            {
                if (graph[node, i] != 0 && graph[node, i] != INF)
                {
                    adjacentNodes.Add(i);
                }
            }
            return adjacentNodes;
        }

        // Hàm tiện ích để tìm tập hợp của một phần tử i (sử dụng kỹ thuật nén đường đi)
        private int Find(Subset[] subsets, int i)
        {
            if (subsets[i].Parent != i)
                subsets[i].Parent = Find(subsets, subsets[i].Parent);

            return subsets[i].Parent;
        }

        // Hàm để hợp nhất hai tập hợp x và y (sử dụng union theo rank)
        private void Union(Subset[] subsets, int x, int y)
        {
            int xroot = Find(subsets, x);
            int yroot = Find(subsets, y);

            // Gắn cây có hạng nhỏ hơn dưới gốc của cây có hạng cao hơn (Union theo Rank)
            if (subsets[xroot].Rank < subsets[yroot].Rank)
                subsets[xroot].Parent = yroot;
            else if (subsets[xroot].Rank > subsets[yroot].Rank)
                subsets[yroot].Parent = xroot;

            // Nếu hạng bằng nhau, làm một cái gốc và tăng hạng của nó lên một
            else
            {
                subsets[yroot].Parent = xroot;
                subsets[xroot].Rank++;
            }
        }

        public class Edge
        {
            public int Src { get; set; }
            public int Dest { get; set; }
            public int Weight { get; set; }
        }

        public class Subset
        {
            public int Parent { get; set; }
            public int Rank { get; set; }
        }

        // Thêm sự kiện để kiểm tra tính liên thông và hiển thị kết quả
        private void btnCheckConnected_Click(object sender, EventArgs e)
        {
            if (IsConnected())
                MessageBox.Show("Đồ thị liên thông!");
            else
                MessageBox.Show("Đồ thị không liên thông!");
        }

        // Thêm sự kiện để duyệt đồ thị theo chiều rộng và hiển thị kết quả
        private void btnBFS_Click(object sender, EventArgs e)
        {
            bool[] visited = new bool[V];
            List<int> result = PerformBFS(0, visited);
            if (result.Count == 0)
            {
                MessageBox.Show("Không có đỉnh nào được duyệt.");
            }
            else
            {
                MessageBox.Show("Duyệt đồ thị theo chiều rộng: " + string.Join(", ", result));
            }
        }
    }
}
