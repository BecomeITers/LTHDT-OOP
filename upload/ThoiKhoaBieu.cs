using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace TKB
{
    internal class ThoiKhoaBieu
    {
        private DateTime ngayBatDau;
        private DateTime ngayKetThuc;
        private int tuanHoc;            // xem xet them truong so tuan hoc (vi du: tuan hoc so 1, so 2, ...)

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
        public void NhapDanhSachHocPhan()
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
        public void NhapTKBtuan1()
        {
            Console.Write("Nhap ngay bat dau tuan hoc (dd/mm/yyyy): ");
            ngayBatDau = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);

            while (ngayBatDau.DayOfWeek != DayOfWeek.Monday)
            {
                Console.Write($"Nhap lai ngay bat dau tuan hoc (nen bat dau tu thu hai, ngay vua nhap la {ngayBatDau.DayOfWeek}): ");
                ngayBatDau = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);
            }
            /*
            Console.Write("Nhap ngay ket thuc tuan hoc (dd/mm/yyyy): ");
            ngayKetThuc = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);
            */
            ngayKetThuc = ngayBatDau.AddDays(6);

            tuanHoc = 1;

            NhapDanhSachHocPhan();
        }
        public void ChinhSuaTKB()
        {

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
        public int InTKB(int DoRongOInput)
        {
            // In 2 dong dau cua TKB
            Console.WriteLine($"Tuan hoc: 1\nNgay bat dau - ket thuc: {ngayBatDau.ToString("dd/MM/yyyy")} - {ngayKetThuc.ToString("dd/MM/yyyy")}");

            // do rong o la be ngang cua o, do rong nua o la 1/2 be ngang cua o (lam tron xuong)
            // so 7 la do dai lay chung cho cac chuoi in thu: "thu hai"
            int DoRongO = DoRongOInput;
            int DoRongNuaO = (DoRongO - 7) / 2;

            // in ki tu "|" dau tien
            Console.SetCursorPosition(DoRongO, 3);
            Console.Write("|");

            // in thu ngay trong tuan kem cac ki tu "|" ngan cach
            //Console.SetCursorPosition(DoRongO + DoRongNuaO, 3); // dat con tro chuot console de in thu hai
            for (int i = 1; i <= 7; i++)
            {
                // dat con tr chuot console de in cac thu ngay
                Console.SetCursorPosition(i * DoRongO + DoRongNuaO, 3);
                Console.Write($"{this.TraVeThu(i)}");

                // in ki tu "|" ngan cach
                Console.SetCursorPosition((i + 1) * DoRongO, 3);
                Console.Write("|");
            }
            // in hang "-", so 8 la 7 cot thu ngay + cot dau tien, hien tai la hang so 4
            Console.WriteLine($"\n{new string('-', DoRongO * 8)}");

            // In lich hoc theo tung tiet trong ngay, bat dau tu tiet 1
            List<HocPhan> DanhSachHPTam = danhSachHocPhan;

            int HangInHP = 5;
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
                for (int j = 5; j <= HangInHP - 1; j++)
                {
                    Console.SetCursorPosition(i * DoRongO, j);
                    Console.Write("|");
                }
            }

            // tra ve vi tri hang o cuoi thoi khoa bieu
            return HangInHP;
        }
    }
}