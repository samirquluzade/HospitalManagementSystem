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
    public partial class PricesForReception : Form
    {
        SqlHelper sql = new SqlHelper();
        public PricesForReception()
        {
            InitializeComponent();
        }

        private void PricesForReception_Load(object sender, EventArgs e)
        {
            listele();
        }
        void listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * FROM tbl_Prices", sql.Connect());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }
        PricesDAL pricesDAL = new PricesDAL();
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string keywords = txtSearch.Text;
            if (keywords != null)
            {
                DataTable dt = pricesDAL.Search(keywords);
                gridControl1.DataSource = dt;
            }
            else
            {
                DataTable dt = pricesDAL.Select();
                gridControl1.DataSource = dt;
            }
        }
    }
}
