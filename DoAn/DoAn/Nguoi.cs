using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn
{
    internal abstract class Nguoi
    {
        public string HoTen { get; set; }
        public string MaSo { get; set; }
        public string Email { get; set; }
        public DateTime NgaySinh { get; set; }

        public Nguoi(string hoTen, string maSo, string email, DateTime ngaySinh)
        {
            HoTen = hoTen;
            MaSo = maSo;
            Email = email;
            NgaySinh = ngaySinh;
        }

        public abstract void LayThongTin();
    }
}
