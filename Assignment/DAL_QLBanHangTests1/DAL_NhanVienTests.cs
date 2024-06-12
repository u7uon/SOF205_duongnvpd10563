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
    public class DAL_NhanVienTests
    {
        [TestMethod()]
        public void Login001()
        {
            DAL_NhanVien nv = new DAL_NhanVien();
            string email = "";
            string pass = "accd";
            bool result = nv.Login(email, pass);
            Assert.IsFalse(result);
        }
        [TestMethod()]
        public void Login002()
        {
            DAL_NhanVien nv = new DAL_NhanVien();
            string email = "a@gmail.com";
            string pass = "";
            bool result = nv.Login(email, pass);
            Assert.IsFalse(result);
        }
        [TestMethod()]
        public void Login003()
        {
            DAL_NhanVien nv = new DAL_NhanVien();
            string email = "duonng1203@gmail.com";
            string pass = "1051418116115713818282291297315712311222104";
            bool result = nv.Login(email, pass);
            Assert.IsTrue(result);
        }


        //thêm nhân viên
        [TestMethod()]
        public void ThemNVTest001()
        {
            // thêm nhân viên thiếu email
            DAL_NhanVien add = new DAL_NhanVien();
            DTO_NhanVien nv = new DTO_NhanVien()
            {
                TenNhanVien = "Thanh",
                diaChi = "HCM",
                vaiTro = 1,
                tinhtrang = 1,
                matKhau = "33333"

            };
            bool result = add.insert_NV(nv);
            Assert.IsFalse(result);
        }

        [TestMethod()]
        public void ThemNVTest002()
        {
            // thêm nhân viên thiếu tên
            DAL_NhanVien add = new DAL_NhanVien();
            DTO_NhanVien nv = new DTO_NhanVien()
            {
                Email = "a@a.a",
                diaChi = "HCM",
                vaiTro = 1,
                tinhtrang = 1,
                matKhau = "33333"

            };
            bool result = add.insert_NV(nv);
            Assert.IsFalse(result);
        }

        [TestMethod()]
        public void ThemNVTest003()
        {
            // thêm nhân viên thiếu địa chỉ
            DAL_NhanVien add = new DAL_NhanVien();
            DTO_NhanVien nv = new DTO_NhanVien()
            {
                Email = "a@a.a",
                TenNhanVien = "Nguyễn Thành",
                vaiTro = 1,
                tinhtrang = 1,
                matKhau = "33333"

            };
            bool result = add.insert_NV(nv);
            Assert.IsFalse(result);
        }

        [TestMethod()]
        public void ThemNVTest004()
        {
            // thêm nhân viên thiếu tinh trạng
            DAL_NhanVien add = new DAL_NhanVien();
            DTO_NhanVien nv = new DTO_NhanVien()
            {
                Email = "akhucute@gmail.com",
                TenNhanVien = "Nguyễn Thành",
                diaChi = "HCM",
                vaiTro = 1,
                tinhtrang = 1,
                matKhau = "matkhaune"
            };
            bool result = add.insert_NV(nv);
            Assert.IsTrue(result);
        }
    }
}