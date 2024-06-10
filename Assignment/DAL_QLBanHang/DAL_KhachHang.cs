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
    public class DAL_KhachHang : DBConnect
    {
        public bool insert_KH(DTO_KhachHang kh)
        {
            try
            {
                _conn.Open();

                SqlCommand cmd = new SqlCommand("insert_KH", _conn);
                cmd.CommandType = CommandType.StoredProcedure;

                // Thêm các tham số
                cmd.Parameters.AddWithValue("@Dienthoai", kh.SDT);
                cmd.Parameters.AddWithValue("@DiaChi", kh.DiaChi);
                cmd.Parameters.AddWithValue("Ten", kh.TenKh);
                cmd.Parameters.AddWithValue("@GioiTinh", kh.gioiTinh);
                cmd.Parameters.AddWithValue("@Email", kh.email);

                // Thực thi lệnh
                if (cmd.ExecuteNonQuery() > 0)
                    return true;
            }
            catch (SqlException sqlEx)
            {
                Console.WriteLine("SQL Error: " + sqlEx.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                _conn.Close();
            }
            return false;
        }

        public bool update_KH(DTO_KhachHang kh)
        {
            try
            {
                _conn.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "update_KH";
                cmd.Parameters.AddWithValue("@Dienthoai", kh.SDT);
                cmd.Parameters.AddWithValue("@Ten", kh.TenKh);
                cmd.Parameters.AddWithValue("@DiaChi", kh.DiaChi);
                cmd.Parameters.AddWithValue("@GioiTinh", kh.gioiTinh);

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
        public bool delete_KH(string sdt)
        {
            try
            {
                _conn.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "delete_KH";
                cmd.Parameters.AddWithValue("@Dienthoai", sdt);

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
        public DataTable Load_KH() 
        {
            try
            {
                _conn.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Load_KH";

                DataTable data = new DataTable();
                data.Load(cmd.ExecuteReader()); 
                return data;

            }
            catch (Exception)
            {
            }
            finally
            {
                _conn.Close();
            }
            return null; 
        }
        public DataTable search_KH(string ten )
        {
            try
            {
                _conn.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "search";
                cmd.Parameters.AddWithValue("@ten", ten);

                DataTable data = new DataTable();
                data.Load(cmd.ExecuteReader());
                return data;

            }
            catch (Exception)
            {
            }
            finally
            {
                _conn.Close();
            }
            return null;
        }
    }
}
