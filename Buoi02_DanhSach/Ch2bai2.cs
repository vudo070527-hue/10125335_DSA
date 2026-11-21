using System;

namespace Buoi02_List
{
    // Cấu trúc lưu thông tin một nhân viên
    struct NhanVien
    {
        public string MaNV;
        public string Hoten;
        public int Namsinh;
        public string Phongban;
        public int LuongCB;
        public int Thuong;
    }

    // Chương 4 - Bài 2 (trang 160-161): Danh sách nhân viên (mảng DS)
    //   a. Tính tổng thực lĩnh tháng của tất cả nhân viên (thực lĩnh = lương cơ bản + thưởng)
    //   b. In danh sách nhân viên có lương cơ bản thấp nhất
    //   c. Đếm số nhân viên có thưởng >= 1200000
    //   d. In danh sách tăng dần theo phòng ban, nếu trùng phòng ban thì giảm dần theo mã nhân viên
    //   e. Cập nhật tăng lương (lương cơ bản) của tất cả nhân viên lên 5%
    class Ch2Bai2
    {
        static NhanVien[] DS;

        static NhanVien TaoNhanVien(string ma, string ten, int namSinh, string phong, int luongCB, int thuong)
        {
            NhanVien nv = new NhanVien();
            nv.MaNV = ma;
            nv.Hoten = ten;
            nv.Namsinh = namSinh;
            nv.Phongban = phong;
            nv.LuongCB = luongCB;
            nv.Thuong = thuong;
            return nv;
        }

        // Thực lĩnh của một nhân viên = lương cơ bản + thưởng
        static int ThucLinh(NhanVien nv)
        {
            return nv.LuongCB + nv.Thuong;
        }

        static void DuLieuMau()
        {
            DS = new NhanVien[6];
            DS[0] = TaoNhanVien("NV001", "Nguyen Van An", 1995, "Ke toan", 8000000, 1200000);
            DS[1] = TaoNhanVien("NV002", "Tran Thi Binh", 1992, "Kinh doanh", 9500000, 2000000);
            DS[2] = TaoNhanVien("NV003", "Le Van Cuong", 1998, "Ke toan", 7000000, 800000);
            DS[3] = TaoNhanVien("NV004", "Pham Thi Dung", 1990, "Ky thuat", 12000000, 1500000);
            DS[4] = TaoNhanVien("NV005", "Hoang Van Em", 1997, "Kinh doanh", 7000000, 1200000);
            DS[5] = TaoNhanVien("NV006", "Vu Thi Phuong", 1999, "Ky thuat", 9000000, 500000);
        }

        static void NhapDanhSach()
        {
            int n = TienIch.DocSoDuong("Nhập số nhân viên: ");
            DS = new NhanVien[n];
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Nhân viên thứ " + (i + 1) + ":");
                DS[i].MaNV = TienIch.DocChuoi("  Mã nhân viên: ");
                DS[i].Hoten = TienIch.DocChuoi("  Họ và tên: ");
                DS[i].Namsinh = TienIch.DocSoNguyen("  Năm sinh: ");
                DS[i].Phongban = TienIch.DocChuoi("  Phòng ban: ");
                DS[i].LuongCB = TienIch.DocSoNguyen("  Lương cơ bản: ");
                DS[i].Thuong = TienIch.DocSoNguyen("  Thưởng: ");
            }
        }

        static void InTieuDe()
        {
            Console.WriteLine("MaNV".PadRight(8) + "Họ và tên".PadRight(20) + "Năm sinh".PadRight(10)
                + "Phòng ban".PadRight(14) + "Lương CB".PadRight(12) + "Thưởng".PadRight(12) + "Thực lĩnh");
        }

        static void InNhanVien(NhanVien nv)
        {
            Console.WriteLine(nv.MaNV.PadRight(8) + nv.Hoten.PadRight(20) + nv.Namsinh.ToString().PadRight(10)
                + nv.Phongban.PadRight(14) + nv.LuongCB.ToString().PadRight(12) + nv.Thuong.ToString().PadRight(12)
                + ThucLinh(nv));
        }

        static void InDanhSach(NhanVien[] ds)
        {
            InTieuDe();
            for (int i = 0; i < ds.Length; i++)
            {
                InNhanVien(ds[i]);
            }
        }

        // a. Duyệt từ đầu đến cuối, cộng dồn thực lĩnh của từng nhân viên
        static long TongThucLinh()
        {
            long tong = 0;
            for (int i = 0; i < DS.Length; i++)
            {
                tong = tong + ThucLinh(DS[i]);
            }
            return tong;
        }

        // b. Tìm lương cơ bản nhỏ nhất, rồi in tất cả nhân viên có lương bằng mức đó
        static void InLuongCBThapNhat()
        {
            int min = int.MaxValue;
            for (int i = 0; i < DS.Length; i++)
            {
                if (DS[i].LuongCB < min)
                    min = DS[i].LuongCB;
            }
            Console.WriteLine("Mức lương cơ bản thấp nhất: " + min);
            InTieuDe();
            for (int i = 0; i < DS.Length; i++)
            {
                if (DS[i].LuongCB == min)
                    InNhanVien(DS[i]);
            }
        }

        // c. Đếm số nhân viên có thưởng >= 1200000
        static int DemThuongLonHon1200000()
        {
            int dem = 0;
            for (int i = 0; i < DS.Length; i++)
            {
                if (DS[i].Thuong >= 1200000)
                    dem++;
            }
            return dem;
        }

        // d. Hai nhân viên a (đứng trước) và b (đứng sau) có cần đổi chỗ không?
        //    Phòng ban tăng dần: a.Phongban > b.Phongban thì đổi.
        //    Cùng phòng ban, mã giảm dần: a.MaNV < b.MaNV thì đổi.
        static bool PhaiDoiCho(NhanVien a, NhanVien b)
        {
            int soSanhPhong = string.Compare(a.Phongban, b.Phongban);
            if (soSanhPhong > 0)
                return true;
            if (soSanhPhong == 0 && string.Compare(a.MaNV, b.MaNV) < 0)
                return true;
            return false;
        }

        // Sắp xếp nổi bọt dựa trên PhaiDoiCho
        static void SapXep(NhanVien[] ds)
        {
            for (int i = 0; i < ds.Length - 1; i++)
            {
                for (int j = 0; j < ds.Length - 1 - i; j++)
                {
                    if (PhaiDoiCho(ds[j], ds[j + 1]))
                    {
                        NhanVien tam = ds[j];
                        ds[j] = ds[j + 1];
                        ds[j + 1] = tam;
                    }
                }
            }
        }

        // Sao chép mảng để sắp xếp mà không làm thay đổi thứ tự của DS gốc
        static NhanVien[] SaoChep(NhanVien[] ds)
        {
            NhanVien[] b = new NhanVien[ds.Length];
            for (int i = 0; i < ds.Length; i++)
            {
                b[i] = ds[i];
            }
            return b;
        }

        // e. Tăng lương cơ bản 5%: LuongCB = LuongCB * 105 / 100
        static void TangLuong5PhanTram()
        {
            for (int i = 0; i < DS.Length; i++)
            {
                DS[i].LuongCB = (int)((long)DS[i].LuongCB * 105 / 100);   // ép long để phép nhân không bị tràn số
            }
        }

        public static void Chay()
        {
            Console.WriteLine("=== Chương 4 - Bài 2: Quản lý danh sách nhân viên ===");
            if (TienIch.DungDuLieuMau())
            {
                DuLieuMau();
                Console.WriteLine("(Dùng dữ liệu mẫu)");
            }
            else
            {
                NhapDanhSach();
            }

            Console.WriteLine();
            Console.WriteLine("Danh sách nhân viên:");
            InDanhSach(DS);

            Console.WriteLine();
            Console.WriteLine("a. Tổng thực lĩnh tháng của công ty: " + TongThucLinh());

            Console.WriteLine();
            Console.WriteLine("b. Nhân viên có lương cơ bản thấp nhất:");
            InLuongCBThapNhat();

            Console.WriteLine();
            Console.WriteLine("c. Số nhân viên có thưởng >= 1200000: " + DemThuongLonHon1200000());

            Console.WriteLine();
            Console.WriteLine("d. Danh sách tăng dần theo phòng ban, trùng phòng ban thì giảm dần theo mã nhân viên:");
            NhanVien[] bang = SaoChep(DS);
            SapXep(bang);
            InDanhSach(bang);

            Console.WriteLine();
            Console.WriteLine("e. Danh sách sau khi tăng lương cơ bản 5%:");
            TangLuong5PhanTram();
            InDanhSach(DS);
        }
    }
}