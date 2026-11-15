using System;

namespace Buoi01_DeQuy
{
    // Bài tập 3: Tính S(n) = 1 + 1/2 + 1/3 + ... + 1/(n-1) + 1/n
    // Trường hợp suy biến: n = 1 thì S(1) = 1
    // Trường hợp đệ quy : n > 1 thì S(n) = S(n-1) + 1.0/n
    class DeQuy3
    {
        static double TinhS(int n)
        {
            if (n == 1)                  // trường hợp suy biến
                return 1;
            return TinhS(n - 1) + 1.0 / n;   // dùng 1.0 để chia ra số thực, không bị cắt phần thập phân
        }

        public static void ChayDeQuy3()
        {
            Console.WriteLine("=== Bài tập 3: S(n) = 1 + 1/2 + ... + 1/n ===");
            int[] mau = { 1, 2, 5, 10 };
            for (int i = 0; i < mau.Length; i++)
            {
                int n = mau[i];
                Console.WriteLine("n = " + n + ": S(n) = " + TinhS(n).ToString("F6"));
            }
        }
    }
}