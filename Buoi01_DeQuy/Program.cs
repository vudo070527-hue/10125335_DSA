using System;
using System.Text;

namespace Buoi01_DeQuy
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;   // hiển thị tiếng Việt

            bool tiepTuc = true;
            while (tiepTuc)
            {
                Console.WriteLine();
                Console.WriteLine("========== MENU - BUỔI 01 ĐỆ QUY ==========");
                Console.WriteLine("--- Chương 2: Độ phức tạp giải thuật ---");
                Console.WriteLine("1. Bài 1 - Tháp Hà Nội");
                Console.WriteLine("2. Bài 2 - Tìm kiếm nhị phân");
                Console.WriteLine("3. Bài 5 - Số Fibonacci thứ n");
                Console.WriteLine("--- Chương 3: Bài tập đệ quy (mục 3.7.2) ---");
                Console.WriteLine("11. Bài 1 - S(n) = 1 + 2 + ... + n");
                Console.WriteLine("12. Bài 2 - S(n) = 1 + 2^2 + ... + n^2");
                Console.WriteLine("13. Bài 3 - S(n) = 1 + 1/2 + ... + 1/n");
                Console.WriteLine("14. Bài 4 - S(x, n) = x^n");
                Console.WriteLine("15. Bài 5 - Ước lẻ lớn nhất");
                Console.WriteLine("16. Bài 6 - Ước chung lớn nhất (Euclid)");
                Console.WriteLine("17. Bài 7 - Đếm số chữ số");
                Console.WriteLine("18. Bài 8 - Tổng căn lồng nhau");
                Console.WriteLine("0. Thoát");
                Console.Write("Chọn: ");
                string chon = Console.ReadLine();
                Console.WriteLine();

                switch (chon)
                {
                    case "1": Bai1.ChayBai1(); break;
                    case "2": Bai2.ChayBai2(); break;
                    case "3": Bai5.ChayBai5(); break;
                    case "11": DeQuy1.ChayDeQuy1(); break;
                    case "12": DeQuy2.ChayDeQuy2(); break;
                    case "13": DeQuy3.ChayDeQuy3(); break;
                    case "14": DeQuy4.ChayDeQuy4(); break;
                    case "15": DeQuy5.ChayDeQuy5(); break;
                    case "16": DeQuy6.ChayDeQuy6(); break;
                    case "17": DeQuy7.ChayDeQuy7(); break;
                    case "18": DeQuy8.ChayDeQuy8(); break;
                    case "0": tiepTuc = false; break;
                    default: Console.WriteLine("Lựa chọn không hợp lệ!"); break;
                }
            }
        }
    }
}