using System;

namespace Buoi01_DeQuy
{
    // Bài tập 1: Tính S(n) = 1 + 2 + 3 + ... + (n-1) + n
    // Trường hợp suy biến: n = 1 thì S(1) = 1
    // Trường hợp đệ quy : n > 1 thì S(n) = S(n-1) + n
    class DeQuy1
    {
        static long TinhS(int n)
        {
            if (n == 1)                 // trường hợp suy biến
                return 1;
            return TinhS(n - 1) + n;    // đệ quy: tổng của n-1 số đầu cộng thêm n
        }

        public static void ChayDeQuy1()
        {
            Console.WriteLine("=== Bài tập 1: S(n) = 1 + 2 + ... + n ===");
            int[] mau = { 1, 5, 10, 100 };
            for (int i = 0; i < mau.Length; i++)
            {
                int n = mau[i];
                long congThuc = (long)n * (n + 1) / 2;   // dùng công thức n(n+1)/2 để kiểm tra
                Console.WriteLine("n = " + n + ": S(n) = " + TinhS(n) + "   (công thức n(n+1)/2 = " + congThuc + ")");
            }
        }
    }
}