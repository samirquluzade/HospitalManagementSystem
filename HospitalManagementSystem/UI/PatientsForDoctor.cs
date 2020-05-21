using HospitalManagementSystem.DLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HospitalManagementSystem.UI
{
    public partial class PatientsForDoctor : Form
    {
        SqlHelper sql = new SqlHelper();
        public string currentusername = string.Empty;
        public PatientsForDoctor(string text)
        {
            InitializeComponent();
            currentusername = text;
            label1.Text = text;
        }

        private void PatientsForDoctor_Load(object sender, EventArgs e)
        {
            listele();
        }
        void listele()
        {
            string check = label1.Text;
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * FROM tbl_Patients where Müraciət_edilən_həkim = (Select Ad_Soyad from tbl_Settings where Username = '" + check + "')", sql.Connect());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }
        patientDAL patient = new patientDAL();
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string keywords = txtSearch.Text;
            if (keywords != null)
            {
                DataTable dt = patient.Search(keywords);
                gridControl1.DataSource = dt;
            }
            else
            {
                DataTable dt = patient.Select();
                gridControl1.DataSource = dt;
            }
        }
    }
}
