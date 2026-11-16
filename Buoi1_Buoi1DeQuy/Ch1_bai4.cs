using System;

namespace Buoi01_DeQuy
{
    // Chương 1 - Bài 4 (trang 25): 1000 số tự nhiên ngẫu nhiên trong mảng
    //   a. In mảng ra màn hình   b. Sắp xếp tăng dần và in ra (tất cả bằng đệ quy)
    class Ch1_Bai4
    {
        static void NhapNgauNhien(int[] a, int i, Random rd)
        {
            if (i >= a.Length) return;
            a[i] = rd.Next(0, 10000);
            NhapNgauNhien(a, i + 1, rd);
        }

        // In mảng, mỗi dòng 10 phần tử
        static void InMang(int[] a, int i)
        {
            if (i >= a.Length) return;
            Console.Write(a[i] + "\t");
            if ((i + 1) % 10 == 0)
                Console.WriteLine();
            InMang(a, i + 1);
        }

        // Sắp xếp nổi bọt đệ quy: một lượt đẩy số lớn nhất về cuối, rồi sắp xếp n-1 phần tử đầu
        static void NoiBot(int[] a, int n)
        {
            if (n <= 1) return;                      // suy biến
            for (int j = 0; j < n - 1; j++)
            {
                if (a[j] > a[j + 1])
                {
                    int tam = a[j];
                    a[j] = a[j + 1];
                    a[j + 1] = tam;
                }
            }
            NoiBot(a, n - 1);
        }

        public static void Chay()
        {
            Console.WriteLine("=== Chương 1 - Bài 4: In mảng và sắp xếp tăng dần ===");
            int[] a = new int[1000];
            NhapNgauNhien(a, 0, new Random());

            Console.WriteLine("a. Mảng ban đầu:");
            InMang(a, 0);

            NoiBot(a, a.Length);

            Console.WriteLine();
            Console.WriteLine("b. Mảng sau khi sắp xếp tăng dần:");
            InMang(a, 0);
        }
    }
}