using System;

namespace Buoi01_DeQuy
{
    // Chương 1 - Bài 3 (trang 25): Nhập một chuỗi, in ra chuỗi đảo ngược (đệ quy)
    class Ch1_Bai3
    {
        // Đảo chuỗi s = (đảo phần còn lại sau ký tự đầu) + ký tự đầu
        static string DaoNguoc(string s)
        {
            if (s.Length <= 1) return s;             // suy biến: chuỗi rỗng hoặc 1 ký tự
            return DaoNguoc(s.Substring(1)) + s[0];
        }

        public static void Chay()
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