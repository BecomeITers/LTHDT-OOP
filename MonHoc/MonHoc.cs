using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonHoc
{
    public class MonHoc
    {
        public string TenMonHoc { get; set; }
        public string MaMonHoc { get; set; }
        public int SoTinChi { get; set; }
        public string LoaiMonHoc { get; set; } // lý thuyết, thí nghiệm, thực tập
        public int SoTiet { get; set; }       // số tiết/tuần   
        public int TietBatDau { get; set; }     
        public string PhongHoc { get; set; }
        public int MaSoThu { get; set; } // dùng cho TKB.cs

        public MonHoc(string tenMonHoc, string maMonHoc, int soTinChi, string loaiMonHoc, int soTiet, int tietBatDau, string phongHoc, int maSoThu)
        {
            this.TenMonHoc = tenMonHoc;
            this.MaMonHoc = maMonHoc;
            this.SoTinChi = soTinChi;
            this.LoaiMonHoc = loaiMonHoc;
            this.SoTiet = soTiet;
            this.TietBatDau = tietBatDau;
            this.PhongHoc = phongHoc;
            this.MaSoThu = maSoThu;
        }


 // hàm dùng cho TKB


        public int InThongTin(int y, int x, int DoRongOInput)
        {
            List<List<string>> DanhSachTu = new List<List<string>>();
            // tao lap 1 chuoi can in, ki tu "!" cho biet can xuong dong truoc khi in 
            string Chuoi = $"Mon: {TenMonHoc} ! Tiet: {TietBatDau} - {TietBatDau + SoTiet - 1}";
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
                }
                else
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


// Hàm cho MonHoc . In thông tin mỗi môn 1 dòng


        public string InThongTinDS()
        {
            return $"Ma mon hoc: {MaMonHoc}; Ten mon hoc: {TenMonHoc}; So tin chi: {SoTinChi}; Loai: {LoaiMonHoc}; So tiet/tuan: {SoTiet}; Tiet bat dau: {TietBatDau}; Phong hoc: {PhongHoc}, Thu: {MaSoThu+2}";
        }
    }
}

