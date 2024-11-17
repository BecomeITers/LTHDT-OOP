using GiangVien_SinhVien;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJECT_OOP
{
    public class TapTin
    {
        public void MoVietString(string thuocTinh)
        {
            string FileName = "Document.txt";
            try
            {
                using (StreamWriter writer = new StreamWriter(FileName, true))
                {
                    writer.WriteLine(thuocTinh);
                }
            }
            catch (Exception ex) 
            {
                Console.WriteLine("ERROR" + ex.Message);
            }
        }

        public void MoVietDateTime(DateTime thuocTinh)
        {
            string FileName = "Document.txt";
            try
            {
                using (StreamWriter writer = new StreamWriter(FileName, true))
                {
                    string NgayThangNam = thuocTinh.ToString("dd / MM / yyyy");
                    writer.WriteLine(NgayThangNam);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR" + ex.Message);
            }
        }

        public void MoVietNumber(int thuocTinh)
        {
            string FileName = "Document.txt";
            try
            {
                using (StreamWriter writer = new StreamWriter(FileName, true))
                {
                    writer.WriteLine(thuocTinh);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR" + ex.Message);
            }
        }

        public void XoaPhanTuCuoi()
        {
            string FileName = "Document.txt";
            List<string> dong = new List<string>(System.IO.File.ReadAllLines(FileName));

            if (dong.Count > 0)
            {
                dong.RemoveAt(dong.Count - 1);
                System.IO.File.WriteAllLines(FileName, dong);
            }
            else
            {
                Console.WriteLine("Invalid");
            }
        }
    }
}
