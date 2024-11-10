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

        public virtual void NhapThongTin()
        {
            Console.Write("Nhap ma so: ");
            MaSo = Console.ReadLine();

            Console.Write("Nhap ho ten: ");
            HoTen = Console.ReadLine();

            Console.Write("Nhap ngay thang nam sinh (dd/MM/yyyy): ");
            NgaySinh = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);
        }

        public virtual void XuatThongTin()
        {
            Console.WriteLine($"Ma so: {MaSo}");
            Console.WriteLine($"Ho ten: {HoTen}");
            Console.WriteLine($"Ngay sinh: {NgaySinh:dd/MM/yyyy}");
        }
    }
}
