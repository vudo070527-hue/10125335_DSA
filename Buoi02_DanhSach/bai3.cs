using System;
using System.Diagnostics;

namespace Buoi01_DeQuy
{
    // Bài tập 3 (Chương 2): Kiểm tra số nguyên tố
    //   Giải thuật 1 (cơ bản)   : duyệt i từ 2 đến n-1                 -> O(n)
    //   Giải thuật 2 (cải tiến) : duyệt i từ 2 đến căn bậc hai của n   -> O(căn n)
    //   Giải thuật 3 (nâng cao) : Miller-Rabin (xác định với n < 3,2 tỉ) -> O(log n) phép nhân modulo
    // Lý do giải thuật 2 đúng: nếu n = a*b thì có ít nhất một thừa số <= căn n.
    class Bai3
    {
        // Biến đếm số phép chia (để minh họa số bước thực tế)
        static long demChia = 0;

        // ---------- Giải thuật 1: duyệt từ 2 đến n-1 ----------
        static bool NguyenToCoBan(int n)
        {
            if (n < 2) return false;
            for (int i = 2; i <= n - 1; i++)
            {
                demChia++;
                if (n % i == 0)
                    return false;      // tìm được ước => không phải số nguyên tố
            }
            return true;
        }

        // ---------- Giải thuật 2: duyệt từ 2 đến căn n ----------
        static bool NguyenToCanBacHai(int n)
        {
            if (n < 2) return false;
            // Dùng kiểu long cho i để i*i không bị tràn số khi n gần 2 tỉ
            for (long i = 2; i * i <= n; i++)
            {
                demChia++;
                if (n % i == 0)
                    return false;
            }
            return true;
        }

        // ---------- Giải thuật 3: Miller-Rabin ----------
        // Tính (co ^ mu) % mod bằng lũy thừa nhanh
        static long LuyThuaMod(long co, long mu, long mod)
        {
            long kq = 1;
            co = co % mod;
            while (mu > 0)
            {
                if (mu % 2 == 1)
                    kq = kq * co % mod;
                co = co * co % mod;
                mu = mu / 2;
            }
            return kq;
        }

        static bool MillerRabin(int soN)
        {
            long n = soN;
            if (n < 2) return false;

            // Xử lý nhanh các số nguyên tố nhỏ và bội của chúng
            long[] cacCoSo = { 2, 3, 5, 7 };
            for (int i = 0; i < cacCoSo.Length; i++)
            {
                if (n == cacCoSo[i]) return true;
                if (n % cacCoSo[i] == 0) return false;
            }

            // Viết n - 1 = d * 2^r với d lẻ
            long d = n - 1;
            int r = 0;
            while (d % 2 == 0)
            {
                d = d / 2;
                r++;
            }

            // Thử với các cơ số 2, 3, 5, 7 (đủ chính xác cho mọi n < 3.215.031.751)
            for (int i = 0; i < cacCoSo.Length; i++)
            {
                long x = LuyThuaMod(cacCoSo[i], d, n);
                if (x == 1 || x == n - 1)
                    continue;

                bool coTheNguyenTo = false;
                for (int j = 1; j < r; j++)
                {
                    x = x * x % n;
                    if (x == n - 1)
                    {
                        coTheNguyenTo = true;
                        break;
                    }
                }
                if (!coTheNguyenTo)
                    return false;   // chắc chắn là hợp số
            }
            return true;
        }

        public static void ChayBai3()
        {
            // ===== Phần 1: chạy thử với dữ liệu mẫu =====
            Console.WriteLine("=== Chạy thử kiểm tra số nguyên tố ===");
            int[] mau = { 1, 2, 3, 4, 17, 25, 97, 100, 7919, 1000000007 };
            Console.WriteLine("n\t\tCơ bản\tCăn n\tMiller-Rabin");
            for (int i = 0; i < mau.Length; i++)
            {
                int n = mau[i];
                string kq1 = "?";
                if (n <= 100000007)   // số quá lớn thì giải thuật 1 chạy rất lâu nên bỏ qua
                    kq1 = NguyenToCoBan(n) ? "Có" : "Không";
                string kq2 = NguyenToCanBacHai(n) ? "Có" : "Không";
                string kq3 = MillerRabin(n) ? "Có" : "Không";
                Console.WriteLine(n + "\t\t" + kq1 + "\t" + kq2 + "\t" + kq3);
            }
            Console.WriteLine();

            // ===== Phần 2: kiểm tra 3 giải thuật cho cùng kết quả =====
            Console.WriteLine("=== Đếm số nguyên tố từ 1 đến 10000 (đáp án đúng: 1229) ===");
            int dem1 = 0, dem2 = 0, dem3 = 0;
            for (int n = 1; n <= 10000; n++)
            {
                if (NguyenToCoBan(n)) dem1++;
                if (NguyenToCanBacHai(n)) dem2++;
                if (MillerRabin(n)) dem3++;
            }
            Console.WriteLine("Cơ bản: " + dem1 + ", Căn n: " + dem2 + ", Miller-Rabin: " + dem3);
            Console.WriteLine();

            // ===== Phần 3: đếm số phép chia khi n là số nguyên tố (trường hợp xấu nhất) =====
            Console.WriteLine("=== Số phép chia khi n là số nguyên tố ===");
            Console.WriteLine("n\t\tCơ bản (n-2)\tCăn n\t\tcăn n");
            int[] cacNT = { 1009, 100003, 1000003, 10000019 };
            for (int k = 0; k < cacNT.Length; k++)
            {
                int n = cacNT[k];
                demChia = 0;
                NguyenToCoBan(n);
                long chia1 = demChia;
                demChia = 0;
                NguyenToCanBacHai(n);
                long chia2 = demChia;
                Console.WriteLine(n + "\t\t" + chia1 + "\t\t" + chia2 + "\t\t" + Math.Sqrt(n).ToString("F1"));
            }
            Console.WriteLine();

            // ===== Phần 4: đo thời gian thực nghiệm (micro giây / 1 lần kiểm tra) =====
            Console.WriteLine("=== Thời gian thực nghiệm với n là số nguyên tố (micro giây) ===");
            Console.WriteLine("n\t\tCơ bản\t\tCăn n\t\tMiller-Rabin");
            int[] cacN = { 1009, 100003, 1000003, 10000019, 100000007, 1000000007, 2147483647 };
            Stopwatch dongHo = new Stopwatch();
            for (int k = 0; k < cacN.Length; k++)
            {
                int n = cacN[k];

                // Giải thuật 1 quá chậm với n lớn nên chỉ đo đến 100000007
                string tg1 = "bỏ qua";
                if (n <= 100000007)
                {
                    int lan1 = 20000000 / n;
                    if (lan1 < 1) lan1 = 1;
                    dongHo.Restart();
                    for (int i = 0; i < lan1; i++)
                        NguyenToCoBan(n);
                    dongHo.Stop();
                    tg1 = (dongHo.Elapsed.TotalMilliseconds * 1000 / lan1).ToString("F1");
                }

                int lan2 = 1000;
                dongHo.Restart();
                for (int i = 0; i < lan2; i++)
                    NguyenToCanBacHai(n);
                dongHo.Stop();
                string tg2 = (dongHo.Elapsed.TotalMilliseconds * 1000 / lan2).ToString("F1");

                int lan3 = 100000;
                dongHo.Restart();
                for (int i = 0; i < lan3; i++)
                    MillerRabin(n);
                dongHo.Stop();
                string tg3 = (dongHo.Elapsed.TotalMilliseconds * 1000 / lan3).ToString("F3");

                Console.WriteLine(n + "\t" + tg1 + "\t\t" + tg2 + "\t\t" + tg3);
            }
            Console.WriteLine();

            Console.WriteLine("Kết luận:");
            Console.WriteLine("- Giải thuật 1: O(n)        (tốt nhất Omega(1) khi n chẵn, xấu nhất khi n nguyên tố)");
            Console.WriteLine("- Giải thuật 2: O(căn n)    (nhanh hơn rất nhiều so với O(n))");
            Console.WriteLine("- Miller-Rabin: O(log n) phép nhân modulo cho mỗi cơ sở thử");
        }
    }
}