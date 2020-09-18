using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AD_LMS.Models;
using AD_LMS.Models.WzbModels;
using LMS_API.Models.WzbModels;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LMS_API.Controllers.Wzb
{
    [Produces("application/json", "application/xml")]
    [Route("api/[controller]")]
    [EnableCors("cors")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public LMScontext db;
        public UserController(LMScontext db) { this.db = db; }
        [Route("KeShow")]
        [HttpGet]
        public List<LMS_Client> KeShow() 
        {
            return db.LMS_Client.ToList();
        }
    }
}
