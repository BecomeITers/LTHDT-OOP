using PROJECT_OOP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GiangVien_SinhVien
{
    public class GiangVien : Nguoi, IThongTin
    {
        public string BoMon { get; set; }

        File file = new File();

        public override void NhapThongTin()
        {
            string tile = "Thong tin giang vien: ";
            file.MoVietString(tile);

            base.NhapThongTin();


            while (true)
            {
                try
                {
                    Console.Write("Nhap bo mon: ");
                    BoMon = Console.ReadLine();
                    file.MoVietString(BoMon);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Loi: {ex.Message}");
                    file.XoaPhanTuCuoi();
                    continue;
                }
                break;
            }
        }

        public override void XuatThongTin()
        {
            base.XuatThongTin();
            Console.WriteLine($"Bo mon: {BoMon}");
        }
    }
}
