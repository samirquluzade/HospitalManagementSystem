using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HospitalManagementSystem.DLL
{
    class settingsDAL
    {
        static string myconnstrng = System.Configuration.ConfigurationManager.ConnectionStrings["connstr"].ConnectionString;
        public DataTable Search(string keywords)
        {
            SqlConnection conn = new SqlConnection(myconnstrng);
            DataTable dt = new DataTable();
            try
            {
                string sql = "Select * FROM tbl_Settings WHERE ID LIKE '%" + keywords + "%' OR Username LIKE '%" + keywords + "%' OR Password LIKE '%" + keywords + "%' OR Email LIKE '%" + keywords + "%'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                conn.Open();
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
                Select();
            }
            finally
            {
                conn.Close();
            }
            return dt;
        }
        public DataTable Select()
        {
            DataTable dt = new DataTable();//DataTable-in obyektini yaradiriq,chunki melumati database-den almaq ve return etmek uchun
            SqlConnection conn = new SqlConnection(myconnstrng);//Database-e qoshulmaq uchun Sql Connection-in obyektini yaradiriq
            try
            {
                string sql = "Select * FROM tbl_Settings";
                //Sorgulamaq uchun SqlCommand yaradiriq
                SqlCommand cmd = new SqlCommand(sql, conn);
                //Melumatlari kechici olaraq saxlamaq uchun SqlDataAdapter yaradiriq
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                // Database elaqesini achiriq
                conn.Open();
                //Melumati adapter-den DataTable-a yonetmek uchun
                adapter.Fill(dt);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {//Database elaqesini baglayiriq
                conn.Close();
            }
            return dt;
        }
    }
}
