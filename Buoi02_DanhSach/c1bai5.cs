using System;

namespace Buoi01_DeQuy
{
    // Chương 1 - Bài tập 5: Nhập số nguyên dương n, in ra số Fibonacci thứ n
    // Dãy Fibonacci: F0 = 0, F1 = 1, Fn = Fn-1 + Fn-2  ->  0, 1, 1, 2, 3, 5, 8, ...
    class C1Bai5
    {
        // Dùng vòng lặp: chỉ cần nhớ 2 số liền trước
        static long Fibonacci(int n)
        {
            if (n == 0) return 0;

            long truoc = 0;   // F(i-2)
            long sau = 1;     // F(i-1)
            for (int i = 2; i <= n; i++)
            {
                long tam = truoc + sau;   // F(i)
                truoc = sau;
                sau = tam;
            }
            return sau;
        }

        public static void ChayC1Bai5()
        {
            Console.WriteLine("=== Chương 1 - Bài 5: Số Fibonacci thứ n ===");
            Console.Write("Nhập n (0 <= n <= 90, bỏ trống để dùng n = 10): ");
            string s = Console.ReadLine();

            int n;
            if (!int.TryParse(s, out n) || n < 0 || n > 90)
            {
                n = 10;
                Console.WriteLine("(Dùng n mặc định = 10)");
            }

            Console.WriteLine("F(" + n + ") = " + Fibonacci(n));

            Console.Write("Dãy từ F0 đến F" + n + ": ");
            for (int i = 0; i <= n; i++)
            {
                Console.Write(Fibonacci(i) + " ");
            }
            Console.WriteLine();
        }
    }
}