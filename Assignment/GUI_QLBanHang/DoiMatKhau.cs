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
    public partial class DoiMatKhau : Form
    {
        public DoiMatKhau()
        {
            InitializeComponent();
        }
        private bool status = false;
        public bool getStatus
        {
            get { return status; }
            set { status = value; }
        }
        private BUS_NhanVien bus_nv = new BUS_NhanVien();
        private void button1_Click(object sender, EventArgs e)
        {
            if (txtNewPass.Text == txtConfirmPass.Text)
            {
                if (bus_nv.Login(txtEmail.Text, txtOldpass.Text))
                {
                    if (bus_nv.setNewPass(txtEmail.Text, txtNewPass.Text))
                    {
                        status = true;
                        MessageBox.Show("Đổi mật khẩu thành công , vui lòng đăng nhập lại");
                        this.Close();

                    }
                }
            }
            else
                MessageBox.Show("Mật khẩu mới và mật khẩu xác nhận không trùng");
        }
    }
}
