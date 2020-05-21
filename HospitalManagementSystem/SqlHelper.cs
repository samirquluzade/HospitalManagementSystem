using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem
{
    class SqlHelper
    {
        public SqlConnection Connect()
        {
            SqlConnection sql = new SqlConnection("Data Source=DESKTOP-IMK3R1P\\SAMIRQULUZADEH;Initial Catalog=HOSPITALMANAGEMENTSYSTEM;Integrated Security=True");
            sql.Open();
            return sql;
        }
    }
}
