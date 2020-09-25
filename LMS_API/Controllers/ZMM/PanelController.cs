using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AD_LMS.Models;
using AD_LMS.Models.WzbModels;
using AD_LMS.Models.zmm;
using LMS_API.Models.Hwc.Product;
using LMS_API.Models.WzbModels;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LMS_API.Controllers.ZMM
{
    //改变响应格式
    [Produces("application/json", "application/xml")]
    [Route("api/[controller]")]
    [EnableCors("cors")]//设置跨域处理的代理
    [ApiController]
    public class PanelController : ControllerBase
    {
        public LMScontext db;
        public PanelController(LMScontext db) { this.db = db; }


        //显示//实际放款总金额
        [Route("GetShow")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LMS_Ding>>> GetShow()
        {
          return await db.LMS_Ding.Where(m=>m.DSzt==11).ToListAsync();
        }
        //回款总金额
        [Route("Showget")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RepaymentSchedule>>> Showget()
        {
            return await db.RepaymentSchedule.Where(m => m.RepaymentMoney == 0).ToListAsync();
        }
        //资产总金额
        [Route("GetShow1")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LMS_Ding>>> GetShow1()
        {
            return await db.LMS_Ding.ToListAsync();
        }
        //总盈亏
        [Route("GetShow2")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LMS_Ding>>> GetShow2()
        {
            return await db.LMS_Ding.ToListAsync();
        }
        //总回款金额
        [Route("Showget1")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RepaymentSchedule>>> Showget1()
        {
            return await db.RepaymentSchedule.ToListAsync();
        }

        [Route("GetShow3")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LMS_Ding>>> GetShow3()
        {
            return await db.LMS_Ding.Where(m => m.DSzt == 16).ToListAsync();
        }
        [Route("GetShow4")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LMS_Ding>>> GetShow4()
        {
            return await db.LMS_Ding.Where(m => m.DSzt == 12).ToListAsync();
        }
        [Route("GetShow5")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LMS_Ding>>> GetShow5()
        {
            return await db.LMS_Ding.Where(m => m.DSzt == 13).ToListAsync();
        }



    }
}


