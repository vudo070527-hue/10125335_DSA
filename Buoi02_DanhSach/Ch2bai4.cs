using System;

namespace Buoi02_List
{
    // Bài 4: Danh sách liên kết đơn
    // a. Đếm số phần tử bằng x
    // b. Tìm phần tử dương nhỏ nhất
    // c. Xóa phần tử x xuất hiện đầu tiên

    class Ch2Bai4
    {
        static Node? pHead = null;

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

        // a. Đếm số lần xuất hiện của x
        static int DemSoLanXuatHien(int x)
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

        // b. Tìm phần tử dương nhỏ nhất
        static int TimDuongNhoNhat()
        {
            int minDuong = int.MaxValue;
            Node? p = pHead;

            while (p != null)
            {
                if (p.Data > 0 && p.Data < minDuong)
                    minDuong = p.Data;

                p = p.Link;
            }

            return minDuong;
        }

        // c. Xóa phần tử x xuất hiện đầu tiên
        static bool XoaPhanTuX(int x)
        {
            Node? p = pHead;
            Node? t = null;

            while (p != null && p.Data != x)
            {
                t = p;
                p = p.Link;
            }

            if (p == null)
                return false;

            if (t == null)
                pHead = p.Link;
            else
                t.Link = p.Link;

            return true;
        }

        // Thử xóa và hiển thị danh sách
        static void ThuXoa(int x)
        {
            Console.WriteLine("Xóa x = " + x + ":");

            if (XoaPhanTuX(x))
                Console.Write("Đã xóa. Danh sách: ");
            else
                Console.Write("Không có " + x + " trong danh sách. Danh sách: ");

            HienThi();
        }

        // Chạy bài 4
        public static void Chay()
        {
            Console.WriteLine("=== Chương 4 - Bài 4: Danh sách liên kết đơn ===");

            pHead = null;
            int x;

            bool mau = TienIch.DungDuLieuMau();

            if (mau)
            {
                int[] duLieu = { 7, 4, 9, 4, 12, 2, 5 };

                for (int i = 0; i < duLieu.Length; i++)
                {
                    ThemCuoi(duLieu[i]);
                }

                x = 4;
                Console.WriteLine("(Dùng dữ liệu mẫu, x = 4)");
            }
            else
            {
                int n = TienIch.DocSoDuong("Nhập số phần tử n: ");

                for (int i = 0; i < n; i++)
                {
                    int a = TienIch.DocSoDuong(
                        "Nhập phần tử thứ " + (i + 1) + ": ");

                    ThemCuoi(a);
                }

                x = TienIch.DocSoDuong("Nhập x: ");
            }

            Console.Write("Danh sách: ");
            HienThi();

            Console.WriteLine("a. Số phần tử bằng " + x + ": "
                + DemSoLanXuatHien(x));

            int min = TimDuongNhoNhat();

            if (min == int.MaxValue)
                Console.WriteLine("b. Không có phần tử dương.");
            else
                Console.WriteLine("b. Phần tử dương nhỏ nhất: " + min);

            Console.WriteLine("c.");
            ThuXoa(x);

            if (mau)
            {
                // Thử xóa phần tử đầu
                ThuXoa(7);

                // Thử xóa phần tử cuối
                ThuXoa(5);

                // Thử xóa phần tử không tồn tại
                ThuXoa(100);
            }
        }
    }
}