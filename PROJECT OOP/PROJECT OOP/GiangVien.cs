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
                    foreach (char c in BoMon)
                    {
                        if (!char.IsLetter(c) && !char.IsWhiteSpace(c))
                        {
                            throw new Exception("Bo mon chi duoc chua chu cai khong dau va khoang trang, khong duoc chua so hoac ky tu dac biet!");
                        }
                    }

                    file.MoVietString(BoMon);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Loi: {ex.Message}");
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
