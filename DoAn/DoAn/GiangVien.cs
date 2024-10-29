using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn
{
    internal class GiangVien : Nguoi
    {
        public string BoMon {  get; set; }
        public List<string> DanhSachMonHocGiangDay { get; set; } = new List<string>();
        public ThoiKhoaBieu LichDayGiangVien { get; set; } = new ThoiKhoaBieu();

        public GiangVien(string hoTen, string maSo, string email, DateTime ngaySinh, string boMon) : base(hoTen, maSo, email, ngaySinh)
        {
            BoMon = boMon;
        }

        public void ThemMonHocGiangDay(string monHoc)
        {
            DanhSachMonHocGiangDay.Add(monHoc);
            Console.WriteLine($"Giang vien {HoTen} da them mon giang day: {monHoc}");
        }

        public void GiangDayMonHoc(string monHoc)
        {
            if (DanhSachMonHocGiangDay.Contains(monHoc))
            {
                Console.WriteLine($"{HoTen} dang giang day mon hoc {monHoc}");
            }
            else
            {
                Console.WriteLine($"{HoTen} khong giang day mon hoc {monHoc}");
            }
        }

        public void XemLichDay()
        {
            Console.WriteLine($"Lich day cua giang vien: {HoTen}");
        }

        public override void LayThongTin()
        {
            Console.WriteLine($"Giang vien: {HoTen}, Ma so: {MaSo}, Email: {Email}, Ngay sinh: {NgaySinh.ToShortDateString()}, Bo mon: {BoMon}");
        }
    }
}
