using System;

namespace Buoi01_DeQuy
{
    // Chương 1 - Bài tập 2: Bài toán FizzBuzz (in các số từ 1 đến 100)
    //   Chia hết cho 3      -> "Fizz"
    //   Chia hết cho 5      -> "Buzz"
    //   Chia hết cho cả 3,5 -> "FizzBuzz"
    //   Còn lại             -> in chính số đó
    class C1Bai2
    {
        public static void ChayC1Bai2()
        {
            Console.WriteLine("=== Chương 1 - Bài 2: FizzBuzz ===");

            for (int i = 1; i <= 100; i++)
            {
                // Phải kiểm tra điều kiện "chia hết cả 3 và 5" trước, nếu không sẽ bị rơi vào nhánh Fizz hoặc Buzz
                if (i % 3 == 0 && i % 5 == 0)
                {
                    Console.Write("FizzBuzz\t");
                }
                else if (i % 3 == 0)
                {
                    Console.Write("Fizz\t");
                }
                else if (i % 5 == 0)
                {
                    Console.Write("Buzz\t");
                }
                else
                {
                    Console.Write(i + "\t");
                }

                // Xuống dòng sau mỗi 10 số cho dễ nhìn
                if (i % 10 == 0)
                {
                    Console.WriteLine();
                }
            }
        }
    }
}