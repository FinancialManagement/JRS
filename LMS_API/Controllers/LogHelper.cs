using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using ServiceStack;
using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Filters;

namespace LMS_API.Controllers
{
    public class LogHelper
    {
        private static string conn = "Data Source=10.3.158.43;Initial Catalog=LMS_Finance;User ID=sa;pwd=123456;";

        public void Add(string OperateUser, string Operation, string RequestMethod,string IPAddress) 
        {
            DateTime ExecutionTime = DateTime.Now;
            Stopwatch sw = new Stopwatch();
            sw.Start();
            Test.TestMethod();
            sw.Stop();
            long ExecutionDura = sw.ElapsedMilliseconds;
            int ExecutionResult = 1;
            using (IDbConnection db=new SqlConnection(conn))
            {
                string sql = $"insert into Log values('{OperateUser}','{ExecutionTime}','{Operation}','{RequestMethod}','{ExecutionDura}','{IPAddress}','{ExecutionResult}')";
                db.Execute(sql);
            }
        }
    }
    public static class Test
    {
        public static void TestMethod()
        {
            string result = "";
            for (int i = 0; i < 10000; i++)
            {
                result += i;
            }
        }
    }
}
