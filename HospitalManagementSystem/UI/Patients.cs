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

namespace HospitalManagementSystem
{
    public partial class Patients : Form
    {
        public Patients()
        {
            InitializeComponent();
        }
        SqlHelper sql = new SqlHelper();
        void listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * FROM tbl_Patients", sql.Connect());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }

        private void Patients_Load(object sender, EventArgs e)
        {
            listele();
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
