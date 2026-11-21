using System;

namespace Buoi3_StackQueue
{
    class Ch3Bai1
    {
        // Nhập chuỗi từ bàn phím.
        static string NhapChuoi(string loiNhac)
        {
            Console.Write(loiNhac);
            return Console.ReadLine() ?? "";
        }

        // Stack ký tự được cài đặt bằng mảng.
        class StackKyTu
        {
            private char[] mang;
            private int dinh;

            public StackKyTu(int dungLuong)
            {
                mang = new char[dungLuong];
                dinh = -1;
            }

            public bool Rong()
            {
                return dinh == -1;
            }

            public bool Day()
            {
                return dinh == mang.Length - 1;
            }

            public void Push(char x)
            {
                if (Day())
                    return;

                dinh++;
                mang[dinh] = x;
            }

            public char Pop()
            {
                if (Rong())
                    return '\0';

                char x = mang[dinh];
                dinh--;
                return x;
            }
        }

        static bool LaNgoacMo(char c)
        {
            return c == '(' || c == '[' || c == '{';
        }

        static bool LaNgoacDong(char c)
        {
            return c == ')' || c == ']' || c == '}';
        }

        // Kiểm tra ngoặc đóng có khớp với ngoặc mở hay không.
        static bool KhopNgoac(char mo, char dong)
        {
            if (mo == '(' && dong == ')') return true;
            if (mo == '[' && dong == ']') return true;
            if (mo == '{' && dong == '}') return true;
            return false;
        }

        // Trả về true nếu biểu thức có các dấu ngoặc hợp lệ.
        public static bool KiemTra(string bieuThuc)
        {
            StackKyTu stack = new StackKyTu(bieuThuc.Length + 1);

            for (int i = 0; i < bieuThuc.Length; i++)
            {
                char c = bieuThuc[i];

                if (LaNgoacMo(c))
                {
                    stack.Push(c);
                }
                else if (LaNgoacDong(c))
                {
                    // Có ngoặc đóng nhưng Stack rỗng nghĩa là thừa ngoặc đóng.
                    if (stack.Rong())
                        return false;

                    char mo = stack.Pop();
                    if (!KhopNgoac(mo, c))
                        return false;
                }
            }

            // Cuối biểu thức, Stack phải rỗng thì mới hợp lệ.
            return stack.Rong();
        }

        static void KiemTraVaIn(string bieuThuc)
        {
            if (KiemTra(bieuThuc))
                Console.WriteLine("  \"" + bieuThuc + "\" -> HỢP LỆ");
            else
                Console.WriteLine("  \"" + bieuThuc + "\" -> KHÔNG HỢP LỆ");
        }

        public static void Chay()
        {
            Console.WriteLine("=== BÀI 1: KIỂM TRA DẤU NGOẶC BẰNG STACK ===");
            Console.WriteLine("Các biểu thức mẫu:");
            KiemTraVaIn("(a + b) * [c - {d / e}]");
            KiemTraVaIn("{[(1 + 2) * 3] - 4}");
            KiemTraVaIn("((a + b)");
            KiemTraVaIn("(a + b))");
            KiemTraVaIn("{[(a + b])}");
            KiemTraVaIn("a + b");

            Console.WriteLine();
            Console.WriteLine("Nhập biểu thức cần kiểm tra (Enter để quay lại menu):");

            while (true)
            {
                string bieuThuc = NhapChuoi("> ");
                if (bieuThuc == "")
                    break;

                KiemTraVaIn(bieuThuc);
            }
        }
    }
}
