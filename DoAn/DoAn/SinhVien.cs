using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn
{
    internal class SinhVien : Nguoi, ILichHoc
    {
        public string LopHoc { get; set; }
        public int KhoaHoc { get; set; }
        public ThoiKhoaBieu ThoiKhoaBieuSinhVien { get; set; } = new ThoiKhoaBieu();

        public SinhVien(string hoTen, string maSo, string email, DateTime ngaySinh, string lopHoc, int khoaHoc)
            : base(hoTen, maSo, email, ngaySinh)
        {
            LopHoc = lopHoc;
            KhoaHoc = khoaHoc;
        }

        public void ThemMonHoc(string monHoc, string thoiGian)
        {
            ThoiKhoaBieuSinhVien.ThemMonHoc(monHoc, thoiGian);
            Console.WriteLine($"Dang ky mon hoc: {monHoc} vao {thoiGian}");
        }

        public void XemThoiKhoaBieu()
        {
            ThoiKhoaBieuSinhVien.XemThoiKhoaBieu();
        }

        public override void LayThongTin()
        {
            Console.WriteLine($"Sinh vien: {HoTen}, Ma so: {MaSo}, Email: {Email}, Ngay sinh: {NgaySinh.ToShortDateString()}, Lop: {LopHoc}, Khoa: {KhoaHoc}");
        }
    }
}

