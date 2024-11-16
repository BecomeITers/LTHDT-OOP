using GiangVien_SinhVien;
using PROJECT_OOP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace TKB
{
    internal class HocPhan
    {
        private string tenHocPhan;
        private string maHocPhan;
        // private GiangVien giangVienPhuTrach;
        private string phongHoc;
        private int soTiet;
        private int tietBatDau;
        // ma so thu: 0 - "hai", 1 - "ba", 2 - "tu", 3 - "nam", 4 - "sau", 5 - "bay", 6 - "chu nhat"
        private int maSoThu;
        GiangVien giangVienPhuTrach = new GiangVien();
        File file = new File();

        //-------------
        // constructors
        //-------------
        public HocPhan()
        {
            tenHocPhan = "";
            maHocPhan = "";
            phongHoc = "";
            soTiet = 0;
            tietBatDau = 0;
            maSoThu = 0;
        }

        public HocPhan(string tenHocPhan_I, string maHocPhan_I, GiangVien giangVienPhuTrach_I, string phongHoc_I, int soTiet_I, int tietBatDau_I, int maSoThu_I)
        {
            tenHocPhan = tenHocPhan_I;
            maHocPhan = maHocPhan_I;
            giangVienPhuTrach = giangVienPhuTrach_I;
            phongHoc = phongHoc_I;
            soTiet = soTiet_I;
            tietBatDau = tietBatDau_I;
            maSoThu = maSoThu_I;
        }

        //-----------
        // properties
        //-----------
        public string TenHocPhan
        {
            get { return tenHocPhan; }
            set { tenHocPhan = value; }
        }

        public string MaHocPhan
        {
            get { return maHocPhan; }
            set { maHocPhan = value; }
        }

        public GiangVien GiangVienPhuTrach
        {
            get { return giangVienPhuTrach; }
            set { giangVienPhuTrach = value; }
        }

        public string PhongHoc
        {
            get { return phongHoc; }
            set { phongHoc = value; }
        }

        public int SoTiet
        {
            get { return soTiet; }
            set { soTiet = value; }
        }

        public int TietBatDau
        {
            get { return tietBatDau; }
            set { tietBatDau = value; }
        }

        public int MaSoThu
        {
            get { return maSoThu; }
            set { maSoThu = value; }
        }
        //--------
        // methods
        //--------

        /// Hàm nhập danh sách học phần
        public void NhapHocPhan()
        {
            while (true)
            {
                try
                {
                    Console.Write("Nhap ten hoc phan: ");
                    tenHocPhan = Console.ReadLine();
                    foreach (char c in tenHocPhan)
                    {
                        if (!char.IsLetter(c) && !char.IsWhiteSpace(c))
                        {
                            throw new Exception("Ten hoc phan chi duoc chua chu cai khong dau va khoang trang, khong duoc chua so hoac ky tu dac biet!");
                        }
                    }
                    file.MoVietString(tenHocPhan);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Loi: {ex.Message}. Vui long nhap lai!");
                    continue;
                }
                break;
            }

            Console.Write("Nhap ma hoc phan: ");
            maHocPhan = Console.ReadLine();
            file.MoVietString(maHocPhan);

            Console.WriteLine("Nhap giang vien phu trach: ");
            giangVienPhuTrach.NhapThongTin();

            Console.Write("Nhap phong hoc: ");
            phongHoc = Console.ReadLine();
            file.MoVietString(PhongHoc);

            Console.Write("Nhap tiet bat dau: ");
            while (true)
            {
                try
                {
                    tietBatDau = int.Parse(Console.ReadLine());
                    file.MoVietNumber(tietBatDau);

                    if (tietBatDau < 1 || tietBatDau > 11) throw new Exception();
                }
                catch (Exception)
                {
                    Console.Write("!!! Nhap lai tiet bat dau: ");
                    file.XoaPhanTuCuoi();
                    continue;
                }

                break;
            }

            Console.Write("Nhap so tiet: ");
            while (true)
            {
                try
                {
                    soTiet = int.Parse(Console.ReadLine());
                    file.MoVietNumber(soTiet);

                    int TietKetThuc = tietBatDau + soTiet - 1;
                    if (TietKetThuc > 11) throw new Exception();
                }
                catch (Exception)
                {
                    Console.Write("!!! Nhap lai so tiet: ");
                    file.XoaPhanTuCuoi();
                    continue;
                }

                break;
            }

            Console.Write("Nhap thu (0 - hai, 1 - ba, ... 6 - chu nhat): ");
            while (true)
            {
                try
                {
                    maSoThu = int.Parse(Console.ReadLine());
                    file.MoVietNumber(maSoThu);

                    if (maSoThu < 0 || maSoThu > 6) throw new Exception();
                }
                catch (Exception)
                {
                    Console.Write("!!! Nhap lai thu ngay trong tuan (0 - hai, 1 - ba, ... 6 - chu nhat): ");
                    file.XoaPhanTuCuoi();
                    continue;
                }

                break;
            }
        }

        /// Hàm chỉnh sửa học phần
        public void ChinhSuaHocPhan()
        {
            /*
            if (this != null)
            {
                
            }
            else
            {
                Console.WriteLine("!!! Khong tim thay hoc phan.");
            }
            */
            int kt = 0;
            while (true)
            {
                Console.WriteLine("Thong tin hien tai cua hoc phan:");
                Console.WriteLine($"1. Ten hoc phan: {tenHocPhan}");
                Console.WriteLine($"2. Ma hoc phan: {maHocPhan}");
                Console.WriteLine($"3. Giang vien phu trach: {giangVienPhuTrach}");
                Console.WriteLine($"4. Phong hoc: {phongHoc}");
                Console.WriteLine($"5. So tiet: {soTiet}");
                Console.WriteLine($"6. Tiet bat dau: {tietBatDau}");
                Console.WriteLine($"7. Ma so thu: {maSoThu}");

                if (kt == 1) break;

                while (true)
                {
                    Console.Write("\nNhap so tuong ung voi thong tin can thay doi (nhap '0' de thoat): ");
                    string luaChon = Console.ReadLine()?.Trim();

                    if (luaChon == "0")
                    {
                        kt = 1;
                        break;
                    }

                    switch (luaChon)
                    {
                        case "1":
                            Console.Write("Nhap ten hoc phan moi: ");
                            string tenMoi = Console.ReadLine();
                            tenHocPhan = tenMoi;
                            break;
                        case "2":
                            Console.Write("Nhap ma hoc phan moi: ");
                            string maMoi = Console.ReadLine();
                            maHocPhan = maMoi;
                            break;
                        case "3":
                            Console.Write("Nhap giang vien phu trach moi: ");
                            giangVienPhuTrach.NhapThongTin();
                            break;
                        case "4":
                            Console.Write("Nhap phong hoc moi: ");
                            string phongMoi = Console.ReadLine();
                            phongHoc = phongMoi;
                            break;
                        case "5":
                            Console.Write("Nhap so tiet moi: ");
                            if (int.TryParse(Console.ReadLine(), out int soTietMoi))
                            {
                                soTiet = soTietMoi;
                            }
                            else
                            {
                                Console.WriteLine("So tiet khong hop le.");
                            }
                            break;
                        case "6":
                            Console.Write("Nhap tiet bat dau moi: ");
                            if (int.TryParse(Console.ReadLine(), out int tietBatDauMoi))
                            {
                                tietBatDau = tietBatDauMoi;
                            }
                            else
                            {
                                Console.WriteLine("Tiet bat dau khong hop le.");
                            }
                            break;
                        case "7":
                            Console.Write("Nhap ma so thu moi (0 - hai, 1 - ba, ... 6 - chu nhat): ");
                            if (int.TryParse(Console.ReadLine(), out int maSoThuMoi))
                            {
                                maSoThu = maSoThuMoi;
                            }
                            else
                            {
                                Console.WriteLine("Ma so thu khong hop le.");
                            }
                            break;
                        default:
                            Console.WriteLine("Lua chon khong hop le.");
                            break;
                    }
                }
                Console.WriteLine(">>> Da cap nhat thong tin hoc phan.\n");
            }
        }

        public int InThongTin(int y, int x, int DoRongOInput)
        {
            List<List<string>> DanhSachTu = new List<List<string>>();

            // tao lap 1 chuoi can in, ki tu "!" cho biet can xuong dong truoc khi in 
            string Chuoi = $"Mon: {tenHocPhan} ! GV: {giangVienPhuTrach.HoTen} ! Tiet: {tietBatDau} - {tietBatDau + soTiet - 1}";
            string[] MangTam = Chuoi.Split(' ');

            // bien "i" luu so luong dong phat sinh can de trinh bay thong tin 1 hoc phan
            // so luong dong phat sinh nay bang so luong doi tuong danh sach con trong danh sach 2 chieu
            // bien "i" dong thoi la vi tri duyet cac danh sach con
            int i = 0;

            // chieu dai chuoi la tong do dai cac tu sao cho bo vua khit trong o (co tinh khoang cach)
            // chieu dai chuoi nay phai nho hon do rong o (dieu kien if)
            int ChieuDaiChuoi = 0;

            // tao doi tuong danh sach con, danh sach con luu cac chuoi
            DanhSachTu.Add(new List<string>());
            foreach (string Tu in MangTam)
            {
                ChieuDaiChuoi += Tu.Length + 1;

                // 2 dieu kien de them "Tu" vao 1 danh sach con (1 hang):
                // + "Tu" khac ki tu "!" (day la ki tu quy dinh xuong dong)
                // + chieu dai chuoi hien tai van con nho hon do rong o (in vua du)
                if (Tu != "!" && ChieuDaiChuoi < DoRongOInput)
                {
                    DanhSachTu[i].Add(Tu);
                } else              
                {
                    // neu khong thoa 1 trong 2 dieu kien thi:
                    // + reset chieu dai chuoi (do da chuyen sang hang moi)
                    // + them danh sach con moi
                    // + tang so luong dong phat sinh dong thoi tang vi tri "i"
                    ChieuDaiChuoi = 0;
                    DanhSachTu.Add(new List<string>());
                    i++;

                    // neu "Tu" hien tai khong phai la ki tu "!" thi them "Tu" nay vao dau dong tiep theo
                    if (Tu != "!")
                    {
                        DanhSachTu[i].Add(Tu);
                    }
                }
            }

            // in thong tin hoc phan bang cach long vong lap for
            // vong lap duyet cac danh sach con
            for (i = 0; i < DanhSachTu.Count; i++)
            {
                Console.SetCursorPosition(y, x + i);

                // vong lap duyet cac phan tu trong danh sach con thu i
                for (int j = 0; j < DanhSachTu[i].Count; j++)
                {
                    // in cac tu trong cung 1 hang kem khoang cach
                    Console.Write(DanhSachTu[i][j] + " ");
                }
            }

            // tra ve tong so hang can thiet de in o hoc phan nay
            return i;
        }

        public string InThongTinDS()
        {
            return $"Ten hoc phan: {tenHocPhan}, ma hoc phan: {maHocPhan}\nTiet: {tietBatDau} - {tietBatDau + soTiet - 1}, so tiet: {soTiet}";
        }
    }
}
