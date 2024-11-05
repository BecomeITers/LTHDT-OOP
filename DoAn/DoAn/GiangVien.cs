using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn
{
    internal class GiangVien : Nguoi, ILichHoc
    {
        public string BoMon { get; set; }
        public List<string> DanhSachMonHocGiangDay { get; set; } = new List<string>();
        public ThoiKhoaBieu LichDayGiangVien { get; set; } = new ThoiKhoaBieu();

        public GiangVien(string hoTen, string maSo, string email, DateTime ngaySinh, string boMon)
            : base(hoTen, maSo, email, ngaySinh)
        {
            BoMon = boMon;
        }

        public void ThemMonHoc(string monHoc, string thoiGian)
        {
            LichDayGiangVien.ThemMonHoc(monHoc, thoiGian);
            Console.WriteLine($"Giang vien {HoTen} da them mon giang day: {monHoc} vao {thoiGian}");
        }

        public void XemThoiKhoaBieu()
        {
            LichDayGiangVien.XemThoiKhoaBieu();
        }

        public override void LayThongTin()
        {
            Console.WriteLine($"Giang vien: {HoTen}, Ma so: {MaSo}, Email: {Email}, Ngay sinh: {NgaySinh.ToShortDateString()}, Bo mon: {BoMon}");
        }
    }
}
