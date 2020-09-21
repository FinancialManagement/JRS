using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using AD_LMS.Models;
using AD_LMS.Models.WzbModels;
using AD_LMS.Models.zmm;
using Dapper;
using LMS_API.Models.Hwc.Product;
using LMS_API.Models.WzbModels;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace LMS_API.Controllers.Hwc
{
    [Route("api/[controller]")]
    [EnableCors("cors")]
    [ApiController]
    public class LoanordersController : ControllerBase
    {
        private static string conn = "Data Source=10.3.158.43;Initial Catalog=LMS_Finance;User ID=sa;pwd=123456;";

        public LMScontext db;
        public LoanordersController(LMScontext db) { this.db = db; }
        /// <summary>
        ///待放款订单
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetDing")]
        public List<Client> GetDing()
        {
            using (IDbConnection db = new SqlConnection(conn))
            {
                string sql = $"select * from LMS_Client l join LMS_Ding d on l.SId=d.DId";
                var list = db.Query<Client>(sql).ToList();
                return list;
            }
        }
        /// <summary>
        /// 产品信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetProduct")]
        public List<RepaymentSchedule1> GetProduct()
        {
            using (IDbConnection db = new SqlConnection(conn))
            {
                string sql = $"select * from LMS_Ding l join RepaymentSchedule r on l.DId=r.Id";
                var list = db.Query<RepaymentSchedule1>(sql).ToList();
                return list;
            }
        }
        /// <summary>
        /// 客户信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetClient")]
        public List<Client> GetClient()
        {
            using (IDbConnection db = new SqlConnection(conn))
            {
                string sql = $"select * from LMS_Client l join LMS_Ding d on l.SId=d.DId";
                var list = db.Query<Client>(sql).ToList();
                return list;
            }
        }
        /// <summary>
        /// 还款计划
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetRepayment")]
        public List<RepaymentSchedule> GetRepayment()
        {
            using (IDbConnection db=new SqlConnection(conn))
            {
                string sql = $"select * from RepaymentSchedule";
                var list = db.Query<RepaymentSchedule>(sql).ToList();
                return list;
            }
        }
        /// <summary>
        /// 授信历史
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetCredithistory")]
        public List<RepaymentSchedule1> GetCredithistory()
        {
            using (IDbConnection db = new SqlConnection(conn))
            {
                string sql = $"select * from LMS_Ding l join RepaymentSchedule r on l.DId=r.Id";
                var list = db.Query<RepaymentSchedule1>(sql).ToList();
                return list;
            }
        }
        /// <summary>
        /// 修改记录
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetUpdateRecord")]
        public async Task<ActionResult<IEnumerable<UpdateRecord>>> GetUpdateRecord()
        {
            return await db.UpdateRecord.ToListAsync();
        }
        /// <summary>
        /// 返填放款
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("FTDing")]
        public async Task<ActionResult<IEnumerable<LMS_Ding>>> FTDing(int DId)
        {
            return await db.LMS_Ding.Where(x => x.DId == DId).ToArrayAsync();
        }
        /// <summary>
        /// 放款操作
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("AddDing")]
        public async Task<ActionResult<int>> AddDing([FromBody] LMS_Ding Ding)
        {
            db.LMS_Ding.Add(Ding);
            return await db.SaveChangesAsync();
        }
        /// <summary>
        /// 结清
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        public int UpdSettle(string Id)
        {
            using (IDbConnection db = new SqlConnection(conn))
            {
                string sql = $"update RepaymentSchedule set RepaymentMoney=1 where Id in ({Id})";
                return db.Execute(sql);
            }
        }
        /// <summary>
        /// 催收负责人下拉
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetCollection")]
        public List<Collection> GetCollection()
        {
            using (IDbConnection connection=new SqlConnection(conn))
            {
                string sql = "select * from Collection";
                var list = connection.Query<Collection>(sql).ToList();
                return list;
            }
        }
        /// <summary>
        /// 返填结清
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("FTRepay")]
        public async Task<ActionResult<IEnumerable<RepaymentSchedule>>> FTRepay(int Id)
        {
            return await db.RepaymentSchedule.Where(x => x.Id == Id).ToArrayAsync();
        }

    }
}
