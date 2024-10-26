using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TKB
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.SetBufferSize(1000, 140);
            Console.WriteLine($"Tuan hoc: 1\nNgay bat dau - ket thuc: 1/1/1 - 2/2/2");

            // In so tiet va gio
            Console.SetCursorPosition(0, 3);
            /* tiet 1: 7:00 -> 7:50
             * tiet 2: 7:50 -> 8:40 (nghi 10 phut)
             * tiet 3: 8:50 -> 9:40
             * tiet 4: 9:40 -> 10:30 (nghi 10 phut)
             * tiet 5: 10:40 -> 11:30
             * tiet 6: 11:30 -> 12:20 (nghi 10 phut)
             * tiet 7: 12:30 -> 13:20
             * tiet 8: 13:20 -> 14:10 
             * tiet 9: 14:10 -> 15:00 (nghi 10 phut)
             * tiet 10: 15:10 -> 16:00 (nghi 10 phut)
             * tiet 11: 16:10 -> 17:00
             */
            string[] DanhSachGio = new string[] {"7:00 -> 7:50", "7:50 -> 8:40", "8:50 -> 9:40",
                                                 "9:40 -> 10:30", "10:40 -> 11:30", "11:30 -> 12:20",
                                                 "12:30 -> 13:20", "13:20 -> 14:10", "14:10 -> 15:00",
                                                 "15:10 -> 16:00", "16:10 -> 17:00"};
            int[] ThuTuHang = new int[11];
            for (int i = 1; i <= 11; i++)
            {
                ThuTuHang[i - 1] = Console.CursorTop;
                Console.WriteLine($"Tiet {i}:\n({DanhSachGio[i - 1]})\n");
            }

            // In lich hoc theo tung ngay trong tuan, bat dau tu thu hai
            for (int i = 1; i <= 7; i++)
            {
                // cot tiet va gio keo dai 16 o ngang tren console -> bat dau in TKB tu o ngang 20
                Console.SetCursorPosition(i * 20, 2);
                Console.WriteLine($"Thu {i}");
            }

            Console.ReadKey();
        }
    }
}
