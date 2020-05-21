using HospitalManagementSystem.BLL;
using HospitalManagementSystem.DLL;
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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }
        public static string loggedInUser;
        loginBLL l = new loginBLL();
        loginDAL dal = new loginDAL();
        private void button1_Click(object sender, EventArgs e)
        {
            l.username = txtusername.Text;
            l.password = txtpassword.Text;
            bool isSuccess = dal.LoginCheck(l);
            if (isSuccess)
            { //loggedInUSer static metodu username yadda saxlamaq
                loggedInUser = l.username;
                if(l.username == "samirquluzadeh")
                {
                    frmHome home = new frmHome(txtusername.Text);
                    home.Show();
                    this.Hide();
                }
                else if (l.username == "reception")
                {
                    frmReception rec = new frmReception(txtusername.Text);
                    rec.Show();
                    this.Hide();
                }
                else
                {
                    frmForDoctor forDoctor = new frmForDoctor(txtusername.Text);
                    forDoctor.Show();
                    this.Hide();
                }

            }
            else
            {
                MessageBox.Show("İstifadəçi adı və ya parol səhvdir");
            }
        }

        private void txtusername_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtusername.Text))
            {
                e.Cancel = true;
                txtusername.Focus();
                MessageBox.Show("İstifadəçi adı yazılmayıb!");
            }
        }

        private void txtusername_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                this.SelectNextControl(txtusername, true, true, true, true);
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmŞifrəBərpası frmŞifrəBərpası = new frmŞifrəBərpası();
            frmŞifrəBərpası.Show();
        }
    }
}
