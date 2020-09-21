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
using Newtonsoft.Json;

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
        public Page KeShow(string name="",int PageSize=3,int PageCurrent=1) 
        {
            //using (IDbConnection db = new SqlConnection(conn))
            //{
            //    string sql = $"select SId,SName,SPhone,SCard,SSfrom,SXFrom,SKuan,SBei from LMS_Client";
            //    var list = db.Query<LMS_Client>(sql).ToList();
            //    return list;
            //}
            var list = from a in db.LMS_Client
                           //where a.SName == name
                       select new LMS_Ke { SId = a.SId, SName = a.SName, SPhone = a.SPhone, SCard = a.SCard, SSfrom = a.SSfrom, SXFrom = a.SXFrom, SKuan = a.SKuan, SBei = a.SBei };

            if (!string.IsNullOrEmpty(name))
            {
                  list = from a in db.LMS_Client
                       where a.SName==name
                       select new LMS_Ke { SId = a.SId, SName = a.SName, SPhone = a.SPhone, SCard = a.SCard, SSfrom = a.SSfrom, SXFrom = a.SXFrom, SKuan = a.SKuan, SBei = a.SBei };

            }
            else
            {
                list = from a in db.LMS_Client
                           //where a.SName == name
                           select new LMS_Ke { SId = a.SId, SName = a.SName, SPhone = a.SPhone, SCard = a.SCard, SSfrom = a.SSfrom, SXFrom = a.SXFrom, SKuan = a.SKuan, SBei = a.SBei,STime=a.STime};

            }
            if (PageCurrent<1)
            {
                PageCurrent = 1;
            }
            int count = list.Count();
            int index = 0;
            if (count%PageSize==0)
            {
                index = count/PageSize;
            }
            else
            {
                index = count / PageSize+1;
            }
            if (PageCurrent> index)
            {
                PageCurrent = index;
            }
            Page p = new Page();
            p.List1 = list.Skip((PageCurrent - 1) * PageSize).Take(PageSize).ToList();
            p.PageCurrent = PageCurrent;
            p.PageCount = count;
            p.PageIndex = index;
            return p;
        }
        [Route("DShow1")]
        [HttpGet]
        public Page1 DShow1(string name = "", int PageSize = 3, int PageCurrent = 1) 
        {
            var list = db.LMS_Ding.Where(s => s.DSzt == 1 || s.DSzt == 6).ToList();
            if (!string.IsNullOrEmpty(name))
            {
                list = list.Where(s => s.DName == name).ToList();
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
            Page1 p = new Page1();
            p.LMS_Dings = list.Skip((PageCurrent - 1) * PageSize).Take(PageSize).ToList();
            p.PageCurrent = PageCurrent;
            p.PageCount = count;
            p.PageIndex = index;
            return p;

        }
        [Route("DShow")]
        [HttpGet]
        public List<LMS_Ding> DShow()
        {
            return db.LMS_Ding.ToList();
        }
        [Route("Add")]
        [HttpPost]
        public int Add([FromForm]string m) 
        {
            LMS_ShouJi model = JsonConvert.DeserializeObject<LMS_ShouJi>(m);
            if (model==null)
            {
                return 0;
            }
            else
            {
                db.LMS_ShouJi.Add(model);                                                      
                return db.SaveChanges();
            }
           
        }
        [Route("Del")]
        [HttpGet]
        public int Del(int id)
        {
            using (IDbConnection db = new SqlConnection(conn))
            {
                string sql = $"delete from LMS_Client where SId={id}";
                return db.Execute(sql);
            }
        }
        [Route("XFan")]
        [HttpGet]
        public LMS_Client XFan(int id) 
        {
            return db.LMS_Client.Where(s => s.SId == id).FirstOrDefault();
        }
    }
}
