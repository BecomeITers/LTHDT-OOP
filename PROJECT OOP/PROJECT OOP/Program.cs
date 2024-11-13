using GiangVien_SinhVien;
using PROJECT_OOP;
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
            Console.SetBufferSize(200, 140);
            Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
            //Console.SetWindowSize(200, Console.LargestWindowHeight);
            File file = new File();
            SinhVien sv = new SinhVien();
            List<HocPhan> DS_HP = new List<HocPhan>();

            Console.WriteLine("Nhap thong tin sinh vien: ");
            sv.NhapThongTin();

            Console.WriteLine();
            Console.Write("Nhap so luong hoc phan: ");
            int num = int.Parse(Console.ReadLine());

            for(int i = 0; i < num; i++)
            {
                HocPhan hp = new HocPhan();
                Console.WriteLine($"Nhap hoc phan thu {i + 1}: ");
                string title = $"Du lieu hoc phan thu {i + 1}: ";
                file.MoVietString(title);
                hp.NhapHocPhan();
                DS_HP.Add(hp);
            }

            Console.WriteLine();
            Console.WriteLine("Thong tin sinh vien: ");
            sv.XuatThongTin();
            Console.WriteLine();

            ThoiKhoaBieu TKB = new ThoiKhoaBieu();

            TKB.DanhSachHocPhan = DS_HP;
            TKB.NgayBatDau = new DateTime(2023, 09, 25);
            TKB.NgayKetThuc = TKB.NgayBatDau.AddDays(6);
            TKB.TuanHoc = 1;

            QuanLyTKB QLTKB = new QuanLyTKB();

            /*
            QLTKB.NhanBanTuanHoc(TKB);

            QLTKB.LamTrongTKB();

            int VTChuot = QLTKB.InTKBTheoTuan(20);
            // TKB.KiemTraTrung();
            Console.SetCursorPosition(0, VTChuot);

            QLTKB.HuyHocPhan();

            QLTKB.ChinhSuaTuanHoc();

            VTChuot = QLTKB.InTKBTheoTuan(20);
            */
            QLTKB.NhanBanTuanHoc(TKB);
            int VTChuot = QLTKB.InTKBTheoTuan(20);
            Console.SetCursorPosition(0, VTChuot);

            QLTKB.ChinhSuaTuanHoc();

            VTChuot = QLTKB.InTKBTheoTuan(20);
            // TKB.KiemTraTrung();
            Console.SetCursorPosition(0, VTChuot);

            Console.ReadKey();
        }
    }
}
