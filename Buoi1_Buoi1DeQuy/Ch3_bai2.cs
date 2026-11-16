using System;

namespace Buoi01_DeQuy
{
    // Chương 3 - Bài 2 (trang 100-101): Tính S(n) = 1 + 2^2 + 3^2 + ... + (n-1)^2 + n^2
    // Trường hợp suy biến: n = 1 thì S(1) = 1
    // Trường hợp đệ quy : n > 1 thì S(n) = S(n-1) + n^2
    class Ch3_Bai2
    {
        static long TinhS(int n)
        {
            if (n == 1)                         // trường hợp suy biến
                return 1;
            return TinhS(n - 1) + (long)n * n;  // đệ quy: cộng thêm bình phương của n
        }

        public static void Chay()
        {
            Console.WriteLine("=== Chương 3 - Bài tập 2: S(n) = 1 + 2^2 + ... + n^2 ===");
            int[] mau = { 1, 3, 5, 10 };
            for (int i = 0; i < mau.Length; i++)
            {
                int n = mau[i];
                long congThuc = (long)n * (n + 1) * (2 * n + 1) / 6;  // công thức n(n+1)(2n+1)/6
                Console.WriteLine("n = " + n + ": S(n) = " + TinhS(n) + "   (công thức = " + congThuc + ")");
            }
        }
    }
}