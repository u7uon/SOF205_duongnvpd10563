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
    public class DAL_SanPhamTests
    {
        [TestMethod()]
        public void insertHangTest001()
        {
            // thiếu tên
            DAL_SanPham add = new DAL_SanPham();
            DTO_SanPham sp = new DTO_SanPham()
            {
                SoLuong = 5,
                giaBan = 12,
                giaNhap = 10,
                Email = "akhucute5@gmail.com",
                HinhAnh = "8.jpg",
                ghiChu = "bánh ngọt"

            };
            bool result = add.insert_SP(sp);
            Assert.IsFalse(result);
        }



        [TestMethod()]
        public void insertHangTest002()
        {
            // thiếu 
            DAL_SanPham add = new DAL_SanPham();
            DTO_SanPham hang = new DTO_SanPham()
            {
                tenSP = "Bánh",
                SoLuong = 5,
                giaBan = 12,
                giaNhap = 10,
                Email = "duonng1203@gmail.com",
                ghiChu = "bánh ngọt"

            };
            bool result = add.insert_SP(hang);
            Assert.IsFalse(result);
        }



        [TestMethod()]
        public void insertHangTest003()
        {
            // thiếu ghi chu
            DAL_SanPham add = new DAL_SanPham();
            DTO_SanPham hang = new DTO_SanPham()
            {
                tenSP = "Bánh",
                SoLuong = 5,
                giaBan = 12,
                giaNhap = 10,
                Email = "duonng1203@gmail.com",
                HinhAnh = @"/Images/8.jpg",

            };
            bool result = add.insert_SP(hang);
            Assert.IsFalse(result);
        }



        [TestMethod()]
        public void insertHangTest004()
        {
            // thành công
            DAL_SanPham add = new DAL_SanPham();
            DTO_SanPham hang = new DTO_SanPham()
            {
                tenSP = "Bánh",
                SoLuong = 5,
                giaBan = 12,
                giaNhap = 10,
                Email = "duonng1203@gmail.com",
                HinhAnh = "8.jpg",
                ghiChu = "bánh ngọt"

            };
            bool result = add.insert_SP(hang);
            Assert.IsTrue(result);
        }

    }
}