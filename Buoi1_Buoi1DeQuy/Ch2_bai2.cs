using System;
using System.Diagnostics;

namespace Buoi01_DeQuy
{
    // Chương 2 - Bài 2 (trang 77): Tìm kiếm nhị phân (Binary Search)
    // Hệ thức truy hồi: T(n) = T(n/2) + 1, T(1) = 1
    // Phương pháp lặp (n = 2^k): T(n) = T(1) + k = log2(n) + 1  =>  O(log n)
    // Định lý Master: a = 1, b = 2, f(n) = 1 = n^0  => trường hợp 2  => Theta(log n)
    //
    // Hai giải thuật (đều đệ quy):  1. Tìm tuần tự O(n)   2. Tìm nhị phân O(log n)
    class Ch2_Bai2
    {
        static long soSoSanh = 0;

        // ---------- Giải thuật 1: tìm tuần tự (đệ quy) ----------
        static int TimTuanTu(int[] a, int i, int n, int x)
        {
            if (i >= n) return -1;                   // suy biến: hết mảng
            soSoSanh++;
            if (a[i] == x) return i;
            return TimTuanTu(a, i + 1, n, x);
        }

        // ---------- Giải thuật 2: tìm nhị phân (đệ quy) ----------
        static int TimNhiPhan(int[] a, int trai, int phai, int x)
        {
            if (trai > phai) return -1;              // suy biến: mảng con rỗng
            soSoSanh++;
            int giua = trai + (phai - trai) / 2;
            if (a[giua] == x) return giua;
            if (a[giua] < x) return TimNhiPhan(a, giua + 1, phai, x);   // 1 bài toán con kích thước n/2
            return TimNhiPhan(a, trai, giua - 1, x);
        }

        // T(n) = T(n/2) + 1 tính theo truy hồi
        static int TinhT(int n)
        {
            if (n <= 1) return 1;
            return TinhT(n / 2) + 1;
        }

        static int[] TaoMang(int n)
        {
            int[] a = new int[n];
            for (int i = 0; i < n; i++)
                a[i] = 2 * i;                        // mảng tăng dần: 0, 2, 4, ...
            return a;
        }

        public static void Chay()
        {
            Console.WriteLine("=== Chương 2 - Bài 2: Tìm kiếm nhị phân ===");

            int[] mau = { 2, 5, 8, 12, 16, 23, 38, 56, 72, 91 };
            Console.WriteLine("Mảng: " + string.Join(" ", mau));
            Console.WriteLine("Tìm 23: tuần tự -> " + TimTuanTu(mau, 0, mau.Length, 23) + ", nhị phân -> " + TimNhiPhan(mau, 0, mau.Length - 1, 23));
            Console.WriteLine("Tìm 50: tuần tự -> " + TimTuanTu(mau, 0, mau.Length, 50) + ", nhị phân -> " + TimNhiPhan(mau, 0, mau.Length - 1, 50) + " (không có)");
            Console.WriteLine();

            // Số phép so sánh trong trường hợp xấu nhất (x không có trong mảng)
            Console.WriteLine("Số phép so sánh (trường hợp xấu nhất):");
            Console.WriteLine("n\tTuần tự\tNhị phân\tT(n) truy hồi\tlog2(n)+1");
            int[] cacN = { 100, 1000, 5000 };
            for (int k = 0; k < cacN.Length; k++)
            {
                int n = cacN[k];
                int[] a = TaoMang(n);
                int x = 2 * n - 1;                   // số lẻ lớn hơn mọi phần tử
                soSoSanh = 0;
                TimTuanTu(a, 0, n, x);
                long s1 = soSoSanh;
                soSoSanh = 0;
                TimNhiPhan(a, 0, n - 1, x);
                long s2 = soSoSanh;
                Console.WriteLine(n + "\t" + s1 + "\t" + s2 + "\t\t" + TinhT(n) + "\t\t" + (Math.Floor(Math.Log(n, 2)) + 1));
            }
            Console.WriteLine();

            // Thời gian thực nghiệm (micro giây / 1 lần tìm), lặp nhiều lần rồi lấy trung bình
            Console.WriteLine("Thời gian thực nghiệm (micro giây / 1 lần tìm):");
            Console.WriteLine("n\t\tTuần tự\t\tNhị phân\tSố so sánh nhị phân");
            int[] cacN2 = { 1000, 5000, 1000000, 10000000 };
            Stopwatch dh = new Stopwatch();
            for (int k = 0; k < cacN2.Length; k++)
            {
                int n = cacN2[k];
                int[] a = TaoMang(n);
                int x = 2 * n - 1;

                string tg1 = "bỏ qua";                // đệ quy tuần tự quá sâu khi n lớn nên chỉ đo n nhỏ
                if (n <= 5000)
                {
                    int lan1 = 2000;
                    dh.Restart();
                    for (int r = 0; r < lan1; r++)
                        TimTuanTu(a, 0, n, x);
                    dh.Stop();
                    tg1 = (dh.Elapsed.TotalMilliseconds * 1000 / lan1).ToString("F2");
                }

                int lan2 = 200000;
                dh.Restart();
                for (int r = 0; r < lan2; r++)
                    TimNhiPhan(a, 0, n - 1, x);
                dh.Stop();
                string tg2 = (dh.Elapsed.TotalMilliseconds * 1000 / lan2).ToString("F3");

                soSoSanh = 0;
                TimNhiPhan(a, 0, n - 1, x);
                Console.WriteLine(n + "\t\t" + tg1 + "\t\t" + tg2 + "\t\t" + soSoSanh);
            }
            Console.WriteLine();
            Console.WriteLine("Kết luận: tuần tự O(n), nhị phân Theta(log n) (tốt nhất của cả hai là Omega(1)).");
        }
    }
}