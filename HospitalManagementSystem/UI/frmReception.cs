using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HospitalManagementSystem.UI
{
    public partial class frmReception : Form
    {
        public string currentusername = string.Empty;
        public frmReception(string text)
        {
            InitializeComponent();
            currentusername = text;
            label1.Text = text;
        }
        Information information1 = new Information();
        SqlHelper sql = new SqlHelper();

        private void frmReception_Load(object sender, EventArgs e)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            information1.MdiParent = this;
            information1.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Information information = new Information();
            information.MdiParent = this;
            information.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult secenek = MessageBox.Show("Çıxmaq istədiyinizdən əminsiniz?", "Məlumat", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (secenek == DialogResult.Yes)
            {
                frmLogin frmLogin = new frmLogin();
                frmLogin.Show();
                this.Hide();
            }
            else { }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PricesForReception forReception = new PricesForReception();
            forReception.MdiParent = this;
            forReception.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AddPasient pasient = new AddPasient();
            pasient.MdiParent = this;
            pasient.Show();
        }

    }
}
