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
        private string currentImg =""; 
        private string FileName;
        private string fileSavePath;
        private string fileAddress;
        private string checkURl; 
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
            dataGridView1.Columns[6].HeaderText = "Hình ảnh";
            dataGridView1.Columns[7].HeaderText = "Mã Nhân viên";
        }
        private void OpenImg(string address)
        {
            try
            {
                pcbImg.Image = Image.FromFile(address); 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể mở hình ảnh"); 
            }
        }

        private bool IsBlank()
        {
            return txtTenSp.Text == "" || txtSoluong.Text == "" || txtGiaBan.Text == "" || txtGiaNhap.Text == "" || rtxtGhichu.Text == "" || currentImg == "";
        }

        private void moHinh()
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "PNG(*.png)|*.png|JPEG(*.jpg)|*.jpg|GIF(.gif)|*.gif|All files(*.*)|*.*";
            open.Title = "Chọn ảnh minh họa cho sản phẩm";
            if (open.ShowDialog() == DialogResult.OK)
            {
                fileAddress = open.FileName;
                OpenImg(fileAddress);
                FileName = Path.GetFileName(open.FileName);
                string saveDirectory = Application.StartupPath.Substring(0, Application.StartupPath.Length);
                fileSavePath = saveDirectory + "\\Images\\" + FileName;
                currentImg = "\\Images\\" + FileName ;
            }
        }
        private void setControls(bool check)
        {
            btnUpdate.Enabled = check;
            btnDelete.Enabled = check;
            btnAddnew.Enabled = check;
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
            currentImg = null;
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
                    HinhAnh = currentImg,
                    ghiChu = rtxtGhichu.Text,
                    Email = usingEmail
                };
                if (bus_sp.insert_SP(sp))
                {
                    MessageBox.Show("Thêm thành công");
                    File.Copy(fileAddress, fileSavePath, true); 
                    setControls(false);
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
            setControls(false);
            btnAddnew.Enabled = false;
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
                    HinhAnh = currentImg,
                    ghiChu = rtxtGhichu.Text,
                    Email = usingEmail
                };
                if (bus_sp.update_SP(sp))
                {
                    if (currentImg != checkURl)
                        File.Copy(fileAddress, fileSavePath, true); 
                    MessageBox.Show("Sửa thành công");
                    setControls(false);
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
                        ClearInput();
                        setControls(false); 
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
            string saveDirectory = Application.StartupPath.Substring(0, Application.StartupPath.Length);
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];
                txtMasp.Text = selectedRow.Cells[0].Value.ToString();
                txtTenSp.Text = selectedRow.Cells[1].Value.ToString();
                txtSoluong.Text = selectedRow.Cells[2].Value.ToString();
                txtGiaBan.Text = selectedRow.Cells[3].Value.ToString();
                txtGiaNhap.Text = selectedRow.Cells[4].Value.ToString();
                rtxtGhichu.Text = selectedRow.Cells[5].Value.ToString();

                currentImg = selectedRow.Cells[6].Value.ToString();
                checkURl = currentImg;
                if (selectedRow.Cells[6].Value.ToString() != "")
                {
                    string img = saveDirectory + currentImg ;
                    OpenImg(img);
                }
                setControls(true);
            }
        }

        
        private void btnRefesh_Click(object sender, EventArgs e)
        {
            setControls(false);
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
            dataGridView1.Columns[5].HeaderText = "Hình ảnh";
            dataGridView1.Columns[6].HeaderText = "Ghi chú";
            dataGridView1.Columns[7].HeaderText = "Mã Nhân viên";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            btnAddnew.Enabled = true;
        }
    }
}
