using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace QuanLyNhanSu1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"D:\SV.xml"; // Đường dẫn tới file XML
            XmlDocument doc = new XmlDocument();

            try
            {
                // Tải file XML
                Console.WriteLine("Đang tải file XML...");
                doc.Load(filePath);
                Console.WriteLine("Tải file XML thành công!");

                // Lấy danh sách các nhân viên
                XmlNodeList employees = doc.GetElementsByTagName("NhanVien");
                Console.WriteLine("\nDanh sách nhân viên:");

                // Lặp qua từng nhân viên và in thông tin ra màn hình
                foreach (XmlNode employee in employees)
                {
                    string id = employee.Attributes["ID"].Value;
                    string name = employee["TenNhanVien"].InnerText;
                    string cmnd = employee["CMND"].InnerText;
                    string gender = employee["GioiTinh"].InnerText;
                    string year = employee["NamSinh"].InnerText;

                    Console.WriteLine($"ID: {id}, Tên: {name}, CMND: {cmnd}, Giới tính: {gender}, Năm sinh: {year}");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Có lỗi xảy ra khi đọc file XML: " + e.Message);
            }

            // Chờ người dùng nhấn phím để thoát
            Console.WriteLine("\nNhấn phím bất kỳ để thoát...");
            Console.ReadKey();
        }
    }
}
