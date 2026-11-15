using System;

namespace Buoi01_DeQuy
{
    // Bài tập 4: Tính S(x, n) = x^n
    // Hàm LuyThua(X, N) tính X^N với N dương (N >= 0):
    //   Suy biến : N = 0 thì LuyThua(X, 0) = 1
    //   Đệ quy   : N > 0 thì LuyThua(X, N) = LuyThua(X, N-1) * X
    // Hàm S(x, n): nếu n < 0 thì x^n = 1 / x^(-n)
    class DeQuy4
    {
        static double LuyThua(double x, int n)
        {
            if (n == 0)                       // trường hợp suy biến
                return 1;
            return LuyThua(x, n - 1) * x;     // đệ quy
        }

        static double TinhS(double x, int n)
        {
            if (n < 0)
                return 1.0 / LuyThua(x, -n);  // số mũ âm: nghịch đảo của lũy thừa dương
            else
                return LuyThua(x, n);
        }

        public static void ChayDeQuy4()
        {
            Console.WriteLine("=== Bài tập 4: S(x, n) = x^n ===");
            double[] cacX = { 2, 2, 5, 1.5, -2 };
            int[] cacN = { 10, -3, 0, 4, 3 };
            for (int i = 0; i < cacX.Length; i++)
            {
                double ketQua = TinhS(cacX[i], cacN[i]);
                double kiemTra = Math.Pow(cacX[i], cacN[i]);   // so sánh với hàm có sẵn
                Console.WriteLine("S(" + cacX[i] + ", " + cacN[i] + ") = " + ketQua + "   (Math.Pow = " + kiemTra + ")");
            }
        }
    }
}