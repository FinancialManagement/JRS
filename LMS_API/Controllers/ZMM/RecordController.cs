using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using AD_LMS.Models;
using AD_LMS.Models.zmm;
using Dapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace LMS_API.Controllers.ZMM
{
    //改变响应格式
    [Produces("application/json", "application/xml")]
    [Route("api/[controller]/[action]")]
    [EnableCors("cors")]//设置跨域处理的代理
    [ApiController]
    public class RecordController : ControllerBase
    {
        public string sqlStr = "Data Source=10.3.158.43;Initial Catalog=LMS_Finance;User ID=sa;pwd=123456;";

        public LMScontext db;
        public RecordController(LMScontext db) { this.db = db; }

        //显示
        //[Route("GetShow")]
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Record>>> GetShow()
        //{
        //    var sql = await db.Record.ToListAsync();
        //    return sql;
        //}
        [HttpGet]
        public List<Record> Show()
        {
            List<Record> sql = new List<Record>();
            using (IDbConnection conn = new SqlConnection(sqlStr))
            {
                sql = conn.Query<Record>("select * from Record").ToList();
            }
            return sql;
        }
        //添加
        [HttpPost]
        public int Add([FromForm] string m)
        {
            int flag = 0;
            Record model = JsonConvert.DeserializeObject<Record>(m);
            if (model == null)
            {
                return 0;
            }
            using (IDbConnection conn = new SqlConnection(sqlStr))
            {
                string sql = $"insert into Record values('{model.Content}','{model.RecordTime}','{model.Operator}')";
                flag = conn.Execute(sql);
            }
            return flag;
        }


    }
}
