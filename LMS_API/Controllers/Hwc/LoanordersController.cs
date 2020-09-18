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
    [Route("api/[controller]/[action]/")]
    [EnableCors("cors")]
    [ApiController]
    //https://localhost:44341/api/Loanorders/GetDing
    public class LoanordersController : ControllerBase
    {
        public LMScontext db;
        public LoanordersController(LMScontext db) { this.db = db; }
        /// <summary>
        ///带放款订单
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LMS_Ding>>> GetWareHouses()
        {
            return await db.LMS_Ding.ToListAsync();
        }
    }
}
