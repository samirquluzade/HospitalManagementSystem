using HospitalManagementSystem.BLL;
using HospitalManagementSystem.DLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HospitalManagementSystem.UI
{
    public partial class frmŞifrəBərpası : Form
    {
        static string myconn = ConfigurationManager.ConnectionStrings["connstr"].ConnectionString;
        public frmŞifrəBərpası()
        {
            InitializeComponent();
        }
        public static string loggedInUser;
        BerpaBLL l = new BerpaBLL();
        BerpaDAL dal = new BerpaDAL();
        SqlHelper sql = new SqlHelper();
        SmtpClient smtpserver = new SmtpClient();
        MailMessage mail = new MailMessage();
        NetworkCredential credential = new NetworkCredential("myhospitaladm@gmail.com","hospitaladmin123");
        MailAddress MailAddress = new MailAddress("myhospitaladm@gmail.com");
        private void button1_Click(object sender, EventArgs e)
        {
            l.username = txtUsername.Text;
            bool isSuccess = dal.LoginCheck(l);
            if (isSuccess)
            {
                string check = txtUsername.Text;
                DataTable dt = new DataTable();
                DataTable dq = new DataTable();
                SqlCommand cmd = null;
                string query = @"Select Email,Password FROM tbl_Settings where Username = '" + check + "'";
                //  SqlDataAdapter sd = new SqlDataAdapter("Select Password FROM tbl_Settings where Username = '" + check + "'", sql.Connect());
                using (SqlConnection connection = new SqlConnection(myconn))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();
                    cmd = new SqlCommand(query);
                    cmd.Connection = connection;
                    SqlDataReader reader = cmd.ExecuteReader();
                    // Call Read before accessing data.
                    while (reader.Read())
                    {
                        var to = new MailAddress(reader["Email"].ToString());
                        mail.To.Add(to);
                        var password = reader["Password"].ToString();
                        mail.Body = "Şifrəniz: " + password;
                    }
                    smtpserver.Credentials = credential;
                    smtpserver.EnableSsl = true;
                    smtpserver.Port = 587;
                    smtpserver.Host = "smtp.gmail.com";
                    mail.From = MailAddress;      
                    smtpserver.Send(mail);
                    reader.Close();
                }
                label2.Text = "Şifrə sistemdə göstərilən email-ə göndərildi";
            }
            else
            {
                label2.Text = "İstifadəçi adı sistemdə tapılmadı";
            }
        }

        private void frmŞifrəBərpası_Load(object sender, EventArgs e)
        {

        }
    }
}
