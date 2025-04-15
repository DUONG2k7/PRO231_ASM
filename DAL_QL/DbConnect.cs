using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DAL_QL
{
    public class DbConnect
    {
        protected string ConnectionString = @"Data Source=192.168.1.4,1433;Initial Catalog=PRO231;Persist Security Info=True;User ID=sa;Password=123;Encrypt=False";
    }
}
