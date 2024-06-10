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
    public class BUS_SanPham
    {
        private DAL_SanPham dal_sp = new DAL_SanPham();
        public bool insert_SP (DTO_SanPham sp)
        {
            return dal_sp.insert_SP(sp);
        }
        public bool update_SP(DTO_SanPham sp)
        {
            return dal_sp.update_SP(sp);
        }
        public bool delete_SP(int maSP)
        {
            return dal_sp.delete_SP(maSP);
        }
        public DataTable LoadData_SP ()
        {
            return dal_sp.LoadData_SP();
        }
        public DataTable Search_SP(string tenSP)
        {
            return dal_sp.search_SP(tenSP);
        }
        public string getIMG(int id)
        {
            return dal_sp.getImg(id);
        }
    }
}
