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
    public partial class frmSettings : Form
    {
        public frmSettings()
        {
            InitializeComponent();
        }
        SqlHelper sql = new SqlHelper();
        void listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * FROM tbl_Settings", sql.Connect());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }
        settingsDAL settings = new settingsDAL();
        private void btnAdd_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("insert into tbl_Settings(Ad_Soyad,Username,Password,Email) Values(@p1,@p2,@p3,@p4)", sql.Connect());
            cmd.Parameters.AddWithValue("@p1", txtAdSoyad.Text);
            cmd.Parameters.AddWithValue("@p2", txtUsername.Text);
            cmd.Parameters.AddWithValue("@p3", txtPassword.Text);
            cmd.Parameters.AddWithValue("@p4", txtEmail.Text);
            cmd.ExecuteNonQuery();
            sql.Connect().Close();
            MessageBox.Show("İstifadəçi sistemə əlavə olundu", "Məlumat", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
        }

        private void frmSettings_Load(object sender, EventArgs e)
        {
            listele();
            txtUsername.Text = "";
            txtPassword.Text = "";
            txtEmail.Text = "";
            txtID.Text = "";
            txtAdSoyad.Text = "";
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("UPDATE tbl_Settings set Ad_Soyad=@p1,Username=@p2,Password=@p3,Email=@p4 where ID=@p5", sql.Connect());
            cmd.Parameters.AddWithValue("@p1", txtAdSoyad.Text);
            cmd.Parameters.AddWithValue("@p2", txtUsername.Text);
            cmd.Parameters.AddWithValue("@p3", txtPassword.Text);
            cmd.Parameters.AddWithValue("@p4", txtEmail.Text);
            cmd.Parameters.AddWithValue("@p5", int.Parse(txtID.Text));
            cmd.ExecuteNonQuery();
            sql.Connect().Close();
            MessageBox.Show("İstifadəçi sistemdə yeniləndi", "Məlumat", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            SqlCommand cmdsil = new SqlCommand("Delete from tbl_Settings where ID=@p1", sql.Connect());
            cmdsil.Parameters.AddWithValue("@p1", txtID.Text);
            cmdsil.ExecuteNonQuery();
            sql.Connect().Close();
            MessageBox.Show("İstifadəçi sistemdən silindi", "Məlumat", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            txtID.Text = dr["ID"].ToString();
            txtID.Text = dr["Ad_Soyad"].ToString();
            txtUsername.Text = dr["Username"].ToString();
            txtPassword.Text = dr["Password"].ToString();
            txtEmail.Text = dr["Email"].ToString();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string keywords = txtSearch.Text;
            if (keywords != null)
            {
                DataTable dt = settings.Search(keywords);
                gridControl1.DataSource = dt;
            }
            else
            {
                DataTable dt = settings.Select();
                gridControl1.DataSource = dt;
            }
        }
    }
}
