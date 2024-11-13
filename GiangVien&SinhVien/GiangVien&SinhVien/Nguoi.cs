using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace GiangVien_SinhVien
{
    public abstract class Nguoi : IThongTin
    {
        public string MaSo { get; set; }
        public string HoTen { get; set; }
        public DateTime NgaySinh { get; set; }

        public virtual void NhapThongTin()
        {
            while (true) // Kiem tra xem nguoi dung co nhap dung hay khong
            {
                try 
                {
                    MaSo = NhapChuoi("Nhap ma so: ");
                    HoTen = NhapHoTen("Nhap ho ten: ");
                    NgaySinh = NhapNgay("Nhap ngay thang nam sinh (dd/MM/yyyy): ");
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Loi: {ex.Message}. Vui long nhap lai!");
                }
            }
        }

        // Xuat Thong tin da nhap
        public virtual void XuatThongTin()
        {
            Console.WriteLine($"Ma so: {MaSo}");
            Console.WriteLine($"Ho ten: {HoTen}");
            Console.WriteLine($"Ngay sinh: {NgaySinh:dd/MM/yyyy}");
        }

        // Neu bo trong du lieu thi se bao loi
        public string NhapChuoi(string thongBao)
        {
            Console.Write(thongBao);
            string dauVao = Console.ReadLine()?.Trim();
            if (string.IsNullOrWhiteSpace(dauVao))
            {
                throw new Exception("Du lieu khong duoc de trong!");
            }
            return dauVao;
        }

        // Ho ten khong duoc bo trong va khong chua ky tu so va ky tu dac biet
        protected string NhapHoTen(string thongBao)
        {
            Console.Write(thongBao);
            string input = Console.ReadLine()?.Trim();
            if (string.IsNullOrWhiteSpace(input))
            {
                throw new Exception("Ho ten khong duoc de trong!");
            }

            foreach (char c in input)
            {
                if (!char.IsLetter(c) && !char.IsWhiteSpace(c))
                {
                    throw new Exception("Ho ten chi duoc chua chu cai khong dau va khoang trang, khong duoc chua so hoac ky tu dac biet!");
                }
            }

            return input;
        }

        // Phai nhap dung theo cau truc dd/MM/yyyy
        public DateTime NhapNgay(string thongBao)
        {
            Console.Write(thongBao);
            string dauVao = Console.ReadLine()?.Trim();
            if (!DateTime.TryParseExact(dauVao, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime ngay))
            {
                throw new Exception("Dinh dang ngay thang nam khong hop le (dd/MM/yyyy)!");
            }
            return ngay;
        }
    }
}
