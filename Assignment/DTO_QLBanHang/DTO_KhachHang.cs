using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QLBanHang
{
    public class DTO_KhachHang
    {
        private string SoDienThoai;
        private string TenKH;
        private string DiaChiKh;
        private string GioiTinh;
        private string Email;

        public string SDT
        {
            get { return SoDienThoai; }
            set { SoDienThoai = value; }

        }
        public string TenKh
        {
            get { return TenKH; }
            set { TenKH = value; }
        }
        public string DiaChi
        {
            get { return DiaChiKh; }
            set { DiaChiKh = value; }
        }
        public string gioiTinh
        {
            get { return GioiTinh; }
            set { GioiTinh = value; }
        }
        public string email
        {
            get { return Email; }
            set { Email = value; }
        }

        public DTO_KhachHang(string dienthoai, string tenkh, string diaChi, string gioiTinh, string email)
        {
            this.SoDienThoai = dienthoai;
            this.TenKH = tenkh;
            this.DiaChi = diaChi;
            this.GioiTinh = gioiTinh;
            this.Email = email;
        }
        public DTO_KhachHang(string dienthoai, string tenkh, string diaChi, string gioiTinh)
        {
            this.SoDienThoai = dienthoai;
            this.TenKH = tenkh;
            this.DiaChi = diaChi;
            this.GioiTinh = gioiTinh;
            
        }
        public DTO_KhachHang() { }
    }
}
