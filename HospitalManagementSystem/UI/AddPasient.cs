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
    public partial class AddPasient : Form
    {
        SqlHelper sql = new SqlHelper();
        public AddPasient()
        {
            InitializeComponent();
        }
        public static string check;
        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("insert into tbl_Patients(Ad,Soyad,Yaş,Xəstəliyi,Müraciət_edilən_həkim) Values(@p1,@p2,@p3,@p4,@p5)", sql.Connect());
            cmd.Parameters.AddWithValue("@p1", txtAd.Text);
            cmd.Parameters.AddWithValue("@p2", txtSoyad.Text);
            cmd.Parameters.AddWithValue("@p3", int.Parse(txtyash.Text));
            cmd.Parameters.AddWithValue("@p4", txtxestelik.Text);
            cmd.Parameters.AddWithValue("@p5", txtmuraciet.Text);
            cmd.ExecuteNonQuery();
            sql.Connect().Close();
            MessageBox.Show("Xəstə sistemə əlavə olundu", "Məlumat", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
            check = txtmuraciet.Text;
        }
        void listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * FROM tbl_Patients", sql.Connect());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }

        private void AddPasient_Load(object sender, EventArgs e)
        {
            listele();
            txtID.Text = "";
            txtAd.Text = "";
            txtSoyad.Text = "";
            txtyash.Text = "";
            txtxestelik.Text = "";
            txtmuraciet.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("UPDATE tbl_Patients set Ad=@p1,Soyad=@p2,Yaş=@p3,Xəstəliyi=@p4,Müraciət_edilən_həkim=@p5 where ID=@p6", sql.Connect());
            cmd.Parameters.AddWithValue("@p1", txtAd.Text);
            cmd.Parameters.AddWithValue("@p2", txtSoyad.Text);
            cmd.Parameters.AddWithValue("@p3", int.Parse(txtyash.Text));
            cmd.Parameters.AddWithValue("@p4", txtxestelik.Text);
            cmd.Parameters.AddWithValue("@p5", txtmuraciet.Text);
            cmd.Parameters.AddWithValue("@p6", int.Parse(txtID.Text));
            cmd.ExecuteNonQuery();
            sql.Connect().Close();
            MessageBox.Show("Xəstə sistemdə yeniləndi", "Məlumat", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlCommand cmdsil = new SqlCommand("Delete from tbl_Patients where ID=@p1", sql.Connect());
            cmdsil.Parameters.AddWithValue("@p1", txtID.Text);
            cmdsil.ExecuteNonQuery();
            sql.Connect().Close();
            MessageBox.Show("Xəstə sistemdən silindi", "Məlumat", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            txtID.Text = dr["ID"].ToString();
            txtAd.Text = dr["Ad"].ToString();
            txtSoyad.Text = dr["Soyad"].ToString();
            txtyash.Text = dr["Yaş"].ToString();
            txtxestelik.Text = dr["Xəstəliyi"].ToString();
            txtmuraciet.Text = dr["Müraciət_edilən_həkim"].ToString();
        }

        private void txtAd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                this.SelectNextControl(txtAd, true, true, true, true);
            }
        }

        private void txtSoyad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                this.SelectNextControl(txtSoyad, true, true, true, true);
            }
        }

        private void txtyash_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                this.SelectNextControl(txtyash, true, true, true, true);
            }
        }

        private void txtxestelik_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                this.SelectNextControl(txtxestelik, true, true, true, true);
            }
        }

        private void txtmuraciet_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                this.SelectNextControl(txtmuraciet, true, true, true, true);
            }
            check = txtmuraciet.Text;
        }
        
    }
}
