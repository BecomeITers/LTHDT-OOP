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
            int BeNgangConsole = Console.LargestWindowWidth - 5;
            int ChieuDocConsole = Console.LargestWindowHeight - 5;
            Console.SetWindowSize(BeNgangConsole, ChieuDocConsole);

            int DoRongO = (BeNgangConsole - 2) / 8;
            TapTin file = new TapTin();
            SinhVien sv = new SinhVien();
            List<HocPhan> DS_HP = new List<HocPhan>();

            Console.WriteLine("Nhap thong tin sinh vien: ");
            sv.NhapThongTin();
            Console.WriteLine();
            Console.WriteLine("Thong tin sinh vien: ");
            sv.XuatThongTin();
            Console.WriteLine();

            ThoiKhoaBieu TKB = new ThoiKhoaBieu();
            TKB.NhapTKB();

            QuanLyTKB QLTKB = new QuanLyTKB();

            QLTKB.NhanBanTuanHoc(TKB);
            int VTChuot = QLTKB.InTKBTheoTuan(DoRongO);
            Console.SetCursorPosition(0, VTChuot);

            QLTKB.ChinhSuaTuanHoc();

            VTChuot = QLTKB.InTKBTheoTuan(DoRongO);
            // TKB.KiemTraTrung();
            Console.SetCursorPosition(0, VTChuot);

            Console.ReadKey();
        }
    }
}
