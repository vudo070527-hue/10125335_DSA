using System;
using System.Diagnostics;

namespace Buoi01_DeQuy
{
    // Chương 2 - Bài 5 (trang 78): Tìm số Fibonacci thứ n (F0 = 0, F1 = 1, Fn = Fn-1 + Fn-2)
    //   Giải thuật 1: đệ quy trực tiếp      T(n) = T(n-1) + T(n-2) + 1  => O(2^n) (chặt hơn: O(1.618^n))
    //   Giải thuật 2: đệ quy có nhớ         => O(n), bộ nhớ O(n)
    //   Giải thuật 3: lũy thừa ma trận đệ quy chia đôi  => O(log n)
    // (Giải thuật vòng lặp O(n) đã nằm ở Chương 1 - Bài 5 nên ở đây chỉ dùng đệ quy.)
    class Ch2_Bai5
    {
        static long demGoi = 0;

        // ---------- Giải thuật 1 ----------
        static long FibDeQuy(int n)
        {
            demGoi++;
            if (n == 0) return 0;
            if (n == 1) return 1;
            return FibDeQuy(n - 1) + FibDeQuy(n - 2);
        }

        // ---------- Giải thuật 2 ----------
        static long FibNho(int n, long[] nho)
        {
            if (n == 0) return 0;
            if (n == 1) return 1;
            if (nho[n] != -1) return nho[n];         // đã tính rồi thì dùng lại
            nho[n] = FibNho(n - 1, nho) + FibNho(n - 2, nho);
            return nho[n];
        }

        static long FibMemo(int n)
        {
            long[] nho = new long[n + 2];
            for (int i = 0; i < nho.Length; i++)
                nho[i] = -1;
            return FibNho(n, nho);
        }

        // ---------- Giải thuật 3 ----------
        // [[1,1],[1,0]]^n = [[F(n+1), F(n)], [F(n), F(n-1)]]
        static long[,] NhanMaTran(long[,] a, long[,] b)
        {
            long[,] c = new long[2, 2];
            c[0, 0] = a[0, 0] * b[0, 0] + a[0, 1] * b[1, 0];
            c[0, 1] = a[0, 0] * b[0, 1] + a[0, 1] * b[1, 1];
            c[1, 0] = a[1, 0] * b[0, 0] + a[1, 1] * b[1, 0];
            c[1, 1] = a[1, 0] * b[0, 1] + a[1, 1] * b[1, 1];
            return c;
        }

        static long[,] LuyThuaMaTran(long[,] m, int n)
        {
            if (n == 1) return m;                    // suy biến
            long[,] nua = LuyThuaMaTran(m, n / 2);   // m^(n/2)
            long[,] kq = NhanMaTran(nua, nua);       // m^(2*(n/2))
            if (n % 2 == 1)
                kq = NhanMaTran(kq, m);              // n lẻ thì nhân thêm một lần m
            return kq;
        }

        static long FibMaTran(int n)
        {
            if (n == 0) return 0;
            long[,] m = { { 1, 1 }, { 1, 0 } };
            return LuyThuaMaTran(m, n)[0, 1];
        }

        public static void Chay()
        {
            Console.WriteLine("=== Chương 2 - Bài 5: Số Fibonacci thứ n (3 giải thuật đệ quy) ===");

            Console.WriteLine("n\tTrực tiếp\tCó nhớ\t\tMa trận");
            for (int n = 0; n <= 11; n++)
                Console.WriteLine(n + "\t" + FibDeQuy(n) + "\t\t" + FibMemo(n) + "\t\t" + FibMaTran(n));
            Console.WriteLine();
            Console.WriteLine("F(50): có nhớ = " + FibMemo(50) + ", ma trận = " + FibMaTran(50));
            Console.WriteLine("F(90): có nhớ = " + FibMemo(90) + ", ma trận = " + FibMaTran(90));
            Console.WriteLine();

            // Số lần gọi hàm của đệ quy trực tiếp = 2*F(n+1) - 1
            Console.WriteLine("Số lần gọi hàm của đệ quy trực tiếp:");
            Console.WriteLine("n\tSố lần gọi\t2*F(n+1)-1");
            int[] cacNGoi = { 5, 10, 20, 25, 30 };
            for (int k = 0; k < cacNGoi.Length; k++)
            {
                int n = cacNGoi[k];
                demGoi = 0;
                FibDeQuy(n);
                Console.WriteLine(n + "\t" + demGoi + "\t\t" + (2 * FibMemo(n + 1) - 1));
            }
            Console.WriteLine();

            // Thời gian thực nghiệm (micro giây / 1 lần tính)
            Console.WriteLine("Thời gian thực nghiệm (micro giây):");
            Console.WriteLine("n\tTrực tiếp\t\tCó nhớ\t\tMa trận");
            int[] cacN = { 10, 20, 30, 35 };
            Stopwatch dh = new Stopwatch();
            for (int k = 0; k < cacN.Length; k++)
            {
                int n = cacN[k];
                int lan1 = 1;
                if (n <= 20) lan1 = 1000;
                else if (n <= 30) lan1 = 5;
                int lan2 = 100000;

                dh.Restart();
                for (int r = 0; r < lan1; r++)
                    FibDeQuy(n);
                dh.Stop();
                double t1 = dh.Elapsed.TotalMilliseconds * 1000 / lan1;

                dh.Restart();
                for (int r = 0; r < lan2; r++)
                    FibMemo(n);
                dh.Stop();
                double t2 = dh.Elapsed.TotalMilliseconds * 1000 / lan2;

                dh.Restart();
                for (int r = 0; r < lan2; r++)
                    FibMaTran(n);
                dh.Stop();
                double t3 = dh.Elapsed.TotalMilliseconds * 1000 / lan2;

                Console.WriteLine(n + "\t" + t1.ToString("F2") + "\t\t" + t2.ToString("F3") + "\t\t" + t3.ToString("F3"));
            }
            Console.WriteLine();
            Console.WriteLine("Kết luận: trực tiếp O(2^n) (tính lặp rất nhiều), có nhớ O(n), ma trận O(log n).");
        }
    }
}