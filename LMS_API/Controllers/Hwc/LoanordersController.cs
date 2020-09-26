using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using AD_LMS.Models;
using AD_LMS.Models.WzbModels;
using AD_LMS.Models.zmm;
using Dapper;
using LMS_API.Models.Hwc;
using LMS_API.Models.Hwc.Product;
using LMS_API.Models.WzbModels;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing.Constraints;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

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
        public Models.Hwc.Page GetDing(string name = "", int PageSize = 3, int PageCurrent = 1)
        {
            using (IDbConnection db = new SqlConnection(conn))
            {
                string sql = $"select * from LMS_Client l join LMS_Ding d on l.SName=d.DName join LMS_DState e on d.DSzt=e.Id where Id between 10 and 15 and not Id=13 and not Id=12 and not Id=11";
                var list = db.Query<Client>(sql).ToList();

                if (!string.IsNullOrEmpty(name))
                {
                    list = db.Query<Client>(sql).Where(m => m.DName.Contains(name)).ToList();
                }
                else
                {
                    list = db.Query<Client>(sql).ToList();
                }
                if (PageCurrent < 1)
                {
                    PageCurrent = 1;
                }
                int count = list.Count();
                int index = 0;
                if (count % PageSize == 0)
                {
                    index = count / PageSize;
                }
                else
                {
                    index = count / PageSize + 1;
                }
                if (PageCurrent > index)
                {
                    PageCurrent = index;
                }
                Models.Hwc.Page p = new Models.Hwc.Page();
                p.List1 = list.Skip((PageCurrent - 1) * PageSize).Take(PageSize).ToList();
                p.PageCurrent = PageCurrent;
                p.PageCount = count;
                p.PageIndex = index;
                return p;
            }
        }
        /// <summary>
        /// 放款订单
        /// </summary>
        /// <param name="name"></param>
        /// <param name="PageSize"></param>
        /// <param name="PageCurrent"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetLoanorders")]
        public Models.Hwc.Page GetLoanorders(string name = "", int PageSize = 3, int PageCurrent = 1)
        {
            using (IDbConnection db = new SqlConnection(conn))//select * from LMS_Client l join LMS_Ding d on l.SName=d.DName join LMS_DState e on d.DSzt=e.Id where Id between 10 and 17 and not Id=10 and not Id=14 and not Id=15 and not Id=16
            {
                string sql = $"select * from LMS_Client l join LMS_Ding d on l.SName=d.DName join LMS_DState e on d.DSzt=e.Id where Id between 10 and 17 and not Id=10 and not Id=14 and not Id=15 and not Id=16";
                var list = db.Query<Client>(sql).ToList();

                if (!string.IsNullOrEmpty(name))
                {
                    list = db.Query<Client>(sql).Where(m => m.DName.Contains(name)).ToList();
                }
                else
                {
                    list = db.Query<Client>(sql).ToList();
                }
                if (PageCurrent < 1)
                {
                    PageCurrent = 1;
                }
                int count = list.Count();
                int index = 0;
                if (count % PageSize == 0)
                {
                    index = count / PageSize;
                }
                else
                {
                    index = count / PageSize + 1;
                }
                if (PageCurrent > index)
                {
                    PageCurrent = index;
                }
                Models.Hwc.Page p = new Models.Hwc.Page();
                p.List1 = list.Skip((PageCurrent - 1) * PageSize).Take(PageSize).ToList();
                p.PageCurrent = PageCurrent;
                p.PageCount = count;
                p.PageIndex = index;
                return p;
            }
        }
        /// <summary>
        /// 账单列表
        /// </summary>
        /// <param name="name"></param>
        /// <param name="PageSize"></param>
        /// <param name="PageCurrent"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetBillList")]
        public Models.Hwc.Page GetBillList(string name = "", int PageSize = 3, int PageCurrent = 1)
        {
            using (IDbConnection db = new SqlConnection(conn))
            {
                string sql = $"select * from LMS_Client c join LMS_Ding d on c.SId=d.DId join RepaymentSchedule r on d.DId=r.Id";
                var list = db.Query<Client>(sql).ToList();

                if (!string.IsNullOrEmpty(name))
                {
                    list = db.Query<Client>(sql).Where(m => m.DName.Contains(name)).ToList();
                }
                else
                {
                    list = db.Query<Client>(sql).ToList();
                }
                if (PageCurrent < 1)
                {
                    PageCurrent = 1;
                }
                int count = list.Count();
                int index = 0;
                if (count % PageSize == 0)
                {
                    index = count / PageSize;
                }
                else
                {
                    index = count / PageSize + 1;
                }
                if (PageCurrent > index)
                {
                    PageCurrent = index;
                }
                Models.Hwc.Page p = new Models.Hwc.Page();
                p.List1 = list.Skip((PageCurrent - 1) * PageSize).Take(PageSize).ToList();
                p.PageCurrent = PageCurrent;
                p.PageCount = count;
                p.PageIndex = index;
                return p;
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
        public LMS_Client FTDing(int id)
        {
            using (IDbConnection db = new SqlConnection(conn))
            {
                string sql = $"select * from LMS_Ding where DId={id}";
                var name = db.Query<LMS_Ding>(sql).FirstOrDefault().DName;
                string sql1 = $"select * from LMS_Client where SName='{name}'";
                return db.Query<LMS_Client>(sql1).FirstOrDefault();
            }
        }
        [Route("FTClient")]
        [HttpGet]
        public LMS_Ding FTClient(int id)
        {
            return db.LMS_Ding.Where(s => s.DId == id).FirstOrDefault();
        }
        /// <summary>
        /// 放款操作
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("UpdDing")]
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
        [Route("UpdDJie")]
        public int UpdDJie(int id)
        {
                var a = db.RepaymentSchedule.Where(s => s.DingWai == id && s.RepaymentMoney == 0).FirstOrDefault();
                db.Entry(a).State = EntityState.Modified;
                a.RepaymentMoney =1;
                return db.SaveChanges();
        }
        /// <summary>
        /// 催收负责人下拉
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetCollection")]
        public List<Collection> GetCollection()
        {
            using (IDbConnection connection = new SqlConnection(conn))
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
            return await db.RepaymentSchedule.Where(x => x.Id == Id).ToListAsync();
        }
        /// <summary>
        /// 绑定状态
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("LMS_DState")]
        public List<LMS_DState> LMS_DState()
        {
            using (IDbConnection db = new SqlConnection(conn))
            {
                string sql = $"select * from LMS_DState";
                var list = db.Query<LMS_DState>(sql).ToList();
                return list;
            }
        }
        /// <summary>
        /// 放款
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="Name"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("UpdDState")]
        public int UpdDState([FromForm] string m)
        {
            LMS_ShouJi model = JsonConvert.DeserializeObject<LMS_ShouJi>(m);
            if (model == null)
            {
                return 0;
            }
            else
            {
                var d = db.LMS_Ding.Find(model.SJId);
                db.Entry(d).State = EntityState.Modified;
                d.DSzt = 11;
                var a = Convert.ToInt32(d.DFMoney) / Convert.ToInt32(d.DCount);
                var b = DateTime.Now;
                using (IDbConnection db = new SqlConnection(conn))
                {
                    for (int i = 1; i <= d.DCount; i++)
                    {
                        b = b.AddMonths(1);
                        string sql1 = $"insert into RepaymentSchedule values({i},'{DateTime.Now}',{a},{a * d.DLi / 100},{0},{a + a * d.DLi / 100},{0},'{b}',{d.DId})";
                        db.Execute(sql1);
                    }
                }
                db.LMS_ShouJi.Add(model);
                return db.SaveChanges();
            }
        }
        /// <summary>
        /// 返填已放款11
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("FTFang")]
        public LMS_Client FTFang(int id)
        {
            using (IDbConnection db = new SqlConnection(conn))
            {
                string sql = $"select * from LMS_Ding where DId={id}";
                var name = db.Query<LMS_Ding>(sql).FirstOrDefault().DName;
                string sql1 = $"select * from LMS_Client where SName='{name}'";
                return db.Query<LMS_Client>(sql1).FirstOrDefault();
            }
        }
        [Route("FTYfang")]
        [HttpGet]
        public LMS_Ding FTYfang(int id)
        {
            return db.LMS_Ding.Where(s => s.DId == id).FirstOrDefault();
        }
        /// <summary>
        /// 还款计划
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("RepaymentJi")]
        public List<RepaymentSchedule> RepaymentJi(int id)
        {
            using (IDbConnection db = new SqlConnection(conn))
            {
                string sql = $"select * from RepaymentSchedule where Dingwai={id}";
                return db.Query<RepaymentSchedule>(sql).ToList();
            }
        }
        /// <summary>
        /// 结清返填
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("Repayment")]
        public RepaymentSchedule Repayment(int id)
        {

            using (IDbConnection db = new SqlConnection(conn))
            {
                string sql = $"select * from RepaymentSchedule where Id={id}";
                return db.Query<RepaymentSchedule>(sql).FirstOrDefault();
            }
        }
    }
}
