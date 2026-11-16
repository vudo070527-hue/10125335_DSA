using System;

namespace Buoi01_DeQuy
{
    // Chương 1 - Bài 5 (trang 25): Nhập số nguyên dương n, in ra số Fibonacci thứ n (đệ quy)
    // F0 = 0, F1 = 1, Fn = Fn-1 + Fn-2   ->   0, 1, 1, 2, 3, 5, 8, ...
    // (Các cách nhanh hơn xem ở Chương 2 - Bài 5)
    class Ch1_Bai5
    {
        static long Fib(int n)
        {
            if (n == 0) return 0;
            if (n == 1) return 1;
            return Fib(n - 1) + Fib(n - 2);
        }

        // In dãy từ F(i) đến F(n)
        static void InDay(int i, int n)
        {
            if (i > n) return;
            Console.Write(Fib(i) + " ");
            InDay(i + 1, n);
        }

        public static void Chay()
        {
            Console.WriteLine("=== Chương 1 - Bài 5: Số Fibonacci thứ n ===");
            Console.Write("Nhập n (0 <= n <= 35, bỏ trống để dùng n = 10): ");
            string s = Console.ReadLine();
            int n;
            if (!int.TryParse(s, out n) || n < 0 || n > 35)
            {
                n = 10;
                Console.WriteLine("(Dùng n mặc định = 10)");
            }
            Console.WriteLine("F(" + n + ") = " + Fib(n));
            Console.Write("Dãy từ F0 đến F" + n + ": ");
            InDay(0, n);
            Console.WriteLine();
        }
    }
}