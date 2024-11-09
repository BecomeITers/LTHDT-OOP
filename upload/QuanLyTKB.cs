using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TKB
{
    internal class QuanLyTKB
    {
        List<ThoiKhoaBieu> danhSachTKB = new List<ThoiKhoaBieu>();

        //-------------
        // constructors
        //-------------
        public QuanLyTKB()
        {

        }

        public QuanLyTKB(List<ThoiKhoaBieu> danhSachTKBInput)
        {
            danhSachTKB = danhSachTKBInput;
        }

        //---------
        // property
        //---------
        public List<ThoiKhoaBieu> DanhSachTKB
        {
            get { return danhSachTKB; }
            set { danhSachTKB = value; }
        }

        //--------
        // methods
        //--------
        public void NhanBanTuanHoc(ThoiKhoaBieu TKBInput)
        {
            int n;          // bien luu so luong tuan hoc co trong nam hoc
            ThoiKhoaBieu TKBtuan1 = new ThoiKhoaBieu();

            TKBInput.SaoLuu(TKBtuan1);

            Console.Write("Nhap so tuan co trong nam hoc: ");
            while (true)
            {
                try
                {
                    n = Convert.ToInt32(Console.ReadLine());

                    if (n <= 0) throw new Exception();
                }
                catch (Exception)
                {
                    Console.Write("!! Nhap lai so tuan hoc trong nam hoc: ");
                    continue;
                }

                break;
            }

            danhSachTKB.Add(TKBtuan1);

            // so thu tu cua tuan hoc bat dau tu 1 -> ...
            // vi tri tuan hoc trong danh sach bat dau tu 0 -> ...
            // i duyet tuan hoc TRONG DANH SACH 
            ThoiKhoaBieu TKBTruoc = new ThoiKhoaBieu();
            ThoiKhoaBieu TKBTiep = new ThoiKhoaBieu();
            for (int i = 1; i < n; i++)
            {
                danhSachTKB[i - 1].SaoLuu(TKBTruoc);
                TKBTruoc.SaoLuu(TKBTiep);

                // cap nhat ngay bat dau, ket thuc tuan hoc tiep theo
                TKBTiep.NgayBatDau = TKBTruoc.NgayBatDau.AddDays(7);
                TKBTiep.NgayKetThuc = TKBTruoc.NgayKetThuc.AddDays(7);

                // cap nhat so thu tu cua tuan hoc tiep theo
                TKBTiep.TuanHoc = i + 1;

                // them tuan hoc tiep theo vao danh sach
                danhSachTKB.Add(TKBTiep);

                TKBTiep = new ThoiKhoaBieu();
            }
        }

        // lam trong 1 tuan hoc trong danh sach TKB
        public void LamTrongTKB()
        {
            int TuanHoc = 0;

            Console.Write("Nhap so thu tu tuan hoc can lam trong: ");
            while (true)
            {
                try
                {
                   TuanHoc = Convert.ToInt32(Console.ReadLine());

                   if (TuanHoc <= 0) throw new Exception();
                }
                catch (Exception)
                {
                    Console.Write("!! Nhap lai so thu tu tuan hoc can lam trong: ");
                    continue;
                }

                break;
            }

            // lam trong chu khong xoa tuan hoc
            danhSachTKB[TuanHoc - 1].DanhSachHocPhan.Clear();
        }

        // Chinh sua tuan hoc (TKB) trong danh sach TKB
        public void ChinhSuaTuanHoc()
        {
            int TuanHocInput;
            Console.Write("Nhap so thu tu tuan hoc can chinh sua: ");
            while (true)
            {
                try
                {
                    TuanHocInput = Convert.ToInt32(Console.ReadLine());

                    if (TuanHocInput <= 0) throw new Exception();
                }
                catch (Exception)
                {
                    Console.Write("!! Nhap lai so thu tu tuan hoc can chinh sua: ");
                    continue;
                }

                break;
            }

            DanhSachTKB[TuanHocInput - 1].ChinhSuaTKB();
        }
        public int InTKBTheoTuan(int DoRongOInput) 
        {
            // mang luu cac tuan hoc duoi dang chuoi, phuc vu cho phuong thuc Split()
            string[] MangTuanHoc;

            // danh sach cac tuan hoc can in sau cung (chuyen ve so nguyen)
            List<int> DanhSachTuanHoc = new List<int>();

            // chuoi luu ket qua nhap tu ban phim
            string s;

            Console.Write("Nhap cac tuan hoc can in ra man hinh: ");
            while (true)
            {
                s = Console.ReadLine();

                MangTuanHoc = s.Split(' ');

                foreach (string i in MangTuanHoc)
                {
                    // cac truong hop:
                    // + i chua ki tu ':'
                    // + i la 1 so nguyen
                    // + i khong phai so nguyen cung khong chua ki tu ':'
                    if (i.Contains(':'))
                    {
                        // tach tiep chuoi i thanh cac phan (so luong phan mong doi la 2)
                        string[] MangPhu = i.Split(':');

                        // neu so luong phan tu thu duoc sau khi tach bang 2 thi tiep tuc xu li
                        if (MangPhu.Length == 2)
                        {
                            // chuyen doi cac phan tu sau khi tach thanh so nguyen:
                            // + neu chuyen duoc (khong loi) thi tiep tuc xu li
                            // + neu khong chuyen duoc thi bo qua
                            try
                            {
                                // dieu kien de vuot qua khoi try-catch:
                                // + chuyen duoc ve so nguyen
                                // + so nguyen thu duoc la so tu nhien khac 0 (N*)
                                if (Convert.ToInt32(MangPhu[0]) <= 0 || Convert.ToInt32(MangPhu[1]) <= 0)
                                    throw new Exception();
                            }
                            catch (Exception)
                            {
                                continue;
                            }

                            // neu chuyen duoc thanh so nguyen thi chuyen
                            int k0 = Convert.ToInt32(MangPhu[0]);
                            int k1 = Convert.ToInt32(MangPhu[1]);

                            // luu cac so nguyen vua thu duoc vao danh sach va dam bao khong trung gia tri
                            for (int k = k0; k <= k1; k++)
                            {
                                // dam bao khong trung voi cac gia tri san co trong danh sach
                                if (!DanhSachTuanHoc.Contains(k))
                                {
                                    // neu thoa tat ca cac dieu kien thi them vao danh sach
                                    DanhSachTuanHoc.Add(k);
                                }
                            }
                        }
                    } else
                    {
                        try
                        {
                            if (Convert.ToInt32(i) <= 0) throw new Exception();
                        }
                        catch (Exception)
                        {
                            continue;
                        }

                        int j = Convert.ToInt32(i);

                        DanhSachTuanHoc.Add(j);
                    }
                }
                // ket thuc vong lap foreach

                if (DanhSachTuanHoc.Count != 0) break;
                else Console.Write("!! Nhap lai cac tuan hoc can in ra man hinh: ");
            }
            // ket thuc vong lap while

            // sap xep danh sach cac tuan hoc tang dan so thu tu tuan hoc
            DanhSachTuanHoc.Sort();

            // in xac nhan danh sach cac tuan hoc se duoc in
            Console.Write(">> Cac tuan hoc se duoc in: ");
            foreach (int i in DanhSachTuanHoc)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();

            // in cac TKB duoc chon
            int HangTiepTheo = Console.CursorTop + 1;
            int HangSaoLuu = HangTiepTheo;

            foreach (int i in DanhSachTuanHoc)
            {
                HangTiepTheo = DanhSachTKB[i - 1].InTKB(DoRongOInput, HangSaoLuu);

                Console.WriteLine();
                Console.ReadKey();

                Console.SetCursorPosition(0, HangSaoLuu);
                for (int j = 0; j < HangTiepTheo - HangSaoLuu + 1; j++)
                {
                    Console.WriteLine($"{new string(' ', DoRongOInput * 10)}");
                }
            }

            Console.SetCursorPosition(0, HangSaoLuu);
            Console.Write(">>> Ket thuc in");
            return HangSaoLuu + 1;
        }
        // bơ-phẹc
        public void HuyHocPhan()
        {
            string TenHPCanHuy = "";
            Console.Write("\n>>> Nhap ten hoc phan muon huy: ");
            TenHPCanHuy =  Console.ReadLine();

            foreach (ThoiKhoaBieu TKBDuyet in danhSachTKB)
            {
                TKBDuyet.DanhSachHocPhan.RemoveAll((hp) => hp.TenHocPhan == TenHPCanHuy);
            }
        }

        // !!! phuong thuc ThemHocPhan chua duoc test !!!
        public void ThemHocPhan()
        {
            HocPhan HocPhanCanThem = new HocPhan();
            // nhap thong tin hoc phan can them
            Console.WriteLine("\n>>> Nhap thong tin hoc phan can them");
            // phuong thuc nhap hoc phan goi tu lop hoc phan va luu vao doi tuong HocPhanCanThem
            // HocPhanCanThem.<phuong thuc nhap hoc phan>()

            foreach (ThoiKhoaBieu TKBDuyet in danhSachTKB)
            {
                TKBDuyet.DanhSachHocPhan.Add(HocPhanCanThem);
            }
        }
    }
}
