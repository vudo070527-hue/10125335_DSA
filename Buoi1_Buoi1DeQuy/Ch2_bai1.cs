using System;
using System.Diagnostics;

namespace Buoi01_DeQuy
{
    // Chương 2 - Bài 1 (trang 76): Tháp Hà Nội
    // Hệ thức truy hồi: T(n) = 2T(n-1) + 1, T(1) = 1
    // Giải bằng phương pháp lặp: T(n) = 2^n - 1  =>  độ phức tạp O(2^n)
    class Ch2_Bai1
    {
        static long soBuoc = 0;

        // Chuyển n đĩa từ cọc "tu" sang cọc "den", dùng cọc "trung"
        static void ThapHaNoi(int n, char tu, char den, char trung, bool inKQ)
        {
            if (n == 1)                              // suy biến: 1 đĩa chuyển thẳng
            {
                soBuoc++;
                if (inKQ) Console.WriteLine("  Chuyển đĩa 1 từ " + tu + " sang " + den);
                return;
            }
            ThapHaNoi(n - 1, tu, trung, den, inKQ);  // bài toán con 1: n-1 đĩa tu -> trung
            soBuoc++;                                // phép toán cơ bản: chuyển đĩa lớn nhất
            if (inKQ) Console.WriteLine("  Chuyển đĩa " + n + " từ " + tu + " sang " + den);
            ThapHaNoi(n - 1, trung, den, tu, inKQ);  // bài toán con 2: n-1 đĩa trung -> den
        }

        // T(n) tính trực tiếp theo hệ thức truy hồi
        static long TinhT(int n)
        {
            if (n == 1) return 1;
            return 2 * TinhT(n - 1) + 1;
        }

        static long LuyThua2(int n)
        {
            if (n == 0) return 1;
            return 2 * LuyThua2(n - 1);
        }

        public static void Chay()
        {
            Console.WriteLine("=== Chương 2 - Bài 1: Tháp Hà Nội ===");
            Console.WriteLine("Các bước chuyển với n = 3:");
            soBuoc = 0;
            ThapHaNoi(3, 'A', 'C', 'B', true);
            Console.WriteLine("Tổng số bước: " + soBuoc);
            Console.WriteLine();

            Console.WriteLine("n\tĐếm bước\tT(n) truy hồi\t2^n - 1");
            for (int n = 1; n <= 10; n++)
            {
                soBuoc = 0;
                ThapHaNoi(n, 'A', 'C', 'B', false);
                Console.WriteLine(n + "\t" + soBuoc + "\t\t" + TinhT(n) + "\t\t" + (LuyThua2(n) - 1));
            }
            Console.WriteLine();

            Console.WriteLine("Thời gian thực nghiệm (mili giây) - n tăng 1 thì thời gian tăng gấp đôi:");
            Console.WriteLine("n\tSố bước\t\tThời gian (ms)");
            int[] cacN = { 10, 15, 20, 25 };
            Stopwatch dh = new Stopwatch();
            for (int k = 0; k < cacN.Length; k++)
            {
                int n = cacN[k];
                soBuoc = 0;
                dh.Restart();
                ThapHaNoi(n, 'A', 'C', 'B', false);
                dh.Stop();
                Console.WriteLine(n + "\t" + soBuoc + "\t\t" + dh.Elapsed.TotalMilliseconds.ToString("F2"));
            }
            Console.WriteLine();
            Console.WriteLine("Kết luận: T(n) = 2^n - 1 => O(2^n)");
        }
    }
}