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
    public partial class frmSplash : Form
    {
        public frmSplash()
        {
            InitializeComponent();
        }
        private void frmSplash_Load(object sender, EventArgs e)
        {
            timer3.Start();
            this.TopMost = true;
            this.WindowState = FormWindowState.Maximized;
        }
        int move = 0;
        private void timer3_Tick(object sender, EventArgs e)
        {
            timer3.Interval = 20;
            panelMovable.Width += 6;
            move += 5;
            if (move == 555)
            {
                timer3.Stop();
                this.Hide();
                frmLogin login = new frmLogin();
                login.Show();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
