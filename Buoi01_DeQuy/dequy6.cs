using System;

namespace Buoi01_DeQuy
{
    // Bài tập 6: Tìm ước chung lớn nhất của 2 số nguyên dương a, b (thuật toán Euclid)
    //   Suy biến : a % b == 0 thì UCLN(a, b) = b
    //   Đệ quy   : ngược lại thì UCLN(a, b) = UCLN(b, a % b)
    class DeQuy6
    {
        static int UCLN(int a, int b)
        {
            if (a % b == 0)               // trường hợp suy biến: b chia hết a
                return b;
            return UCLN(b, a % b);        // đệ quy: thay (a, b) bằng (b, phần dư)
        }

        public static void ChayDeQuy6()
        {
            Console.WriteLine("=== Bài tập 6: Ước chung lớn nhất (Euclid) ===");
            int[] cacA = { 48, 100, 17, 1071, 12 };
            int[] cacB = { 18, 25, 5, 462, 30 };
            for (int i = 0; i < cacA.Length; i++)
            {
                Console.WriteLine("UCLN(" + cacA[i] + ", " + cacB[i] + ") = " + UCLN(cacA[i], cacB[i]));
            }
        }
    }
}