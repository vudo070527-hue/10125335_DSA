using System;

namespace Buoi02_List
{
    // Chương 4 - Bài 3 (trang 162): Ma trận vuông n dòng n cột các số nguyên (0 <= n < 100)
    //   a. Tính tổng tất cả các phần tử
    //   b. Tìm giá trị dương nhỏ nhất
    //   c. Tính tổng các phần tử trên đường chéo phụ
    //   d. Kiểm tra các phần tử trên đường chéo chính có tăng dần không (từ góc trên trái xuống góc dưới phải)
    class Ch2Bai3
    {
        static int[,] NhapMaTran(int n)
        {
            int[,] a = new int[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    a[i, j] = TienIch.DocSoNguyen("a[" + i + "," + j + "] = ");
                }
            }
            return a;
        }

        static void HienThiMaTran(int[,] a, int n)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(a[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }

        // a. Khởi tạo t = 0, duyệt từng phần tử và cộng vào t
        static int TongTatCa(int[,] a, int n)
        {
            int t = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    t = t + a[i, j];
                }
            }
            return t;
        }

        // b. min = int.MaxValue; phần tử nào > 0 và nhỏ hơn min thì gán vào min
        //    Nếu không có số dương nào thì min vẫn là int.MaxValue
        static int TimDuongNhoNhat(int[,] a, int n)
        {
            int min = int.MaxValue;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (a[i, j] > 0 && a[i, j] < min)
                        min = a[i, j];
                }
            }
            return min;
        }

        // c. Phần tử a[i,j] thuộc đường chéo phụ khi j = (n-1) - i
        static int TongDuongCheoPhu(int[,] a, int n)
        {
            int tong = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (j == (n - 1) - i)
                        tong = tong + a[i, j];
                }
            }
            return tong;
        }

        // d. Lấy các phần tử đường chéo chính (i = j) vào mảng tg gồm n phần tử,
        //    rồi kiểm tra tg[i] < tg[j] với mọi j sau i; nếu sai ở đâu thì trả về false ngay
        static bool CheoChinhTangDan(int[,] a, int n)
        {
            int[] tg = new int[n];
            for (int i = 0; i < n; i++)
            {
                tg[i] = a[i, i];
            }

            for (int i = 0; i < n - 1; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    if (tg[i] >= tg[j])
                        return false;     // không tăng dần
                }
            }
            return true;
        }

        public static void Chay()
        {
            Console.WriteLine("=== Chương 4 - Bài 3: Các phép xử lý trên ma trận vuông ===");
            int n;
            int[,] a;

            if (TienIch.DungDuLieuMau())
            {
                n = 4;
                a = new int[,] { { 2, -1, 5, 7 },
                                 { 3, 4, 0, 9 },
                                 { -2, 6, 8, 1 },
                                 { 5, 3, 2, 10 } };
                Console.WriteLine("(Dùng dữ liệu mẫu, n = 4)");
            }
            else
            {
                n = TienIch.DocSoTrongKhoang("Nhập n (0 <= n < 100): ", 0, 99);
                a = NhapMaTran(n);
            }

            Console.WriteLine("Ma trận:");
            HienThiMaTran(a, n);

            Console.WriteLine("a. Tổng tất cả các phần tử: " + TongTatCa(a, n));

            int min = TimDuongNhoNhat(a, n);
            if (min == int.MaxValue)
                Console.WriteLine("b. Ma trận không có giá trị dương.");
            else
                Console.WriteLine("b. Giá trị dương nhỏ nhất: " + min);

            Console.WriteLine("c. Tổng đường chéo phụ: " + TongDuongCheoPhu(a, n));

            if (CheoChinhTangDan(a, n))
                Console.WriteLine("d. Đường chéo chính có tăng dần.");
            else
                Console.WriteLine("d. Đường chéo chính không tăng dần.");
        }
    }
}