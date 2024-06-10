using BUS_QLBanHang;
using DTO_QLBanHang;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GUI_QLBanHang
{
    public partial class QL_NhanVien : Form
    {
        public QL_NhanVien()
        {
            InitializeComponent();
        }
        BUS_NhanVien bus_nv = new BUS_NhanVien();
        

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
        private void clearInput()
        {
            txtAddress.Clear();
            txtEmail.Clear();
            txtName.Clear();
            rdoActive.Checked = false;
            rdoUnactive.Checked = false;
            rdoStaff.Checked = false;
            rdoManager.Checked = false;
            txtName.Focus();
            txtEmail.Enabled = true;
        }

        private bool nullInput()
        {
            return txtAddress == null || txtEmail == null || txtName == null || rdoActive.Checked == false && rdoUnactive.Checked == false || rdoManager.Checked == false && rdoStaff.Checked == false;
        }
        private void btnAddnew_Click(object sender, EventArgs e)
        {
            if (!nullInput())
            {
                int role = rdoManager.Checked ? 1 : 0;
                int status = rdoActive.Checked ? 1 : 0;
                DTO_NhanVien nv = new DTO_NhanVien(txtEmail.Text, txtName.Text, txtAddress.Text, role, status);
                BUS_NhanVien bUS_NhanVien = new BUS_NhanVien();
                if (bUS_NhanVien.insert_nv(nv))
                {
                    MessageBox.Show("Thêm thành công");
                    Load_Gridview();
                    clearInput();
                }
            }
            else
            {
                MessageBox.Show("Nhập các trường thông tin trước khi thêm");
            }
        }
        void Load_Gridview()
        {
            dataGridView1.DataSource = bus_nv.LoadData_NV();
            dataGridView1.Columns[0].HeaderText = "Email";
            dataGridView1.Columns[1].HeaderText = "Tên Nhân Viên";
            dataGridView1.Columns[2].HeaderText = "Địa chỉ";
            dataGridView1.Columns[3].HeaderText = "Vai trò";
            dataGridView1.Columns[4].HeaderText = "Tình trạng";
        }
        private void resetValues()
        {

        }

        private void QL_NhanVien_Load(object sender, EventArgs e)
        {
            Load_Gridview();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtEmail.Text != "")
            {
                string email = txtEmail.Text;
                DialogResult result = MessageBox.Show(" Không thể khôi phục sau khi xóa. Bạn có chắc chắn muốn xóa? ", "Cảnh báo", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    if (bus_nv.delete_NV(email))
                    {
                        MessageBox.Show("Xóa thành công");
                        Load_Gridview();
                        clearInput();
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập email của nhân viên cần xóa cần xóa");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!nullInput())
            {
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn sửa không", "Cảnh báo ", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    int role = rdoManager.Checked ? 1 : 0;
                    int status = rdoActive.Checked ? 1 : 0;
                    DTO_NhanVien nv = new DTO_NhanVien(txtEmail.Text, txtName.Text, txtAddress.Text, role, status);
                    if (bus_nv.update_NV(nv))
                    {
                        MessageBox.Show("Cập nhật thành công");
                        Load_Gridview();
                        clearInput() ;
                    }
                }
            }
            else
            {
                MessageBox.Show("Nhập đủ các trường thông tin trước");
            }
        }

        private void btnRefesh_Click(object sender, EventArgs e)
        {
            clearInput();
            Load_Gridview(); 
        }

        private void button5_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = bus_nv.search_NV(txtSearch.Text);
            dataGridView1.Columns[0].HeaderText = "Email";
            dataGridView1.Columns[1].HeaderText = "Tên Nhân Viên";
            dataGridView1.Columns[2].HeaderText = "Địa chỉ";
            dataGridView1.Columns[3].HeaderText = "Vai trò";
            dataGridView1.Columns[4].HeaderText = "Tình trạng";

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) 
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                txtEmail.Text = row.Cells[0].Value.ToString();
                txtName.Text = row.Cells[1].Value.ToString();
                txtAddress.Text = row.Cells[2].Value.ToString();
                if(Convert.ToInt16(row.Cells[3].Value.ToString()) == 0) 
                    rdoStaff.Checked = true;
                else 
                    rdoManager.Checked = true;
                if (Convert.ToInt16(row.Cells[4].Value.ToString()) == 0) 
                    rdoUnactive.Checked = true;
                else 
                    rdoActive.Checked = true;
                txtEmail.Enabled = false;
            }
        }

        private void txtAddress_ImeChange(object sender, EventArgs e)
        {
        }
    }
}
