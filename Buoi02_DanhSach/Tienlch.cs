using System;

namespace Buoi02_List
{
    public static class TienIch
    {
        // Đọc số nguyên
        public static int DocSoNguyen(string loiNhac)
        {
            int so;
            Console.Write(loiNhac);

            while (!int.TryParse(Console.ReadLine(), out so))
            {
                Console.Write("Giá trị không hợp lệ, nhập lại: ");
            }

            return so;
        }

        // Đọc số nguyên dương
        public static int DocSoDuong(string loiNhac)
        {
            int so = DocSoNguyen(loiNhac);

            while (so <= 0)
            {
                so = DocSoNguyen("Phải là số nguyên dương, nhập lại: ");
            }

            return so;
        }

        // Đọc số nguyên trong khoảng
        public static int DocSoTrongKhoang(string loiNhac, int tu, int den)
        {
            int so = DocSoNguyen(loiNhac);

            while (so < tu || so > den)
            {
                so = DocSoNguyen("Giá trị phải từ " + tu + " đến " + den + ", nhập lại: ");
            }

            return so;
        }

        // Đọc chuỗi
        public static string DocChuoi(string loiNhac)
        {
            Console.Write(loiNhac);
            return Console.ReadLine() ?? "";
        }

        public static bool DungDuLieuMau()
        {
            Console.WriteLine("1. Dùng dữ liệu mẫu");
            Console.WriteLine("2. Nhập từ bàn phím");

            int chon = DocSoTrongKhoang("Chọn (1/2): ", 1, 2);

            return chon == 1;
        }
    }
}