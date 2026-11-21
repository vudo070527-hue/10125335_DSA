using System;

namespace Buoi3_StackQueue
{
    // Bài 4: Mô phỏng hệ thống in ấn bằng Queue, xử lý theo nguyên tắc FIFO.
    class Ch3Bai4
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

        // Nhập số nguyên dương.
        static int NhapSoDuong(string loiNhac)
        {
            int so = NhapSoNguyen(loiNhac);
            while (so <= 0)
            {
                Console.WriteLine("Giá trị phải lớn hơn 0.");
                so = NhapSoNguyen(loiNhac);
            }
            return so;
        }

        class YeuCauIn
        {
            public int Ma;
            public string TenTaiLieu;
            public int SoTrang;

            public YeuCauIn(int ma, string tenTaiLieu, int soTrang)
            {
                Ma = ma;
                TenTaiLieu = tenTaiLieu;
                SoTrang = soTrang;
            }
        }

        class Nut
        {
            public YeuCauIn DuLieu;
            public Nut Next;

            public Nut(YeuCauIn duLieu)
            {
                DuLieu = duLieu;
                Next = null;
            }
        }

        // Queue dùng danh sách liên kết với hai con trỏ front và rear.
        class QueueIn
        {
            private Nut front;
            private Nut rear;
            private int soLuong;

            public QueueIn()
            {
                front = null;
                rear = null;
                soLuong = 0;
            }

            public bool Rong()
            {
                return front == null;
            }

            public int SoLuong()
            {
                return soLuong;
            }

            // Thêm yêu cầu vào cuối hàng đợi.
            public void Enqueue(YeuCauIn x)
            {
                Nut moi = new Nut(x);
                if (Rong())
                {
                    front = moi;
                    rear = moi;
                }
                else
                {
                    rear.Next = moi;
                    rear = moi;
                }
                soLuong++;
            }

            // Lấy yêu cầu ở đầu hàng đợi.
            public YeuCauIn Dequeue()
            {
                if (Rong())
                    return null;

                YeuCauIn x = front.DuLieu;
                front = front.Next;
                if (front == null)
                    rear = null;
                soLuong--;
                return x;
            }

            public YeuCauIn Front()
            {
                if (Rong())
                    return null;
                return front.DuLieu;
            }

            public void HienThi()
            {
                if (Rong())
                {
                    Console.WriteLine("Hàng đợi in: (rỗng)");
                    return;
                }

                Console.WriteLine("Hàng đợi in (" + soLuong + " yêu cầu), FRONT -> REAR:");
                Nut p = front;
                while (p != null)
                {
                    YeuCauIn yc = p.DuLieu;
                    Console.WriteLine("  [#" + yc.Ma + "] " + yc.TenTaiLieu + " - " + yc.SoTrang + " trang");
                    p = p.Next;
                }
            }
        }

        static QueueIn hangDoi = new QueueIn();
        static int maTiepTheo = 1;

        static void ThemYeuCau(string ten, int soTrang)
        {
            YeuCauIn yc = new YeuCauIn(maTiepTheo, ten, soTrang);
            maTiepTheo++;
            hangDoi.Enqueue(yc);
            Console.WriteLine("Đã thêm yêu cầu in #" + yc.Ma + ": " + ten + " (" + soTrang + " trang)");
        }

        static void XuLyYeuCau()
        {
            YeuCauIn yc = hangDoi.Dequeue();
            if (yc == null)
            {
                Console.WriteLine("Không có yêu cầu in nào để xử lý.");
                return;
            }

            Console.WriteLine("Đang in yêu cầu #" + yc.Ma + ": " + yc.TenTaiLieu
                + " (" + yc.SoTrang + " trang) ... xong!");
        }

        public static void Chay()
        {
            Console.WriteLine("=== BÀI 4: MÔ PHỎNG HỆ THỐNG IN ẤN (FIFO) ===");
            hangDoi = new QueueIn();
            maTiepTheo = 1;

            Console.WriteLine("[Kịch bản mẫu]");
            ThemYeuCau("BaoCao.docx", 10);
            ThemYeuCau("BaiTap.pdf", 3);
            ThemYeuCau("HoaDon.xlsx", 1);
            hangDoi.HienThi();
            XuLyYeuCau();
            hangDoi.HienThi();

            int chon = -1;
            while (chon != 0)
            {
                Console.WriteLine();
                Console.WriteLine("1. Thêm yêu cầu in (Enqueue)");
                Console.WriteLine("2. Xử lý yêu cầu in (Dequeue)");
                Console.WriteLine("3. Xem yêu cầu đầu hàng đợi (Front)");
                Console.WriteLine("4. Hiển thị hàng đợi");
                Console.WriteLine("0. Quay lại menu chính");
                chon = NhapSoNguyen("Chọn: ");

                if (chon == 1)
                {
                    string ten = NhapChuoi("Tên tài liệu: ");
                    if (ten == "")
                    {
                        Console.WriteLine("Tên tài liệu không được để trống.");
                    }
                    else
                    {
                        int soTrang = NhapSoDuong("Số trang: ");
                        ThemYeuCau(ten, soTrang);
                    }
                }
                else if (chon == 2)
                    XuLyYeuCau();
                else if (chon == 3)
                {
                    YeuCauIn yc = hangDoi.Front();
                    if (yc == null)
                        Console.WriteLine("Hàng đợi rỗng.");
                    else
                        Console.WriteLine("Yêu cầu tiếp theo: #" + yc.Ma + " " + yc.TenTaiLieu);
                }
                else if (chon == 4)
                    hangDoi.HienThi();
                else if (chon != 0)
                    Console.WriteLine("Lựa chọn không hợp lệ.");
            }
        }
    }
}
