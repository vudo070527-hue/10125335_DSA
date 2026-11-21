using System;

namespace Buoi3_StackQueue
{
    class Ch3Bai2
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

        // Một nút trong Stack trang.
        class Nut
        {
            public string DuLieu;
            public Nut Next;

            public Nut(string duLieu)
            {
                DuLieu = duLieu;
                Next = null;
            }
        }

        // Stack được cài đặt bằng danh sách liên kết, head là đỉnh Stack.
        class StackTrang
        {
            private Nut head;

            public StackTrang()
            {
                head = null;
            }

            public bool Rong()
            {
                return head == null;
            }

            public void Push(string x)
            {
                Nut moi = new Nut(x);
                moi.Next = head;
                head = moi;
            }

            public string Pop()
            {
                if (Rong())
                    return null;

                string x = head.DuLieu;
                head = head.Next;
                return x;
            }

            public string Peek()
            {
                if (Rong())
                    return null;

                return head.DuLieu;
            }

            public void XoaSach()
            {
                head = null;
            }

            public void HienThi()
            {
                if (Rong())
                {
                    Console.WriteLine("(rỗng)");
                    return;
                }

                Nut p = head;
                while (p != null)
                {
                    Console.Write(p.DuLieu);
                    if (p.Next != null)
                        Console.Write(" <- ");
                    p = p.Next;
                }

                Console.WriteLine(" (trái là đỉnh Stack)");
            }
        }

        // Mô phỏng trình duyệt.
        class TrinhDuyet
        {
            private string trangHienTai;
            private StackTrang stackBack;
            private StackTrang stackForward;

            public TrinhDuyet()
            {
                trangHienTai = "about:blank";
                stackBack = new StackTrang();
                stackForward = new StackTrang();
            }

            public void TruyCap(string url)
            {
                stackBack.Push(trangHienTai);
                stackForward.XoaSach();
                trangHienTai = url;
                Console.WriteLine("Đã truy cập: " + trangHienTai);
            }

            public void Back()
            {
                if (stackBack.Rong())
                {
                    Console.WriteLine("Không thể Back: không còn trang trước.");
                    return;
                }

                stackForward.Push(trangHienTai);
                trangHienTai = stackBack.Pop()!;
                Console.WriteLine("Quay lại: " + trangHienTai);
            }

            public void Forward()
            {
                if (stackForward.Rong())
                {
                    Console.WriteLine("Không thể Forward: không còn trang phía trước.");
                    return;
                }

                stackBack.Push(trangHienTai);
                trangHienTai = stackForward.Pop()!;
                Console.WriteLine("Chuyển tiếp: " + trangHienTai);
            }

            public void HienThiTrangThai()
            {
                Console.WriteLine("Trang hiện tại : " + trangHienTai);
                Console.Write("Stack Back     : ");
                stackBack.HienThi();
                Console.Write("Stack Forward  : ");
                stackForward.HienThi();
            }
        }

        public static void Chay()
        {
            Console.WriteLine("=== BÀI 2: LỊCH SỬ TRÌNH DUYỆT WEB ===");
            TrinhDuyet trinhDuyet = new TrinhDuyet();

            Console.WriteLine("[Kịch bản mẫu]");
            trinhDuyet.TruyCap("google.com");
            trinhDuyet.TruyCap("facebook.com");
            trinhDuyet.TruyCap("youtube.com");
            trinhDuyet.HienThiTrangThai();
            trinhDuyet.Back();
            trinhDuyet.Back();
            trinhDuyet.HienThiTrangThai();
            trinhDuyet.Forward();
            trinhDuyet.TruyCap("github.com");
            trinhDuyet.HienThiTrangThai();

            Console.WriteLine();
            Console.WriteLine("[Tự thao tác]");
            int chon = -1;

            while (chon != 0)
            {
                Console.WriteLine();
                Console.WriteLine("1. Truy cập trang mới");
                Console.WriteLine("2. Back");
                Console.WriteLine("3. Forward");
                Console.WriteLine("4. Xem trạng thái");
                Console.WriteLine("0. Quay lại menu chính");
                chon = NhapSoNguyen("Chọn: ");

                if (chon == 1)
                {
                    string url = NhapChuoi("Nhập địa chỉ trang web: ");
                    if (url == "")
                        Console.WriteLine("Địa chỉ không được để trống.");
                    else
                        trinhDuyet.TruyCap(url);
                }
                else if (chon == 2)
                    trinhDuyet.Back();
                else if (chon == 3)
                    trinhDuyet.Forward();
                else if (chon == 4)
                    trinhDuyet.HienThiTrangThai();
                else if (chon != 0)
                    Console.WriteLine("Lựa chọn không hợp lệ.");
            }
        }
    }
}
