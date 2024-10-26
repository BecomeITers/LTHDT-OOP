using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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

        // constructors
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

        // properties
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
        // methods
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
                // phuong thuc nhap hoc phan kem nhap phong hoc duoc cap cua hoc phan do
                
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
        public void InTKB()
        {
            Console.WriteLine($"Tuan hoc: {tuanHoc}\nNgay bat dau - ket thuc: {ngayBatDau.ToString("dd/MM/yyyy")} - {ngayKetThuc.ToString("dd/MM/yyyy")}");

            // In so tiet va gio
            Console.SetCursorPosition(0, 3);
            /* tiet 1: 7:00 -> 7:50
             * tiet 2: 7:50 -> 8:40 (nghi 10 phut)
             * tiet 3: 8:50 -> 9:40
             * tiet 4: 9:40 -> 10:30 (nghi 10 phut)
             * tiet 5: 10:40 -> 11:30
             * tiet 6: 11:30 -> 12:20 (nghi 10 phut)
             * tiet 7: 12:30 -> 13:20
             * tiet 8: 13:20 -> 14:10 
             * tiet 9: 14:10 -> 15:00 (nghi 10 phut)
             * tiet 10: 15:10 -> 16:00 (nghi 10 phut)
             * tiet 11: 16:10 -> 17:00
             */
            string[] DanhSachGio = new string[] {"7:00 -> 7:50", "7:50 -> 8:40", "8:50 -> 9:40",
                                                 "9:40 -> 10:30", "10:40 -> 11:30", "11:30 -> 12:20",
                                                 "12:30 -> 13:20", "13:20 -> 14:10", "14:10 -> 15:00",
                                                 "15:10 -> 16:00", "16:10 -> 17:00"};
            int[] ThuTuHang = new int[11];
            for (int i = 1; i <= 11; i++)
            {
                // luu lai hang (dong) con chuot bat dau tuong ung voi thu tu tiet -> in thong tin hoc phan bat dau o dung hang cua tiet hoc tuong ung
                ThuTuHang[i - 1] = Console.CursorTop;
                Console.WriteLine($"Tiet {i}:\n({DanhSachGio[i - 1]})\n");
            }

            // In lich hoc theo tung ngay trong tuan, bat dau tu thu hai
            Console.SetCursorPosition(15, 3);

            for (int i = 0; i < 7; i++)
            {
                Console.WriteLine("Test");
            }
        }
    }
}
