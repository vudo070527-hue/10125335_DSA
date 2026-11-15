using System;
using System.Text;

namespace Buoi01_DeQuy
{
    // Bài tập 1: Tháp Hà Nội
    // Hệ thức truy hồi: T(n) = 2T(n-1) + 1, với T(1) = 1
    // Kết quả: T(n) = 2^n - 1  =>  độ phức tạp O(2^n)

    class Bai1
    {
        // Biến đếm số bước di chuyển thực tế khi chạy giải thuật
        static long soBuoc = 0;

        // Giải thuật Tháp Hà Nội: chuyển n đĩa từ cọc "tu" sang cọc "den", dùng cọc "trungGian"
        static void ThapHaNoi(int n, char tu, char den, char trungGian)
        {
            // Trường hợp cơ sở: chỉ có 1 đĩa thì chuyển thẳng
            if (n == 1)
            {
                Console.WriteLine("Chuyển đĩa 1 từ " + tu + " sang " + den);
                soBuoc++;
                return;
            }

            // Bước 1: chuyển n-1 đĩa phía trên sang cọc trung gian (bài toán con kích thước n-1)
            ThapHaNoi(n - 1, tu, trungGian, den);

            // Bước 2: chuyển đĩa lớn nhất (phép toán cơ bản, tốn 1 bước)
            Console.WriteLine("Chuyển đĩa " + n + " từ " + tu + " sang " + den);
            soBuoc++;

            // Bước 3: chuyển n-1 đĩa từ cọc trung gian sang cọc đích (bài toán con kích thước n-1)
            ThapHaNoi(n - 1, trungGian, den, tu);
        }

        // Tính T(n) trực tiếp theo hệ thức truy hồi T(n) = 2T(n-1) + 1
        static long TinhTheoTruyHoi(int n)
        {
            if (n == 1) return 1;            // T(1) = 1
            return 2 * TinhTheoTruyHoi(n - 1) + 1;
        }

        // Tính T(n) bằng phương pháp lặp (thay thế) - dùng vòng for
        // T(n) = 2T(n-1)+1 = 2(2T(n-2)+1)+1 = 4T(n-2)+2+1 = ... = 2^(n-1)*T(1) + 2^(n-2)+...+2+1
        static long TinhBangLap(int n)
        {
            long t = 1;                      // T(1) = 1
            for (int i = 2; i <= n; i++)
            {
                t = 2 * t + 1;
            }
            return t;
        }

        // Công thức đóng sau khi giải hệ thức: T(n) = 2^n - 1
        static long CongThucDong(int n)
        {
            long ketQua = 1;
            for (int i = 1; i <= n; i++)
            {
                ketQua = ketQua * 2;         // tính 2^n
            }
            return ketQua - 1;
        }

        public static void ChayBai1()
        {
            Console.OutputEncoding = Encoding.UTF8; // để hiển thị tiếng Việt

            // ----- Phần 1: chạy thử giải thuật với n = 3 -----
            int n = 3;
            Console.WriteLine("=== Giải Tháp Hà Nội với n = " + n + " ===");
            soBuoc = 0;
            ThapHaNoi(n, 'A', 'C', 'B');
            Console.WriteLine("Tổng số bước đếm được: " + soBuoc);
            Console.WriteLine();

            // ----- Phần 2: so sánh các cách tính T(n) -----
            Console.WriteLine("=== So sánh T(n) theo các cách ===");
            Console.WriteLine("n\tTruy hồi\tLặp\t\t2^n - 1");
            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine(i + "\t" + TinhTheoTruyHoi(i) + "\t\t" + TinhBangLap(i) + "\t\t" + CongThucDong(i));
            }
            Console.WriteLine();

            // ----- Phần 3: kiểm tra số bước đếm thực tế khớp với 2^n - 1 -----
            Console.WriteLine("=== Kiểm tra số bước thực tế ===");
            for (int i = 1; i <= 5; i++)
            {
                soBuoc = 0;
                // Chạy giải thuật nhưng không cần xem từng bước nên chỉ đếm
                DemBuoc(i);
                Console.WriteLine("n = " + i + ": đếm được " + soBuoc + " bước, 2^n - 1 = " + CongThucDong(i));
            }
            Console.WriteLine();

            Console.WriteLine("Kết luận: T(n) = 2^n - 1 => độ phức tạp thời gian là O(2^n)");
            Console.WriteLine("Trường hợp cơ sở: T(1) = 1 (chỉ có 1 đĩa, chuyển 1 lần)");
        }

        // Phiên bản chỉ đếm bước (không in) để kiểm tra nhanh
        static void DemBuoc(int n)
        {
            if (n == 1)
            {
                soBuoc++;
                return;
            }
            DemBuoc(n - 1);
            soBuoc++;
            DemBuoc(n - 1);
        }
    }
}