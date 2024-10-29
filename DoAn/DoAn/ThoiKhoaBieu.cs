using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn
{
    internal class ThoiKhoaBieu
    {
        public List<string> MonHoc { get; set; } = new List<string>();
        public Dictionary<string, string> LichHoc { get; set; } = new Dictionary<string, string>();

        public void ThemMonHoc(string monHoc, string thoiGian)
        {
            MonHoc.Add(monHoc);
            LichHoc[monHoc] = thoiGian;
        }

        public void XemThoiKhoaBieu()
        {
            Console.WriteLine("Thời khóa biểu:");
            foreach (var monHoc in LichHoc)
            {
                Console.WriteLine($"- Môn: {monHoc.Key}, Thời gian: {monHoc.Value}");
            }
        }
    }
}
