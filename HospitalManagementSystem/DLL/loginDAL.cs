using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using HospitalManagementSystem.BLL;
using System.Collections.Specialized;
namespace HospitalManagementSystem.DLL
{
    class loginDAL
    {
        static string myconn = ConfigurationManager.ConnectionStrings["connstr"].ConnectionString;
        public bool LoginCheck(loginBLL l)
        {
            bool isSuccess = false;
            SqlConnection con = new SqlConnection(myconn);
            try
            {
                string sql = "Select * FROM tbl_Settings WHERE Username=@username AND Password=@password";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@username", l.username);
                cmd.Parameters.AddWithValue("@password", l.password);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    isSuccess = true;
                }
                else
                {
                    isSuccess = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
            return isSuccess;
        }

    }
}
