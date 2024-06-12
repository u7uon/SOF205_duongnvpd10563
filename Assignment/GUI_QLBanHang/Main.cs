using BUS_QLBanHang;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI_QLBanHang
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }
        private BUS_NhanVien bus_nv = new BUS_NhanVien();
        private string usingEmail;
        private bool isAdmin; 

        void ChangeForm(Form form)
        {
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;

            panel1.Controls.Clear();
            panel1.Controls.Add(form);
            form.Show();
        }

        private void LoggedIn(bool check)
        {
            menu_thongKe.Visible = check;
            menu_danhmuc.Visible = check;
            menu_login.Enabled = !check;
            menu_Logout.Visible = check;
            if (!check)
            {
                panel1.Controls.Clear();
                panel1.BackgroundImage = Properties.Resources.
            }
            if (check) 
            {
                menuNhanVien.Visible = isAdmin;
                menu_thongKe.Visible = isAdmin;
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            
        }



        private void đăngNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (frm_login frmlogin = new frm_login())
            {
                frmlogin.ShowDialog();
                if (frmlogin.getStatus)
                {
                    usingEmail = frmlogin.getEmail;
                    isAdmin = frmlogin.isAdmin;
                    LoggedIn(true);
                    frmlogin.Close();
                }
            }
        }



        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn muốn đăng xuất ?", "Cảnh báo", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
                LoggedIn(false);
        }

        private void thôngTinNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (DoiMatKhau frmDoiMk = new DoiMatKhau())
            {
                frmDoiMk.ShowDialog();
                if (frmDoiMk.getStatus)
                {
                    frmDoiMk.Close();
                    LoggedIn(false);

                }
            }
        }

        private void menuNhanVien_Click(object sender, EventArgs e)
        {
            ChangeForm(new QL_NhanVien());
        }

        private void MenuKhachhang_Click(object sender, EventArgs e)
        {
            ChangeForm(new QL_KhachHang(usingEmail));

        }

        private void MenuSanPham_Click(object sender, EventArgs e)
        {
            ChangeForm(new Ql_SanPham(usingEmail));
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void menu_danhmuc_Click(object sender, EventArgs e)
        {

        }

        private void menu_HuonDan_Click(object sender, EventArgs e)
        {

        }
    }
}
