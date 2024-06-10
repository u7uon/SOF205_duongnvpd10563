namespace GUI_QLBanHang
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_login = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_Logout = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_profile = new System.Windows.Forms.ToolStripMenuItem();
            this.thoátToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_HuonDan = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_danhmuc = new System.Windows.Forms.ToolStripMenuItem();
            this.menuNhanVien = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuKhachhang = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuSanPham = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_thongKe = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.menu_HuonDan,
            this.menu_danhmuc,
            this.menu_thongKe});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1219, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_login,
            this.menu_Logout,
            this.menu_profile,
            this.thoátToolStripMenuItem});
            this.toolStripMenuItem1.Image = global::GUI_QLBanHang.Properties.Resources.security;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(105, 24);
            this.toolStripMenuItem1.Text = "Hệ thống";
            // 
            // menu_login
            // 
            this.menu_login.Image = global::GUI_QLBanHang.Properties.Resources.password_code;
            this.menu_login.Name = "menu_login";
            this.menu_login.Size = new System.Drawing.Size(181, 26);
            this.menu_login.Text = "Đăng Nhập";
            this.menu_login.Click += new System.EventHandler(this.đăngNhậpToolStripMenuItem_Click);
            // 
            // menu_Logout
            // 
            this.menu_Logout.Image = global::GUI_QLBanHang.Properties.Resources.arrow;
            this.menu_Logout.Name = "menu_Logout";
            this.menu_Logout.Size = new System.Drawing.Size(181, 26);
            this.menu_Logout.Text = "Đăng xuất";
            this.menu_Logout.Visible = false;
            this.menu_Logout.Click += new System.EventHandler(this.đăngXuấtToolStripMenuItem_Click);
            // 
            // menu_profile
            // 
            this.menu_profile.Image = global::GUI_QLBanHang.Properties.Resources.preference;
            this.menu_profile.Name = "menu_profile";
            this.menu_profile.Size = new System.Drawing.Size(181, 26);
            this.menu_profile.Text = "Đổi mật khẩu";
            this.menu_profile.Visible = false;
            this.menu_profile.Click += new System.EventHandler(this.thôngTinNhânViênToolStripMenuItem_Click);
            // 
            // thoátToolStripMenuItem
            // 
            this.thoátToolStripMenuItem.Name = "thoátToolStripMenuItem";
            this.thoátToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.thoátToolStripMenuItem.Text = "Thoát";
            this.thoátToolStripMenuItem.Click += new System.EventHandler(this.thoátToolStripMenuItem_Click);
            // 
            // menu_HuonDan
            // 
            this.menu_HuonDan.Image = global::GUI_QLBanHang.Properties.Resources.drone;
            this.menu_HuonDan.Name = "menu_HuonDan";
            this.menu_HuonDan.Size = new System.Drawing.Size(118, 24);
            this.menu_HuonDan.Text = "Hướng dẫn";
            // 
            // menu_danhmuc
            // 
            this.menu_danhmuc.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuNhanVien,
            this.MenuKhachhang,
            this.MenuSanPham});
            this.menu_danhmuc.Image = global::GUI_QLBanHang.Properties.Resources.menu;
            this.menu_danhmuc.Name = "menu_danhmuc";
            this.menu_danhmuc.Size = new System.Drawing.Size(110, 24);
            this.menu_danhmuc.Text = "Danh Mục";
            this.menu_danhmuc.Visible = false;
            this.menu_danhmuc.Click += new System.EventHandler(this.menu_danhmuc_Click);
            // 
            // menuNhanVien
            // 
            this.menuNhanVien.Image = global::GUI_QLBanHang.Properties.Resources.man;
            this.menuNhanVien.Name = "menuNhanVien";
            this.menuNhanVien.Size = new System.Drawing.Size(172, 26);
            this.menuNhanVien.Text = "Nhân viên";
            this.menuNhanVien.Click += new System.EventHandler(this.menuNhanVien_Click);
            // 
            // MenuKhachhang
            // 
            this.MenuKhachhang.Image = global::GUI_QLBanHang.Properties.Resources.rating;
            this.MenuKhachhang.Name = "MenuKhachhang";
            this.MenuKhachhang.Size = new System.Drawing.Size(172, 26);
            this.MenuKhachhang.Text = "Khách Hàng";
            this.MenuKhachhang.Click += new System.EventHandler(this.MenuKhachhang_Click);
            // 
            // MenuSanPham
            // 
            this.MenuSanPham.Image = global::GUI_QLBanHang.Properties.Resources.box;
            this.MenuSanPham.Name = "MenuSanPham";
            this.MenuSanPham.Size = new System.Drawing.Size(172, 26);
            this.MenuSanPham.Text = "Sản phẩm";
            this.MenuSanPham.Click += new System.EventHandler(this.MenuSanPham_Click);
            // 
            // menu_thongKe
            // 
            this.menu_thongKe.Image = global::GUI_QLBanHang.Properties.Resources.statistical;
            this.menu_thongKe.Name = "menu_thongKe";
            this.menu_thongKe.Size = new System.Drawing.Size(104, 24);
            this.menu_thongKe.Text = "Thống kê";
            this.menu_thongKe.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(3, 31);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1216, 761);
            this.panel1.TabIndex = 1;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1219, 793);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.Text = "Main";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menu_danhmuc;
        private System.Windows.Forms.ToolStripMenuItem menu_thongKe;
        private System.Windows.Forms.ToolStripMenuItem menu_HuonDan;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem menu_login;
        private System.Windows.Forms.ToolStripMenuItem menu_Logout;
        private System.Windows.Forms.ToolStripMenuItem menu_profile;
        private System.Windows.Forms.ToolStripMenuItem thoátToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripMenuItem menuNhanVien;
        private System.Windows.Forms.ToolStripMenuItem MenuKhachhang;
        private System.Windows.Forms.ToolStripMenuItem MenuSanPham;
    }
}