using System;

namespace Buoi01_DeQuy
{
    // Chương 1 - Bài tập 4: Nhập ngẫu nhiên 1000 số tự nhiên vào mảng
    //   a. In mảng ra màn hình
    //   b. Sắp xếp mảng tăng dần và in ra màn hình
    class C1Bai4
    {
        // In mảng, mỗi dòng 10 phần tử
        static void InMang(int[] a, int n)
        {
            for (int i = 0; i < n; i++)
            {
                Console.Write(a[i] + "\t");
                if ((i + 1) % 10 == 0)
                {
                    Console.WriteLine();
                }
            }
        }

        // Sắp xếp nổi bọt (Bubble Sort): đẩy dần phần tử lớn về cuối mảng
        static void SapXepTang(int[] a, int n)
        {
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - 1 - i; j++)
                {
                    if (a[j] > a[j + 1])
                    {
                        int tam = a[j];
                        a[j] = a[j + 1];
                        a[j + 1] = tam;
                    }
                }
            }
        }

        public static void ChayC1Bai4()
        {
            Console.WriteLine("=== Chương 1 - Bài 4: In mảng và sắp xếp tăng dần ===");

            int n = 1000;
            int[] a = new int[n];
            Random rd = new Random();
            for (int i = 0; i < n; i++)
            {
                a[i] = rd.Next(0, 10000);
            }

            Console.WriteLine("a. Mảng ban đầu:");
            InMang(a, n);

            SapXepTang(a, n);

            Console.WriteLine();
            Console.WriteLine("b. Mảng sau khi sắp xếp tăng dần:");
            InMang(a, n);
        }
    }
}