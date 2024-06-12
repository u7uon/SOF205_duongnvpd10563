using BUS_QLBanHang;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI_QLBanHang
{
    public partial class frm_login : Form
    {
        public frm_login()
        {
            InitializeComponent();
        }

        private bool successLogin = false;
        public string getEmail
        {
            get { return txtEmail.Text; }
        }
        public bool getStatus
        {
            get
            {
                return successLogin;
            }
        }
        BUS_NhanVien bus_nv = new BUS_NhanVien();
        public bool isAdmin
        {
            get { return bus_nv.GetVaiTro(getEmail); }
        }



        public string RandomString(int size, bool lowerCase)
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char cha;
            for (int i = 0; i < size; i++)
            {
                cha = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(cha);
            }
            if (lowerCase)
                return builder.ToString().ToLower();
            return builder.ToString();
        }
        public int RandomNumber(int min, int max)
        {
            Random rd = new Random();
            return rd.Next(min, max);
        }
        public void SendMail(string mail, string matKhau)
        {
            try
            {

                MailMessage msg = new MailMessage();
                msg.To.Add(mail);
                msg.From = new MailAddress("duongvpd10563@gmail.com");
                msg.Subject = "Chức năng quên mật khẩu";
                msg.Body = "Mật khẩu mới của bạn là : " + matKhau;

                SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                smtp.EnableSsl = true;
                smtp.Port = 587;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Credentials = new NetworkCredential("duongnvpd10563@gmail.com", "jipazvuqvjhktwxi");
                smtp.Send(msg);

                MessageBox.Show("Mail khôi phục mật khẩu đã được gửi tới mail của bạn ");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void btnLogin_Click(object sender, EventArgs e)
        {
            BUS_NhanVien bus_nv = new BUS_NhanVien();
            if (bus_nv.Login(txtEmail.Text, txtPass.Text))
            {
                successLogin = true;
                MessageBox.Show("Chào  mừng " + txtEmail.Text, "Đăng nhập thành công");
                Close();
            }
            else
            {
                MessageBox.Show("Sai mật khẩu hoặc tài khoản");
                txtPass.Text = "";
                txtEmail.Focus();
                successLogin = false;
            }
        }

        private void btnForgetPass_Click(object sender, EventArgs e)
        {
            string userEmail = txtEmail.Text.Trim();
            if (userEmail != "")
            {
                if (bus_nv.checkEmaik(userEmail))
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append(RandomString(5, true));
                    sb.Append(RandomNumber(1000, 9999));
                    sb.Append(RandomString(3, false));
                    SendMail(userEmail, sb.ToString()); //Gửi mật khẩu mới tới mail người dùng

                    //Lưu mật khẩu mới vào database
                    bus_nv.setNewPass(userEmail, sb.ToString());
                }
                else
                {
                    MessageBox.Show("Email không tôn tại");
                    txtEmail.Clear();
                    txtEmail.Focus();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập email ");
                txtEmail.Focus();
            }

        }
    }
}
