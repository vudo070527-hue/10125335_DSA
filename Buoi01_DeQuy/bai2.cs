using System;
using System.Diagnostics;
using System.Text;

namespace Buoi01_DeQuy
{
    // Bài tập 2: Tìm kiếm nhị phân (Binary Search)
    // Hệ thức truy hồi: T(n) = T(n/2) + 1, với T(1) = 1
    // Kết quả: T(n) = log2(n) + 1  =>  độ phức tạp O(log n)
    //
    // Cài đặt 3 giải thuật để so sánh:
    //   1. Tìm kiếm tuần tự (Linear Search)        - O(n)
    //   2. Tìm kiếm nhị phân dùng vòng lặp         - O(log n)
    //   3. Tìm kiếm nhị phân dùng đệ quy           - O(log n), đúng với T(n) = T(n/2) + 1

    class Bai2
    {
        // Biến đếm số lần so sánh (để minh họa số bước thực tế)
        static long demSoSanh = 0;

        // ---------- Giải thuật 1: Tìm kiếm tuần tự ----------
        // Trả về vị trí của x trong mảng a, không có thì trả về -1
        static int TimTuanTu(int[] a, int n, int x)
        {
            for (int i = 0; i < n; i++)
            {
                demSoSanh++;
                if (a[i] == x)
                    return i;
            }
            return -1;
        }

        // ---------- Giải thuật 2: Tìm nhị phân (vòng lặp) ----------
        static int TimNhiPhanLap(int[] a, int n, int x)
        {
            int trai = 0;
            int phai = n - 1;

            while (trai <= phai)
            {
                int giua = trai + (phai - trai) / 2; // tránh tràn số khi trai + phai quá lớn
                demSoSanh++;
                if (a[giua] == x)
                    return giua;
                else if (a[giua] < x)
                    trai = giua + 1;   // x nằm nửa bên phải
                else
                    phai = giua - 1;   // x nằm nửa bên trái
            }
            return -1;
        }

        // ---------- Giải thuật 3: Tìm nhị phân (đệ quy) ----------
        static int TimNhiPhanDeQuy(int[] a, int trai, int phai, int x)
        {
            // Trường hợp cơ sở: mảng con rỗng => không tìm thấy
            if (trai > phai)
                return -1;

            int giua = trai + (phai - trai) / 2;
            demSoSanh++;
            if (a[giua] == x)
                return giua;
            else if (a[giua] < x)
                return TimNhiPhanDeQuy(a, giua + 1, phai, x); // 1 bài toán con kích thước n/2
            else
                return TimNhiPhanDeQuy(a, trai, giua - 1, x); // 1 bài toán con kích thước n/2
        }

        // Tạo mảng đã sắp xếp tăng dần: 0, 2, 4, 6, ... (toàn số chẵn)
        static int[] TaoMang(int n)
        {
            int[] a = new int[n];
            for (int i = 0; i < n; i++)
                a[i] = 2 * i;
            return a;
        }

        // Tính T(n) theo hệ thức truy hồi T(n) = T(n/2) + 1 để đối chiếu lý thuyết
        static int TinhTheoTruyHoi(int n)
        {
            if (n <= 1) return 1;        // T(1) = 1
            return TinhTheoTruyHoi(n / 2) + 1;
        }

        public static void ChayBai2()
        {
            Console.OutputEncoding = Encoding.UTF8;

            // ===== Phần 1: chạy thử với dữ liệu mẫu =====
            Console.WriteLine("=== Chạy thử với mảng mẫu ===");
            int[] mau = { 2, 5, 8, 12, 16, 23, 38, 56, 72, 91 };
            int nMau = mau.Length;
            int x1 = 23; // có trong mảng
            int x2 = 50; // không có trong mảng

            Console.WriteLine("Mảng: " + string.Join(", ", mau));
            Console.WriteLine("Tìm x = " + x1);
            Console.WriteLine("  Tuần tự     : vị trí " + TimTuanTu(mau, nMau, x1));
            Console.WriteLine("  Nhị phân lặp: vị trí " + TimNhiPhanLap(mau, nMau, x1));
            Console.WriteLine("  Nhị phân đệ quy: vị trí " + TimNhiPhanDeQuy(mau, 0, nMau - 1, x1));
            Console.WriteLine("Tìm x = " + x2 + " (không có, kết quả -1)");
            Console.WriteLine("  Tuần tự     : " + TimTuanTu(mau, nMau, x2));
            Console.WriteLine("  Nhị phân lặp: " + TimNhiPhanLap(mau, nMau, x2));
            Console.WriteLine("  Nhị phân đệ quy: " + TimNhiPhanDeQuy(mau, 0, nMau - 1, x2));
            Console.WriteLine();

            // ===== Phần 2: đếm số phép so sánh (trường hợp xấu nhất) =====
            Console.WriteLine("=== Số phép so sánh trong trường hợp xấu nhất (x không có trong mảng) ===");
            Console.WriteLine("n\t\tTuần tự\t\tNhị phân\tT(n) truy hồi\tlog2(n)+1");
            int[] cacN = { 10, 100, 1000, 10000, 100000, 1000000 };
            for (int k = 0; k < cacN.Length; k++)
            {
                int n = cacN[k];
                int[] a = TaoMang(n);
                int x = 2 * n - 1; // số lẻ lớn hơn mọi phần tử => chắc chắn không có

                demSoSanh = 0;
                TimTuanTu(a, n, x);
                long soSanhTuanTu = demSoSanh;

                demSoSanh = 0;
                TimNhiPhanLap(a, n, x);
                long soSanhNhiPhan = demSoSanh;

                double lyThuyet = Math.Floor(Math.Log(n, 2)) + 1;
                Console.WriteLine(n + "\t\t" + soSanhTuanTu + "\t\t" + soSanhNhiPhan + "\t\t" + TinhTheoTruyHoi(n) + "\t\t" + lyThuyet);
            }
            Console.WriteLine();

            // ===== Phần 3: đo thời gian thực nghiệm =====
            Console.WriteLine("=== Đo thời gian thực nghiệm (trung bình 1 lần tìm, đơn vị nano giây) ===");
            Console.WriteLine("n\t\tTuần tự\t\tNhị phân lặp\tNhị phân đệ quy");
            int[] cacN2 = { 1000, 10000, 100000, 1000000, 10000000 };
            for (int k = 0; k < cacN2.Length; k++)
            {
                int n = cacN2[k];
                int[] a = TaoMang(n);
                int x = 2 * n - 1; // trường hợp xấu nhất

                // Tìm nhị phân rất nhanh nên phải lặp nhiều lần rồi lấy trung bình
                int soLanNhiPhan = 200000;
                // Tìm tuần tự chậm nên lặp ít hơn khi n lớn
                int soLanTuanTu = 20000000 / n;
                if (soLanTuanTu < 1) soLanTuanTu = 1;

                Stopwatch dongHo = new Stopwatch();

                // Đo tuần tự
                dongHo.Start();
                for (int i = 0; i < soLanTuanTu; i++)
                    TimTuanTu(a, n, x);
                dongHo.Stop();
                double tgTuanTu = dongHo.Elapsed.TotalMilliseconds * 1000000 / soLanTuanTu;

                // Đo nhị phân lặp
                dongHo.Restart();
                for (int i = 0; i < soLanNhiPhan; i++)
                    TimNhiPhanLap(a, n, x);
                dongHo.Stop();
                double tgLap = dongHo.Elapsed.TotalMilliseconds * 1000000 / soLanNhiPhan;

                // Đo nhị phân đệ quy
                dongHo.Restart();
                for (int i = 0; i < soLanNhiPhan; i++)
                    TimNhiPhanDeQuy(a, 0, n - 1, x);
                dongHo.Stop();
                double tgDeQuy = dongHo.Elapsed.TotalMilliseconds * 1000000 / soLanNhiPhan;

                Console.WriteLine(n + "\t\t" + tgTuanTu.ToString("F1") + "\t\t" + tgLap.ToString("F1") + "\t\t" + tgDeQuy.ToString("F1"));
            }
            Console.WriteLine();

            // ===== Kết luận =====
            Console.WriteLine("Kết luận:");
            Console.WriteLine("- Tìm tuần tự : tốt nhất Omega(1), xấu nhất O(n)");
            Console.WriteLine("- Tìm nhị phân: tốt nhất Omega(1), xấu nhất Theta(log n)");
            Console.WriteLine("- T(n) = T(n/2) + 1, T(1) = 1  =>  T(n) = log2(n) + 1 = O(log n)");
            Console.WriteLine("- Khi n tăng 10 lần, tìm tuần tự chậm ~10 lần, còn nhị phân gần như không đổi.");
        }
    }
}