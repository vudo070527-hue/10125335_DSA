using System;

namespace Buoi01_DeQuy
{
    // Chương 1 - Bài 1 (trang 25): Nhập ngẫu nhiên 1000 số tự nhiên vào mảng, tìm số lớn nhất và số nhỏ nhất
    // Toàn bộ viết bằng đệ quy.
    class Ch1_Bai1
    {
        // Điền mảng ngẫu nhiên: điền phần tử i rồi gọi tiếp i + 1
        static void NhapNgauNhien(int[] a, int i, Random rd)
        {
            if (i >= a.Length) return;               // suy biến: đã điền hết
            a[i] = rd.Next(0, 10000);
            NhapNgauNhien(a, i + 1, rd);
        }

        // Max của n phần tử đầu = lớn hơn giữa (max của n-1 phần tử đầu) và a[n-1]
        static int TimMax(int[] a, int n)
        {
            if (n == 1) return a[0];                 // suy biến: chỉ có 1 phần tử
            int maxTruoc = TimMax(a, n - 1);
            if (a[n - 1] > maxTruoc) return a[n - 1];
            return maxTruoc;
        }

        // Min tương tự
        static int TimMin(int[] a, int n)
        {
            if (n == 1) return a[0];
            int minTruoc = TimMin(a, n - 1);
            if (a[n - 1] < minTruoc) return a[n - 1];
            return minTruoc;
        }

        static void InMang(int[] a, int i, int soIn)
        {
            if (i >= soIn) return;
            Console.Write(a[i] + " ");
            InMang(a, i + 1, soIn);
        }

        public static void Chay()
        {
            Console.WriteLine("=== Chương 1 - Bài 1: Số lớn nhất, số nhỏ nhất trong 1000 số ngẫu nhiên ===");
            int[] a = new int[1000];
            NhapNgauNhien(a, 0, new Random());

            Console.Write("10 phần tử đầu của mảng: ");
            InMang(a, 0, 10);
            Console.WriteLine();

            Console.WriteLine("a. Số lớn nhất: " + TimMax(a, a.Length));
            Console.WriteLine("b. Số nhỏ nhất: " + TimMin(a, a.Length));
        }
    }
}