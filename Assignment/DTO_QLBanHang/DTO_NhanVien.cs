using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QLBanHang
{
    public class DTO_NhanVien
    {
        private string TenNV;
        private string email;
        private string DiaChi;
        private int VaiTro;
        private int TinhTrang;
        private string MatKhau;


        public string TenNhanVien
        {
            get
            {
                return TenNV;
            }
            set
            {
                TenNV = value;
            }
        }
        public string Email
        {
            get
            {
                return email;
            }
            set
            {
                email = value;
            }
        }
        public string diaChi
        {
            get
            {
                return DiaChi;
            }
            set
            {
                DiaChi = value;
            }
        }
        public int vaiTro
        {
            get
            {
                return VaiTro;
            }
            set
            {
                VaiTro = value;
            }
        }
        public int tinhtrang
        {
            get
            {
                return TinhTrang;
            }
            set
            {
                TinhTrang = value;
            }
        }
        public string matKhau
        {
            get
            {
                return MatKhau;
            }
            set
            {
                MatKhau = value;
            }
        }


        #region constructer
        public DTO_NhanVien(string TenNV, string email, string diaChi, int VaiTro, int TinhTrang, string MatKhau)
        {
            this.TenNV = TenNV;
            this.email = email;
            this.DiaChi = diaChi;
            this.VaiTro = VaiTro;
            this.TinhTrang = TinhTrang;
            this.MatKhau = MatKhau;
        }

        public DTO_NhanVien(string emailnv, string tennv, string diaChi, int VaiTro, int tinhTrang)
        {
            this.email = emailnv;
            this.TenNV = tennv;
            this.DiaChi = diaChi;
            this.VaiTro = VaiTro;
            this.TinhTrang = tinhTrang;
        }
        #endregion
    }
}
