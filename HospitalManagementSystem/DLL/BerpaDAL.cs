using HospitalManagementSystem.BLL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HospitalManagementSystem.DLL
{
    class BerpaDAL
    {
        static string myconn = ConfigurationManager.ConnectionStrings["connstr"].ConnectionString;
        public bool LoginCheck(BerpaBLL l)
        {
            bool isSuccess = false;
            SqlConnection con = new SqlConnection(myconn);
            try
            {
                string sql = "Select Email FROM tbl_Settings WHERE Username=@username";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@username", l.username);
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
