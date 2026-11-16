using System;
using System.Diagnostics;

namespace Buoi01_DeQuy
{
    // Chương 2 - Bài 4 (trang 78): Liệt kê các số hoàn hảo nhỏ hơn N (đệ quy)
    // Số hoàn hảo: tổng các ước (không kể chính nó) bằng chính nó, ví dụ 28 = 1 + 2 + 4 + 7 + 14.
    //   Giải thuật 1 (cơ bản)   : với mỗi số, tìm ước từ 1 đến n/2        -> O(N^2)
    //   Giải thuật 2 (cải tiến) : với mỗi số, chỉ tìm ước đến căn n       -> O(N * căn N)
    //   Giải thuật 3 (toán học) : số hoàn hảo chẵn = 2^(p-1) * (2^p - 1) với 2^p - 1 là số nguyên tố
    class Ch2_Bai4
    {
        // ---------- Giải thuật 1 ----------
        // Tổng các ước của n trong khoảng i..n/2
        static int TongUocCoBan(int n, int i)
        {
            if (i > n / 2) return 0;
            if (n % i == 0) return i + TongUocCoBan(n, i + 1);
            return TongUocCoBan(n, i + 1);
        }

        static int LietKe1(int i, int N, bool inKQ)
        {
            if (i >= N) return 0;
            int la = 0;
            if (i > 1 && TongUocCoBan(i, 1) == i)
            {
                la = 1;
                if (inKQ) Console.Write(i + " ");
            }
            return la + LietKe1(i + 1, N, inKQ);
        }

        // ---------- Giải thuật 2 ----------
        // Tổng các ước của n trong khoảng i..căn n (mỗi ước i cộng thêm ước đối n/i)
        static int TongUocCan(int n, int i)
        {
            if ((long)i * i > n) return 0;
            if (n % i == 0)
            {
                int tong = i;
                if (i != n / i)
                    tong = tong + n / i;             // tránh cộng trùng khi n là số chính phương
                return tong + TongUocCan(n, i + 1);
            }
            return TongUocCan(n, i + 1);
        }

        static int LietKe2(int i, int N, bool inKQ)
        {
            if (i >= N) return 0;
            int la = 0;
            if (i > 1 && 1 + TongUocCan(i, 2) == i)  // 1 luôn là ước nên cộng sẵn
            {
                la = 1;
                if (inKQ) Console.Write(i + " ");
            }
            return la + LietKe2(i + 1, N, inKQ);
        }

        // ---------- Giải thuật 3: Mersenne ----------
        static bool LaNguyenTo(long m, long i)
        {
            if (m < 2) return false;
            if (i * i > m) return true;
            if (m % i == 0) return false;
            return LaNguyenTo(m, i + 1);
        }

        // Thử p = 2, 3, 4, ... đến khi 2^(p-1) * (2^p - 1) >= N (nên dùng N <= 10^12 để đệ quy không quá sâu)
        static int LietKeMersenne(int p, long N, bool inKQ)
        {
            if (p > 31) return 0;
            long mersenne = (1L << p) - 1;
            long so = (1L << (p - 1)) * mersenne;
            if (so >= N) return 0;                   // các số sau chỉ lớn hơn nên dừng
            int la = 0;
            if (LaNguyenTo(mersenne, 2))
            {
                la = 1;
                if (inKQ) Console.Write(so + " ");
            }
            return la + LietKeMersenne(p + 1, N, inKQ);
        }

        public static void Chay()
        {
            Console.WriteLine("=== Chương 2 - Bài 4: Liệt kê số hoàn hảo ===");

            Console.Write("Giải thuật 1, N = 2000 : ");
            LietKe1(1, 2000, true);
            Console.WriteLine();
            Console.Write("Giải thuật 2, N = 10000: ");
            LietKe2(1, 10000, true);
            Console.WriteLine();
            Console.Write("Giải thuật 3, N = 10000: ");
            LietKeMersenne(2, 10000, true);
            Console.WriteLine();
            Console.Write("Giải thuật 3, N = 10^12: ");
            LietKeMersenne(2, 1000000000000, true);
            Console.WriteLine();
            Console.WriteLine();

            // Đo thời gian (mili giây)
            Console.WriteLine("Thời gian thực nghiệm (mili giây):");
            Console.WriteLine("N\t\tCơ bản O(N^2)\tCăn bậc 2\tMersenne");
            int[] cacN = { 1000, 2000, 5000, 10000 };
            Stopwatch dh = new Stopwatch();
            for (int k = 0; k < cacN.Length; k++)
            {
                int N = cacN[k];

                string t1 = "bỏ qua";                 // giải thuật 1 chậm và đệ quy sâu nên chỉ đo N nhỏ
                if (N <= 2000)
                {
                    dh.Restart();
                    LietKe1(1, N, false);
                    dh.Stop();
                    t1 = dh.Elapsed.TotalMilliseconds.ToString("F2");
                }

                dh.Restart();
                LietKe2(1, N, false);
                dh.Stop();
                string t2 = dh.Elapsed.TotalMilliseconds.ToString("F2");

                int lan3 = 1000;
                dh.Restart();
                for (int r = 0; r < lan3; r++)
                    LietKeMersenne(2, N, false);
                dh.Stop();
                string t3 = (dh.Elapsed.TotalMilliseconds / lan3).ToString("F4");

                Console.WriteLine(N + "\t\t" + t1 + "\t\t" + t2 + "\t\t" + t3);
            }
            Console.WriteLine();
            Console.WriteLine("Kết luận: GT1 O(N^2), GT2 O(N*căn N), GT3 gần như tức thì (nhưng chỉ cho số hoàn hảo chẵn).");
        }
    }
}