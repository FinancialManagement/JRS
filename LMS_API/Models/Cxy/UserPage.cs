using AD_LMS.Models.Cxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMS_API.Models.Cxy
{
    public class UserPage
    {
        public int PageIndex { get; set; }
        public int CurrentPage { get; set; }
        public int TotalCount { get; set; }
        public List<VirtualUser> VirtualUsers { get; set; }
    }
}
