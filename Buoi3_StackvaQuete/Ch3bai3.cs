using System;

namespace Buoi3_StackQueue
{
    // Bài 3: Mô phỏng quá trình gọi hàm và trả về từ hàm bằng Call Stack.
    class Ch3Bai3
    {
        // Nhập số nguyên từ bàn phím, nếu sai thì yêu cầu nhập lại.
        static int NhapSoNguyen(string loiNhac)
        {
            while (true)
            {
                Console.Write(loiNhac);
                string duLieu = Console.ReadLine();

                if (int.TryParse(duLieu, out int so))
                    return so;

                Console.WriteLine("Giá trị không hợp lệ, vui lòng nhập lại.");
            }
        }

        // Nhập chuỗi từ bàn phím.
        static string NhapChuoi(string loiNhac)
        {
            Console.Write(loiNhac);
            return Console.ReadLine() ?? "";
        }

        // Một khung ngăn xếp lưu thông tin của một lần gọi hàm.
        class KhungNganXep
        {
            public string TenHam;
            public string ThamSo;
            public string DiaChiTra;
            public KhungNganXep Next;

            public KhungNganXep(string tenHam, string thamSo, string diaChiTra)
            {
                TenHam = tenHam;
                ThamSo = thamSo;
                DiaChiTra = diaChiTra;
                Next = null;
            }
        }

        // Stack khung ngăn xếp được cài đặt bằng danh sách liên kết.
        class StackKhung
        {
            private KhungNganXep head;
            private int soLuong;

            public StackKhung()
            {
                head = null;
                soLuong = 0;
            }

            public bool Rong()
            {
                return head == null;
            }

            public int DoSau()
            {
                return soLuong;
            }

            public void Push(KhungNganXep khung)
            {
                khung.Next = head;
                head = khung;
                soLuong++;
            }

            public KhungNganXep Pop()
            {
                if (Rong())
                    return null;

                KhungNganXep khung = head!;
                head = head.Next;
                khung.Next = null;
                soLuong--;
                return khung;
            }

            public KhungNganXep Peek()
            {
                return head;
            }

            public void HienThi()
            {
                Console.WriteLine("  +------------- CALL STACK -------------+");

                if (Rong())
                {
                    Console.WriteLine("  |              (rỗng)                  |");
                }
                else
                {
                    KhungNganXep p = head;
                    while (p != null)
                    {
                        string dau = (p == head) ? "-> " : "   ";
                        Console.WriteLine("  " + dau + p.TenHam + "(" + p.ThamSo + ") | Trả về: " + p.DiaChiTra);
                        p = p.Next;
                    }
                }

                Console.WriteLine("  +--------------------------------------+");
            }
        }

        static StackKhung stack = new StackKhung();

        // Phần 1: Mô phỏng tự động lời gọi đệ quy tính giai thừa.
        static int GiaiThua(int n, string noiGoi)
        {
            stack.Push(new KhungNganXep("GiaiThua", "n=" + n, noiGoi));
            Console.WriteLine("[GỌI] GiaiThua(" + n + ")");
            stack.HienThi();

            int ketQua;
            if (n <= 1)
                ketQua = 1;
            else
                ketQua = n * GiaiThua(n - 1, "GiaiThua(n=" + n + ")");

            KhungNganXep khung = stack.Pop();
            if (khung != null)
            {
                Console.WriteLine("[TRẢ VỀ] GiaiThua(" + n + ") = " + ketQua
                    + " (quay về " + khung.DiaChiTra + ")");
            }
            stack.HienThi();
            return ketQua;
        }

        static void DemoGiaiThua()
        {
            int n = NhapSoNguyen("Nhập n để tính n! (nên chọn số nhỏ, ví dụ 3): ");
            if (n < 0 || n > 10)
            {
                Console.WriteLine("n không hợp lệ (0 đến 10). Sử dụng n = 3.");
                n = 3;
            }

            stack.Push(new KhungNganXep("main", "", "hệ điều hành"));
            Console.WriteLine("[GỌI] main()");
            stack.HienThi();

            int ketQua = GiaiThua(n, "main");
            Console.WriteLine(">>> Kết quả " + n + "! = " + ketQua);

            stack.Pop();
            Console.WriteLine("[TRẢ VỀ] main() kết thúc");
            stack.HienThi();
        }

        // Phần 2: Người dùng tự thao tác Push, Pop và Peek.
        static void TuThaoTac()
        {
            while (!stack.Rong())
                stack.Pop();

            int chon = -1;
            while (chon != 0)
            {
                Console.WriteLine();
                Console.WriteLine("1. Gọi hàm (Push)");
                Console.WriteLine("2. Hàm kết thúc (Pop)");
                Console.WriteLine("3. Xem hàm đang chạy (Peek)");
                Console.WriteLine("4. Xem Call Stack");
                Console.WriteLine("0. Quay lại");
                chon = NhapSoNguyen("Chọn: ");

                if (chon == 1)
                {
                    string ten = NhapChuoi("Tên hàm: ");
                    string thamSo = NhapChuoi("Tham số: ");
                    if (ten == "")
                    {
                        Console.WriteLine("Tên hàm không được để trống.");
                        continue;
                    }

                    string diaChiTra = stack.Rong() ? "hệ điều hành" : stack.Peek()!.TenHam;
                    stack.Push(new KhungNganXep(ten, thamSo, diaChiTra));
                    Console.WriteLine("Đã gọi hàm " + ten);
                    stack.HienThi();
                }
                else if (chon == 2)
                {
                    KhungNganXep khung = stack.Pop();
                    if (khung == null)
                        Console.WriteLine("Stack rỗng, không có hàm nào đang chạy.");
                    else
                        Console.WriteLine("Hàm " + khung.TenHam + " kết thúc, quay về " + khung.DiaChiTra);
                    stack.HienThi();
                }
                else if (chon == 3)
                {
                    KhungNganXep khung = stack.Peek();
                    if (khung == null)
                        Console.WriteLine("Không có hàm nào đang chạy.");
                    else
                        Console.WriteLine("Hàm đang chạy: " + khung.TenHam + "(" + khung.ThamSo + ")");
                }
                else if (chon == 4)
                    stack.HienThi();
                else if (chon != 0)
                    Console.WriteLine("Lựa chọn không hợp lệ.");
            }

            while (!stack.Rong())
                stack.Pop();
        }

        public static void Chay()
        {
            Console.WriteLine("=== BÀI 3: MÔ PHỎNG FUNCTION CALL STACK ===");
            Console.WriteLine("1. Demo tự động: tính giai thừa bằng đệ quy");
            Console.WriteLine("2. Tự gọi và kết thúc hàm");
            int chon = NhapSoNguyen("Chọn: ");

            while (!stack.Rong())
                stack.Pop();

            if (chon == 1)
                DemoGiaiThua();
            else if (chon == 2)
                TuThaoTac();
            else
                Console.WriteLine("Lựa chọn không hợp lệ.");
        }
    }
}
