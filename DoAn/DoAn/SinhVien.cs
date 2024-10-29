using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn
{
    internal class SinhVien : Nguoi
    {
        public string LopHoc { get; set; }
        public int KhoaHoc { get; set; }

        public SinhVien(string HoTen, string MaSo, string Email, DateTime NgaySinh, string lopHoc, int khoaHoc) : base(HoTen, MaSo, Email, NgaySinh)
        {
            LopHoc = lopHoc;
            KhoaHoc = khoaHoc;
        }

        public ThoiKhoaBieu ThoiKhoaBieuSinhVien { get; set; } = new ThoiKhoaBieu();

        public void DangKyMonHoc(string monHoc, string thoiGian)
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
