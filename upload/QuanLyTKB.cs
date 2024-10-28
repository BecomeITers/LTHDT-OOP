using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TKB
{
    internal class QuanLyTKB
    {
        List<ThoiKhoaBieu> DanhSachTKB = new List<ThoiKhoaBieu>();

        // methods
        public void NhanBanTuanHoc(ThoiKhoaBieu TKBtuan1Input)
        {
            int n;
            Console.Write("Nhap so tuan co trong nam hoc: ");
            n = Convert.ToInt32(Console.ReadLine());

            DanhSachTKB.Add(TKBtuan1Input);

            for (int i = 2; i <= n; i++)
            {
                ThoiKhoaBieu TKBTruoc = TKBtuan1Input;
                ThoiKhoaBieu TKBSau = TKBTruoc;
                TKBSau.NgayBatDau = TKBTruoc.NgayBatDau.AddDays(7);
                TKBSau.NgayKetThuc = TKBSau.NgayBatDau.AddDays(6);
            }
            
        }
        public void InTKBTheoTuan(int[] tuanHocMangInput) 
        {
            // sap xep tuan hoc can in theo thu tu tang dan
            Array.Sort(tuanHocMangInput);

        }
    }
}
