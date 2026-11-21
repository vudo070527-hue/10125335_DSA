using System;

namespace Buoi02_List
{
    class Ch2Bai5
    {
        static Node? pHead = null;

        static int demAm = 0;
        static int demKhong = 0;
        static int demDuong = 0;

        // Thêm phần tử vào cuối danh sách
        static void ThemCuoi(int x)
        {
            Node moi = new Node(x);

            if (pHead == null)
            {
                pHead = moi;
                return;
            }

            Node p = pHead;

            while (p.Link != null)
            {
                p = p.Link;
            }

            p.Link = moi;
        }

        // Hiển thị danh sách
        static void HienThi()
        {
            Node? p = pHead;

            if (p == null)
            {
                Console.WriteLine("(Danh sách rỗng)");
                return;
            }

            while (p != null)
            {
                Console.Write(p.Data);

                if (p.Link != null)
                    Console.Write(" -> ");

                p = p.Link;
            }

            Console.WriteLine();
        }

        // a. Tìm phần tử lớn nhất
        static int TimMax()
        {
            int max = int.MinValue;
            Node? p = pHead;

            while (p != null)
            {
                if (p.Data > max)
                    max = p.Data;

                p = p.Link;
            }

            return max;
        }

        // b. Tính tổng các phần tử
        static long TinhTong()
        {
            long tong = 0;
            Node? p = pHead;

            while (p != null)
            {
                tong += p.Data;
                p = p.Link;
            }

            return tong;
        }

        // c. Kiểm tra số nguyên tố
        static bool KTNT(int x)
        {
            if (x < 2)
                return false;

            for (int i = 2; i * i <= x; i++)
            {
                if (x % i == 0)
                    return false;
            }

            return true;
        }

        // Đếm số nguyên tố
        static int DemNguyenTo()
        {
            int dem = 0;
            Node? p = pHead;

            while (p != null)
            {
                if (KTNT(p.Data))
                    dem++;

                p = p.Link;
            }

            return dem;
        }

        // d. Thống kê số âm, số 0, số dương
        static void ThongKeAmDuongKhong()
        {
            demAm = 0;
            demKhong = 0;
            demDuong = 0;

            Node? p = pHead;

            while (p != null)
            {
                if (p.Data < 0)
                    demAm++;
                else if (p.Data > 0)
                    demDuong++;
                else
                    demKhong++;

                p = p.Link;
            }
        }

        // e. Đếm số phần tử bằng x
        static int DemBangX(int x)
        {
            int dem = 0;
            Node? p = pHead;

            while (p != null)
            {
                if (p.Data == x)
                    dem++;

                p = p.Link;
            }

            return dem;
        }

        // f. Tìm phần tử dương nhỏ nhất
        static int TimDuongNhoNhat()
        {
            int min = int.MaxValue;
            Node? p = pHead;

            while (p != null)
            {
                if (p.Data > 0 && p.Data < min)
                    min = p.Data;

                p = p.Link;
            }

            return min;
        }

        // Chạy bài 5
        public static void Chay()
        {
            Console.WriteLine("=== Chương 4 - Bài 5: Danh sách liên kết đơn ===");

            pHead = null;
            int x;

            if (TienIch.DungDuLieuMau())
            {
                int[] duLieu = { 12, -5, 7, 0, 3, 7, -2, 11, 0, 4 };

                for (int i = 0; i < duLieu.Length; i++)
                {
                    ThemCuoi(duLieu[i]);
                }

                x = 7;
                Console.WriteLine("Sử dụng dữ liệu mẫu, x = 7");
            }
            else
            {
                int n = TienIch.DocSoDuong("Nhập số phần tử n: ");

                for (int i = 0; i < n; i++)
                {
                    int a = TienIch.DocSoNguyen("Nhập phần tử thứ " + (i + 1) + ": ");
                    ThemCuoi(a);
                }

                x = TienIch.DocSoNguyen("Nhập x: ");
            }

            Console.Write("Danh sách: ");
            HienThi();

            if (pHead == null)
            {
                Console.WriteLine("Danh sách rỗng.");
                return;
            }

            Console.WriteLine("a. Phần tử lớn nhất: " + TimMax());
            Console.WriteLine("b. Tổng các phần tử: " + TinhTong());
            Console.WriteLine("c. Số lượng số nguyên tố: " + DemNguyenTo());

            ThongKeAmDuongKhong();

            Console.WriteLine("d. Số âm: " + demAm
                + ", số bằng 0: " + demKhong
                + ", số dương: " + demDuong);

            Console.WriteLine("e. Số phần tử bằng " + x + ": " + DemBangX(x));

            int min = TimDuongNhoNhat();

            if (min == int.MaxValue)
                Console.WriteLine("f. Danh sách không có phần tử dương.");
            else
                Console.WriteLine("f. Phần tử dương nhỏ nhất: " + min);
        }
    }
}