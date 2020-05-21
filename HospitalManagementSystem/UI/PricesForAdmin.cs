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
    public partial class Prices : Form
    {
        public Prices()
        {
            InitializeComponent();
        }
        SqlHelper sql = new SqlHelper();
        void listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * FROM tbl_Prices", sql.Connect());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("insert into tbl_Prices(Həkim,Müayinə_qiyməti,İcra_etdiyi_emeliyyat,Əməliyyat_qiyməti) Values(@p1,@p2,@p3,@p4)", sql.Connect());
               cmd.Parameters.AddWithValue("@p1", txtHekim.Text);
               cmd.Parameters.AddWithValue("@p2", txtmqiymet.Text);
               cmd.Parameters.AddWithValue("@p3", txtIcra.Text);
               cmd.Parameters.AddWithValue("@p4", txteqiymet.Text);
               cmd.ExecuteNonQuery();
               sql.Connect().Close();
               MessageBox.Show("Qiymət sistemə əlavə olundu", "Məlumat", MessageBoxButtons.OK, MessageBoxIcon.Information);
               listele();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("UPDATE tbl_Prices set Həkim=@p1,Müayinə_qiyməti=@p2,İcra_etdiyi_emeliyyat=@p3,Əməliyyat_qiyməti=@p4 where ID=@p5", sql.Connect());
            cmd.Parameters.AddWithValue("@p1", txtHekim.Text);
            cmd.Parameters.AddWithValue("@p2", txtmqiymet.Text);
            cmd.Parameters.AddWithValue("@p3", txtIcra.Text);
            cmd.Parameters.AddWithValue("@p4", txteqiymet.Text);
            cmd.Parameters.AddWithValue("@p5", int.Parse(txtID.Text));
            cmd.ExecuteNonQuery();
            sql.Connect().Close();
            MessageBox.Show("Qiymət sistemdə yeniləndi", "Məlumat", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            txtID.Text = dr["ID"].ToString();
            txtHekim.Text = dr["Həkim"].ToString();
            txtmqiymet.Text = dr["Müayinə_qiyməti"].ToString();
            txtIcra.Text = dr["İcra_etdiyi_emeliyyat"].ToString();
            txteqiymet.Text = dr["Əməliyyat_qiyməti"].ToString();
        }

        private void Prices_Load(object sender, EventArgs e)
        {
            listele();
            txtHekim.Text = "";
            txtmqiymet.Text = "";
            txteqiymet.Text = "";
            txtIcra.Text = "";
            txtID.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlCommand cmdsil = new SqlCommand("Delete from tbl_Prices where ID=@p1", sql.Connect());
            cmdsil.Parameters.AddWithValue("@p1", txtID.Text);
            cmdsil.ExecuteNonQuery();
            sql.Connect().Close();
            MessageBox.Show("Qiymət sistemdən silindi", "Məlumat", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
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
