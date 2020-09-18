using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using AD_LMS.Models;
using AD_LMS.Models.WzbModels;
using LMS_API.Models.WzbModels;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Dapper;

namespace LMS_API.Controllers.Wzb
{
    [Produces("application/json", "application/xml")]
    [Route("api/[controller]")]
    [EnableCors("cors")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private static string conn = "Data Source=10.3.158.43;Initial Catalog=LMS_Finance;User ID=sa;pwd=123456;";
        public LMScontext db;
        public UserController(LMScontext db) { this.db = db; }
        [Route("KeShow")]
        [HttpGet]
        public List<LMS_Ke> KeShow() 
        {
            //using (IDbConnection db = new SqlConnection(conn))
            //{
            //    string sql = $"select SId,SName,SPhone,SCard,SSfrom,SXFrom,SKuan,SBei from LMS_Client";
            //    var list = db.Query<LMS_Client>(sql).ToList();
            //    return list;
            //}
            var list = from a in db.LMS_Client
                       select new LMS_Ke { SId = a.SId, SName = a.SName, SPhone = a.SPhone, SCard = a.SCard, SSfrom = a.SSfrom, SXFrom = a.SXFrom, SKuan = a.SKuan, SBei = a.SBei };
            return list.ToList();
        }
        [Route("DShow")]
        [HttpGet]
        public List<LMS_Ding> DShow()
        {
            return db.LMS_Ding.ToList();
        }
    }
}
