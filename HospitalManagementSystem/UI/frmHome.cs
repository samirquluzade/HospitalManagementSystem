using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HospitalManagementSystem.DLL;
using HospitalManagementSystem.BLL;
using HospitalManagementSystem.UI;
using System.Windows.Input;

namespace HospitalManagementSystem.UI
{
    public partial class frmHome : Form
    {
        public string currentusername = string.Empty;
        public frmHome(string text)
        {
            InitializeComponent();
            currentusername = text;
            label1.Text = text;
        }
        loginDAL dal = new loginDAL();
        loginBLL loginBLL = new loginBLL();
        AddWorker AddWorker;
        Information information = new Information();
        private void frmHome_Load(object sender, EventArgs e)
        {
            this.TopMost = true;
            this.WindowState = FormWindowState.Maximized;
            information.MdiParent = this;
            information.Show();
        }

        private void button1_Click(object sender, EventArgs e)
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

        private void button3_Click_1(object sender, EventArgs e)
        {
            AddWorker = new AddWorker();
            AddWorker.MdiParent = this;
            AddWorker.Show();
        }
        Patients patients;
        private void button5_Click(object sender, EventArgs e)
        {
            patients = new Patients();
            patients.MdiParent = this;
            patients.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            Prices prices = new Prices();
            prices.MdiParent = this;
            prices.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Information information = new Information();
            information.MdiParent = this;
            information.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            frmSettings settings = new frmSettings();
            settings.MdiParent = this;
            settings.Show();
        }
    }
}
