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
    public partial class Kruscal : Form
    {
        private const string FILENAME = "data.bin";
        private List<Edge> edges;
        private int V; // Số đỉnh trong đồ thị

        public Kruscal()
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
            edges = new List<Edge>
            {
                new Edge { Src = 0, Dest = 1, Weight = 10 },
                new Edge { Src = 0, Dest = 2, Weight = 6 },
                new Edge { Src = 0, Dest = 3, Weight = 5 },
                new Edge { Src = 1, Dest = 3, Weight = 15 },
                new Edge { Src = 2, Dest = 3, Weight = 4 }
            };

            V = 4; // Số đỉnh ví dụ
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

        private void graphUI1_SelectedNodeChanged(object sender, EventArgs e)
        {
            groupBox1.Enabled = sender != null;
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

        private void btnClearEdge_Click(object sender, EventArgs e)
        {
            graphUI1.ClearEdges();
        }

        private void btnDeleteLastestEdge_Click(object sender, EventArgs e)
        {
            graphUI1.DeleteLastestEdge();
        }

        private void DeleteAll_Click(object sender, EventArgs e)
        {
            graphUI1.Reset();
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

        private void btnKruskal_Click(object sender, EventArgs e)
        {
            try
            {
                List<Edge> mstEdges = KruskalAlgorithm();
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("Cạnh \tTrọng số");
                foreach (var edge in mstEdges)
                {
                    sb.AppendLine($"{edge.Src} - {edge.Dest} \t{edge.Weight}");
                }
                MessageBox.Show(sb.ToString(), "MST của Kruskal");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private List<Edge> KruskalAlgorithm()
        {
            // Bước 1: Sắp xếp tất cả các cạnh theo thứ tự không giảm của trọng số.
            edges.Sort((x, y) => x.Weight.CompareTo(y.Weight));

            // Cấp phát bộ nhớ cho việc tạo V tập hợp con
            Subset[] subsets = new Subset[V];
            for (int v = 0; v < V; ++v)
                subsets[v] = new Subset { Parent = v, Rank = 0 };

            List<Edge> mstEdges = new List<Edge>(); // Đây sẽ lưu trữ MST kết quả

            int e = 0; // Một biến chỉ số, dùng cho các cạnh đã sắp xếp
            int i = 0; // Một biến chỉ số, dùng cho các cạnh

            // Số cạnh cần lấy là V-1
            while (e < V - 1 && i < edges.Count)
            {
                // Bước 2: Lấy cạnh nhỏ nhất. Và tăng chỉ số lên cho lần lặp tiếp theo
                Edge nextEdge = edges[i++];

                int x = Find(subsets, nextEdge.Src);
                int y = Find(subsets, nextEdge.Dest);

                // Nếu bao gồm cạnh này không tạo thành chu trình, bao gồm nó vào kết quả và tăng chỉ số kết quả cho cạnh tiếp theo
                if (x != y)
                {
                    mstEdges.Add(nextEdge);
                    e++;
                    Union(subsets, x, y);
                }
            }

            return mstEdges;
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
    }
}
