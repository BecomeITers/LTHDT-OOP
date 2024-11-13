using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiangVien_SinhVien
{
    public class GiangVien : Nguoi
    {
        public string BoMon { get; set; }

        public override void NhapThongTin()
        {
            base.NhapThongTin();
            while (true)
            {
                try
                {
                    BoMon = NhapChuoi("Nhap bo mon: ");
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
            Console.WriteLine($"Bo mon: {BoMon}");
        }
    }
}
