using Microsoft.VisualStudio.TestTools.UnitTesting;
using DAL_QLBanHang;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO_QLBanHang;

namespace DAL_QLBanHang.Tests
{
    [TestClass()]
    public class DAL_KhachHangTests
    {
        [TestMethod()]
        public void insertKHTest001()
        {
            // login thiếu số điện thoại
            DAL_KhachHang add = new DAL_KhachHang();
            DTO_KhachHang khachHang = new DTO_KhachHang()
            {
                gioiTinh = "Nam",
                TenKh = "Nguyễn Thành",
                DiaChi = "BRVT",
                email = "duonng1203@gmail.com"
            };
            bool result = add.insert_KH(khachHang);
            Assert.IsFalse(result);
        }
        [TestMethod()]

        public void insertKHTest002()
        {
            // login thiếu tên
            DAL_KhachHang add = new DAL_KhachHang();
            DTO_KhachHang khachHang = new DTO_KhachHang()
            {
                gioiTinh = "Nam",

                SDT = "0123456789",
                DiaChi = "BRVT",
                email = "duonng1203@gmail.com"
            };
            bool result = add.insert_KH(khachHang);
            Assert.IsFalse(result);

        }

        [TestMethod()]

        public void insertKHTest003()
        {
            // login thiếu địa chỉ
            DAL_KhachHang add = new DAL_KhachHang();
            DTO_KhachHang khachHang = new DTO_KhachHang()
            {
                gioiTinh = "Nam",
                SDT = "0123456789",
                TenKh = "Nguyễn Thành",
                email = "duonng1203@gmail.com"
            };
            bool result = add.insert_KH(khachHang);
            Assert.IsFalse(result);

        }
        [TestMethod()]

        public void insertKHTest004()
        {
            // login thiếu phái
            DAL_KhachHang add = new DAL_KhachHang();
            DTO_KhachHang khachHang = new DTO_KhachHang()
            {
                SDT = "0123456789",
                TenKh = "Nguyễn Thành",
                email = "duonng1203@gmail.com",
                DiaChi = "BRVT"
            };
            bool result = add.insert_KH(khachHang);
            Assert.IsFalse(result);

        }
        [TestMethod()]

        public void insertKHTest005()
        {
            // login thành công
            DAL_KhachHang add = new DAL_KhachHang();
            DTO_KhachHang khachHang = new DTO_KhachHang()
            {
                SDT = "012345674",
                TenKh = "Nguyễn Thành",
                DiaChi = "BRVT",
                gioiTinh = "Nam",
                email = "duonng1203@gmail.com"
            };
            bool result = add.insert_KH(khachHang);
            Assert.IsTrue(result);

        }

    }
}