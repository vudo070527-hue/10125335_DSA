using System;

namespace Buoi01_DeQuy
{
    // Chương 3 - Bài 7 (trang 100-101): Đếm số chữ số của số nguyên dương n
    //   Suy biến : n == 0 thì SoChuSo(n) = 0
    //   Đệ quy   : ngược lại thì SoChuSo(n) = SoChuSo(n / 10) + 1
    //              (bỏ đi chữ số cuối cùng rồi đếm thêm 1)
    class Ch3_Bai7
    {
        static int SoChuSo(long n)
        {
            if (n == 0)                   // trường hợp suy biến: hết chữ số
                return 0;
            return SoChuSo(n / 10) + 1;   // chia 10 để bỏ chữ số cuối
        }

        public static void Chay()
        {
            Console.WriteLine("=== Chương 3 - Bài tập 7: Đếm số chữ số của n ===");
            long[] mau = { 7, 100, 12345, 1000000, 987654321012 };
            for (int i = 0; i < mau.Length; i++)
            {
                Console.WriteLine("n = " + mau[i] + ": có " + SoChuSo(mau[i]) + " chữ số");
            }
        }
    }
}