using PROJECT_OOP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiangVien_SinhVien
{ 
    public abstract class Nguoi : IThongTin
    {
        public string MaSo { get; set; }
        public string HoTen { get; set; }
        public DateTime NgaySinh { get; set; }
        public string GioiTinh { get; set; }

        File file = new File();

        public virtual void NhapThongTin()
        {
            Console.Write("Nhap ma so: ");
            MaSo = Console.ReadLine();
            file.MoVietString(MaSo);

            Console.Write("Nhap ho ten: ");
            HoTen = Console.ReadLine();
            file.MoVietString(HoTen);

            Console.Write("Nhap ngay thang nam sinh (dd/MM/yyyy): ");
            NgaySinh = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);
            file.MoVietDateTime(NgaySinh);

            Console.Write("Nhap gioi tinh: ");
            GioiTinh = Console.ReadLine();
            file.MoVietString(GioiTinh);
        }

        public virtual void XuatThongTin()
        {
            Console.WriteLine($"Ma so: {MaSo}");
            Console.WriteLine($"Ho ten: {HoTen}");
            Console.WriteLine($"Ngay sinh: {NgaySinh:dd/MM/yyyy}");
            Console.WriteLine($"Gioi tinh: {GioiTinh}");
        }
    }
}
