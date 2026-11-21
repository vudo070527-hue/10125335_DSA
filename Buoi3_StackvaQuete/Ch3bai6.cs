using System;

namespace Buoi3_StackQueue
{
    // Bài 6: Mô phỏng hàng đợi khách hàng tại ngân hàng hoặc trung tâm dịch vụ.
    class Ch3Bai6
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

        class KhachHang
        {
            public int SoThuTu;
            public string Ten;
            public string LoaiDichVu;
            public string GioDen;

            public KhachHang(int soThuTu, string ten, string loaiDichVu, string gioDen)
            {
                SoThuTu = soThuTu;
                Ten = ten;
                LoaiDichVu = loaiDichVu;
                GioDen = gioDen;
            }
        }

        class Nut
        {
            public KhachHang DuLieu;
            public Nut Next;

            public Nut(KhachHang duLieu)
            {
                DuLieu = duLieu;
                Next = null;
            }
        }

        // Queue khách hàng dùng danh sách liên kết với front và rear.
        class QueueKhach
        {
            private Nut front;
            private Nut rear;
            private int soLuong;

            public QueueKhach()
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

            public void Enqueue(KhachHang khach)
            {
                Nut moi = new Nut(khach);
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

            public KhachHang Dequeue()
            {
                if (Rong())
                    return null;

                KhachHang khach = front.DuLieu;
                front = front.Next;
                if (front == null)
                    rear = null;
                soLuong--;
                return khach;
            }

            public KhachHang Front()
            {
                if (Rong())
                    return null;
                return front.DuLieu;
            }

            public void HienThi()
            {
                if (Rong())
                {
                    Console.WriteLine("Hàng đợi khách hàng: (rỗng)");
                    return;
                }

                Console.WriteLine("Hàng đợi khách hàng (" + soLuong + " người), FRONT -> REAR:");
                Nut p = front;
                int viTri = 1;

                while (p != null)
                {
                    KhachHang khach = p.DuLieu;
                    Console.WriteLine("  " + viTri + ". Số " + khach.SoThuTu + " | " + khach.Ten
                        + " | " + khach.LoaiDichVu + " | Đến lúc " + khach.GioDen);
                    p = p.Next;
                    viTri++;
                }
            }
        }

        static QueueKhach hangDoi = new QueueKhach();
        static int soTiepTheo = 1;

        static void KhachDen(string ten, string loaiDichVu)
        {
            string gio = DateTime.Now.ToString("HH:mm:ss");
            KhachHang khach = new KhachHang(soTiepTheo, ten, loaiDichVu, gio);
            soTiepTheo++;
            hangDoi.Enqueue(khach);
            Console.WriteLine("Khách " + khach.Ten + " nhận số " + khach.SoThuTu
                + ", phía trước còn " + (hangDoi.SoLuong() - 1) + " người.");
        }

        static void PhucVuKhach()
        {
            KhachHang khach = hangDoi.Dequeue();
            if (khach == null)
            {
                Console.WriteLine("Không có khách nào đang chờ.");
                return;
            }

            Console.WriteLine("Mời khách số " + khach.SoThuTu + " (" + khach.Ten
                + ") đến quầy - dịch vụ: " + khach.LoaiDichVu);
        }

        public static void Chay()
        {
            Console.WriteLine("=== BÀI 6: QUẢN LÝ HÀNG ĐỢI KHÁCH HÀNG ===");
            hangDoi = new QueueKhach();
            soTiepTheo = 1;

            Console.WriteLine("[Kịch bản mẫu]");
            KhachDen("Nguyễn Văn An", "Gửi tiết kiệm");
            KhachDen("Trần Thị Bình", "Chuyển khoản");
            KhachDen("Lê Văn Cường", "Mở thẻ");
            hangDoi.HienThi();
            PhucVuKhach();
            hangDoi.HienThi();

            int chon = -1;
            while (chon != 0)
            {
                Console.WriteLine();
                Console.WriteLine("1. Khách hàng mới đến (Enqueue)");
                Console.WriteLine("2. Nhân viên rảnh - phục vụ khách tiếp theo (Dequeue)");
                Console.WriteLine("3. Xem khách đầu hàng đợi (Front)");
                Console.WriteLine("4. Hiển thị trạng thái hàng đợi");
                Console.WriteLine("0. Quay lại menu chính");
                chon = NhapSoNguyen("Chọn: ");

                if (chon == 1)
                {
                    string ten = NhapChuoi("Tên khách hàng: ");
                    string dichVu = NhapChuoi("Loại dịch vụ: ");
                    if (ten == "" || dichVu == "")
                        Console.WriteLine("Thông tin không được để trống.");
                    else
                        KhachDen(ten, dichVu);
                }
                else if (chon == 2)
                    PhucVuKhach();
                else if (chon == 3)
                {
                    KhachHang khach = hangDoi.Front();
                    if (khach == null)
                        Console.WriteLine("Hàng đợi rỗng.");
                    else
                        Console.WriteLine("Khách tiếp theo: số " + khach.SoThuTu + " - " + khach.Ten);
                }
                else if (chon == 4)
                    hangDoi.HienThi();
                else if (chon != 0)
                    Console.WriteLine("Lựa chọn không hợp lệ.");
            }
        }
    }
}
