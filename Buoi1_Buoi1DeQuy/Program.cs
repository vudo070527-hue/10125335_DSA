using System;
using System.Text;
using System.Threading;

namespace Buoi01_DeQuy
{
    class Program
    {
        static void Main(string[] args)
        {
            // Chạy menu trong một luồng có ngăn xếp lớn (256 MB) để đệ quy sâu không bị tràn (stack overflow)
            Thread luong = new Thread(ChayMenu, 256 * 1024 * 1024);
            luong.Start();
            luong.Join();
        }

        static void ChayMenu()
        {
            Console.OutputEncoding = Encoding.UTF8;   // hiển thị tiếng Việt

            bool tiepTuc = true;
            while (tiepTuc)
            {
                Console.WriteLine();
                Console.WriteLine("================ BUỔI 01 - ĐỆ QUY ================");
                Console.WriteLine("--- Chương 1 (mục 1.4.2, trang 25) ---");
                Console.WriteLine("1.  Bài 1 - Số lớn nhất, nhỏ nhất trong 1000 số");
                Console.WriteLine("2.  Bài 2 - FizzBuzz");
                Console.WriteLine("3.  Bài 3 - Đảo ngược chuỗi");
                Console.WriteLine("4.  Bài 4 - In mảng và sắp xếp tăng dần");
                Console.WriteLine("5.  Bài 5 - Số Fibonacci thứ n");
                Console.WriteLine("--- Chương 2 (trang 76-79) ---");
                Console.WriteLine("6.  Bài 1 - Tháp Hà Nội");
                Console.WriteLine("7.  Bài 2 - Tìm kiếm nhị phân");
                Console.WriteLine("8.  Bài 3 - Kiểm tra số nguyên tố");
                Console.WriteLine("9.  Bài 4 - Liệt kê số hoàn hảo");
                Console.WriteLine("10. Bài 5 - Fibonacci (3 giải thuật)");
                Console.WriteLine("11. Bài 6 - Sắp xếp dãy số (5 giải thuật)");
                Console.WriteLine("--- Chương 3 (mục 3.7.2, trang 100-101) ---");
                Console.WriteLine("12. Bài 1 - S(n) = 1 + 2 + ... + n");
                Console.WriteLine("13. Bài 2 - S(n) = 1 + 2^2 + ... + n^2");
                Console.WriteLine("14. Bài 3 - S(n) = 1 + 1/2 + ... + 1/n");
                Console.WriteLine("15. Bài 4 - S(x, n) = x^n");
                Console.WriteLine("16. Bài 5 - Ước lẻ lớn nhất");
                Console.WriteLine("17. Bài 6 - Ước chung lớn nhất (Euclid)");
                Console.WriteLine("18. Bài 7 - Đếm số chữ số");
                Console.WriteLine("19. Bài 8 - Tổng căn lồng nhau");
                Console.WriteLine("0.  Thoát");
                Console.Write("Chọn: ");
                string chon = Console.ReadLine();
                Console.WriteLine();

                switch (chon)
                {
                    case "1": Ch1_Bai1.Chay(); break;
                    case "2": Ch1_Bai2.Chay(); break;
                    case "3": Ch1_Bai3.Chay(); break;
                    case "4": Ch1_Bai4.Chay(); break;
                    case "5": Ch1_Bai5.Chay(); break;
                    case "6": Ch2_Bai1.Chay(); break;
                    case "7": Ch2_Bai2.Chay(); break;
                    case "8": Ch2_Bai3.Chay(); break;
                    case "9": Ch2_Bai4.Chay(); break;
                    case "10": Ch2_Bai5.Chay(); break;
                    case "11": Ch2_Bai6.Chay(); break;
                    case "12": Ch3_Bai1.Chay(); break;
                    case "13": Ch3_Bai2.Chay(); break;
                    case "14": Ch3_Bai3.Chay(); break;
                    case "15": Ch3_Bai4.Chay(); break;
                    case "16": Ch3_Bai5.Chay(); break;
                    case "17": Ch3_Bai6.Chay(); break;
                    case "18": Ch3_Bai7.Chay(); break;
                    case "19": Ch3_Bai8.Chay(); break;
                    case "0": tiepTuc = false; break;
                    default: Console.WriteLine("Lựa chọn không hợp lệ!"); break;
                }
            }
        }
    }
}