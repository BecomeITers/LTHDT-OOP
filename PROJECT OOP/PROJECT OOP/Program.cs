using GiangVien_SinhVien;
using PROJECT_OOP;
using ShutdownApp;
using System;
using System.Collections.Generic;
using System.IO;

namespace TKB
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Khởi tạo đối tượng
            ThoiKhoaBieu TKB = new ThoiKhoaBieu();
            QuanLyTKB QLTKB = new QuanLyTKB();
            int BeNgangConsole = Console.LargestWindowWidth - 5;
            int ChieuDocConsole = Console.LargestWindowHeight - 5;
            Console.SetWindowSize(BeNgangConsole, ChieuDocConsole);

            int DoRongO = (BeNgangConsole - 2) / 8;
            TapTin file = new TapTin();
            SinhVien sv = new SinhVien();

            //Nhập thông tin sinh viên
            Console.WriteLine("Nhap thong tin sinh vien: ");
            sv.NhapThongTin();
            file.MoVietString(string.Empty);
            Console.WriteLine("\nThong tin sinh vien: ");
            sv.XuatThongTin();
            Console.WriteLine();

            bool exitMainLoop = false;
            while (!exitMainLoop)
            {
                Console.Clear();
                Console.WriteLine("=== MENU ===");
                Console.WriteLine("1: Quan Ly Thoi Khoa Bieu");
                Console.WriteLine("2: In Thoi Khoa Bieu co san");
                Console.WriteLine("3: Ket thuc chuong trinh");
                Console.WriteLine("==================");

                Console.Write("chon phuong an: ");
                int choose = int.Parse(Console.ReadLine());

                switch (choose)
                {
                    case 1:
                        bool exitSubLoop = false;
                        while (!exitSubLoop)
                        {
                            Console.Clear();
                            Console.WriteLine("=== QUAN LY THOI KHOA BIEU ===");
                            Console.WriteLine("1: Nhap thoi khoa bieu");
                            Console.WriteLine("2: In thoi khoa bieu theo tuan");
                            Console.WriteLine("3: Chinh sua tuan hoc");
                            Console.WriteLine("4: Lam trong thoi khoa bieu");
                            Console.WriteLine("5: Them hoc phan");
                            Console.WriteLine("6: Huy hoc phan");
                            Console.WriteLine("7: Quay lai menu chinh");
                            Console.WriteLine("==============================");

                            Console.Write("chon phuong an: ");
                            int subChoose = int.Parse(Console.ReadLine());

                            switch (subChoose)
                            {
                                case 1:
                                    try
                                    {
                                        TKB.NhapTKB();
                                        Console.WriteLine("Nhap thoi khoa bieu thanh cong!");
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine($"ERROR: {ex.Message}");
                                    }
                                    break;

                                case 2:
                                    try
                                    {
                                        QLTKB.NhanBanTuanHoc(TKB);
                                        int VTChuot1 = QLTKB.InTKBTheoTuan(DoRongO);
                                        Console.SetCursorPosition(0, VTChuot1);
                                        Console.Clear();
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine($"ERROR: {ex.Message}");
                                    }
                                    break;

                                case 3:
                                    try
                                    {
                                        QLTKB.ChinhSuaTuanHoc();
                                        Console.WriteLine("Chinh sua thanh cong!");
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine($"ERROR: {ex.Message}");
                                    }
                                    break;

                                case 4:
                                    QLTKB.LamTrongTKB();
                                    Console.WriteLine("Thoi khoa bieu da duoc lam trong!");
                                    break;

                                case 5:
                                    QLTKB.ThemHocPhan();
                                    Console.WriteLine("Hoc phan da duoc themn!");
                                    break;

                                case 6:
                                    QLTKB.HuyHocPhan();
                                    Console.WriteLine("Hoc phan da huy!");
                                    break;

                                case 7:
                                    exitSubLoop = true;
                                    break;

                                default:
                                    Console.WriteLine("Vui long nhap lai");
                                    break;
                            }

                            if (!exitSubLoop)
                            {
                                Console.WriteLine("\nBan co muon tiep tuc (yes/no) ?");
                                string continueInput = Console.ReadLine().ToLower();
                                if (continueInput == "no") exitSubLoop = true;
                            }
                        }
                        break;

                    case 2:
                        List<HocPhan> DS_HP = new List<HocPhan>();
                        string fileName = "TKB.txt";
                        try
                        {
                            foreach (var line in File.ReadLines(fileName))
                            {
                                var parts = line.Split(';');
                                string tenHocPhan = parts[0];
                                string maHocPhan = parts[1];
                                GiangVien giangVien = new GiangVien(parts[2], parts[3], DateTime.Parse(parts[4]), parts[5], parts[6]);
                                string phongHoc = parts[7];
                                int soTiet = int.Parse(parts[8]);
                                int tietBatDau = int.Parse(parts[9]);
                                int maSoThu = int.Parse(parts[10]);
                                DS_HP.Add(new HocPhan(tenHocPhan, maHocPhan, giangVien, phongHoc, soTiet, tietBatDau, maSoThu));
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("ERROR: " + ex.Message);
                        }

                        ThoiKhoaBieu tkb = new ThoiKhoaBieu();
                        tkb.DanhSachHocPhan = DS_HP;
                        tkb.NgayBatDau = new DateTime(2023, 09, 25);
                        tkb.NgayKetThuc = tkb.NgayBatDau.AddDays(6);
                        tkb.TuanHoc = 1;

                        QuanLyTKB qltkb = new QuanLyTKB();
                        qltkb.NhanBanTuanHoc(tkb);
                        int VTChuot2 = qltkb.InTKBTheoTuan(DoRongO);
                        Console.SetCursorPosition(0, VTChuot2);
                        Console.Clear();
                        break;

                    case 3:
                        KetThuc kt = new KetThuc();
                        kt.TheEnd();
                        break;

                    default:
                        Console.WriteLine("Vui long nhap lai");
                        break;
                }

                if (!exitMainLoop)
                {
                    Console.WriteLine("\nBan co muon tiep tuc chuong trinh chinh (yes/no) ?");
                    string input = Console.ReadLine().ToLower();
                    if (input == "no") exitMainLoop = true;
                }
            }
        }
    }
}
