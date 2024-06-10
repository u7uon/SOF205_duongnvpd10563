using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO_QLBanHang;

namespace DAL_QLBanHang
{
    public class DAL_NhanVien : DBConnect
    {
        public bool Login(string email, string pwd)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "DangNhap";
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@MatKhau", pwd);
                if (Convert.ToInt16(cmd.ExecuteScalar()) > 0)
                {
                    return true;
                }

            }
            catch
            {
            }
            finally
            {
                _conn.Close();
            }
            return false;
        }
        public bool checkEmail(string email)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "checkEmail";
                cmd.Parameters.AddWithValue("email", email);
                if (Convert.ToInt16(cmd.ExecuteScalar()) > 0)
                    return true;
            }
            catch
            {

            }
            finally { _conn.Close(); }
            return false;
        }

        public bool SetNewPass(string email, string newPass)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "setNewpass";
                cmd.Parameters.AddWithValue("email", email);
                cmd.Parameters.AddWithValue("pass", newPass);
                if (cmd.ExecuteNonQuery() > 0)
                    return true;
            }
            catch
            {

            }
            finally { _conn.Close(); }
            return false;
        }


        public bool insert_NV(DTO_NhanVien nv)
        {
            try
            {
                _conn.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "insert_NV";
                cmd.Parameters.AddWithValue("email", nv.Email);
                cmd.Parameters.AddWithValue("ten", nv.TenNhanVien);
                cmd.Parameters.AddWithValue("diaChi", nv.diaChi);
                cmd.Parameters.AddWithValue("vaitro", nv.vaiTro);
                cmd.Parameters.AddWithValue("Tinhtrang", nv.tinhtrang);
                cmd.Parameters.AddWithValue("MatKhau", nv.matKhau);

                if (cmd.ExecuteNonQuery() > 0)
                {
                    return true;
                }
            }
            catch (SqlException)
            {

            }
            finally
            {
                _conn.Close();
            }
            return false;
        }

        public bool delete_NV(string email)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "delete_NV";
                cmd.Parameters.AddWithValue("email", email);
                if (cmd.ExecuteNonQuery() > 0)
                    return true;
            }
            catch (SqlException)
            {

            }
            finally { _conn.Close(); }
            return false;
        }

        public bool update_NV(DTO_NhanVien nv)
        {
            try
            {
                _conn.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "update_NV";
                cmd.Parameters.AddWithValue("email", nv.Email);
                cmd.Parameters.AddWithValue("tennv", nv.TenNhanVien);
                cmd.Parameters.AddWithValue("diaChi", nv.diaChi);
                cmd.Parameters.AddWithValue("vaiTro", nv.vaiTro);
                cmd.Parameters.AddWithValue("tinhTrang", nv.tinhtrang);
                if (cmd.ExecuteNonQuery() > 0)
                    return true;
            }
            catch (Exception ex) {
                Console.WriteLine(ex);
            }
            finally
            {
                _conn.Close();
            }
            return false;
        }
        public DataTable Load_NhanVien()
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Load_NV";
                DataTable data_nv = new DataTable();
                data_nv.Load(cmd.ExecuteReader());
                return data_nv;
            }
            finally { _conn.Close(); }
        }
        public DataTable Search_NV(string name ="")
        {
            try
            {
                _conn.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "search_NV"; 
                cmd.Parameters.AddWithValue ("tenNV", name);

                DataTable data_nv = new DataTable();
                data_nv.Load(cmd.ExecuteReader());

                return data_nv; 
            }
            finally
            {
                _conn.Close();
            }
        }
        public bool GetVaiTro(string email)
        {
            try
            {
                _conn.Open(); 
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "LayVaiTro";
                cmd.Parameters.AddWithValue("Email", email);
                if (Convert.ToInt16(cmd.ExecuteScalar()) == 1)
                    return true;     
            }
            catch { }
            finally { _conn.Close(); }
            return false;
        }

    }
}

