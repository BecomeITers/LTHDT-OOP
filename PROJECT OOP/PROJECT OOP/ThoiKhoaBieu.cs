using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TKB
{
    internal class ThoiKhoaBieu
    {
        private DateTime ngayBatDau;
        private DateTime ngayKetThuc;
        private int tuanHoc;            

        List<HocPhan> danhSachHocPhan = new List<HocPhan>();           // class HocPhan can bo sung sau

        //-------------
        // constructors
        //-------------
        public ThoiKhoaBieu()
        {
            ngayBatDau = new DateTime();
            ngayKetThuc = new DateTime();
            tuanHoc = 0;
        }
        public ThoiKhoaBieu(DateTime ngayBatDauInput, DateTime ngayKetThucInput, int tuanHocInput, List<HocPhan> danhSachHocPhanInput)
        {
            ngayBatDau = ngayBatDauInput;
            ngayKetThuc = ngayKetThucInput;
            tuanHoc = tuanHocInput;
            danhSachHocPhan = danhSachHocPhanInput;
        }

        //-----------
        // properties
        //-----------
        public DateTime NgayBatDau
        {
            get { return ngayBatDau; }
            set { ngayBatDau = value; }
        }

        public DateTime NgayKetThuc
        {
            get { return ngayKetThuc; }
            set { ngayKetThuc = value; }
        }
        public int TuanHoc
        {
            get { return tuanHoc; }
            set { tuanHoc = value; }
        }
        public List<HocPhan> DanhSachHocPhan
        {
            get { return danhSachHocPhan; }
            set { danhSachHocPhan = value; }
        }

        //--------
        // methods
        //--------
        public void SaoLuu(ThoiKhoaBieu TKBKhac)
        {
            TKBKhac.NgayBatDau = ngayBatDau;
            TKBKhac.NgayKetThuc = ngayKetThuc;
            TKBKhac.DanhSachHocPhan = new List<HocPhan>(danhSachHocPhan);
            TKBKhac.TuanHoc = tuanHoc;
        }
        private void NhapDanhSachHocPhan()
        {
            // so luong mon hoc can nhap
            int n = 0;      

            Console.Write("\nNhap so luong hoc phan co trong thoi khoa bieu: ");
            try
            {
                n = Convert.ToInt32(Console.ReadLine());
            } catch (Exception)
            {
                Console.Write("!! Nhap lai so luong hoc phan: ");
            }
            
            for (int i = 0; i < n; i++)
            {
                // phuong thuc nhap hoc phan 
                
                // them vao danh sach mon hoc
            }
        }
        public void NhapTKB()
        {
            Console.Write("\nNhap ngay bat dau tuan hoc (dd/mm/yyyy): ");
            ngayBatDau = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);

            while (ngayBatDau.DayOfWeek != DayOfWeek.Monday)
            {
                string Thu = "";
                if (ngayBatDau.DayOfWeek == DayOfWeek.Tuesday) Thu = "Thu ba";
                else if (ngayBatDau.DayOfWeek == DayOfWeek.Wednesday) Thu = "Thu tu";
                else if (ngayBatDau.DayOfWeek == DayOfWeek.Thursday) Thu = "Thu nam";
                else if (ngayBatDau.DayOfWeek == DayOfWeek.Friday) Thu = "Thu sau";
                else if (ngayBatDau.DayOfWeek == DayOfWeek.Saturday) Thu = "Thu bay";
                else if (ngayBatDau.DayOfWeek == DayOfWeek.Sunday) Thu = "Chu nhat";

                Console.Write($"!!! Nhap lai ngay bat dau tuan hoc (nen bat dau tu thu hai, ngay vua nhap la {Thu}): ");
                ngayBatDau = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);
            }
            ngayKetThuc = ngayBatDau.AddDays(6);

            // tuan hoc duoc nhap lan dau tien de nhan ban mac dinh la tuan hoc so 1
            tuanHoc = 1;

            NhapDanhSachHocPhan();
        }
        public void ChinhSuaTKB()
        {
            while (true)
            {
                // in danh sach mon hoc hien tai cung thong tin mon hoc co trong TKB
                Console.Write("\nCac mon hoc hien co trong tuan hoc: ");
                int dem = 1;
                foreach (HocPhan HPDuyet in DanhSachHocPhan)
                {
                    Console.WriteLine($"\n{dem}> {HPDuyet.InThongTinDS()}.");
                    dem++;
                }

                Console.WriteLine("\nt> Thoat chinh sua.");

                // lua chon cua nguoi dung
                Console.Write("\n>>> Ban can chinh sua mon hoc nao: ");
                string LuaChon = Console.ReadLine();

                // phan loai
                try
                {
                    Convert.ToInt32(LuaChon);
                }
                catch (Exception)
                {
                    return;
                }

                // neu la mon hoc can chinh sua
                int i = Convert.ToInt32(LuaChon);

                DanhSachHocPhan[i - 1].ChinhSuaHocPhan();

                // tiep tuc hoac dung chinh sua
                Console.Write("\n>>> Ban co can chinh sua tiep? (nhap 1 neu co, nhap cac ki tu con lai neu khong): ");
                LuaChon = Console.ReadLine();

                // dung vong lap while neu LuaChon khac "1"
                if (LuaChon != "1") break;
                // if (string.Compare(LuaChon, "1", true) != 0) break;
            }
        }
        public string TraVeThu(int x)
        {
            if (x == 1) return "thu hai";
            else if (x == 2) return "thu ba";
            else if (x == 3) return "thu tu";
            else if (x == 4) return "thu nam";
            else if (x == 5) return "thu sau";
            else if (x == 6) return "thu bay";
            else return "chu nhat";
        }
        public int InTKB(int DoRongOInput, int HangInHPInput)
        {
            Console.SetCursorPosition(0, HangInHPInput);
            // In 2 dong dau cua TKB
            Console.WriteLine($"Tuan hoc: {tuanHoc}\nNgay bat dau - ket thuc: {ngayBatDau.ToString("dd/MM/yyyy")} - {ngayKetThuc.ToString("dd/MM/yyyy")}");

            // do rong o la be ngang cua o, do rong nua o la 1/2 be ngang cua o (lam tron xuong)
            // so 7 la do dai lay chung cho cac chuoi in thu: "thu hai"
            int DoRongO = DoRongOInput;
            int DoRongNuaO = (DoRongO - 7) / 2;

            // in ki tu "|" dau tien
            Console.SetCursorPosition(DoRongO, HangInHPInput + 3);
            Console.Write("|");

            // in thu ngay trong tuan kem cac ki tu "|" ngan cach
            //Console.SetCursorPosition(DoRongO + DoRongNuaO, 3); // dat con tro chuot console de in thu hai
            for (int i = 1; i <= 7; i++)
            {
                // dat con tro chuot console de in cac thu ngay
                Console.SetCursorPosition(i * DoRongO + DoRongNuaO, HangInHPInput + 3);
                Console.Write($"{this.TraVeThu(i)}");

                // in ki tu "|" ngan cach
                Console.SetCursorPosition((i + 1) * DoRongO, HangInHPInput + 3);
                Console.Write("|");
            }
            // in hang "-", so 8 la 7 cot thu ngay + cot dau tien, hien tai la hang so 4
            Console.WriteLine($"\n{new string('-', DoRongO * 8)}");

            // In lich hoc theo tung tiet trong ngay, bat dau tu tiet 1
            List<HocPhan> DanhSachHPTam = new List<HocPhan>(danhSachHocPhan);

            int HangInHP = HangInHPInput + 5;
            int CotInHP = 0;
            int ChieuCaoMax = 0;

            while (true)
            {
                // dieu kien dung vong lap while: danh sach hp tam bi rong
                if (DanhSachHPTam.Count == 0) break;

                // moi vong while in 1 hang khac nhau -> reset chieu cao o max moi vong while
                ChieuCaoMax = 0;

                // bien luu phong hoc o hang hien tai, dung cho dieu kien if va in cot doc
                // * moi hang 1 phong hoc, moi hang in cac lop hoc phan cung phong hoc
                string PhongHocHT = DanhSachHPTam[0].PhongHoc;

                // dat con tro chuot console o dau hang de in phong hoc (in cot doc)
                Console.SetCursorPosition(0, HangInHP);
                Console.Write($"Phong: {PhongHocHT}");

                // in cac lop hoc phan chung 1 hang (cung 1 phong hoc)
                foreach (HocPhan HP in DanhSachHPTam)
                {
                    // loc cac hoc phan co phong hoc trung voi phong hoc o hang hien tai
                    if (HP.PhongHoc == PhongHocHT)
                    {
                        // cap nhat cot de in hoc phan tuong ung voi thu ngay cua hoc phan do
                        CotInHP = (HP.MaSoThu + 1) * DoRongO + 1;
                        int ChieuCaoO = HP.InThongTin(CotInHP, HangInHP, DoRongO - 1);

                        // neu tong so hang can thiet nhieu hon chieu cao o max thi cap nhat chieu cao o max
                        if (ChieuCaoO >= ChieuCaoMax) ChieuCaoMax = ChieuCaoO;
                    }
                }

                // cap nhat vi tri hang in hoc phan tiep theo
                HangInHP += ChieuCaoMax + 1;

                // di chuyen len 1 hang de in hang "-"
                Console.SetCursorPosition(0, HangInHP - 1);
                Console.WriteLine($"{new string('-', DoRongO * 8)}");

                // xoa cac hoc phan co cung phong hoc hien tai trong danh sach hp tam
                DanhSachHPTam.RemoveAll((HP) => HP.PhongHoc == PhongHocHT);
            }

            // in ki tu "|" ngan cach cac o cot thu ngay 
            for (int i = 1; i <= 8; i++)
            {
                for (int j = HangInHPInput + 4; j <= HangInHP - 1; j++)
                {
                    Console.SetCursorPosition(i * DoRongO, j);
                    Console.Write("|");
                }
            }

            // tra ve vi tri hang o cuoi thoi khoa bieu
            return HangInHP;
        }
        public int SoSanh(HocPhan HP1, HocPhan HP2)
        {
            if (HP1.TietBatDau > HP2.TietBatDau) return 1;
            return 0;
        }
        public void KiemTraTrung()
        {
            // danh sach hoc phan tam thoi dung de luu cac hoc phan trong cung ngay
            List<HocPhan> DanhSachHPTam = new List<HocPhan>();
            int DuyetThu = 0;
            int kt = 0;

            while (true)
            {
                // dieu kien dung vong lap while
                if (DuyetThu > 6) break;

                foreach (HocPhan HP in danhSachHocPhan)
                {
                    if (HP.MaSoThu == DuyetThu) DanhSachHPTam.Add(HP);
                }

                // sap xep cac hoc phan tang dan theo tiet bat dau
                DanhSachHPTam.Sort((hp1, hp2) => SoSanh(hp1, hp2));

                for (int i = 0; i < DanhSachHPTam.Count - 1; i++)
                {
                    for (int j = i + 1; j < DanhSachHPTam.Count; j++)
                    {
                        if (DanhSachHPTam[i].TietBatDau + DanhSachHPTam[i].SoTiet - 1 >= DanhSachHPTam[j].TietBatDau)
                        {
                            Console.WriteLine("\nHoc phan bi trung:");
                            Console.WriteLine($"!! {DanhSachHPTam[i].InThongTinDS()}");
                            Console.WriteLine($"!! {DanhSachHPTam[j].InThongTinDS()}");
                            kt = 1;
                        }
                    }
                }

                DuyetThu++;
                DanhSachHPTam.Clear();
            }

            if (kt == 0) Console.WriteLine("\n>>> Khong co hoc phan nao bi trung");
        }
    }
}
