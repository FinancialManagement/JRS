using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using AD_LMS.Models;
using AD_LMS.Models.WzbModels;
using Dapper;
using LMS_API.Models;
using LMS_API.Models.WzbModels;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

using Newtonsoft.Json;

namespace LMS_API.Controllers.Xrt
{
    [Produces("application/json", "application/xml")]
    [Route("api/[controller]")]
    [EnableCors("cors")]
    [ApiController]
    public class UserLSController : ControllerBase
    {
        private static string conn = "Data Source=10.3.158.43;Initial Catalog=LMS_Finance;User ID=sa;pwd=123456;";

        public LMScontext db;
        public UserLSController(LMScontext db) { this.db = db; }
        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="name"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        [Route("Login")]
        [HttpGet]
        public async Task<ActionResult<int>> Login(string UName, string UPwd)
        {
            var list = db.UserInfos.Where(s => s.UName.Equals(UName) && s.UPwd.Equals(UPwd)).CountAsync();
            return await list;
        }
        /// <summary>
        /// 用户注册
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        [Route("Regin")]
        [HttpPost]

        public async Task<ActionResult<int>> Regin(string s)
        {
            UserInfos user = JsonConvert.DeserializeObject<UserInfos>(s);
            if (user==null)
            {
                return 0;
            }
            else
            {
                db.UserInfos.Add(user);
                return await db.SaveChangesAsync();
            }
            
        }
        #region 客户申请
        /// <summary>
        /// 客户申请贷款
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        [Route("ShenQing")]
        [HttpPost]
        public async Task<ActionResult<int>> ShenQing(string s)
        {
            LMS_Client user = JsonConvert.DeserializeObject<LMS_Client>(s);
            if (user == null)
            {
                return 0;
            }
            else
            {
                db.LMS_Client.Add(user);
                return await db.SaveChangesAsync();
            }
        }

        /// <summary>
        /// 客户填写详细信息
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        [Route("UpdShengQ")]
        [HttpPost]
        public async Task<ActionResult<int>> UpdShengQ(string s)
        {
            LMS_Client user = JsonConvert.DeserializeObject<LMS_Client>(s);
            if (user == null)
            {
                return 0;
            }
            else
            {
                db.LMS_Client.Add(user);
                return await db.SaveChangesAsync();
            }
        }
        /// <summary>
        /// 订单
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        [Route("AddDing")]
        [HttpPost]
        public async Task<ActionResult<int>> AddDing(int DMoney,int DCount,string DTu,string DHuan)
        {
            LMS_Ding l = new LMS_Ding();
            l.DMoney = DMoney;
            l.DCount = DCount;
            l.DTu = DTu;
            l.DHuan = DHuan;

            db.LMS_Ding.Add(l);
            return await db.SaveChangesAsync();

        }

        #endregion
        #region 下拉
        /// <summary>
        /// 民族下拉
        /// </summary>
        /// <returns></returns>
        [Route("XiaMinZu")]
        [HttpGet]
        public List<LMS_Nation> XiaMinZu()
        {
            List<LMS_Nation> sql = new List<LMS_Nation>();
            using (IDbConnection db = new SqlConnection(conn))
            {
                sql = db.Query<LMS_Nation>("select * from LMS_Nation").ToList();
            }
            return sql;
        }
        /// <summary>
        /// 学历下拉
        /// </summary>
        /// <returns></returns>
        [Route("XiaXueLi")]
        [HttpGet]
        public List<Lms_Education> XiaXueLi()
        {
            List<Lms_Education> sql = new List<Lms_Education>();
            using (IDbConnection db = new SqlConnection(conn))
            {
                sql = db.Query<Lms_Education>("select * from Lms_Education").ToList();
            }
            return sql;
        }
        #endregion


    }
}
