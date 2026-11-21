using System;
using System.Text;

namespace Buoi3_StackQueue
{
    // Chương trình chính: menu chọn bài tập Chương 3 (Stack và Queue).
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            int chon = -1;
            while (chon != 0)
            {
                Console.WriteLine();
                Console.WriteLine("========== CHƯƠNG 3: STACK VÀ QUEUE ==========");
                Console.WriteLine("1. [STACK] Bài 1: Kiểm tra dấu ngoặc trong biểu thức");
                Console.WriteLine("2. [STACK] Bài 2: Mô phỏng lịch sử trình duyệt web");
                Console.WriteLine("3. [STACK] Bài 3: Mô phỏng Function Call Stack");
                Console.WriteLine("4. [QUEUE] Bài 4: Mô phỏng hệ thống in ấn");
                Console.WriteLine("5. [QUEUE] Bài 5: Mô phỏng đường truyền dữ liệu");
                Console.WriteLine("6. [QUEUE] Bài 6: Quản lý hàng đợi khách hàng");
                Console.WriteLine("0. Thoát");
                Console.Write("Chọn bài: ");

                if (!int.TryParse(Console.ReadLine(), out chon))
                    chon = -1;

                Console.WriteLine();
                switch (chon)
                {
                    case 1:
                        Ch3Bai1.Chay();
                        break;
                    case 2:
                        Ch3Bai2.Chay();
                        break;
                    case 3:
                        Ch3Bai3.Chay();
                        break;
                    case 4:
                        Ch3Bai4.Chay();
                        break;
                    case 5:
                        Ch3Bai5.Chay();
                        break;
                    case 6:
                        Ch3Bai6.Chay();
                        break;
                    case 0:
                        Console.WriteLine("Tạm biệt!");
                        break;
                    default:
                        Console.WriteLine("Lựa chọn không hợp lệ.");
                        break;
                }
            }
        }
    }
}
