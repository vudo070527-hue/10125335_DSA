using System;

namespace Buoi3_StackQueue
{
    // Bài 5: Mô phỏng đường truyền dữ liệu bằng Queue cài đặt trên mảng vòng.
    class Ch3Bai5
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

        class GoiTin
        {
            public int SoThuTu;
            public string NoiDung;

            public GoiTin(int soThuTu, string noiDung)
            {
                SoThuTu = soThuTu;
                NoiDung = noiDung;
            }
        }

        class QueueGoiTin
        {
            private GoiTin[] mang;
            private int front;
            private int rear;
            private int soLuong;

            public QueueGoiTin(int dungLuong)
            {
                mang = new GoiTin[dungLuong];
                front = 0;
                rear = -1;
                soLuong = 0;
            }

            public bool Rong()
            {
                return soLuong == 0;
            }

            public bool Day()
            {
                return soLuong == mang.Length;
            }

            public int SoLuong()
            {
                return soLuong;
            }

            // Thêm gói tin vào cuối Queue theo cơ chế vòng.
            public bool Enqueue(GoiTin x)
            {
                if (Day())
                    return false;

                rear = (rear + 1) % mang.Length;
                mang[rear] = x;
                soLuong++;
                return true;
            }

            // Lấy gói tin ở đầu Queue.
            public GoiTin Dequeue()
            {
                if (Rong())
                    return null;

                GoiTin x = mang[front];
                mang[front] = null;
                front = (front + 1) % mang.Length;
                soLuong--;
                return x;
            }

            public void HienThi()
            {
                if (Rong())
                {
                    Console.WriteLine("Hàng đợi gói tin: (rỗng)");
                    return;
                }

                Console.Write("Hàng đợi gói tin (" + soLuong + "/" + mang.Length + ") FRONT -> REAR: ");
                for (int i = 0; i < soLuong; i++)
                {
                    int viTri = (front + i) % mang.Length;
                    GoiTin goiTin = mang[viTri];
                    if (goiTin != null)
                        Console.Write("[" + goiTin.SoThuTu + "] ");
                }
                Console.WriteLine();
            }
        }

        static QueueGoiTin duongTruyen = new QueueGoiTin(5);
        static int soGoiTiepTheo = 1;

        static void GuiGoiTin(string noiDung)
        {
            GoiTin goiTin = new GoiTin(soGoiTiepTheo, noiDung);
            if (duongTruyen.Enqueue(goiTin))
            {
                Console.WriteLine("Đã gửi gói tin #" + goiTin.SoThuTu + ": " + noiDung);
                soGoiTiepTheo++;
            }
            else
            {
                Console.WriteLine("Bộ đệm đầy! Gói tin #" + goiTin.SoThuTu + " bị từ chối.");
            }
        }

        static void NhanGoiTin()
        {
            GoiTin goiTin = duongTruyen.Dequeue();
            if (goiTin == null)
            {
                Console.WriteLine("Không có gói tin nào để xử lý.");
                return;
            }

            Console.WriteLine("Đã xử lý gói tin #" + goiTin.SoThuTu + ": " + goiTin.NoiDung);
        }

        // Mô phỏng nâng cao: gói tin có thể bị mất và có độ trễ truyền.
        static void MoPhongNangCao()
        {
            Random rd = new Random();
            duongTruyen = new QueueGoiTin(10);
            soGoiTiepTheo = 1;
            int soGoi = 8;

            Console.WriteLine("Gửi " + soGoi + " gói tin, xác suất mất gói 20%:");
            for (int i = 1; i <= soGoi; i++)
            {
                if (rd.Next(100) < 20)
                {
                    Console.WriteLine("  Gói tin #" + i + " bị mất trên đường truyền!");
                }
                else
                {
                    GoiTin goiTin = new GoiTin(i, "Dữ liệu " + i);
                    duongTruyen.Enqueue(goiTin);
                    Console.WriteLine("  Gói tin #" + i + " đã vào hàng đợi.");
                }
            }

            Console.WriteLine();
            duongTruyen.HienThi();
            Console.WriteLine("Xử lý theo đúng thứ tự đến:");
            while (!duongTruyen.Rong())
            {
                GoiTin goiTin = duongTruyen.Dequeue();
                if (goiTin != null)
                {
                    int doTre = rd.Next(10, 100);
                    Console.WriteLine("  Gói tin #" + goiTin.SoThuTu + " đến nơi, độ trễ " + doTre + " ms");
                }
            }
        }

        public static void Chay()
        {
            Console.WriteLine("=== BÀI 5: MÔ PHỎNG ĐƯỜNG TRUYỀN DỮ LIỆU ===");
            duongTruyen = new QueueGoiTin(5);
            soGoiTiepTheo = 1;

            Console.WriteLine("[Kịch bản mẫu] Bộ đệm tối đa 5 gói tin");
            GuiGoiTin("Xin chào");
            GuiGoiTin("Dữ liệu A");
            GuiGoiTin("Dữ liệu B");
            duongTruyen.HienThi();
            NhanGoiTin();
            NhanGoiTin();
            duongTruyen.HienThi();
            GuiGoiTin("Dữ liệu C");
            GuiGoiTin("Dữ liệu D");
            GuiGoiTin("Dữ liệu E");
            GuiGoiTin("Dữ liệu F");
            GuiGoiTin("Dữ liệu G");
            duongTruyen.HienThi();

            int chon = -1;
            while (chon != 0)
            {
                Console.WriteLine();
                Console.WriteLine("1. Gửi gói tin (Enqueue)");
                Console.WriteLine("2. Xử lý gói tin (Dequeue)");
                Console.WriteLine("3. Hiển thị hàng đợi");
                Console.WriteLine("4. Mô phỏng nâng cao (mất gói và độ trễ)");
                Console.WriteLine("0. Quay lại menu chính");
                chon = NhapSoNguyen("Chọn: ");

                if (chon == 1)
                {
                    string noiDung = NhapChuoi("Nội dung gói tin: ");
                    if (noiDung == "")
                        Console.WriteLine("Nội dung không được để trống.");
                    else
                        GuiGoiTin(noiDung);
                }
                else if (chon == 2)
                    NhanGoiTin();
                else if (chon == 3)
                    duongTruyen.HienThi();
                else if (chon == 4)
                    MoPhongNangCao();
                else if (chon != 0)
                    Console.WriteLine("Lựa chọn không hợp lệ.");
            }
        }
    }
}
