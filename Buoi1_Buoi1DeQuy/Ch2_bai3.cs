using System;

namespace Buoi01_DeQuy
{
    // Chương 2 - Bài 3 (trang 77): Kiểm tra số nguyên tố (đệ quy)
    //   Giải thuật 1 (cơ bản)   : thử ước i từ 2 đến n-1                -> O(n)
    //   Giải thuật 2 (cải tiến) : thử ước i từ 2 đến căn n              -> O(căn n)
    // (Lý do: nếu n = a*b thì có ít nhất một thừa số <= căn n.)
    // Lưu ý: đệ quy dùng ngăn xếp nên chỉ thử n vừa phải (giải thuật 1 tối đa vài nghìn).
    class Ch2_Bai3
    {
        static long demChia = 0;

        // ---------- Giải thuật 1 ----------
        static bool NguyenToCoBan(int n, int i)
        {
            if (n < 2) return false;
            if (i > n - 1) return true;              // suy biến: đã thử hết mà không có ước
            demChia++;
            if (n % i == 0) return false;            // suy biến: gặp ước
            return NguyenToCoBan(n, i + 1);          // thử ước tiếp theo
        }

        // ---------- Giải thuật 2 ----------
        static bool NguyenToCanN(int n, long i)
        {
            if (n < 2) return false;
            if (i * i > n) return true;              // đã thử đến căn n
            demChia++;
            if (n % i == 0) return false;
            return NguyenToCanN(n, i + 1);
        }

        // Đếm số nguyên tố từ n đến N (đệ quy) để đối chiếu 2 giải thuật
        static int DemCoBan(int n, int N)
        {
            if (n > N) return 0;
            int la = NguyenToCoBan(n, 2) ? 1 : 0;
            return la + DemCoBan(n + 1, N);
        }

        static int DemCanN(int n, int N)
        {
            if (n > N) return 0;
            int la = NguyenToCanN(n, 2) ? 1 : 0;
            return la + DemCanN(n + 1, N);
        }

        public static void Chay()
        {
            Console.WriteLine("=== Chương 2 - Bài 3: Kiểm tra số nguyên tố ===");

            int[] mau = { 1, 2, 3, 4, 17, 25, 97, 100, 1009, 4999 };
            Console.WriteLine("n\tCơ bản\tCăn n");
            for (int k = 0; k < mau.Length; k++)
            {
                int n = mau[k];
                string kq1 = NguyenToCoBan(n, 2) ? "Có" : "Không";
                string kq2 = NguyenToCanN(n, 2) ? "Có" : "Không";
                Console.WriteLine(n + "\t" + kq1 + "\t" + kq2);
            }
            Console.WriteLine();

            Console.WriteLine("Số nguyên tố từ 1 đến 1000 (đáp án đúng: 168): cơ bản = "
                + DemCoBan(1, 1000) + ", căn n = " + DemCanN(1, 1000));
            Console.WriteLine();

            // Số phép chia khi n là số nguyên tố (trường hợp xấu nhất)
            Console.WriteLine("Số phép chia khi n là số nguyên tố:");
            Console.WriteLine("n\t\tCơ bản (n-2)\tCăn n\t\tcăn n");
            int[] cacN = { 101, 1009, 4999, 100003, 1000003, 10000019 };
            for (int k = 0; k < cacN.Length; k++)
            {
                int n = cacN[k];
                string c1 = "bỏ qua";                 // giải thuật 1 đệ quy sâu n tầng nên chỉ chạy n nhỏ
                if (n <= 5000)
                {
                    demChia = 0;
                    NguyenToCoBan(n, 2);
                    c1 = demChia.ToString();
                }
                demChia = 0;
                NguyenToCanN(n, 2);
                Console.WriteLine(n + "\t\t" + c1 + "\t\t" + demChia + "\t\t" + Math.Sqrt(n).ToString("F1"));
            }
            Console.WriteLine();
            Console.WriteLine("Kết luận: giải thuật 1 là O(n), giải thuật 2 là O(căn n) - nhanh hơn rất nhiều.");
        }
    }
}