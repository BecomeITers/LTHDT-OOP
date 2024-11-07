using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MonHoc
{
    public class QuanLyMonHoc
    {
        private List<MonHoc> danhSachMonHoc;
        string loaiMonHoc;

        public QuanLyMonHoc()
        {
            danhSachMonHoc = new List<MonHoc>();
        }


// Thêm môn học
        

        public void ThemMonHoc()
        {
            Console.Write("Nhap ten mon hoc: ");
            string tenMonHoc = Console.ReadLine();

            Console.Write("Nhap ma mon hoc: ");
            string maMonHoc = Console.ReadLine();

            Console.Write("Nhap so tin chi: ");
            int soTinChi = int.Parse(Console.ReadLine());

            Console.Write("Nhap loai mon hoc (1. Ly thuyet; 2. Thi nghiem; 3. Thuc tap): ");
            string nhapVao = Console.ReadLine();
            if (nhapVao == "1")
            {
                loaiMonHoc = "Ly thuyet";
            }
            else if (nhapVao == "2")
            {
                loaiMonHoc = "Thi nghiem";
            }
            else if (nhapVao == "3")
            {
                loaiMonHoc = "Thuc tap";
            }
            else
            {
                loaiMonHoc = "Khong xac dinh"; // Nếu nhập sai
            }

            Console.Write("Nhap so tiet/tuan: ");
            int soTiet = int.Parse(Console.ReadLine());

            Console.Write("Nhap tiet bat dau: ");
            int tietBatDau = int.Parse(Console.ReadLine());

            Console.Write("Nhap phong hoc: ");
            string phongHoc = Console.ReadLine();

            Console.Write("Nhap ngay hoc cua mon hoc (2 -> 8 tuong ung voi Thu Hai -> Chu Nhat): ");
            int thu = int.Parse(Console.ReadLine());

            // Gán giá trị mã số thứ tương ứng
            int maSoThu;
            switch (thu)
            {
                case 2: maSoThu = 0; break;
                case 3: maSoThu = 1; break;
                case 4: maSoThu = 2; break;
                case 5: maSoThu = 3; break;
                case 6: maSoThu = 4; break;
                case 7: maSoThu = 5; break;
                case 8: maSoThu = 6; break;
                default:
                    Console.WriteLine("Thu nhap vao khong hop le. Khong duoc gan.");
                    return; // Kết thúc hàm nếu nhập sai thứ
            }

            // thêm môn học vào list
            MonHoc monHoc = new MonHoc(tenMonHoc, maMonHoc, soTinChi, loaiMonHoc, soTiet, tietBatDau, phongHoc, maSoThu);
            danhSachMonHoc.Add(monHoc);
            Console.WriteLine("Them mon hoc thanh cong.");
        }


// Sửa thông tin môn học theo mã môn 
 
        
        public void SuaMonHoc()
        {
            Console.Write("Nhap ma mon hoc can chinh sua: ");
            string maMon = Console.ReadLine();

            // Tìm môn học theo mã môn
            MonHoc monHoc = danhSachMonHoc.Find(mh => mh.MaMonHoc == maMon);
            if (monHoc == null)
            {
                Console.WriteLine("Khong tim thay mon hoc da nhap.");
                return;
            }

            Console.WriteLine("Chon thong tin muon chinh sua:");
            Console.WriteLine("1. Ten mon hoc");
            Console.WriteLine("2. Ma mon hoc");
            Console.WriteLine("3. So tin chi");
            Console.WriteLine("4. Loai mon hoc");
            Console.WriteLine("5. So tiet/tuan");
            Console.WriteLine("6. Tiet bat dau");
            Console.WriteLine("7. Phong hoc");
            Console.WriteLine("8. Ngay hoc cua mon hoc");
            Console.Write("Lua chon cua ban: ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.Write("Nhap ten mon hoc moi: ");
                    monHoc.TenMonHoc = Console.ReadLine();
                    break;
                case 2:
                    Console.Write("Nhap ma mon hoc moi: ");
                    monHoc.MaMonHoc = Console.ReadLine();
                    break;
                case 3:
                    Console.Write("Nhap so tin chi moi: ");
                    monHoc.SoTinChi = int.Parse(Console.ReadLine());
                    break;
                case 4:
                    Console.Write("Nhap loai mon hoc (1. Ly thuyet; 2. Thi nghiem; 3. Thuc tap): ");
                    string loaiInput = Console.ReadLine();
                    monHoc.LoaiMonHoc = loaiInput == "1" ? "LyThuyet" : loaiInput == "2" ? "ThiNghiem" : "ThucTap";
                    break;
                case 5:
                    Console.Write("Nhap so tiet/tuan moi: ");
                    monHoc.SoTiet = int.Parse(Console.ReadLine());
                    break;
                case 6:
                    Console.Write("Nhap tiet bat dau moi: ");
                    monHoc.TietBatDau = int.Parse(Console.ReadLine());
                    break;
                case 7:
                    Console.Write("Nhap phong hoc moi: ");
                    monHoc.PhongHoc = Console.ReadLine();
                    break;
                case 8:
                    Console.Write("Nhap ngay hoc moi cua mon hoc (2 -> 8 tuong ung voi Thu 2 -> Chu Nhat): ");
                    int thu = int.Parse(Console.ReadLine());

                    int maSoThu;
                    switch (thu)
                    { // thứ 2 có maSoThu là 0 ,... chủ nhật là 6
                        case 2: maSoThu = 0; break;
                        case 3: maSoThu = 1; break;
                        case 4: maSoThu = 2; break;
                        case 5: maSoThu = 3; break;
                        case 6: maSoThu = 4; break;
                        case 7: maSoThu = 5; break;
                        case 8: maSoThu = 6; break;
                        default:
                            Console.WriteLine("Thu nhap vao khong hop le.");
                            return; // Kết thúc hàm nếu nhập sai thứ
                    }
                    monHoc.MaSoThu = maSoThu; // Gán giá trị mới cho MaSoThu
                    break;
                default:
                    Console.WriteLine("Lua chon khong hop le.");
                    break;
            }
        }

       
// Xóa môn học 
       
        
        public void XoaMonHoc()
        {
            Console.Write("Nhap ma mon hoc can xoa: ");
            string maMonHoc = Console.ReadLine();

            MonHoc monHoc = danhSachMonHoc.Find(m => m.MaMonHoc == maMonHoc);
            if (monHoc != null)
            {
                danhSachMonHoc.Remove(monHoc);
                Console.WriteLine("Xoa mon hoc thanh cong.");
            }
            else
            {
                Console.WriteLine("Khong tim thay mon hoc.");
            }
        }


// Hiển thị danh sách môn học


        public void HienThiDanhSachMonHoc()
        {
            Console.WriteLine("Danh sach cac mon hoc:");
            foreach (var monHoc in danhSachMonHoc)
            {
                Console.WriteLine(monHoc.InThongTinDS());
            }
        }
    }
}
