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
    class patientDAL
    {
        static string myconnstrng = ConfigurationManager.ConnectionStrings["connstr"].ConnectionString;
        public DataTable Search(string keywords)
        {
            SqlConnection conn = new SqlConnection(myconnstrng);
            DataTable dt = new DataTable();
            try
            {
                string sql = "Select * FROM tbl_Patients WHERE ID LIKE '%" + keywords + "%' OR Ad LIKE '%" + keywords + "%' OR Soyad LIKE '%" + keywords + "%' OR Yaş LIKE '%" + keywords + "%' OR Xəstəliyi LIKE '%" + keywords + "%' OR Müraciət_edilən_həkim LIKE '%" + keywords + "%'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                conn.Open();
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
                string sql = "Select * FROM tbl_Patients";
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
