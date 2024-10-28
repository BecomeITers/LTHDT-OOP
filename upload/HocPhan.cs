using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TKB
{
    internal class HocPhan
    {
        private string tenHocPhan;
        private string maHocPhan;
        private string giangVienPhuTrach;
        private string phongHoc;
        private int soTiet;
        private int tietBatDau;
        // ma so thu: 0 - "hai", 1 - "ba", 2 - "tu", 3 - "nam", 4 - "sau", 5 - "bay", 6 - "chu nhat"
        private int maSoThu;

        //-------------
        // constructors
        //-------------
        public HocPhan()
        {
            tenHocPhan = "";
            maHocPhan = "";
            giangVienPhuTrach = "";
            phongHoc = "";
            soTiet = 0;
            tietBatDau = 0;
            maSoThu = 0;
        }

        public HocPhan(string tenHocPhan_I, string maHocPhan_I, string giangVienPhuTrach_I, string phongHoc_I, int soTiet_I, int tietBatDau_I, int thu_I)
        {
            tenHocPhan = tenHocPhan_I;
            maHocPhan = tenHocPhan_I;
            giangVienPhuTrach = giangVienPhuTrach_I;
            phongHoc = phongHoc_I;
            soTiet = soTiet_I;
            tietBatDau = tietBatDau_I;
            maSoThu = thu_I;
        }

        //-----------
        // properties
        //-----------
        public int MaSoThu
        {
            get { return maSoThu; }
            set { maSoThu = value; }
        }
        public string PhongHoc
        {
            get { return phongHoc; }
            set { phongHoc = value; }
        }

        //-------
        // method
        //-------
        public int InThongTin(int y, int x, int DoRongOInput)
        {
            List<List<string>> DanhSachTu = new List<List<string>>();

            // tao lap 1 chuoi can in, ki tu "!" cho biet can xuong dong truoc khi in 
            string Chuoi = $"Mon: {tenHocPhan} ! GV: {giangVienPhuTrach} ! Tiet: {tietBatDau} - {tietBatDau + soTiet - 1}";
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
    }
}
