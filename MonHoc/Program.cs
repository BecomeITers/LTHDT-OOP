using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonHoc
{
    public class Program
    {
        static void Main(string[] args)
        {
           
            QuanLyMonHoc qlMonHoc = new QuanLyMonHoc();
            bool running = true;

            while (running)
            {
                Console.WriteLine("\nChon thao tac:");
                Console.WriteLine("1. Them mon hoc");
                Console.WriteLine("2. Sua mon hoc");
                Console.WriteLine("3. Xoa mon hoc");
                Console.WriteLine("4. Hien thi danh sach mon hoc");
                Console.WriteLine("5. Thoat chuong trinh");
                Console.Write("Nhap lua chon: ");
                int choice = int.Parse(Console.ReadLine());
                Console.WriteLine(" ");

                switch (choice)
                {
                    case 1:
                        qlMonHoc.ThemMonHoc();
                        break;
                    case 2:
                        qlMonHoc.SuaMonHoc();
                        break;
                    case 3:
                        qlMonHoc.XoaMonHoc();
                        break;
                    case 4:
                        qlMonHoc.HienThiDanhSachMonHoc();
                        break;
                    case 5:
                        running = false;
                        Console.WriteLine("Da thoat chuong trinh.");
                        break;
                    default:
                        Console.WriteLine("Lua chon khong hop le! Vui long thu lai.");
                        break;
                }
            }
            Console.ReadLine(); // dừng màn hình
        }
    }
}
