﻿using PROJECT_OOP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiangVien_SinhVien
{
    public class SinhVien : Nguoi, IThongTin
    {
        public string MaLop { get; set; }
        public int KhoaHoc { get; set; }

        TapTin file = new TapTin();

        public override void NhapThongTin()
        {
            string title = "Thong tin sinh vien: ";
            file.MoVietString(title);

            base.NhapThongTin();

            Console.Write("Nhap ma lop: ");
            MaLop = Console.ReadLine();
            file.MoVietString(MaLop);

            while (true)
            {
                try
                {
                    Console.Write("Nhap khoa hoc: ");
                    KhoaHoc = int.Parse(Console.ReadLine());
                    file.MoVietNumber(KhoaHoc);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Loi: {ex.Message}");
                    file.XoaPhanTuCuoi();
                    continue;
                }
                break;
            }

            string space = string.Empty;
            file.MoVietString(space);
        }

        public override void XuatThongTin()
        {
            base.XuatThongTin();
            Console.WriteLine($"Ma lop: {MaLop}");
            Console.WriteLine($"Khoa hoc: {KhoaHoc}");
        }
    }
}
