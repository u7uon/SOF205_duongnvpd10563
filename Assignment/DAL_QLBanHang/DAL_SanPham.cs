using DTO_QLBanHang;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_QLBanHang
{
    public class DAL_SanPham : DBConnect
    {
        public DataTable LoadData_SP()
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "LoadSanPham";
                DataTable data = new DataTable();
                data.Load(cmd.ExecuteReader());
                return data;
            }
            finally
            {
                _conn.Close();
            }
        }

        public bool insert_SP(DTO_SanPham sp)
        {

            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "insert_SP";
                cmd.Parameters.AddWithValue("TenHang", sp.tenSP);
                cmd.Parameters.AddWithValue("SoLuong", sp.SoLuong);
                cmd.Parameters.AddWithValue("Giaban", sp.giaBan);
                cmd.Parameters.AddWithValue("GiaNhap", sp.giaNhap);
                cmd.Parameters.AddWithValue("HinhAnh", sp.HinhAnh);
                cmd.Parameters.AddWithValue("GhiChu", sp.ghiChu);
                cmd.Parameters.AddWithValue("email", sp.Email);
                
                
                if (cmd.ExecuteNonQuery() > 0)
                    return true;
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                _conn.Close();
            }
            return false;
        }

        public bool update_SP(DTO_SanPham sp)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "update_SP";
                cmd.Parameters.AddWithValue("@maSP", sp.MaSP);
                cmd.Parameters.AddWithValue("@tenSp", sp.tenSP);
                cmd.Parameters.AddWithValue("@soLuong", sp.SoLuong);
                cmd.Parameters.AddWithValue("@giaBan", sp.giaBan);
                cmd.Parameters.AddWithValue("@giaNhap", sp.giaNhap);
                cmd.Parameters.AddWithValue("@hinhAnh", sp.HinhAnh);
                cmd.Parameters.AddWithValue("@ghiChu", sp.ghiChu);

                if (cmd.ExecuteNonQuery() > 0)
                    return true;

            }
            catch (Exception  )
            {
            }
            finally
            {
                _conn.Close();
            }

            return false;
        }

        public bool delete_SP(int maSP)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "delete_SP";
                cmd.Parameters.AddWithValue("@maSP", maSP); 

                if (cmd.ExecuteNonQuery() > 0)
                    return true;

            }
            catch (Exception)
            {

            }
            finally
            {
                _conn.Close();
            }

            return false;
        }
        public string getImg(int id )
        {
            try 
            {
                _conn.Open(); 
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "getImg";
                cmd.Parameters.AddWithValue("maSp", id);

                return cmd.ExecuteScalar().ToString();
            }
            catch(Exception ) { }
            finally { _conn.Close(); }
            return null;
        }

        public DataTable search_SP(string tensp)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "search_SP";
                cmd.Parameters.AddWithValue("@tenSP", tensp);
                DataTable data = new DataTable();
                data.Load(cmd.ExecuteReader());
                return data;

            }

            finally
            {
                _conn.Close();
            }
        }
    }
}
