using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace BaoCao
{
    public partial class Prim : Form
    {
        public Prim()
        {
            InitializeComponent();
        }
        Graphics g;
        Pen p;
        Bitmap bmp;
        List<Lines> lines = new List<Lines>();
        static class Global
        {
            private static string _globalVar = "";
            public static string GlobalVar
            {
                get { return _globalVar; }
                set { _globalVar = value; }
            }
            public static DataTable Dt { get => dt; set => dt = value; }
            public static int Sodinh { get => sodinh; set => sodinh = value; }
            private static DataTable dt = new DataTable();
            private static int sodinh = 0;
        }
        class Lines
        {
            Point x, y;
            String name;
            public Lines()
            {
                this.x = new Point(0, 0);
                this.y = new Point(0, 0);
                this.Name = "0";
            }
            public Lines(Point x, Point y, string _name)
            {
                this.x = x;
                this.y = y;
                this.Name = _name;
            }
            public Point X { get => x; set => x = value; }
            public Point Y { get => y; set => y = value; }
            public string Name { get => name; set => name = value; }
        }
        private void Prim_Load(object sender, EventArgs e)
        {
            bmp = new Bitmap(Width, Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            pictureBox1.BackgroundImage = bmp;
            g = Graphics.FromImage(pictureBox1.BackgroundImage);
            g.Clear(Color.White);
        }
        private int MinKey(int[] key, bool[] mstSet, int V)
        {
            int min = int.MaxValue;
            int minIndex = -1;

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
        private void UpdateDataGridView2(int[] parent, int[,] graph, int V)
        {
            // Tạo DataTable mới cho DataGridView2
            DataTable dt2 = new DataTable();
            for (int i = 0; i < V; i++)
            {
                dt2.Columns.Add(i.ToString(), typeof(string));
            }
            for (int i = 0; i < V; i++)
            {
                DataRow row = dt2.NewRow();
                for (int j = 0; j < V; j++)
                {
                    row[j] = "-"; // Mặc định là "-"
                }
                dt2.Rows.Add(row);
            }
            // Cập nhật các trọng số của cây khung nhỏ nhất
            for (int i = 1; i < V; i++) // Bắt đầu từ 1 vì parent[0] = -1 (gốc)
            {
                int u = parent[i];
                int v = i;
                // Chỉ cập nhật nếu các chỉ số nằm trong phạm vi hợp lệ
                if (u < V && v < V)
                {
                    dt2.Rows[u][v] = graph[u, v].ToString();
                    dt2.Rows[v][u] = graph[u, v].ToString();
                }
            }
            dataGridView2.DataSource = dt2;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string[] mang = textBox1.Text.Split(' ');
            if (mang.Length != 2)
            {
                MessageBox.Show("Vui lòng nhập hai chữ cái để nối các điểm.");
                return;
            }
            int x1 = 0;
            int y1 = 0;
            int x2 = 0;
            int y2 = 0;
            System.Windows.Forms.Label lbl = new System.Windows.Forms.Label();
            lbl.Text = textBox2.Text; // Trọng số
            lbl.AutoSize = true;
            lbl.ForeColor = Color.Red;
            foreach (var item in pictureBox1.Controls.OfType<System.Windows.Forms.Label>().Except(new[] { label3, label2, label1, lbl }.ToList()))
            {
                if (item.Text == mang[0] && item.ForeColor == Color.Black)
                {
                    x1 = item.Location.X;
                    y1 = item.Location.Y + 15;
                }
                if (item.Text == mang[1] && item.ForeColor == Color.Black)
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
            int index1 = mang[0][0] - 'A';
            int index2 = mang[1][0] - 'A';
            dataGridView1.Rows[index1].Cells[index2 + 1].Value = textBox2.Text; // Điền trọng số vào ô tương ứng
            dataGridView1.Rows[index2].Cells[index1 + 1].Value = textBox2.Text; // Điền trọng số vào ô tương ứng
            textBox2.Select();
        }
        private void btnprim_Click(object sender, EventArgs e)
        {
            int V = Global.Sodinh;
            DataTable dt = Global.Dt; int[,] graph = new int[V, V];
            // Đọc ma trận trọng số từ DataTable
            for (int i = 0; i < V; i++)
            {
                for (int j = 0; j < V; j++)
                {
                    graph[i, j] = Convert.ToInt32(dt.Rows[i][j + 1]);
                }
            }
            // Khởi tạo các biến cần thiết cho thuật toán Prim
            int[] parent = new int[V];
            int[] key = new int[V];
            bool[] mstSet = new bool[V];
            // Khởi tạo các giá trị cho thuật toán Prim
            for (int i = 0; i < V; i++)
            {
                key[i] = int.MaxValue;
                mstSet[i] = false;
            }
            key[0] = 0;
            parent[0] = -1;
            // Thực hiện thuật toán Prim
            for (int count = 0; count < V - 1; count++)
            {
                int u = MinKey(key, mstSet, V);
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
            // Cập nhật DataGridView2 với kết quả
            UpdateDataGridView2(parent, graph, V);
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

            int dem = pictureBox1.Controls.OfType<System.Windows.Forms.Label>().Count(item => item.ForeColor == Color.Black);
            var mouseEventArgs = e as MouseEventArgs;
            Button btn = new Button();
            pictureBox1.Controls.Add(btn);
            btn.Location = new Point(mouseEventArgs.X, mouseEventArgs.Y);
            btn.Size = new Size(10, 10);
            btn.BackColor = Color.Black;
            System.Windows.Forms.Label lbl = new System.Windows.Forms.Label();
            lbl.Location = new Point(mouseEventArgs.X, mouseEventArgs.Y - 15);
            char labelChar = (char)('A' + dem);
            btn.Name = "btn" + labelChar;
            btn.AccessibleName = labelChar.ToString();
            lbl.Name = "label" + labelChar;
            lbl.Text = labelChar.ToString();
            lbl.AutoSize = true;
            lbl.ForeColor = Color.Black;
            pictureBox1.Controls.Add(lbl);
            // Cập nhật DataTable và DataGridView
            DataTable dataTable = Global.Dt;
            if (dataTable.Columns.Count == 0)
            {
                dataTable.Columns.Add(new DataColumn(" ")); // Thêm cột đầu tiên
            }
            dataTable.Columns.Add(new DataColumn(labelChar.ToString())); // Thêm cột mới cho chữ cái mớiforeach (DataRow row in dataTable.Rows)
            {
                //row[labelChar.ToString()] = 0; // Khởi tạo giá trị cho cột mới
            }
            DataRow newRow = dataTable.NewRow();
            newRow[0] = labelChar; // Đặt tên hàng là chữ cái
            for (int i = 1; i < dataTable.Columns.Count; i++)
            {
                newRow[i] = 0; // Khởi tạo giá trị cho hàng mới
            }
            dataTable.Rows.Add(newRow);
            Global.Dt = dataTable;
            dataGridView1.DataSource = dataTable;
            Global.Sodinh = dem + 1; // Cập nhật số đỉnh
        }
        private void btnxoacanh_Click(object sender, EventArgs e)
        {
                string[] mang = textBox3.Text.Split(' ');
                if (mang.Length != 2)
                {
                    MessageBox.Show("Vui lòng nhập hai chữ cái của các điểm để xóa cạnh.");
                    return;
                }
                int index1 = mang[0][0] - 'A';
                int index2 = mang[1][0] - 'A';
                if (index1 < 0 || index1 >= Global.Sodinh || index2 < 0 || index2 >= Global.Sodinh)
                {
                    MessageBox.Show("Đỉnh không hợp lệ.");
                    return;
                }
                // Xóa trọng số từ DataTable và DataGridView
                DataTable dt = Global.Dt;
                dt.Rows[index1][index2 + 1] = 0;
                dt.Rows[index2][index1 + 1] = 0;

                dataGridView1.DataSource = dt;

                // Xóa dòng trên pictureBox
                foreach (Control control in pictureBox1.Controls.OfType<Label>().ToList())
                {
                    if (control.Text == textBox3.Text)
                    {
                        pictureBox1.Controls.Remove(control);
                    }
                }
                pictureBox1.Invalidate();
        }
        private void btnxoaALL_Click(object sender, EventArgs e)
        {
            // Xóa tất cả các nhãn và nút trên pictureBox1
            pictureBox1.Controls.Clear();
            pictureBox1.Invalidate();
            // Xóa tất cả các hàng và cột trong DataTable
            DataTable dt = Global.Dt;
            dt.Clear();
            while (dt.Columns.Count > 0)
            {
                dt.Columns.RemoveAt(0);
            }
            // Cập nhật DataGridView
            dataGridView1.DataSource = null;
            dataGridView2.DataSource = null;
            // Đặt lại các biến toàn cục
            Global.Sodinh = 0;
            Global.Dt = new DataTable();
        }
        private void btnxoanut_Click(object sender, EventArgs e)
        {
            // Tìm Label và Button cuối cùng trên PictureBox
            var lastLabel = pictureBox1.Controls.OfType<Label>()
                                  .Where(l => l.ForeColor == Color.Black)
                                  .OrderByDescending(l => l.Location.Y)
                                  .FirstOrDefault();
            var lastButton = pictureBox1.Controls.OfType<Button>()
                                  .Where(b => b.BackColor == Color.Black)
                                  .OrderByDescending(b => b.Location.Y)
                                  .FirstOrDefault();
            if (lastLabel != null && lastButton != null)
            {
                // Xóa Label và Button khỏi PictureBox
                pictureBox1.Controls.Remove(lastLabel);
                pictureBox1.Controls.Remove(lastButton);
                // Cập nhật DataTable
                DataTable dt = Global.Dt;
                int index = lastLabel.Text[0] - 'A';

                if (index >= 0 && index < dt.Rows.Count)
                {
                    dt.Rows.RemoveAt(index); // Xóa hàng

                    if (dt.Columns.Count > 0)
                    {
                        dt.Columns.RemoveAt(index + 1); // Xóa cột
                    }
                }
                // Cập nhật lại DataGridView
                dataGridView1.DataSource = dt;
                Global.Dt = dt;

                // Cập nhật số lượng đỉnh
                Global.Sodinh--;
            }
        }
    }
}