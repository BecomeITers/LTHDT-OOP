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
        public int NienKhoa { get; set; }

        public override void NhapThongTin()
        {
            base.NhapThongTin();
            while (true)
            {
                try
                {
                    MaLop = NhapChuoi("Nhap ma lop: ");
                    NienKhoa = NhapSoNguyen("Nhap khoa hoc: "); // Phai nhap nien khoa la 1 so nguyen duong
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Loi: {ex.Message}. Vui long nhap lai!");
                }
            }
        }

        public override void XuatThongTin()
        {
            base.XuatThongTin();
            Console.WriteLine($"Ma lop: {MaLop}");
            Console.WriteLine($"Khoa hoc: {NienKhoa}");
        }

        public int NhapSoNguyen(string thongBao)
        {
            Console.Write(thongBao);
            string input = Console.ReadLine()?.Trim();
            if (!int.TryParse(input, out int so) || so <= 0)
            {
                throw new Exception("Nien khoa phai la mot so nguyen duong!");
            }
            return so;
        }
    }
}
