using System;
using System.Diagnostics;

namespace Buoi01_DeQuy
{
    // Chương 2 - Bài 6 (trang 78-79): Sắp xếp một dãy n số thực tăng dần (5 giải thuật, viết bằng đệ quy)
    //   1. Bubble Sort    - O(n^2)           (tốt nhất O(n) nếu có cờ dừng sớm)
    //   2. Selection Sort - Theta(n^2)
    //   3. Insertion Sort - O(n^2)           (tốt nhất O(n) khi mảng gần sắp xếp)
    //   4. Quick Sort     - trung bình O(n log n), xấu nhất O(n^2)
    //   5. Merge Sort     - Theta(n log n), cần thêm O(n) bộ nhớ, ổn định
    // Với 3 giải thuật đầu, vòng lặp ngoài được thay bằng lời gọi đệ quy.
    class Ch2_Bai6
    {
        static void DoiCho(double[] a, int i, int j)
        {
            double tam = a[i];
            a[i] = a[j];
            a[j] = tam;
        }

        // ---------- 1. Bubble Sort ----------
        static void NoiBot(double[] a, int n)
        {
            if (n <= 1) return;
            for (int j = 0; j < n - 1; j++)
            {
                if (a[j] > a[j + 1])
                    DoiCho(a, j, j + 1);
            }
            NoiBot(a, n - 1);                        // số lớn nhất đã về cuối, xử lý n-1 phần tử đầu
        }

        // ---------- 2. Selection Sort ----------
        static void Chon(double[] a, int i, int n)
        {
            if (i >= n - 1) return;
            int viTriMin = i;
            for (int j = i + 1; j < n; j++)
            {
                if (a[j] < a[viTriMin])
                    viTriMin = j;
            }
            DoiCho(a, i, viTriMin);
            Chon(a, i + 1, n);                       // xếp tiếp vị trí i + 1
        }

        // ---------- 3. Insertion Sort ----------
        static void Chen(double[] a, int n)
        {
            if (n <= 1) return;
            Chen(a, n - 1);                          // sắp xếp n-1 phần tử đầu trước
            double x = a[n - 1];                     // rồi chèn phần tử thứ n vào đúng chỗ
            int j = n - 2;
            while (j >= 0 && a[j] > x)
            {
                a[j + 1] = a[j];
                j--;
            }
            a[j + 1] = x;
        }

        // ---------- 4. Quick Sort (chốt là phần tử ở giữa) ----------
        static void Nhanh(double[] a, int trai, int phai)
        {
            if (trai >= phai) return;
            double chot = a[trai + (phai - trai) / 2];
            int i = trai;
            int j = phai;
            while (i <= j)
            {
                while (a[i] < chot) i++;
                while (a[j] > chot) j--;
                if (i <= j)
                {
                    DoiCho(a, i, j);
                    i++;
                    j--;
                }
            }
            Nhanh(a, trai, j);                       // sắp xếp phần bên trái
            Nhanh(a, i, phai);                       // sắp xếp phần bên phải
        }

        // ---------- 5. Merge Sort ----------
        static void Tron(double[] a, double[] tam, int trai, int giua, int phai)
        {
            int i = trai;
            int j = giua + 1;
            int k = trai;
            while (i <= giua && j <= phai)
            {
                if (a[i] <= a[j])
                {
                    tam[k] = a[i];
                    i++;
                }
                else
                {
                    tam[k] = a[j];
                    j++;
                }
                k++;
            }
            while (i <= giua)
            {
                tam[k] = a[i];
                i++;
                k++;
            }
            while (j <= phai)
            {
                tam[k] = a[j];
                j++;
                k++;
            }
            for (k = trai; k <= phai; k++)
                a[k] = tam[k];
        }

        static void TronSort(double[] a, double[] tam, int trai, int phai)
        {
            if (trai >= phai) return;
            int giua = trai + (phai - trai) / 2;
            TronSort(a, tam, trai, giua);
            TronSort(a, tam, giua + 1, phai);
            Tron(a, tam, trai, giua, phai);
        }

        // ---------- Hàm hỗ trợ ----------
        static string[] ten = { "Bubble", "Selection", "Insertion", "Quick", "Merge" };

        static void ChaySapXep(int loai, double[] a, int n)
        {
            if (loai == 0) NoiBot(a, n);
            else if (loai == 1) Chon(a, 0, n);
            else if (loai == 2) Chen(a, n);
            else if (loai == 3) Nhanh(a, 0, n - 1);
            else TronSort(a, new double[n], 0, n - 1);
        }

        static bool LaMangTang(double[] a, int i)
        {
            if (i >= a.Length - 1) return true;
            if (a[i] > a[i + 1]) return false;
            return LaMangTang(a, i + 1);
        }

        static double[] TaoNgauNhien(int n)
        {
            Random rd = new Random(12345);
            double[] a = new double[n];
            for (int i = 0; i < n; i++)
                a[i] = Math.Round(rd.NextDouble() * 10000, 2);
            return a;
        }

        static double DoThoiGian(int loai, double[] a)
        {
            double[] b = (double[])a.Clone();
            Stopwatch dh = new Stopwatch();
            dh.Start();
            ChaySapXep(loai, b, b.Length);
            dh.Stop();
            return dh.Elapsed.TotalMilliseconds;
        }

        public static void Chay()
        {
            Console.WriteLine("=== Chương 2 - Bài 6: Sắp xếp dãy số thực ===");

            double[] mau = { 5.5, 2.1, 9.8, 1.0, 7.3, 3.3, 8.8, 2.1 };
            Console.WriteLine("Ban đầu: " + string.Join(" ", mau));
            for (int loai = 0; loai < 5; loai++)
            {
                double[] b = (double[])mau.Clone();
                ChaySapXep(loai, b, b.Length);
                Console.WriteLine(ten[loai].PadRight(10) + ": " + string.Join(" ", b));
            }
            Console.WriteLine();

            // Kiểm tra tính đúng đắn
            double[] kiemTra = TaoNgauNhien(1000);
            for (int loai = 0; loai < 5; loai++)
            {
                double[] b = (double[])kiemTra.Clone();
                ChaySapXep(loai, b, b.Length);
                Console.WriteLine(ten[loai] + " Sort (1000 số ngẫu nhiên): " + (LaMangTang(b, 0) ? "đúng" : "SAI"));
            }
            Console.WriteLine();

            // Thời gian trên dữ liệu ngẫu nhiên
            Console.WriteLine("Thời gian thực nghiệm - dữ liệu ngẫu nhiên (mili giây):");
            Console.WriteLine("n\t\tBubble\t\tSelection\tInsertion\tQuick\t\tMerge");
            int[] cacN = { 500, 1000, 2000, 5000, 100000, 1000000 };
            for (int k = 0; k < cacN.Length; k++)
            {
                int n = cacN[k];
                double[] a = TaoNgauNhien(n);
                string dong = n + "\t\t";
                for (int loai = 0; loai < 5; loai++)
                {
                    // 3 giải thuật đầu là O(n^2) và đệ quy sâu n tầng nên chỉ đo n <= 5000
                    if (loai <= 2 && n > 5000)
                        dong = dong + "bỏ qua\t\t";
                    else
                        dong = dong + DoThoiGian(loai, a).ToString("F2") + "\t\t";
                }
                Console.WriteLine(dong);
            }
            Console.WriteLine();

            // Ảnh hưởng của dạng dữ liệu
            Console.WriteLine("Ảnh hưởng của dạng dữ liệu (n = 2000, mili giây):");
            Console.WriteLine("Dạng\t\tBubble\t\tSelection\tInsertion\tQuick\t\tMerge");
            int nn = 2000;
            double[] tang = new double[nn];
            double[] giam = new double[nn];
            for (int i = 0; i < nn; i++)
            {
                tang[i] = i;
                giam[i] = nn - i;
            }
            double[][] cacDang = { tang, giam, TaoNgauNhien(nn) };
            string[] tenDang = { "Tăng sẵn", "Giảm dần", "Ngẫu nhiên" };
            for (int d = 0; d < 3; d++)
            {
                string dong = tenDang[d] + "\t";
                for (int loai = 0; loai < 5; loai++)
                    dong = dong + DoThoiGian(loai, cacDang[d]).ToString("F2") + "\t\t";
                Console.WriteLine(dong);
            }
            Console.WriteLine();
            Console.WriteLine("Kết luận: Bubble/Selection/Insertion O(n^2); Quick trung bình O(n log n); Merge luôn O(n log n).");
            Console.WriteLine("Ổn định: Bubble, Insertion, Merge. Không ổn định: Selection, Quick.");
        }
    }
}