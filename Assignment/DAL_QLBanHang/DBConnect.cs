using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_QLBanHang
{
    public class DBConnect
    {
        static string connectString  = ConfigurationManager.ConnectionStrings["QLBH"].ToString();
        protected SqlConnection _conn = new SqlConnection(connectString);
    }
}
