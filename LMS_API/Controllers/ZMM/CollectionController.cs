using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public class CollectionController : ControllerBase
    {

        public string sqlStr = "Data Source=10.3.158.43;Initial Catalog=LMS_Finance;User ID=sa;pwd=123456;";

        public LMScontext db;
        public CollectionController(LMScontext db) { this.db = db; }


        //显示//查询
        [HttpGet]
        public Page1 Show(string name = "",string collector="",int pageSize = 4, int currentPage = 1)
        {
            List<Collection> list = new List<Collection>();
            using (IDbConnection conn = new SqlConnection(sqlStr))
            {
                list = conn.Query<Collection>("select * from Collection").ToList();
            }  
            if(!string.IsNullOrEmpty(name))
            {
                list = list.Where(s => s.Name.Contains(name)).ToList();
            }
            if (!string.IsNullOrEmpty(collector))
            {
                list = list.Where(s => s.Collector.Contains(collector)).ToList();
            }

            if (currentPage < 1)
            {
                currentPage = 1;
            }
            var count = list.Count();
            int page;
            if (count % pageSize == 0)
            {
                page = count / pageSize;
            }
            else
            {
                page = count / pageSize + 1;
            }
            if (currentPage > page)
            {
                currentPage = page;
            }
            //分页
            Page1 p = new Page1();
            p.Collection = list.Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();//分页查询
            p.currentPage = currentPage;
            p.totalCount = count;
            p.totalPage = page;
            return p;
        }

        //public async Task<ActionResult<IEnumerable<Collection>>> GetShow(/*string name = "", string collector = ""*/)
        //{
        //    var sql = await db.Collection.ToListAsync();
        //    //if (!string.IsNullOrEmpty(name))
        //    //{
        //    //    sql = sql.Where(s => s.Name == name).ToList();
        //    //}
        //    //if (!string.IsNullOrEmpty(collector))
        //    //{
        //    //    sql = sql.Where(s => s.Collector == collector).ToList();
        //    //}
        //    //if (RecordTime!=null)
        //    //{
        //    //    sql = sql.Where(s => s.RecordTime == RecordTime).ToList();
        //    //}
        //    return sql;
        //}


        //添加
        // [HttpPost("Add")]
        //public async Task<ActionResult<int>> Add([FromBody] Collection m)
        //{
        //     db.Collection.Add(m);
        //     return await db.SaveChangesAsync();
        //}
       // 添加
       [HttpPost]
       public int Add([FromForm]string m)
        {
            int flag = 0;
            Collection model= JsonConvert.DeserializeObject<Collection>(m);
            if(model==null)
            {
                return 0;
            }
            using (IDbConnection conn = new SqlConnection(sqlStr))
            {
                string sql = $"insert into Collection values('{model.Code}','{model.Name}',{model.Status},'{ model.Record}','{ model.RecordTime}','{model.Collector}')";
                flag = conn.Execute(sql);
            }
            return flag;
        }
        //删除
        [HttpPost]
        public int Delete([FromForm]int id)
        {
            int flag = 0;
            using (IDbConnection conn = new SqlConnection(sqlStr))
            {
                flag = conn.Execute($"delete  from Collection where Id = {id} ");
            };
            return flag;
        }

       //删除
        //[Route("Delete")]
        //[HttpGet]
        //public async Task<ActionResult<int>> Delete(int id)
        //{
        //    db.Collection.Remove(db.Collection.FirstOrDefault(m => m.Id == id));
        //    return await db.SaveChangesAsync();
        //}
        //修改
        [Route("Update")]
        [HttpPut]
        public async Task<ActionResult<int>> Update([FromBody] Collection m)
        {
            db.Entry(m).State = EntityState.Modified;
            return await db.SaveChangesAsync();
        }
        //反填
        [Route("Fian")]
        [HttpGet]
        public Collection Fian(int id)
        {
            return db.Collection.Where(s => s.Id == id).FirstOrDefault();
        }


    }
}
