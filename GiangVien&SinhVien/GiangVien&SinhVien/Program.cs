using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiangVien_SinhVien
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("1. Nhap thong tin giang vien");
                Console.WriteLine("2. Nhap thong tin sinh vien");
                Console.WriteLine("3. Thoat chuong trinh");
                Console.Write("Lua chon (1/2/3): ");
                int choice = int.Parse(Console.ReadLine());
                if (choice == 1)
                {
                    GiangVien gv = new GiangVien();
                    gv.NhapThongTin();
                    Console.WriteLine("\nThong tin giang vien:");
                    gv.XuatThongTin();
                }
                else if (choice == 2)
                {
                    SinhVien sv = new SinhVien();
                    sv.NhapThongTin();
                    Console.WriteLine("\nThong tin sinh vien:");
                    sv.XuatThongTin();
                }
                else if (choice == 3)
                {
                    Console.WriteLine("Chuong trinh ket thuc!");
                    break;
                }
                else
                {
                    Console.WriteLine("Lua chon khong hop le!");
                }
            }
        }
    }
}
