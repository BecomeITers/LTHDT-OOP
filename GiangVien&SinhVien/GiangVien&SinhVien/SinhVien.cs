using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiangVien_SinhVien
{
    public class SinhVien : Nguoi
    {
        public string MaLop { get; set; }
        public int KhoaHoc { get; set; }

        public override void NhapThongTin()
        {
            base.NhapThongTin();
            Console.Write("Nhap ma lop: ");
            MaLop = Console.ReadLine();
            Console.Write("Nhap khoa hoc: ");
            KhoaHoc = int.Parse(Console.ReadLine());
        }

        public override void XuatThongTin()
        {
            base.XuatThongTin();
            Console.WriteLine($"Ma lop: {MaLop}");
            Console.WriteLine($"Khoa hoc: {KhoaHoc}");
        }
    }
}
