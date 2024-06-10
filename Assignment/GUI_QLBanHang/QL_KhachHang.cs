using BUS_QLBanHang;
using DTO_QLBanHang;
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
    public partial class QL_KhachHang : Form
    {
        public QL_KhachHang(string email)
        {
            InitializeComponent();
            this.usingEmail = email;
        }
        private string usingEmail;
        private BUS_KhachHang bus_kh = new BUS_KhachHang();
        private bool isBlank()
        {
            return txtAddress.Text == "" || txtSdt.Text == "" || txtName.Text == "" || (!rdoMale.Checked && !rdoFemale.Checked);
        }
        private void ClearInput()
        {
            txtAddress.Clear();
            txtName.Clear();
            txtSdt.Clear();
            rdoFemale.Checked = false;
            rdoMale.Checked = false;
        }
        private void setControls(bool check)
        {
            btnUpdate.Enabled = check;
            btnDelete.Enabled = check;
            btnAddnew.Enabled = check;
        }
        void LoadGridView()
        {
            dataGridView1.Columns[0].HeaderText = "Số điện thoại";
            dataGridView1.Columns[1].HeaderText = "Tên Khách hàng";
            dataGridView1.Columns[2].HeaderText = "Địa chỉ";
            dataGridView1.Columns[3].HeaderText = "Giới tính";
            dataGridView1.Columns[4].HeaderText = "Mã nhân viên";
        }
        void LoadData()
        {
            dataGridView1.DataSource = bus_kh.Load_KH();
            LoadGridView();
        }
        private void btnAddnew_Click(object sender, EventArgs e)
        {
            if (!isBlank())
            {
                DTO_KhachHang kh = new DTO_KhachHang()
                {
                    SDT = txtSdt.Text,
                    TenKh = txtName.Text,
                    DiaChi = txtAddress.Text,
                    gioiTinh = rdoFemale.Checked ? "Nữ" : "Nam",
                    email = usingEmail
                };
                if (bus_kh.insert_KH(kh))
                {
                    MessageBox.Show("Thêm thành công");
                    setControls(false);
                    LoadData();
                    ClearInput();
                }
                else
                    MessageBox.Show("Thêm thất bại , kiểm tra dữ kiệu");
            }
            else
                MessageBox.Show("Vui lòng nhập đủ thông tin trước khi thêm");

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!isBlank())
            {
                DTO_KhachHang kh = new DTO_KhachHang()
                {
                    SDT = txtSdt.Text,
                    TenKh = txtName.Text,
                    DiaChi = txtAddress.Text,
                    gioiTinh = rdoFemale.Checked ? "Nữ" : "Nam",
                    email = usingEmail
                };
                if (bus_kh.update_KH(kh))
                {
                    MessageBox.Show("Sửa thành công");
                    setControls(false);
                    LoadData();
                    ClearInput();
                }
                else
                    MessageBox.Show("Sửa thất bại, kiểm tra lại thông tin");
            }
            else
                MessageBox.Show("Nhập thông tin trước khi sửa");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtSdt.Text != "")
            {
                DialogResult result = MessageBox.Show("Chắc chắn muốn xóa ?", "Cảnh báo", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    if (bus_kh.delete_KH(txtSdt.Text))
                    {
                        MessageBox.Show("Xóa thành công ");
                        setControls(false);
                        LoadData();
                        ClearInput();
                    }
                    else
                        MessageBox.Show("Không thể xóa khách hàng  này");
                }
            }
            else
                MessageBox.Show("Nhập số điện thoại cần xóa");
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                setControls(true);
                btnAddnew.Enabled = false;
                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];
                txtSdt.Text = selectedRow.Cells[0].Value.ToString();
                txtName.Text = selectedRow.Cells[1].Value.ToString();
                txtAddress.Text = selectedRow.Cells[2].Value.ToString();
                string gender = selectedRow.Cells[3].Value.ToString();
                if (gender == "Nam")
                    rdoMale.Checked = true;
                else
                    rdoFemale.Checked = true;
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = bus_kh.search_KH(txtSearch.Text);
            LoadGridView();

        }


        private void btnRefesh_Click(object sender, EventArgs e)
        {
            ClearInput();
            LoadData();
            setControls(false);
        }

        private void QL_KhachHang_Load(object sender, EventArgs e)
        {
            setControls(false);
            LoadData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            setControls(false);
            btnAddnew.Enabled = true;
        }
    }
}
