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
                Console.WriteLine("================ MENU BÀI TẬP DSA ================");
                Console.WriteLine("--- Chương 1: Bài tập áp dụng (mục 1.4.2) ---");
                Console.WriteLine("1.  Bài 1 - Số lớn nhất, nhỏ nhất trong 1000 số");
                Console.WriteLine("2.  Bài 2 - FizzBuzz");
                Console.WriteLine("3.  Bài 3 - Đảo ngược chuỗi");
                Console.WriteLine("4.  Bài 4 - In mảng và sắp xếp tăng dần");
                Console.WriteLine("5.  Bài 5 - Số Fibonacci thứ n");
                Console.WriteLine("--- Chương 2: Phân tích giải thuật ---");
                Console.WriteLine("6.  Bài 1 - Tháp Hà Nội");
                Console.WriteLine("7.  Bài 2 - Tìm kiếm nhị phân");
                Console.WriteLine("8.  Bài 3 - Kiểm tra số nguyên tố");
                Console.WriteLine("9.  Bài 4 - Liệt kê số hoàn hảo");
                Console.WriteLine("10. Bài 5 - Số Fibonacci (4 giải thuật)");
                Console.WriteLine("11. Bài 6 - Sắp xếp dãy số (5 giải thuật)");
                Console.WriteLine("--- Chương 3: Đệ quy (mục 3.7.2) ---");
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
                    case "1": C1Bai1.ChayC1Bai1(); break;
                    case "2": C1Bai2.ChayC1Bai2(); break;
                    case "3": C1Bai3.ChayC1Bai3(); break;
                    case "4": C1Bai4.ChayC1Bai4(); break;
                    case "5": C1Bai5.ChayC1Bai5(); break;
                    case "6": Bai1.ChayBai1(); break;
                    case "7": Bai2.ChayBai2(); break;
                    case "8": Bai3.ChayBai3(); break;
                    case "9": Bai4.ChayBai4(); break;
                    case "10": Bai5.ChayBai5(); break;
                    case "11": Bai6.ChayBai6(); break;
                    case "12": DeQuy1.ChayDeQuy1(); break;
                    case "13": DeQuy2.ChayDeQuy2(); break;
                    case "14": DeQuy3.ChayDeQuy3(); break;
                    case "15": DeQuy4.ChayDeQuy4(); break;
                    case "16": DeQuy5.ChayDeQuy5(); break;
                    case "17": DeQuy6.ChayDeQuy6(); break;
                    case "18": DeQuy7.ChayDeQuy7(); break;
                    case "19": DeQuy8.ChayDeQuy8(); break;
                    case "0": tiepTuc = false; break;
                    default: Console.WriteLine("Lựa chọn không hợp lệ!"); break;
                }
            }
        }
    }
}