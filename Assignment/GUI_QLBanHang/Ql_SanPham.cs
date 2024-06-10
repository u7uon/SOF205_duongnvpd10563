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

namespace GUI_QLBanHang
{
    public partial class Ql_SanPham : Form
    {
        public Ql_SanPham(string usingEmail)
        {
            InitializeComponent();
            this.usingEmail = usingEmail;
        }

        private string usingEmail;
        private string FileName = null;
        private BUS_SanPham bus_sp = new BUS_SanPham();


        void LoadGridView()
        {
            dataGridView1.DataSource = bus_sp.LoadData_SP();
            dataGridView1.Columns[0].HeaderText = "Mã sản phẩm";
            dataGridView1.Columns[1].HeaderText = "Tên Sản phẩm";
            dataGridView1.Columns[2].HeaderText = "Số lượng";
            dataGridView1.Columns[3].HeaderText = "Giá bán";
            dataGridView1.Columns[4].HeaderText = "Giá Nhập";
            dataGridView1.Columns[5].HeaderText = "Ghi chú";
            dataGridView1.Columns[4].HeaderText = "Mã Nhân viên";
        }

        private bool IsBlank()
        {
            return txtTenSp == null || txtSoluong == null || txtGiaBan == null || txtGiaNhap == null || rtxtGhichu == null || FileName == null;
        }

        private void moHinh()
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "PNG(*.png)|*.png|JPEG(*.jpg)|*.jpg|GIF(.gif)|*.gif|All files(*.*)|*.*";
            open.Title = "Chọn ảnh minh họa cho sản phẩm";
            if (open.ShowDialog() == DialogResult.OK)
            {
                FileName = open.FileName;
                pcbImg.Image = Image.FromFile(FileName);
            }
        }
        void ClearInput()
        {
            txtMasp.Clear();
            txtTenSp.Clear();
            txtSoluong.Clear();
            txtGiaBan.Clear();
            txtGiaNhap.Clear();
            rtxtGhichu.Clear();
            pcbImg.Image = null;
            FileName = null;
        }
        private void btnImg_Click(object sender, EventArgs e)
        {
            moHinh();
        }

        private void btnAddnew_Click(object sender, EventArgs e)
        {
            if (!IsBlank())
            {
                DTO_SanPham sp = new DTO_SanPham()
                {
                    tenSP = txtTenSp.Text,
                    SoLuong = Convert.ToInt16(txtSoluong.Text),
                    giaBan = Convert.ToDouble(txtGiaBan.Text),
                    giaNhap = Convert.ToDouble(txtGiaNhap.Text),
                    HinhAnh = FileName,
                    ghiChu = rtxtGhichu.Text,
                    Email = usingEmail
                };
                if (bus_sp.insert_SP(sp))
                {
                    MessageBox.Show("Thêm thành công");
                    LoadGridView();
                    ClearInput();
                }
                else
                {
                    MessageBox.Show("Thêm thất bại , vui lòng kiểm tra lại");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng kiểm tra nhập liệu");
            }
        }

        private void txtSoluong_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Chỉ cho nhập số vào các text box này
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Delete)
            {
                e.Handled = true;
            }
        }

        private void txtGiaNhap_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Chỉ cho nhập số vào các text box này
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Delete)
            {
                e.Handled = true;
            }
        }

        private void txtGiaBan_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Chỉ cho nhập số vào các text box này
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Delete)
            {
                e.Handled = true;
            }
        }

        private void Ql_SanPham_Load(object sender, EventArgs e)
        {
            LoadGridView();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!IsBlank())
            {
                DTO_SanPham sp = new DTO_SanPham()
                {
                    MaSP = Convert.ToInt16(txtMasp.Text),
                    tenSP = txtTenSp.Text,
                    SoLuong = Convert.ToInt16(txtSoluong.Text),
                    giaBan = Convert.ToDouble(txtGiaBan.Text),
                    giaNhap = Convert.ToDouble(txtGiaNhap.Text),
                    HinhAnh = FileName,
                    ghiChu = rtxtGhichu.Text,
                    Email = usingEmail
                };
                if (bus_sp.update_SP(sp))
                {
                    MessageBox.Show("Sửa thành công");
                    LoadGridView();
                    ClearInput();
                }
                else
                {
                    MessageBox.Show("Sửa  thất bại , vui lòng kiểm tra lại");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng kiểm tra nhập liệu");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtMasp != null)
            {
                DialogResult result = MessageBox.Show("Bạn có chắc chắc muốn xóa? ", "Cảnh báo", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    if (bus_sp.delete_SP(int.Parse(txtMasp.Text)))
                    {
                        MessageBox.Show("Xóa thành công");
                        LoadGridView();
                        ClearInput() ;
                    }
                }
            }
            else
            {
                MessageBox.Show("Chọn mã sản phẩm cần xóa ở bảng dưới");
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];
                txtMasp.Text = selectedRow.Cells[0].Value.ToString();
                txtTenSp.Text = selectedRow.Cells[1].Value.ToString();
                txtSoluong.Text = selectedRow.Cells[2].Value.ToString();
                txtGiaBan.Text = selectedRow.Cells[3].Value.ToString();
                txtGiaNhap.Text = selectedRow.Cells[4].Value.ToString();
                rtxtGhichu.Text = selectedRow.Cells[5].Value.ToString();

                FileName = bus_sp.getIMG(int.Parse(selectedRow.Cells[0].Value.ToString()));
                if (FileName != "")
                    pcbImg.Image = Image.FromFile(FileName);

            }
        }

        private void btnRefesh_Click(object sender, EventArgs e)
        {
            ClearInput();
            LoadGridView();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = bus_sp.Search_SP(txtTenSp.Text);
            dataGridView1.Columns[0].HeaderText = "Mã sản phẩm";
            dataGridView1.Columns[1].HeaderText = "Tên Sản phẩm";
            dataGridView1.Columns[2].HeaderText = "Số lượng";
            dataGridView1.Columns[3].HeaderText = "Giá bán";
            dataGridView1.Columns[4].HeaderText = "Giá Nhập";
            dataGridView1.Columns[5].HeaderText = "Ghi chú";
            dataGridView1.Columns[4].HeaderText = "Mã Nhân viên";
        }
    }
}
