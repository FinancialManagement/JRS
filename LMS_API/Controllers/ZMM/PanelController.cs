using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AD_LMS.Models;
using AD_LMS.Models.zmm;
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


        //显示
        [Route("GetShow")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LMS_Ding>>> GetShow()
        {
          return await db.LMS_Ding.ToListAsync();
        }




    }
}


