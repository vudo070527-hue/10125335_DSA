using System;

namespace Buoi02_List
{
    // Chương 4 - Bài 1 (trang 159): Cho n số nguyên dương a0, a1, ..., a(n-1)
    //   a. Nhập từ bàn phím
    //   b. Hiển thị danh sách ra màn hình, các phần tử cách nhau 1 khoảng trống
    //   c. Chèn phần tử x vào vị trí k của dãy
    // Cài đặt bằng mảng một chiều. Vị trí k tính từ 0 (giống chỉ số mảng).
    class Ch2Bai1
    {
        // a. Nhập mảng: dùng for i = 0..n-1, mỗi lần nhập một giá trị a[i] (phải là số dương)
        static int[] NhapMang(int n)
        {
            int[] a = new int[n];
            for (int i = 0; i < n; i++)
            {
                a[i] = TienIch.DocSoDuong("a[" + i + "] = ");
            }
            return a;
        }

        // b. Hiển thị mảng, các phần tử cách nhau 1 khoảng trống
        static void HienThi(int[] a)
        {
            for (int i = 0; i < a.Length; i++)
            {
                Console.Write(a[i] + " ");
            }
            Console.WriteLine();
        }

        // c. Chèn x vào vị trí k: tạo mảng tmp dài hơn 1, chép phần trước k, đặt x, chép phần còn lại
        static int[] ChenPhanTu(int[] a, int k, int x)
        {
            // k hợp lệ khi 0 <= k <= a.Length (k = a.Length nghĩa là chèn vào cuối)
            if (k < 0 || k > a.Length)
            {
                Console.WriteLine("Vị trí k không hợp lệ (phải từ 0 đến " + a.Length + "), giữ nguyên mảng.");
                return a;
            }

            int[] tmp = new int[a.Length + 1];
            for (int i = 0; i < k; i++)
            {
                tmp[i] = a[i];            // các phần tử đứng trước vị trí k giữ nguyên chỗ
            }
            tmp[k] = x;                   // đặt giá trị cần chèn
            for (int i = k; i < a.Length; i++)
            {
                tmp[i + 1] = a[i];        // các phần tử từ k trở đi dời sang phải 1 ô
            }
            return tmp;                   // trả về mảng mới để gán a = tmp
        }

        // In mảng trước và sau khi chèn
        static int[] ThuChen(int[] a, int k, int x)
        {
            Console.WriteLine("Chèn x = " + x + " vào vị trí k = " + k + ":");
            int[] ketQua = ChenPhanTu(a, k, x);
            Console.Write("  Sau khi chèn: ");
            HienThi(ketQua);
            return ketQua;
        }

        public static void Chay()
        {
            Console.WriteLine("=== Chương 4 - Bài 1: Mảng - nhập, hiển thị, chèn phần tử ===");
            int[] a;
            bool mau = TienIch.DungDuLieuMau();

            if (mau)
            {
                a = new int[] { 5, 8, 12, 3, 9 };
                Console.WriteLine("(Dùng dữ liệu mẫu)");
            }
            else
            {
                int n = TienIch.DocSoDuong("Nhập n: ");
                a = NhapMang(n);
            }

            Console.Write("Danh sách ban đầu: ");
            HienThi(a);

            if (mau)
            {
                // Chạy thử các trường hợp: giữa, đầu, cuối, vị trí sai (mỗi lần chèn vào mảng ban đầu)
                ThuChen(a, 2, 99);          // chèn vào giữa
                ThuChen(a, 0, 1);           // chèn vào đầu
                ThuChen(a, a.Length, 7);    // chèn vào cuối
                ThuChen(a, 10, 50);         // vị trí không hợp lệ
            }
            else
            {
                int x = TienIch.DocSoDuong("Nhập giá trị x cần chèn: ");
                int k = TienIch.DocSoNguyen("Nhập vị trí k (0.." + a.Length + "): ");
                a = ThuChen(a, k, x);
            }
        }
    }
}