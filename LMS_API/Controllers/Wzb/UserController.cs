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
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using StackExchange.Redis;
using ServiceStack.Redis;

namespace LMS_API.Controllers.Wzb
{
    [Produces("application/json", "application/xml")]
    [Route("api/[controller]")]
    [EnableCors("cors")]
    [ApiController]
    public class UserController : ControllerBase
    {
        RedisClient redis = new RedisClient("127.0.0.1",6379);
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
        public Page1 DShow1(string name ="", int PageSize = 3, int PageCurrent = 1) 
        {
            var list1 = new List<LMS_Ding>();
            list1 = redis.Get<List<LMS_Ding>>("stulist");
                list1 = db.LMS_Ding.Where(s => s.DSzt == 1 || s.DSzt == 6).ToList();
                if (!string.IsNullOrEmpty(name))
                {
                    list1 = list1.Where(s => s.DName == name).ToList();
                }
                if (PageCurrent < 1)
                {
                    PageCurrent = 1;
                }
                int count = list1.Count();
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
                p.LMS_Dings = list1.Skip((PageCurrent - 1) * PageSize).Take(PageSize).ToList();
                p.PageCurrent = PageCurrent;
                p.PageCount = count;
                p.PageIndex = index;
                redis.Set<List<LMS_Ding>>("stulist", list1);
                return p;
        }
        [Route("DShow2")]
        [HttpGet]
        public Page1 DShow2(string name = "", int PageSize = 3, int PageCurrent = 1)
        {
            var list1 = new List<LMS_Ding>();
            list1 = redis.Get<List<LMS_Ding>>("stulist1");
            list1 = db.LMS_Ding.Where(s => s.DSzt == 3 || s.DSzt == 4).ToList();
            if (!string.IsNullOrEmpty(name))
            {
                list1 = list1.Where(s => s.DName == name).ToList();
            }
            if (PageCurrent < 1)
            {
                PageCurrent = 1;
            }
            int count = list1.Count();
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
            p.LMS_Dings = list1.Skip((PageCurrent - 1) * PageSize).Take(PageSize).ToList();
            p.PageCurrent = PageCurrent;
            p.PageCount = count;
            p.PageIndex = index;
            redis.Set<List<LMS_Ding>>("stulist1", list1);
            return p;




        }
        [Route("DShow3")]
        [HttpGet]
        public Page1 DShow3(string name = "", int PageSize = 3, int PageCurrent = 1)
        {
            var list1 = new List<LMS_Ding>();
            list1 = redis.Get<List<LMS_Ding>>("stulist2");
            list1 = db.LMS_Ding.Where(s => s.DSzt == 7).ToList();
            if (!string.IsNullOrEmpty(name))
            {
                list1 = list1.Where(s => s.DName == name).ToList();
            }
            if (PageCurrent < 1)
            {
                PageCurrent = 1;
            }
            int count = list1.Count();
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
            p.LMS_Dings = list1.Skip((PageCurrent - 1) * PageSize).Take(PageSize).ToList();
            p.PageCurrent = PageCurrent;
            p.PageCount = count;
            p.PageIndex = index;
            redis.Set<List<LMS_Ding>>("stulist2", list1);
            return p;




        }
        [Route("DShow4")]
        [HttpGet]
        public Page1 DShow4(string name = "", int PageSize = 3, int PageCurrent = 1)
        {
            var list1 = new List<LMS_Ding>();
            list1 = redis.Get<List<LMS_Ding>>("stulist3");
            list1 = db.LMS_Ding.ToList();
            if (!string.IsNullOrEmpty(name))
            {
                list1 = list1.Where(s => s.DName == name).ToList();
            }
            if (PageCurrent < 1)
            {
                PageCurrent = 1;
            }
            int count = list1.Count();
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
            p.LMS_Dings = list1.Skip((PageCurrent - 1) * PageSize).Take(PageSize).ToList();
            p.PageCurrent = PageCurrent;
            p.PageCount = count;
            p.PageIndex = index;
            redis.Set<List<LMS_Ding>>("stulist3", list1);
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
        public LMS_Ding XFan(int id) 
        {
            return db.LMS_Ding.Where(s => s.DId == id).FirstOrDefault();
        }
        [Route("XFan1")]
        [HttpGet]
        public LMS_Client XFan1(int id)
        {
            
            using (IDbConnection db=new SqlConnection(conn))
            {
                string sql = $"select * from LMS_Ding where DId={id}";
                var name = db.Query<LMS_Ding>(sql).FirstOrDefault().DName;
                string sql1 = $"select * from LMS_Client where SName='{name}'";
                return db.Query<LMS_Client>(sql1).FirstOrDefault();
            }
        }
        [Route("XFan4")]
        [HttpGet]
        public LMS_Client XFan4(int id)
        {
            using (IDbConnection db = new SqlConnection(conn))
            {
                string sql1 = $"select * from LMS_Client where SId='{id}'";
                return db.Query<LMS_Client>(sql1).FirstOrDefault();
            }
        }
        [Route("Xiu1")]
        [HttpPost]
        public int Xiu1([FromForm]string m) 
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
                d.DSzt += 3;
                db.LMS_ShouJi.Add(model);
                return db.SaveChanges();
            }
        }
        [Route("Xiu2")]
        [HttpPost]
        public int Xiu2([FromForm] string m)
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
                d.DSzt += 2;
                db.LMS_ShouJi.Add(model);
                return db.SaveChanges();
            }
        }
        [Route("HeiAdd")]
        [HttpPost]
        public int HeiAdd([FromForm]int id)
        {
                var d = db.LMS_Client.Find(id);
                db.Entry(d).State = EntityState.Modified;
                d.SHei = 2;
                return db.SaveChanges();
        }
        [Route("BeiAdd")]
        [HttpPost]
        public int BeiAdd(int id,string bei)
        {
            var d = db.LMS_Client.Find(id);
            db.Entry(d).State = EntityState.Modified;
            d.SBei = bei;
            return db.SaveChanges();
        }
        [Route("BeiAdd")]
        [HttpPost]
        public int FuAdd(int id, string bei,string fu)
        {
            var a = db.LMS_Ding.Find(id);
            db.Entry(a).State = EntityState.Modified;
            a.DFu = fu;
            var d = db.LMS_Client.Find(a.DName);
            db.Entry(d).State = EntityState.Modified;
            d.SBei = bei;
            return db.SaveChanges();
        }

    }
}
