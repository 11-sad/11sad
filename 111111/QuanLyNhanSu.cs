using System;
using System.Xml;

class Program
{
    static void DisplayEmployees(XmlDocument doc)
    {
        Console.WriteLine("\nDanh sách nhân viên:");
        XmlNodeList employees = doc.GetElementsByTagName("NhanVien");
        foreach (XmlNode employee in employees)
        {
            string id = employee.Attributes["ID"].Value;
            string name = employee["TenNhanVien"].InnerText.Trim();
            string cmnd = employee["CMND"].InnerText.Trim();
            string gender = employee["GioiTinh"].InnerText.Trim();
            string year = employee["NamSinh"].InnerText.Trim();
            Console.WriteLine($"ID: {id}, Tên: {name}, CMND: {cmnd}, Giới tính: {gender}, Năm sinh: {year}");
        }
    }

    static void AddEmployee(XmlDocument doc)
    {
        XmlNode danhSachNhanVien = doc.SelectSingleNode("//DanhSachNhanVien");

        Console.Write("Nhập mã nhân viên (định dạng NVxx): ");
        string id = Console.ReadLine();

        Console.Write("Nhập tên nhân viên: ");
        string name = Console.ReadLine();

        Console.Write("Nhập CMND (9 chữ số): ");
        string cmnd = Console.ReadLine();

        Console.Write("Nhập giới tính (Nam/Nữ): ");
        string gender = Console.ReadLine();

        Console.Write("Nhập năm sinh (<= 1985): ");
        string year = Console.ReadLine();

        XmlElement newEmployee = doc.CreateElement("NhanVien");
        newEmployee.SetAttribute("ID", id);

        XmlElement ten = doc.CreateElement("TenNhanVien");
        ten.InnerText = name;
        newEmployee.AppendChild(ten);

        XmlElement cmndElem = doc.CreateElement("CMND");
        cmndElem.InnerText = cmnd;
        newEmployee.AppendChild(cmndElem);

        XmlElement gioiTinh = doc.CreateElement("GioiTinh");
        gioiTinh.InnerText = gender;
        newEmployee.AppendChild(gioiTinh);

        XmlElement namSinh = doc.CreateElement("NamSinh");
        namSinh.InnerText = year;
        newEmployee.AppendChild(namSinh);

        danhSachNhanVien.AppendChild(newEmployee);
        doc.Save(filePath);
        Console.WriteLine("Thêm nhân viên thành công!");
    }

    static void UpdateEmployee(XmlDocument doc)
    {
        Console.Write("Nhập mã nhân viên cần cập nhật: ");
        string id = Console.ReadLine();

        XmlNode employee = doc.SelectSingleNode($"//NhanVien[@ID='{id}']");
        if (employee != null)
        {
            Console.Write("Nhập tên mới: ");
            employee["TenNhanVien"].InnerText = Console.ReadLine();

            Console.Write("Nhập CMND mới: ");
            employee["CMND"].InnerText = Console.ReadLine();

            Console.Write("Nhập giới tính mới (Nam/Nữ): ");
            employee["GioiTinh"].InnerText = Console.ReadLine();

            Console.Write("Nhập năm sinh mới: ");
            employee["NamSinh"].InnerText = Console.ReadLine();
            doc.Save(filePath);
            Console.WriteLine("Cập nhật thông tin thành công!");
        }
        else
        {
            Console.WriteLine("Không tìm thấy mã nhân viên.");
        }
    }

    static void DeleteEmployee(XmlDocument doc)
    {
        Console.Write("Nhập mã nhân viên cần xóa: ");
        string id = Console.ReadLine();

        XmlNode employee = doc.SelectSingleNode($"//NhanVien[@ID='{id}']");
        if (employee != null)
        {
            employee.ParentNode.RemoveChild(employee);
            doc.Save(filePath);
            Console.WriteLine("Xóa nhân viên thành công!");
        }
        else
        {
            Console.WriteLine("Không tìm thấy mã nhân viên.");
        }
    }

    static void Main(string[] args)
    {
        XmlDocument doc = new XmlDocument();
        try
        {
            string XmlString = @"D:\111\QuanLyNhanSu.xml";
            xmlDoc.Load(XmlString);
            XmlNode danhSachNhanVien = xmlDoc.SelectSingleNode("//DanhSachNhanVien");

        }
        catch (Exception e)
        {
            Console.WriteLine("Không thể đọc tập tin XML. Vui lòng kiểm tra đường dẫn hoặc nội dung tập tin.");
            return;
        }

        while (true)
        {
            Console.WriteLine("\nChọn chức năng:");
            Console.WriteLine("1. Hiển thị danh sách nhân viên");
            Console.WriteLine("2. Thêm nhân viên mới");
            Console.WriteLine("3. Cập nhật thông tin nhân viên");
            Console.WriteLine("4. Xóa nhân viên");
            Console.WriteLine("5. Thoát chương trình");
            Console.Write("Lựa chọn của bạn: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    DisplayEmployees(doc);
                    break;
                case "2":
                    AddEmployee(doc);
                    break;
                case "3":
                    UpdateEmployee(doc);
                    break;
                case "4":
                    DeleteEmployee(doc);
                    break;
                case "5":
                    Console.WriteLine("Thoát chương trình.");
                    return;
                default:
                    Console.WriteLine("Lựa chọn không hợp lệ. Vui lòng chọn lại.");
                    break;
            }
        }
    }
}