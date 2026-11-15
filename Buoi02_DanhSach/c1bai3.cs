using System;

namespace Buoi01_DeQuy
{
    // Chương 1 - Bài tập 3: Đảo ngược chuỗi
    class C1Bai3
    {
        // Duyệt chuỗi từ cuối về đầu, nối từng ký tự vào chuỗi kết quả
        static string DaoNguoc(string s)
        {
            string kq = "";
            for (int i = s.Length - 1; i >= 0; i--)
            {
                kq = kq + s[i];
            }
            return kq;
        }

        public static void ChayC1Bai3()
        {
            Console.WriteLine("=== Chương 1 - Bài 3: Đảo ngược chuỗi ===");
            Console.Write("Nhập một chuỗi (bỏ trống để dùng chuỗi mẫu): ");
            string s = Console.ReadLine();

            if (s == null || s == "")
            {
                s = "Hello DSA 2026";
                Console.WriteLine("(Dùng chuỗi mẫu: " + s + ")");
            }

            Console.WriteLine("Chuỗi ban đầu  : " + s);
            Console.WriteLine("Chuỗi đảo ngược: " + DaoNguoc(s));
        }
    }
}