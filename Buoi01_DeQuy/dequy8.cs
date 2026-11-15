using System;

namespace Buoi01_DeQuy
{
    // Bài tập 8: Tính S(n) = sqrt(1 + sqrt(2 + sqrt(3 + ... + sqrt(n-1 + sqrt(n)))))
    // Hàm Can(i, n) tính căn lồng nhau bắt đầu từ số i đến số n:
    //   Suy biến : i == n thì Can(i, n) = sqrt(n)
    //   Đệ quy   : ngược lại Can(i, n) = sqrt(i + Can(i+1, n))
    // Khi đó S(n) = Can(1, n)
    class DeQuy8
    {
        static double Can(int i, int n)
        {
            if (i == n)                                   // trường hợp suy biến: căn trong cùng
                return Math.Sqrt(n);
            return Math.Sqrt(i + Can(i + 1, n));          // đệ quy: lấy căn của (i + căn bên trong)
        }

        static double TinhS(int n)
        {
            return Can(1, n);
        }

        public static void ChayDeQuy8()
        {
            Console.WriteLine("=== Bài tập 8: S(n) = căn lồng nhau ===");
            int[] mau = { 1, 2, 3, 4, 10 };
            for (int i = 0; i < mau.Length; i++)
            {
                Console.WriteLine("n = " + mau[i] + ": S(n) = " + TinhS(mau[i]).ToString("F6"));
            }
        }
    }
}