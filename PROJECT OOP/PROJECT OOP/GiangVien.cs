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
        public string Khoa { get; set; }

        TapTin file = new TapTin();

        public GiangVien() : base()
        {
            Khoa = string.Empty;
        }

        public GiangVien(string maSo, string hoTen, DateTime ngaySinh, string gioiTinh, string khoa) : base(maSo, hoTen, ngaySinh, gioiTinh)
        {
            this.Khoa = khoa;
        }

        public override void NhapThongTin()
        {
            string tile = "Thong tin giang vien: ";
            file.MoVietString(tile);

            base.NhapThongTin();


            while (true)
            {
                try
                {
                    Console.Write("Nhap khoa: ");
                    Khoa = Console.ReadLine();
                    foreach (char c in Khoa)
                    {
                        if (!char.IsLetter(c) && !char.IsWhiteSpace(c))
                        {
                            throw new Exception("Bo mon chi duoc chua chu cai khong dau va khoang trang, khong duoc chua so hoac ky tu dac biet!");
                        }
                    }

                    file.MoVietString(Khoa);
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
            Console.WriteLine($"Khoa: {Khoa}");
        }
    }
}
