using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;

namespace LMS_API.Controllers
{
    public class LogHelper
    {
        private static string conn = "Data Source=10.3.158.43;Initial Catalog=LMS_Finance;User ID=sa;pwd=123456;";
        public void Add(string name,string RNei,DateTime RTime,string RFangfa) 
        {
            using (IDbConnection db=new SqlConnection(conn))
            {
                string sql = $"insert into Rizhi values('{name}','{RNei}','{RTime}','{RFangfa}')";
                db.Execute(sql);
            }
        }
    }
}
