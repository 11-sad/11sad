using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace BaoCao
{
    public partial class Dijkstra : Form
    {
        public Dijkstra()
        {
            InitializeComponent();
        }

        static class Global
        {
            public static string GlobalVar { get; set; } = "";
            public static DataTable Dt { get; set; } = new DataTable();
            public static int Sodinh { get; set; } = 0;
            public static int Dem { get; set; } = 0;
            public static string Start { get; set; }
            public static DataGridView Dgv { get; set; }
            public static string Diem1 { get; set; }
            public static string Diem2 { get; set; }
            public static string Path { get; set; }
        }

        class Edge
        {
            public string U { get; }
            public string V { get; }
            public int W { get; }

            public Edge(string u, string v, int w)
            {
                U = u;
                V = v;
                W = w;
            }
        }

        class Graph
        {
            private readonly List<Edge> edges = new List<Edge>();
            private readonly List<string> vertices = new List<string>();

            public Graph()
            {
                int[,] matrix = new int[Global.Dem, Global.Dem];

                for (int i = 0; i < Global.Dt.Rows.Count; i++)
                {
                    for (int j = 1; j < Global.Dt.Columns.Count; j++)
                    {
                        matrix[i, j - 1] = Convert.ToInt32(Global.Dgv.Rows[i].Cells[j].Value);
                    }
                }

                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        if (matrix[i, j] != 0)
                        {
                            edges.Add(new Edge(i.ToString(), j.ToString(), matrix[i, j]));
                            if (!vertices.Contains(i.ToString()))
                            {
                                vertices.Add(i.ToString());
                            }
                            if (!vertices.Contains(j.ToString()))
                            {
                                vertices.Add(j.ToString());
                            }
                        }
                    }
                }
            }

            public void DuongDi(Dictionary<string, string> prev, string start, string end)
            {
                ArrayList path = new ArrayList();
                string current = end;

                while (current != null)
                {
                    path.Add(Convert.ToInt32(current) + 1);
                    current = prev.ContainsKey(current) ? prev[current] : null;
                }

                path.Reverse();
                Global.Path = string.Join(" ", path.Cast<int>());
            }

            public void DijkstraAlgorithm(string source, string end)
            {
                var dist = new Dictionary<string, int>();
                var prev = new Dictionary<string, string>();
                var q = new List<string>();

                foreach (var vertex in vertices)
                {
                    dist[vertex] = int.MaxValue;
                    prev[vertex] = null;
                    q.Add(vertex);
                }

                dist[source] = 0;

                while (q.Count > 0)
                {
                    var u = q.OrderBy(v => dist[v]).First();
                    q.Remove(u);

                    if (dist[u] == int.MaxValue)
                        break;

                    foreach (var edge in edges.Where(e => e.U == u && q.Contains(e.V)))
                    {
                        int alt = dist[u] + edge.W;
                        if (alt < dist[edge.V])
                        {
                            dist[edge.V] = alt;
                            prev[edge.V] = u;
                        }
                    }
                }

                DuongDi(prev, source, end);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] points = textBox1.Text.Split(' ');
            if (points.Length != 2)
            {
                MessageBox.Show("Vui lòng nhập hai chữ cái để nối các điểm.");
                return;
            }

            int x1 = 0, y1 = 0, x2 = 0, y2 = 0;
            Label lbl = new Label
            {
                Text = textBox2.Text,
                AutoSize = true,
                ForeColor = Color.Red
            };

            foreach (var item in pictureBox1.Controls.OfType<Label>().Where(l => l.ForeColor == Color.Black))
            {
                if (item.Text == points[0])
                {
                    x1 = item.Location.X;
                    y1 = item.Location.Y + 15;
                }
                if (item.Text == points[1])
                {
                    x2 = item.Location.X;
                    y2 = item.Location.Y + 15;
                }
            }

            Pen pen = new Pen(Color.Blue, 1);
            Graphics g = pictureBox1.CreateGraphics();
            g.DrawLine(pen, x1, y1, x2, y2);

            lbl.Location = new Point((x1 + x2) / 2, (y1 + y2) / 2);
            pictureBox1.Controls.Add(lbl);

            DataTable dt = Global.Dt;
            int index1 = points[0][0] - 'A';
            int index2 = points[1][0] - 'A';

            dt.Rows[index1][index2 + 1] = textBox2.Text;
            dt.Rows[index2][index1 + 1] = textBox2.Text;

            textBox2.Select();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e, Pen pen, int x1, int y1, int x2, int y2)
        {
            Graphics g = pictureBox1.CreateGraphics();
            g.DrawLine(pen, x1, y1, x2, y2);
        }

        private void btndijkstra_Click(object sender, EventArgs e)
        {
            int diem1 = Convert.ToInt32(txtdiem1.Text) - 1;
            int diem2 = Convert.ToInt32(txtdiem2.Text) - 1;
            Global.Diem1 = txtdiem1.Text;
            Global.Diem2 = txtdiem2.Text;
            Global.Start = diem1.ToString();

            Graph g = new Graph();
            g.DijkstraAlgorithm(diem1.ToString(), diem2.ToString());

            string[] dd = Global.Path.Split(' ');
            int j1 = 1;

            for (int i = 0; i < dd.Length - 1; i++)
            {
                DrawPath(dd[i], dd[j1]);
                j1++;
            }
        }

        private void DrawPath(string start, string end)
        {
            foreach (var item in pictureBox1.Controls.OfType<Label>().Where(l => l.ForeColor == Color.Black))
            {
                int x1 = 0, y1 = 0, x2 = 0, y2 = 0;
                if (item.Text == start)
                {
                    x1 = item.Location.X;
                    y1 = item.Location.Y + 15;
                    foreach (var item2 in pictureBox1.Controls.OfType<Label>().Where(l => l.ForeColor == Color.Black))
                    {
                        if (item2.Text == end)
                        {
                            x2 = item2.Location.X;
                            y2 = item2.Location.Y + 15;
                            Pen pen = new Pen(Color.Red, 1);
                            pictureBox1.CreateGraphics().DrawLine(pen, x1, y1, x2, y2);
                            break;
                        }
                    }
                    break;
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            int dem = pictureBox1.Controls.OfType<Label>()
                             .Count(l => l.ForeColor == Color.Black);

            var mouseEventArgs = e as MouseEventArgs;
            Button btn = new Button
            {
                Location = new Point(mouseEventArgs.X, mouseEventArgs.Y),
                Size = new Size(10, 10),
                BackColor = Color.Black
            };
            pictureBox1.Controls.Add(btn);

            Label lbl = new Label
            {
                Location = new Point(mouseEventArgs.X, mouseEventArgs.Y - 15),
                Text = ((char)('A' + dem)).ToString(),
                AutoSize = true,
                ForeColor = Color.Black
            };
            pictureBox1.Controls.Add(lbl);

            UpdateDataTable(lbl.Text);

            Global.Sodinh = dem + 1;
            Global.Dem = dem + 1;
            Global.Dgv = dataGridView1;
        }

        private void UpdateDataTable(string labelChar)
        {
            DataTable dt = Global.Dt;
            if (dt.Columns.Count == 0)
            {
                dt.Columns.Add(new DataColumn(" "));
            }
            dt.Columns.Add(new DataColumn(labelChar));

            foreach (DataRow row in dt.Rows)
            {
                row[labelChar] = 0;
            }

            DataRow newRow = dt.NewRow();
            newRow[0] = labelChar;
            for (int i = 1; i < dt.Columns.Count; i++)
            {
                newRow[i] = 0;
            }
            dt.Rows.Add(newRow);

            Global.Dt = dt;
            dataGridView1.DataSource = dt;
        }

        private void btnxoacanh_Click(object sender, EventArgs e)
        {
            string[] points = textBox3.Text.Split(' ');
            if (points.Length != 2)
            {
                MessageBox.Show("Vui lòng nhập hai chữ cái của các điểm để xóa cạnh.");
                return;
            }

            int index1 = points[0][0] - 'A';
            int index2 = points[1][0] - 'A';

            if (index1 < 0 || index1 >= Global.Sodinh || index2 < 0 || index2 >= Global.Sodinh)
            {
                MessageBox.Show("Đỉnh không hợp lệ.");
                return;
            }

            DataTable dt = Global.Dt;
            dt.Rows[index1][index2 + 1] = 0;
            dt.Rows[index2][index1 + 1] = 0;

            dataGridView1.DataSource = dt;

            RemoveLineFromPictureBox(points);
        }

        private void RemoveLineFromPictureBox(string[] points)
        {
            foreach (Control control in pictureBox1.Controls.OfType<Label>().ToList())
            {
                if (control.Text == textBox3.Text)
                {
                    pictureBox1.Controls.Remove(control);
                }
            }
            pictureBox1.Invalidate();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            pictureBox1.Controls.Clear();
            pictureBox1.Invalidate();

            DataTable dt = Global.Dt;
            dt.Clear();
            while (dt.Columns.Count > 0)
            {
                dt.Columns.RemoveAt(0);
            }

            dataGridView1.DataSource = null;
            dataGridView2.DataSource = null;

            Global.Sodinh = 0;
            Global.Dt = new DataTable();
        }

        private void btnxoanut_Click(object sender, EventArgs e)
        {
            var lastLabel = pictureBox1.Controls.OfType<Label>()
                               .Where(l => l.ForeColor == Color.Black)
                               .OrderByDescending(l => l.Text)
                               .FirstOrDefault();
            if (lastLabel != null)
            {
                var lastButton = pictureBox1.Controls.OfType<Button>()
                                  .OrderByDescending(b => b.Location.Y)
                                  .FirstOrDefault();

                if (lastButton != null)
                {
                    pictureBox1.Controls.Remove(lastLabel);
                    pictureBox1.Controls.Remove(lastButton);
                }

                // Cập nhật DataTable
                DataTable dt = Global.Dt;
                if (dt.Columns.Count > 1)
                {
                    dt.Columns.RemoveAt(dt.Columns.Count - 1);
                    dt.Rows.RemoveAt(dt.Rows.Count - 1);
                }

                Global.Sodinh--;
                Global.Dem--;
                Global.Dt = dt;
                dataGridView1.DataSource = dt;
            }
        }
    }
}
