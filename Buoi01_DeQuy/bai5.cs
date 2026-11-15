using System;
using System.Diagnostics;
using System.Text;

namespace Buoi01_DeQuy
{
    // Bài tập 5: Tìm số Fibonacci thứ n
    // F0 = 0, F1 = 1, Fn = Fn-1 + Fn-2 (n >= 2)
    //
    // Cài đặt 4 giải thuật:
    //   1. Đệ quy trực tiếp        - O(2^n) (chặt hơn: O(1.618^n))
    //   2. Vòng lặp                - O(n), bộ nhớ phụ O(1)
    //   3. Đệ quy có nhớ (Memo)    - O(n), bộ nhớ phụ O(n)
    //   4. Lũy thừa ma trận        - O(log n)
    //
    // Lưu ý: kiểu long chứa được tối đa đến F(92), nên chỉ thử n <= 90.

    class Bai5
    {
        // Biến đếm số lần gọi hàm của giải thuật đệ quy trực tiếp
        static long demGoi = 0;

        // ---------- Giải thuật 1: Đệ quy trực tiếp ----------
        // Hệ thức thời gian: T(n) = T(n-1) + T(n-2) + 1
        static long FibDeQuy(int n)
        {
            demGoi++;
            if (n == 0) return 0;   // F0 = 0
            if (n == 1) return 1;   // F1 = 1
            return FibDeQuy(n - 1) + FibDeQuy(n - 2);
        }

        // ---------- Giải thuật 2: Vòng lặp ----------
        static long FibLap(int n)
        {
            if (n == 0) return 0;
            if (n == 1) return 1;

            long truoc = 0;   // F(i-2)
            long sau = 1;     // F(i-1)
            long ketQua = 0;
            for (int i = 2; i <= n; i++)
            {
                ketQua = truoc + sau;  // F(i) = F(i-2) + F(i-1)
                truoc = sau;           // dịch cửa sổ lên một bước
                sau = ketQua;
            }
            return ketQua;
        }

        // ---------- Giải thuật 3: Đệ quy có nhớ (Memoization) ----------
        // Mảng nho[i] lưu F(i) đã tính, -1 nghĩa là chưa tính
        static long FibCoNho(int n, long[] nho)
        {
            if (n == 0) return 0;
            if (n == 1) return 1;

            // Nếu đã tính rồi thì lấy ra dùng luôn, không tính lại
            if (nho[n] != -1)
                return nho[n];

            nho[n] = FibCoNho(n - 1, nho) + FibCoNho(n - 2, nho);
            return nho[n];
        }

        // Hàm bao ngoài: tạo mảng nhớ rồi gọi hàm đệ quy
        static long FibMemo(int n)
        {
            long[] nho = new long[n + 2];
            for (int i = 0; i < nho.Length; i++)
                nho[i] = -1;
            return FibCoNho(n, nho);
        }

        // ---------- Giải thuật 4: Lũy thừa ma trận ----------
        // Ta có: [[1,1],[1,0]]^n = [[F(n+1), F(n)], [F(n), F(n-1)]]
        // Dùng lũy thừa nhanh (bình phương liên tiếp) nên chỉ cần O(log n) phép nhân ma trận

        // Nhân hai ma trận 2x2
        static long[,] NhanMaTran(long[,] a, long[,] b)
        {
            long[,] c = new long[2, 2];
            c[0, 0] = a[0, 0] * b[0, 0] + a[0, 1] * b[1, 0];
            c[0, 1] = a[0, 0] * b[0, 1] + a[0, 1] * b[1, 1];
            c[1, 0] = a[1, 0] * b[0, 0] + a[1, 1] * b[1, 0];
            c[1, 1] = a[1, 0] * b[0, 1] + a[1, 1] * b[1, 1];
            return c;
        }

        static long FibMaTran(int n)
        {
            if (n == 0) return 0;

            long[,] kq = { { 1, 0 }, { 0, 1 } };  // ma trận đơn vị
            long[,] m = { { 1, 1 }, { 1, 0 } };   // ma trận cơ sở

            while (n > 0)
            {
                // Nếu bit hiện tại của n là 1 thì nhân kết quả với m
                if (n % 2 == 1)
                    kq = NhanMaTran(kq, m);
                n = n / 2;
                // Chỉ bình phương m khi còn bit tiếp theo (tránh tràn số không cần thiết)
                if (n > 0)
                    m = NhanMaTran(m, m);
            }
            return kq[0, 1];  // phần tử F(n)
        }

        public static void ChayBai5()
        {
            Console.OutputEncoding = Encoding.UTF8;

            // ===== Phần 1: chạy thử với dữ liệu mẫu =====
            Console.WriteLine("=== Chạy thử: 12 số Fibonacci đầu tiên ===");
            Console.WriteLine("n\tĐệ quy\tLặp\tMemo\tMa trận");
            for (int i = 0; i <= 11; i++)
            {
                Console.WriteLine(i + "\t" + FibDeQuy(i) + "\t" + FibLap(i) + "\t" + FibMemo(i) + "\t" + FibMaTran(i));
            }
            Console.WriteLine();

            int nMau = 50;
            Console.WriteLine("F(" + nMau + ") theo các cách (không dùng đệ quy trực tiếp vì quá chậm):");
            Console.WriteLine("  Lặp    : " + FibLap(nMau));
            Console.WriteLine("  Memo   : " + FibMemo(nMau));
            Console.WriteLine("  Ma trận: " + FibMaTran(nMau));
            Console.WriteLine();

            // ===== Phần 2: đếm số lần gọi hàm của đệ quy trực tiếp =====
            Console.WriteLine("=== Số lần gọi hàm của đệ quy trực tiếp ===");
            Console.WriteLine("n\tF(n)\t\tSố lần gọi\t2*F(n+1)-1");
            int[] cacNGoi = { 5, 10, 20, 25, 30 };
            for (int k = 0; k < cacNGoi.Length; k++)
            {
                int n = cacNGoi[k];
                demGoi = 0;
                long f = FibDeQuy(n);
                long congThuc = 2 * FibLap(n + 1) - 1;
                Console.WriteLine(n + "\t" + f + "\t\t" + demGoi + "\t\t" + congThuc);
            }
            Console.WriteLine();

            // ===== Phần 3: đo thời gian thực nghiệm (đơn vị: micro giây) =====
            Console.WriteLine("=== Thời gian thực nghiệm - so sánh 4 giải thuật (micro giây / 1 lần tính) ===");
            Console.WriteLine("n\tĐệ quy\t\tLặp\t\tMemo\t\tMa trận");
            int[] cacN = { 10, 20, 30, 35, 40 };
            Stopwatch dongHo = new Stopwatch();
            for (int k = 0; k < cacN.Length; k++)
            {
                int n = cacN[k];

                // Đệ quy chạy rất chậm khi n lớn nên giảm số lần lặp
                int lanDeQuy = 1;
                if (n <= 20) lanDeQuy = 1000;
                else if (n <= 30) lanDeQuy = 10;
                int lanNhanh = 100000;

                dongHo.Restart();
                for (int i = 0; i < lanDeQuy; i++)
                    FibDeQuy(n);
                dongHo.Stop();
                double tgDeQuy = dongHo.Elapsed.TotalMilliseconds * 1000 / lanDeQuy;

                dongHo.Restart();
                for (int i = 0; i < lanNhanh; i++)
                    FibLap(n);
                dongHo.Stop();
                double tgLap = dongHo.Elapsed.TotalMilliseconds * 1000 / lanNhanh;

                dongHo.Restart();
                for (int i = 0; i < lanNhanh; i++)
                    FibMemo(n);
                dongHo.Stop();
                double tgMemo = dongHo.Elapsed.TotalMilliseconds * 1000 / lanNhanh;

                dongHo.Restart();
                for (int i = 0; i < lanNhanh; i++)
                    FibMaTran(n);
                dongHo.Stop();
                double tgMaTran = dongHo.Elapsed.TotalMilliseconds * 1000 / lanNhanh;

                Console.WriteLine(n + "\t" + tgDeQuy.ToString("F2") + "\t\t" + tgLap.ToString("F3") + "\t\t" + tgMemo.ToString("F3") + "\t\t" + tgMaTran.ToString("F3"));
            }
            Console.WriteLine();

            // ===== Phần 4: so sánh 3 giải thuật nhanh với n lớn hơn =====
            Console.WriteLine("=== So sánh 3 giải thuật nhanh với n lớn (micro giây / 1 lần tính) ===");
            Console.WriteLine("n\tLặp\t\tMemo\t\tMa trận");
            int[] cacN2 = { 10, 30, 50, 70, 90 };
            for (int k = 0; k < cacN2.Length; k++)
            {
                int n = cacN2[k];
                int lan = 200000;

                dongHo.Restart();
                for (int i = 0; i < lan; i++)
                    FibLap(n);
                dongHo.Stop();
                double tgLap = dongHo.Elapsed.TotalMilliseconds * 1000 / lan;

                dongHo.Restart();
                for (int i = 0; i < lan; i++)
                    FibMemo(n);
                dongHo.Stop();
                double tgMemo = dongHo.Elapsed.TotalMilliseconds * 1000 / lan;

                dongHo.Restart();
                for (int i = 0; i < lan; i++)
                    FibMaTran(n);
                dongHo.Stop();
                double tgMaTran = dongHo.Elapsed.TotalMilliseconds * 1000 / lan;

                Console.WriteLine(n + "\t" + tgLap.ToString("F3") + "\t\t" + tgMemo.ToString("F3") + "\t\t" + tgMaTran.ToString("F3"));
            }
            Console.WriteLine();

            // ===== Kết luận =====
            Console.WriteLine("Kết luận:");
            Console.WriteLine("- Đệ quy trực tiếp: T(n) = T(n-1) + T(n-2) + 1 => O(2^n) (chặt hơn là O(1.618^n)), tính lặp lại rất nhiều");
            Console.WriteLine("- Vòng lặp        : Theta(n) thời gian, O(1) bộ nhớ phụ");
            Console.WriteLine("- Đệ quy có nhớ   : Theta(n) thời gian, O(n) bộ nhớ phụ (mảng nhớ + ngăn xếp đệ quy)");
            Console.WriteLine("- Lũy thừa ma trận: O(log n) thời gian");
        }
    }
}