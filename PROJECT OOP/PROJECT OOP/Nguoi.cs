using PROJECT_OOP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiangVien_SinhVien
{ 
    public abstract class Nguoi : IThongTin
    {
        public string MaSo { get; set; }
        public string HoTen { get; set; }
        public DateTime NgaySinh { get; set; }
        public string GioiTinh { get; set; }

        File file = new File();

        public virtual void NhapThongTin()
        {
            Console.Write("Nhap ma so: ");
            MaSo = Console.ReadLine();
            file.MoVietString(MaSo);

            while (true)
            {
                try
                {
                    Console.Write("Nhap ho ten: ");
                    HoTen = Console.ReadLine();
                    foreach (char c in HoTen)
                    {
                        if (!char.IsLetter(c) && !char.IsWhiteSpace(c))
                        {
                            throw new Exception("Ho ten chi duoc chua chu cai khong dau va khoang trang, khong duoc chua so hoac ky tu dac biet!");
                        }
                    }
                    file.MoVietString(HoTen);
                }
                catch(Exception ex)
                {
                    Console.WriteLine($"Loi: {ex.Message}");
                    continue;
                }
                break;
            }

            while (true)
            {
                try
                {
                    Console.Write("Nhap ngay thang nam sinh (dd/MM/yyyy): ");
                    NgaySinh = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);
                    file.MoVietDateTime(NgaySinh);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Loi: {ex.Message}. Vui long nhap lai!");
                    continue;
                }
                break;
            }

            while (true)
            {
                try
                {
                    Console.Write("Nhap gioi tinh: ");
                    GioiTinh = Console.ReadLine();
                    foreach (char c in GioiTinh)
                    {
                        if (!char.IsLetter(c) && !char.IsWhiteSpace(c))
                        {
                            throw new Exception("Nam/Nu/Khac");
                        }
                    }

                    file.MoVietString(GioiTinh);
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

        public virtual void XuatThongTin()
        {
            Console.WriteLine($"Ma so: {MaSo}");
            Console.WriteLine($"Ho ten: {HoTen}");
            Console.WriteLine($"Ngay sinh: {NgaySinh:dd/MM/yyyy}");
            Console.WriteLine($"Gioi tinh: {GioiTinh}");
        }
    }
}