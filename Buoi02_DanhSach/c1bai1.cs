using System;

namespace Buoi01_DeQuy
{
    // Chương 1 - Bài tập 1: Nhập ngẫu nhiên 1000 số tự nhiên vào mảng, tìm số lớn nhất và số nhỏ nhất
    class C1Bai1
    {
        public static void ChayC1Bai1()
        {
            Console.WriteLine("=== Chương 1 - Bài 1: Số lớn nhất, số nhỏ nhất trong 1000 số ngẫu nhiên ===");

            int n = 1000;
            int[] a = new int[n];
            Random rd = new Random();

            // Sinh 1000 số tự nhiên ngẫu nhiên trong khoảng 0..9999
            for (int i = 0; i < n; i++)
            {
                a[i] = rd.Next(0, 10000);
            }

            Console.Write("10 phần tử đầu của mảng: ");
            for (int i = 0; i < 10; i++)
            {
                Console.Write(a[i] + " ");
            }
            Console.WriteLine();

            // Giả sử phần tử đầu tiên vừa là lớn nhất vừa là nhỏ nhất, rồi duyệt so sánh
            int max = a[0];
            int viTriMax = 0;
            int min = a[0];
            int viTriMin = 0;
            for (int i = 1; i < n; i++)
            {
                if (a[i] > max)
                {
                    max = a[i];
                    viTriMax = i;
                }
                if (a[i] < min)
                {
                    min = a[i];
                    viTriMin = i;
                }
            }

            Console.WriteLine("a. Số lớn nhất: " + max + " (vị trí " + viTriMax + ")");
            Console.WriteLine("b. Số nhỏ nhất: " + min + " (vị trí " + viTriMin + ")");
        }
    }
}