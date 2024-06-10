using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QLBanHang
{
    public class DTO_SanPham
    {
            private int maSP;
            private string TenSP;
            private int soLuong;
            private double GiaNhap;
            private double GiaBan;
            private string GhiChu;
            private string email;
            private string hinhAnh;

            public int MaSP
            {
                get { return maSP; }
                set { maSP = value; }
            }
            public int SoLuong
            {
                get { return soLuong; }
                set { soLuong = value; }
            }
            public string tenSP
            {
                get { return TenSP; }
                set { TenSP = value; }
            }
            public double giaBan
            {
                get { return GiaBan; }
                set { GiaBan = value; }
            }
            public double giaNhap
            {
                get { return GiaNhap; }
                set { GiaNhap = value; }
            }
            public string ghiChu
            {
                get { return GhiChu; }
                set { GhiChu = value; }
            }
            public string Email
            {
                get { return email; }
                set { email = value; }
            }
            public string HinhAnh
            {
                get { return hinhAnh; }
                set { hinhAnh = value; }
            }
            public DTO_SanPham(int maSp, string tenSP, int soLuong, double giaNhap, double giaBan, string ghiChu, string email)
            {
                this.maSP = maSp;
                this.TenSP = tenSP;
                this.soLuong = soLuong;
                this.GiaNhap = giaNhap;
                this.GiaBan = giaBan;
                this.GhiChu = ghiChu;
                this.email = email;
            }
            public DTO_SanPham( string tenSP, int soLuong, double giaNhap, double giaBan,string HinhAnh, string ghiChu, string email)
            {
                this.hinhAnh = HinhAnh;
                this.TenSP = tenSP;
                this.soLuong = soLuong;
                this.GiaNhap = giaNhap;
                this.GiaBan = giaBan;
                this.GhiChu = ghiChu;
                this.email = email;
            }
            public DTO_SanPham() { }
    }

}
