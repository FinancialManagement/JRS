using AD_LMS.Models.WzbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMS_API.Models.WzbModels
{
    public class Page
    {
        public List<LMS_Ke> List1 { get; set; }
        public int PageCurrent { get; set; }
        public int PageIndex { get; set; }
        public int PageCount { get; set; }
    }
}
