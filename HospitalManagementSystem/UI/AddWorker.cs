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
    public partial class AddWorker : Form
    {
        public AddWorker()
        {
            InitializeComponent();
        }
        SqlHelper sql = new SqlHelper();
        private void AddWorker_Load(object sender, EventArgs e)
        {
            listele();
            txtID.Text = "";
            txtAd.Text = "";
            txtSoyad.Text = "";
            txtyash.Text = "";
            txtemek.Text = "";
            txtVezife.Text = "";
            txtHaqqinda.Text = "";
            txtBolme.Text = "";
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                this.SelectNextControl(txtAd, true, true, true, true);
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                this.SelectNextControl(txtSoyad, true, true, true, true);
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                this.SelectNextControl(txtyash, true, true, true, true);
            }
        }
        private void txtBolme_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                this.SelectNextControl(txtBolme, true, true, true, true);
            }
        }
        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                this.SelectNextControl(txtemek, true, true, true, true);
            }
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                this.SelectNextControl(txtVezife, true, true, true, true);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("insert into tbl_İşçilər(Ad,Soyad,Yaş,Əmək_haqqı,Bölmə,Vəzifə,Haqqında) Values(@p1,@p2,@p3,@p4,@p5,@p6,@p7)", sql.Connect());
            cmd.Parameters.AddWithValue("@p1", txtAd.Text);
            cmd.Parameters.AddWithValue("@p2", txtSoyad.Text);
            cmd.Parameters.AddWithValue("@p3", int.Parse(txtyash.Text));
            cmd.Parameters.AddWithValue("@p4", int.Parse(txtemek.Text));
            cmd.Parameters.AddWithValue("@p5", txtBolme.Text);
            cmd.Parameters.AddWithValue("@p6", txtVezife.Text);
            cmd.Parameters.AddWithValue("@p7", txtHaqqinda.Text);
            cmd.ExecuteNonQuery();
            sql.Connect().Close();
            MessageBox.Show("İşçi sistemə əlavə olundu", "Məlumat", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
        }
        void listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * FROM tbl_İşçilər", sql.Connect());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("UPDATE tbl_İşçilər set Ad=@p1,Soyad=@p2,Yaş=@p3,Əmək_haqqı=@p4,Bölmə=@p5,Vəzifə=@p6,Haqqında=@p7 where ID=@p8", sql.Connect());
            cmd.Parameters.AddWithValue("@p1", txtAd.Text);
            cmd.Parameters.AddWithValue("@p2", txtSoyad.Text);
            cmd.Parameters.AddWithValue("@p3", int.Parse(txtyash.Text));
            cmd.Parameters.AddWithValue("@p4", int.Parse(txtemek.Text));
            cmd.Parameters.AddWithValue("@p5", txtBolme.Text);
            cmd.Parameters.AddWithValue("@p6", txtVezife.Text);
            cmd.Parameters.AddWithValue("@p8", txtHaqqinda.Text);
            cmd.Parameters.AddWithValue("@p8", int.Parse(txtID.Text));
            cmd.ExecuteNonQuery();
            sql.Connect().Close();
            MessageBox.Show("İşçi sistemdə yeniləndi", "Məlumat", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
        }
        workersDAL wDAL = new workersDAL();
        private void button3_Click(object sender, EventArgs e)
        {
            SqlCommand cmdsil = new SqlCommand("Delete from tbl_İşçilər where ID=@p1", sql.Connect());
            cmdsil.Parameters.AddWithValue("@p1", txtID.Text);

            cmdsil.ExecuteNonQuery();
            sql.Connect().Close();
            MessageBox.Show("İşçi sistemdən silindi", "Məlumat", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
        }
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string keywords = txtSearch.Text;
            if (keywords != null)
            {
                DataTable dt = wDAL.Search(keywords);
                gridControl1.DataSource = dt;
            }
            else
            {
                DataTable dt = wDAL.Select();
                gridControl1.DataSource = dt;
            }
        }

        private void gridView1_FocusedRowChanged_1(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            txtID.Text = dr["ID"].ToString();
            txtAd.Text = dr["Ad"].ToString();
            txtSoyad.Text = dr["Soyad"].ToString();
            txtyash.Text = dr["Yaş"].ToString();
            txtemek.Text = dr["Əmək_haqqı"].ToString();
            txtBolme.Text = dr["Bölmə"].ToString();
            txtVezife.Text = dr["Vəzifə"].ToString();
            txtHaqqinda.Text = dr["Haqqında"].ToString();
        }

       
    }
}
