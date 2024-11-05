using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn
{
    internal class ThoiKhoaBieu : ILichHoc
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
            Console.WriteLine("Thoi khoa bieu:");
            foreach (var monHoc in LichHoc)
            {
                Console.WriteLine($"- Mon: {monHoc.Key}, Thoi gian: {monHoc.Value}");
            }
        }
    }
}
