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
    public partial class frmForDoctor : Form
    {
        public string currentusername = string.Empty;
        public frmForDoctor(string text)
        {
            InitializeComponent();
            currentusername = text;
            label1.Text = text;
        }
        Information information1 = new Information();
        private void frmForDoctor_Load(object sender, EventArgs e)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
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

        private void button2_Click_1(object sender, EventArgs e)
        {
            information1.MdiParent = this;
            information1.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            PatientsForDoctor forDoctor = new PatientsForDoctor(label1.Text);
            forDoctor.MdiParent = this;
            forDoctor.Show();
        }

        private void button5_Click_1(object sender, EventArgs e)
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
    }
}
