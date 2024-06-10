using DAL_QLBanHang;
using DTO_QLBanHang;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BUS_QLBanHang
{
    public class BUS_NhanVien
    {
        private   DAL_NhanVien dal_nv = new DAL_NhanVien();
        private string encrytion(string password)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] encrypt;
            UTF8Encoding encode = new UTF8Encoding();
            encrypt = md5.ComputeHash(encode.GetBytes(password));
            StringBuilder builder = new StringBuilder();
            foreach (var item in encrypt)
            {
                builder.Append(item.ToString());
            }
            return builder.ToString();
        }
        private string newPassword()
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char cha;
            for (int i = 0; i < 7; i++)
            {
                cha = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(cha);
            }
            return builder.ToString();
        }
        private void sendMail(string recieverMail , string Pass)
        {
            MailMessage msg = new MailMessage();
            msg.To.Add(recieverMail);
            msg.From = new MailAddress("duongvpd10563@gmail.com");
            msg.Subject = "Bạn đã tạo tài khoản mới ";
            msg.Body = "Mật khẩu mới của bạn là : " + Pass;

            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.EnableSsl = true;
            smtp.Port = 587;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Credentials = new NetworkCredential("duongnvpd10563@gmail.com", "jipazvuqvjhktwxi");
            smtp.Send(msg);

        }
        public bool GetVaiTro(string email)
        {
            return dal_nv.GetVaiTro(email);
        }
        public bool Login(string email, string password)
        {
            return dal_nv.Login(email, encrytion(password));
        }
        public bool checkEmaik(string email)
        {
            return dal_nv.checkEmail(email);
        }
        public bool setNewPass(string email, string password)
        {
            return dal_nv.SetNewPass(email, encrytion(password) );
        }
        public DataTable LoadData_NV ()
        {
            return dal_nv.Load_NhanVien();
        }
        public bool insert_nv (DTO_NhanVien nv )
        {
            string randomPass = newPassword(); 
            nv.matKhau = encrytion(randomPass);
            if (dal_nv.insert_NV(nv))
            {
                sendMail(nv.Email, randomPass);
                return true;
            }
            return false;

        }

        public bool delete_NV(string email)
        {
            return dal_nv.delete_NV(email);
        }

        public bool update_NV(DTO_NhanVien nv)
        {
            return dal_nv.update_NV(nv);
        }
        public DataTable search_NV(string name)
        {
            return dal_nv.Search_NV(name);
        }

    }
}
