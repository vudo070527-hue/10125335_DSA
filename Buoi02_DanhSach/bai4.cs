using System;
using System.Diagnostics;

namespace Buoi01_DeQuy
{
    // Bài tập 4 (Chương 2): Liệt kê các số hoàn hảo nhỏ hơn N
    // Số hoàn hảo: tổng các ước (không kể chính nó) bằng chính nó. Ví dụ 28 = 1 + 2 + 4 + 7 + 14.
    //   Giải thuật 1 (cơ bản)   : với mỗi i, tìm ước từ 1 đến i-1       -> O(N^2)
    //   Giải thuật 2 (cải tiến) : với mỗi i, chỉ duyệt ước đến căn i    -> O(N * căn N)
    //   Giải thuật 3 (toán học) : số hoàn hảo chẵn có dạng 2^(p-1) * (2^p - 1)
    //                             với (2^p - 1) là số nguyên tố Mersenne -> rất nhanh
    class Bai4
    {
        // ---------- Giải thuật 1 ----------
        static bool HoanHaoCoBan(int n)
        {
            int tong = 0;
            for (int i = 1; i <= n - 1; i++)
            {
                if (n % i == 0)
                    tong = tong + i;
            }
            return n > 1 && tong == n;
        }

        static int LietKeCoBan(int N, bool inKetQua)
        {
            int dem = 0;
            for (int i = 1; i < N; i++)
            {
                if (HoanHaoCoBan(i))
                {
                    dem++;
                    if (inKetQua) Console.Write(i + " ");
                }
            }
            return dem;
        }

        // ---------- Giải thuật 2 ----------
        static bool HoanHaoCanBacHai(int n)
        {
            if (n < 2) return false;
            int tong = 1;   // 1 là ước của mọi số n > 1
            for (int i = 2; (long)i * i <= n; i++)
            {
                if (n % i == 0)
                {
                    tong = tong + i;            // ước nhỏ i
                    if (i != n / i)
                        tong = tong + n / i;    // ước lớn tương ứng n / i (tránh cộng trùng khi n là số chính phương)
                }
            }
            return tong == n;
        }

        static int LietKeCanBacHai(int N, bool inKetQua)
        {
            int dem = 0;
            for (int i = 1; i < N; i++)
            {
                if (HoanHaoCanBacHai(i))
                {
                    dem++;
                    if (inKetQua) Console.Write(i + " ");
                }
            }
            return dem;
        }

        // ---------- Giải thuật 3: dùng tính chất số Mersenne ----------
        // Kiểm tra số nguyên tố bằng cách chia thử đến căn m
        static bool LaNguyenTo(long m)
        {
            if (m < 2) return false;
            for (long i = 2; i * i <= m; i++)
            {
                if (m % i == 0)
                    return false;
            }
            return true;
        }

        // Chỉ tìm được các số hoàn hảo chẵn (số hoàn hảo lẻ đến nay chưa ai tìm ra)
        static int LietKeMersenne(long N, bool inKetQua)
        {
            int dem = 0;
            for (int p = 2; p <= 31; p++)
            {
                long mersenne = (1L << p) - 1;              // 2^p - 1
                long so = (1L << (p - 1)) * mersenne;       // 2^(p-1) * (2^p - 1)
                if (so >= N)
                    break;                                  // các số sau chỉ lớn hơn nên dừng
                if (LaNguyenTo(mersenne))
                {
                    dem++;
                    if (inKetQua) Console.Write(so + " ");
                }
            }
            return dem;
        }

        public static void ChayBai4()
        {
            // ===== Phần 1: chạy thử =====
            int N = 10000;
            Console.WriteLine("=== Các số hoàn hảo nhỏ hơn " + N + " ===");
            Console.Write("Giải thuật 1 (cơ bản)  : ");
            LietKeCoBan(N, true);
            Console.WriteLine();
            Console.Write("Giải thuật 2 (căn bậc 2): ");
            LietKeCanBacHai(N, true);
            Console.WriteLine();
            Console.Write("Giải thuật 3 (Mersenne) : ");
            LietKeMersenne(N, true);
            Console.WriteLine();
            Console.WriteLine();

            long Nlon = 1000000000000;
            Console.Write("Giải thuật 3 với N = 10^12: ");
            LietKeMersenne(Nlon, true);
            Console.WriteLine();
            Console.WriteLine();

            // ===== Phần 2: đo thời gian thực nghiệm (mili giây) =====
            Console.WriteLine("=== Thời gian thực nghiệm (mili giây) ===");
            Console.WriteLine("N\t\tCơ bản O(N^2)\tCăn bậc 2\tMersenne");
            int[] cacN = { 1000, 5000, 10000, 20000, 100000, 1000000 };
            Stopwatch dongHo = new Stopwatch();
            for (int k = 0; k < cacN.Length; k++)
            {
                int n = cacN[k];

                // Giải thuật 1 là O(N^2) nên chỉ đo đến N = 20000
                string tg1 = "bỏ qua";
                if (n <= 20000)
                {
                    dongHo.Restart();
                    LietKeCoBan(n, false);
                    dongHo.Stop();
                    tg1 = dongHo.Elapsed.TotalMilliseconds.ToString("F2");
                }

                dongHo.Restart();
                LietKeCanBacHai(n, false);
                dongHo.Stop();
                string tg2 = dongHo.Elapsed.TotalMilliseconds.ToString("F2");

                int lan3 = 1000;
                dongHo.Restart();
                for (int i = 0; i < lan3; i++)
                    LietKeMersenne(n, false);
                dongHo.Stop();
                string tg3 = (dongHo.Elapsed.TotalMilliseconds / lan3).ToString("F4");

                Console.WriteLine(n + "\t\t" + tg1 + "\t\t" + tg2 + "\t\t" + tg3);
            }
            Console.WriteLine();

            Console.WriteLine("Kết luận:");
            Console.WriteLine("- Giải thuật 1: O(N^2)");
            Console.WriteLine("- Giải thuật 2: O(N * căn N)");
            Console.WriteLine("- Giải thuật 3: chỉ thử vài chục giá trị p, gần như tức thì (nhưng chỉ cho số hoàn hảo chẵn)");
        }
    }
}