using BUS_QLBanHang;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI_QLBanHang
{
    public partial class ThongKecs : Form
    {
        public ThongKecs()
        {
            InitializeComponent();
        }
        void LoadGridview()
        {
            dtgvThongKeTonKho.Columns[0].HeaderText = "Tên hàng";
            dtgvThongKeTonKho.Columns[1].HeaderText = "Số lượng";
           
            dtgvThongKeSP.Columns[0].HeaderText = "Mã nhân viên";
            dtgvThongKeSP.Columns[1].HeaderText = "Tên nhân viên";
            dtgvThongKeSP.Columns[2].HeaderText = "Số lượng sản phẩm nhập";
        }
        private void ThongKecs_Load(object sender, EventArgs e)
        {
            BUS_SanPham sp = new BUS_SanPham();
            dtgvThongKeSP.DataSource = sp.thongke_sp();
            dtgvThongKeTonKho.DataSource = sp.thongketonkho();
            LoadGridview(); 
        }
    }
}
