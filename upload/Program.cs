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


            HocPhan hp1 = new HocPhan("HP 1", "111", "werf rgf ytre wertghre vghj", "A1", 3, 1, 0);
            HocPhan hp2 = new HocPhan("HP 2", "112", "Giang vien B", "B2", 2, 5, 0);
            HocPhan hp3 = new HocPhan("HP bdfhg rfhj rfhg 234 432", "113", "Giang vien C", "A2", 4, 1, 3);
            HocPhan hp4 = new HocPhan("HP 4", "114", "Giang vien D", "C4", 2, 3, 5);
            HocPhan hp5 = new HocPhan("HP 5", "115", "Giang vien E", "A1", 3, 4, 5);
            HocPhan hp6 = new HocPhan();

            hp6.NhapHocPhan();

            List<HocPhan> DS_HP = new List<HocPhan>() {hp1, hp2, hp3, hp4, hp5};

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
