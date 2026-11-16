using System;

namespace Buoi01_DeQuy
{
    // Chương 1 - Bài 2 (trang 25): FizzBuzz từ 1 đến 100 (đệ quy)
    //   Chia hết 3 -> Fizz; chia hết 5 -> Buzz; chia hết cả 3 và 5 -> FizzBuzz; còn lại in số
    class Ch1_Bai2
    {
        // In các số từ i đến n
        static void FizzBuzz(int i, int n)
        {
            if (i > n) return;                       // suy biến: đã in hết

            if (i % 3 == 0 && i % 5 == 0)            // kiểm tra "cả 3 và 5" trước tiên
                Console.Write("FizzBuzz\t");
            else if (i % 3 == 0)
                Console.Write("Fizz\t");
            else if (i % 5 == 0)
                Console.Write("Buzz\t");
            else
                Console.Write(i + "\t");

            if (i % 10 == 0)
                Console.WriteLine();                 // xuống dòng sau mỗi 10 số

            FizzBuzz(i + 1, n);                      // đệ quy: in số tiếp theo
        }

        public static void Chay()
        {
            Console.WriteLine("=== Chương 1 - Bài 2: FizzBuzz ===");
            FizzBuzz(1, 100);
        }
    }
}