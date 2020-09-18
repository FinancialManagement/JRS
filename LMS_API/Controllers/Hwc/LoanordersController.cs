using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AD_LMS.Models;
using LMS_API.Models.WzbModels;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LMS_API.Controllers.Hwc
{
    [Route("api/[controller]")]
    [EnableCors("cors")]
    [ApiController]
    public class LoanordersController : ControllerBase
    {
        public LMScontext db;
        public LoanordersController(LMScontext db) { this.db = db; }
        /// <summary>
        ///带放款订单
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetDing")]
        public async Task<ActionResult<IEnumerable<LMS_Ding>>> GetDing()
        {
            return await db.LMS_Ding.ToListAsync();
        }
    }
}
