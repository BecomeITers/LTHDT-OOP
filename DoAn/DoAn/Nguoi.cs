using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn
{
    internal abstract class Nguoi : IThongTin
    {
        public string HoTen { get; set; }
        public string MaSo { get; set; }
        public string Email { get; set; }
        public DateTime NgaySinh { get; set; }

        public Nguoi(string hoTen, string maSo, string email, DateTime ngaySinh)
        {
            HoTen = hoTen;
            MaSo = maSo;
            Email = email;
            NgaySinh = ngaySinh;
        }

        public abstract void LayThongTin();
    }

    internal class NguoiNhap : Nguoi
    {
        public NguoiNhap(string hoTen, string maSo, string email, DateTime ngaySinh)
            : base(hoTen, maSo, email, ngaySinh)
        {
        }

        public override void LayThongTin()
        {
            Console.WriteLine("Thông tin người:");
            Console.WriteLine($"Họ Tên: {HoTen}");
            Console.WriteLine($"Mã Số: {MaSo}");
            Console.WriteLine($"Email: {Email}");
            Console.WriteLine($"Ngày Sinh: {NgaySinh.ToShortDateString()}");
        }

        // Hàm tĩnh để nhập thông tin từ người dùng
        public static NguoiNhap NhapThongTin()
        {
            Console.Write("Nhập Họ Tên: ");
            string hoTen = Console.ReadLine();

            Console.Write("Nhập Mã Số: ");
            string maSo = Console.ReadLine();

            Console.Write("Nhập Email: ");
            string email = Console.ReadLine();

            Console.Write("Nhập Ngày Sinh (dd/MM/yyyy): ");
            DateTime ngaySinh;
            while (!DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out ngaySinh))
            {
                Console.Write("Ngày sinh không hợp lệ. Vui lòng nhập lại (dd/MM/yyyy): ");
            }

            return new NguoiNhap(hoTen, maSo, email, ngaySinh);
        }
    }
}

//// Gọi hàm nhập thông tin và tạo đối tượng
// NguoiNhap nguoi = NguoiNhap.NhapThongTin();

// // Hiển thị thông tin vừa nhập
// nguoi.LayThongTin();