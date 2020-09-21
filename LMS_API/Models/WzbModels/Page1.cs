using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMS_API.Models.WzbModels
{
    public class Page1
    {
        public List<LMS_Ding> LMS_Dings { get; set; }
        public int PageCurrent { get; set; }
        public int PageIndex { get; set; }
        public int PageCount { get; set; }
    }
}
