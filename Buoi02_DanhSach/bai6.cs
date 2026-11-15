using System;
using System.Diagnostics;

namespace Buoi01_DeQuy
{
    // Bài tập 6 (Chương 2): Sắp xếp một dãy n số thực thành dãy tăng dần
    // Cài đặt 5 giải thuật:
    //   1. Bubble Sort    - tốt nhất O(n) (có cờ dừng sớm), trung bình/xấu nhất O(n^2)
    //   2. Selection Sort - luôn Theta(n^2)
    //   3. Insertion Sort - tốt nhất O(n), trung bình/xấu nhất O(n^2)
    //   4. Quick Sort     - trung bình O(n log n), xấu nhất O(n^2)
    //   5. Merge Sort     - luôn Theta(n log n), cần thêm O(n) bộ nhớ
    class Bai6
    {
        // ---------- 1. Bubble Sort ----------
        static void NoiBot(double[] a, int n)
        {
            for (int i = 0; i < n - 1; i++)
            {
                bool daDoi = false;
                for (int j = 0; j < n - 1 - i; j++)
                {
                    if (a[j] > a[j + 1])
                    {
                        double tam = a[j];
                        a[j] = a[j + 1];
                        a[j + 1] = tam;
                        daDoi = true;
                    }
                }
                if (!daDoi)
                    break;   // một lượt không đổi chỗ lần nào => mảng đã sắp xếp
            }
        }

        // ---------- 2. Selection Sort ----------
        static void Chon(double[] a, int n)
        {
            for (int i = 0; i < n - 1; i++)
            {
                int viTriMin = i;
                for (int j = i + 1; j < n; j++)
                {
                    if (a[j] < a[viTriMin])
                        viTriMin = j;
                }
                if (viTriMin != i)
                {
                    double tam = a[i];
                    a[i] = a[viTriMin];
                    a[viTriMin] = tam;
                }
            }
        }

        // ---------- 3. Insertion Sort ----------
        static void Chen(double[] a, int n)
        {
            for (int i = 1; i < n; i++)
            {
                double x = a[i];     // phần tử cần chèn vào đoạn đã sắp xếp a[0..i-1]
                int j = i - 1;
                while (j >= 0 && a[j] > x)
                {
                    a[j + 1] = a[j]; // dời các phần tử lớn hơn x sang phải
                    j--;
                }
                a[j + 1] = x;
            }
        }

        // ---------- 4. Quick Sort (chọn phần tử ở giữa làm chốt) ----------
        static void NhanhDeQuy(double[] a, int trai, int phai)
        {
            if (trai >= phai)
                return;

            double chot = a[trai + (phai - trai) / 2];
            int i = trai;
            int j = phai;
            while (i <= j)
            {
                while (a[i] < chot) i++;   // tìm phần tử >= chốt ở bên trái
                while (a[j] > chot) j--;   // tìm phần tử <= chốt ở bên phải
                if (i <= j)
                {
                    double tam = a[i];
                    a[i] = a[j];
                    a[j] = tam;
                    i++;
                    j--;
                }
            }
            NhanhDeQuy(a, trai, j);    // sắp xếp phần bên trái chốt
            NhanhDeQuy(a, i, phai);    // sắp xếp phần bên phải chốt
        }

        static void Nhanh(double[] a, int n)
        {
            NhanhDeQuy(a, 0, n - 1);
        }

        // ---------- 5. Merge Sort ----------
        // Trộn hai đoạn đã sắp xếp a[trai..giua] và a[giua+1..phai]
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
            {
                a[k] = tam[k];
            }
        }

        static void TronDeQuy(double[] a, double[] tam, int trai, int phai)
        {
            if (trai >= phai)
                return;
            int giua = trai + (phai - trai) / 2;
            TronDeQuy(a, tam, trai, giua);        // sắp xếp nửa trái
            TronDeQuy(a, tam, giua + 1, phai);    // sắp xếp nửa phải
            Tron(a, tam, trai, giua, phai);       // trộn hai nửa
        }

        static void SapXepTron(double[] a, int n)
        {
            double[] tam = new double[n];
            TronDeQuy(a, tam, 0, n - 1);
        }

        // ---------- Các hàm hỗ trợ ----------
        static string[] tenGiaiThuat = { "Bubble", "Selection", "Insertion", "Quick", "Merge" };

        // Gọi giải thuật theo số thứ tự 0..4
        static void ChaySapXep(int loai, double[] a, int n)
        {
            if (loai == 0) NoiBot(a, n);
            else if (loai == 1) Chon(a, n);
            else if (loai == 2) Chen(a, n);
            else if (loai == 3) Nhanh(a, n);
            else SapXepTron(a, n);
        }

        static double[] SaoChep(double[] a, int n)
        {
            double[] b = new double[n];
            for (int i = 0; i < n; i++)
                b[i] = a[i];
            return b;
        }

        static bool LaMangTang(double[] a, int n)
        {
            for (int i = 0; i < n - 1; i++)
            {
                if (a[i] > a[i + 1])
                    return false;
            }
            return true;
        }

        static double[] TaoNgauNhien(int n)
        {
            Random rd = new Random(12345);   // cố định hạt giống để mỗi lần chạy cùng dữ liệu
            double[] a = new double[n];
            for (int i = 0; i < n; i++)
                a[i] = Math.Round(rd.NextDouble() * 10000, 2);
            return a;
        }

        static void InMang(double[] a, int n)
        {
            for (int i = 0; i < n; i++)
                Console.Write(a[i] + " ");
            Console.WriteLine();
        }

        // Đo thời gian (mili giây) chạy giải thuật loai trên bản sao của a
        static double DoThoiGian(int loai, double[] a, int n)
        {
            double[] b = SaoChep(a, n);
            Stopwatch dongHo = new Stopwatch();
            dongHo.Start();
            ChaySapXep(loai, b, n);
            dongHo.Stop();
            return dongHo.Elapsed.TotalMilliseconds;
        }

        public static void ChayBai6()
        {
            // ===== Phần 1: chạy thử với mảng mẫu =====
            Console.WriteLine("=== Chạy thử với mảng mẫu ===");
            double[] mau = { 5.5, 2.1, 9.8, 1.0, 7.3, 3.3, 8.8, 2.1 };
            int nMau = mau.Length;
            Console.Write("Mảng ban đầu: ");
            InMang(mau, nMau);
            for (int loai = 0; loai < 5; loai++)
            {
                double[] b = SaoChep(mau, nMau);
                ChaySapXep(loai, b, nMau);
                Console.Write(tenGiaiThuat[loai] + " Sort: ");
                InMang(b, nMau);
            }
            Console.WriteLine();

            // ===== Phần 2: kiểm tra tính đúng đắn trên 1000 số ngẫu nhiên =====
            Console.WriteLine("=== Kiểm tra tính đúng đắn (1000 số ngẫu nhiên) ===");
            double[] kiemTra = TaoNgauNhien(1000);
            for (int loai = 0; loai < 5; loai++)
            {
                double[] b = SaoChep(kiemTra, 1000);
                ChaySapXep(loai, b, 1000);
                Console.WriteLine(tenGiaiThuat[loai] + " Sort: " + (LaMangTang(b, 1000) ? "đúng" : "SAI"));
            }
            Console.WriteLine();

            // ===== Phần 3: đo thời gian trên dữ liệu ngẫu nhiên (mili giây) =====
            Console.WriteLine("=== Thời gian thực nghiệm - dữ liệu ngẫu nhiên (mili giây) ===");
            Console.WriteLine("n\t\tBubble\t\tSelection\tInsertion\tQuick\t\tMerge");
            int[] cacN = { 1000, 2000, 5000, 10000, 20000, 100000, 1000000 };
            for (int k = 0; k < cacN.Length; k++)
            {
                int n = cacN[k];
                double[] a = TaoNgauNhien(n);
                string dong = n + "\t\t";
                for (int loai = 0; loai < 5; loai++)
                {
                    // Ba giải thuật O(n^2) quá chậm với n lớn nên chỉ đo đến n = 20000
                    if (loai <= 2 && n > 20000)
                        dong = dong + "bỏ qua\t\t";
                    else
                        dong = dong + DoThoiGian(loai, a, n).ToString("F2") + "\t\t";
                }
                Console.WriteLine(dong);
            }
            Console.WriteLine();

            // ===== Phần 4: ảnh hưởng của dạng dữ liệu đầu vào (n = 5000) =====
            Console.WriteLine("=== Ảnh hưởng của dạng dữ liệu (n = 5000, mili giây) ===");
            Console.WriteLine("Dạng dữ liệu\tBubble\t\tSelection\tInsertion\tQuick\t\tMerge");
            int nn = 5000;
            double[] tangSan = new double[nn];
            double[] giamDan = new double[nn];
            for (int i = 0; i < nn; i++)
            {
                tangSan[i] = i;
                giamDan[i] = nn - i;
            }
            double[] ngauNhien = TaoNgauNhien(nn);

            double[][] cacDang = { tangSan, giamDan, ngauNhien };
            string[] tenDang = { "Tăng sẵn", "Giảm dần", "Ngẫu nhiên" };
            for (int d = 0; d < 3; d++)
            {
                string dong = tenDang[d] + "\t";
                for (int loai = 0; loai < 5; loai++)
                {
                    dong = dong + DoThoiGian(loai, cacDang[d], nn).ToString("F2") + "\t\t";
                }
                Console.WriteLine(dong);
            }
            Console.WriteLine();

            Console.WriteLine("Kết luận:");
            Console.WriteLine("- Bubble, Selection, Insertion: O(n^2) - chậm khi n lớn (Insertion/Bubble rất nhanh nếu mảng gần sắp xếp)");
            Console.WriteLine("- Quick Sort: trung bình O(n log n), xấu nhất O(n^2); Merge Sort: luôn O(n log n) nhưng tốn thêm bộ nhớ");
            Console.WriteLine("- Ổn định (stable): Bubble, Insertion, Merge. Không ổn định: Selection, Quick");
        }
    }
}