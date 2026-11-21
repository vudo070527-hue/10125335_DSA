using System;
using System.Text;

namespace Buoi02_List
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;   // hiển thị tiếng Việt
            Console.InputEncoding = Encoding.UTF8;    // nhập tiếng Việt

            bool tiepTuc = true;
            while (tiepTuc)
            {
                Console.WriteLine();
                Console.WriteLine("============ BUỔI 02 - LIST (Chương 4, mục 4.6.2) ============");
                Console.WriteLine("1. Bài 1 - Mảng: nhập, hiển thị, chèn phần tử");
                Console.WriteLine("2. Bài 2 - Danh sách nhân viên (mảng struct)");
                Console.WriteLine("3. Bài 3 - Ma trận vuông");
                Console.WriteLine("4. Bài 4 - Danh sách liên kết đơn: đếm, min dương, xóa x");
                Console.WriteLine("5. Bài 5 - Danh sách liên kết đơn: các phép thống kê");
                Console.WriteLine("0. Thoát");
                Console.Write("Chọn: ");
                string chon = Console.ReadLine();
                Console.WriteLine();

                bool hopLe = true;
                switch (chon)
                {
                    case "1": Ch2Bai1.Chay(); break;
                    case "2": Ch2Bai2.Chay(); break;
                    case "3": Ch2Bai3.Chay(); break;
                    case "4": Ch2Bai4.Chay(); break;
                    case "5": Ch2Bai5.Chay(); break;
                    case "0": tiepTuc = false; break;
                    default:
                        Console.WriteLine("Lựa chọn không hợp lệ!");
                        hopLe = false;
                        break;
                }

                // Sau mỗi bài, chờ người dùng đọc kết quả rồi mới quay lại menu
                if (tiepTuc && hopLe)
                {
                    Console.WriteLine();
                    Console.Write("Nhấn Enter để quay lại menu...");
                    Console.ReadLine();
                }
            }
        }
    }
}