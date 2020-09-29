using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMS_API.Models.Cxy
{
    public class VirtualUser
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string UserPwd { get; set; }
        public string RoleName { get; set; }
        public int States { get; set; }
        public string PositionName { get; set; }
        public string Phone { get; set; }
        public DateTime CreateTime { get; set; }
    }
}
