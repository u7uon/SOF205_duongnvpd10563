using DAL_QLBanHang;
using DTO_QLBanHang;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_QLBanHang
{
    public class BUS_KhachHang
    {
        private DAL_KhachHang dal_kh = new DAL_KhachHang();
        public bool insert_KH(DTO_KhachHang kh)
        {
            return  dal_kh.insert_KH(kh);
        }
        public bool update_KH(DTO_KhachHang kh)
        {
            return dal_kh.update_KH(kh);
        }
        public bool delete_KH(string sdt)
        {
            return dal_kh.delete_KH(sdt);
        }
        public DataTable Load_KH()
        {
            return dal_kh.Load_KH();
        }
        public DataTable search_KH(string ten) {
            return dal_kh.search_KH(ten);
        }
    }
}
