using System;

namespace Buoi01_DeQuy
{
    // Chương 3 - Bài 5 (trang 100-101): Tìm ước lẻ lớn nhất của số nguyên dương n
    // Ví dụ: n = 100 thì ước lẻ lớn nhất là 25
    //   Suy biến : n lẻ (n % 2 == 1) thì UocLeMax(n) = n
    //   Đệ quy   : ngược lại (n chẵn) thì UocLeMax(n) = UocLeMax(n / 2)
    class Ch3_Bai5
    {
        static int UocLeMax(int n)
        {
            if (n % 2 == 1)               // n lẻ thì chính n là ước lẻ lớn nhất
                return n;
            return UocLeMax(n / 2);       // n chẵn thì bỏ bớt một thừa số 2
        }

        public static void Chay()
        {
            Console.WriteLine("=== Chương 3 - Bài tập 5: Ước lẻ lớn nhất của n ===");
            int[] mau = { 100, 45, 48, 7, 96 };
            for (int i = 0; i < mau.Length; i++)
            {
                Console.WriteLine("n = " + mau[i] + ": ước lẻ lớn nhất = " + UocLeMax(mau[i]));
            }
        }
    }
}