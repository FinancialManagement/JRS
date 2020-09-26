using LMS_API.Models.Hwc.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMS_API.Models.Hwc
{
    public class Page1
    {
        public List<RepaymentSchedule1> LMS_Dings { get; set; }
        public int PageCurrent { get; set; }
        public int PageIndex { get; set; }
        public int PageCount { get; set; }
    }
}
