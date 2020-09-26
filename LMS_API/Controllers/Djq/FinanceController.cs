using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AD_LMS.Models;
using LMS_API.Models.Finances;
using LMS_API.Models.WzbModels;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.WebSockets;
using Microsoft.EntityFrameworkCore.Storage;
using Newtonsoft.Json;

namespace LMS_API.Controllers.Djq
{
    [Produces("application/json", "application/xml")]
    [Route("api/[controller]")]
    [EnableCors("cors")]//设置跨域处理的代理
    [ApiController]
    public class FinanceController : ControllerBase
    {
        public LMScontext db;
        public FinanceController(LMScontext db) { this.db = db; }




        [Route("Fang")]
        [HttpGet]
        public Leiyui Show()   //放款明细
        {
   
             var list = db.LMS_Ding;
            var model = new Leiyui
            {
                code = 0,
                count = 10,
                msg = "success",
                data = list.ToList()
            };
            return model;
        }
      
        [Route("GetShow")]
        [HttpGet]
        public  Leiyui2 GetShow() //回款明细
        {
            var list = from a in db.RepaymentSchedule
                       from b in db.LMS_Ding
                       where a.DingWai == b.DId
                       select new HuanMoney { Dtn = b.DNo, Name = b.DName, HuiMoney = a.Capital, LiMoney = a.Interest, FaXi = a.DefaultInterest, HuanTime = a.RepaymentDate ,State=a.RepaymentMoney };
         var model = new Leiyui2
            {
                code = 0,
                count = 10,
                msg = "success",
                data = list.ToList()
            };
            return model;
        }

         
    }
}
