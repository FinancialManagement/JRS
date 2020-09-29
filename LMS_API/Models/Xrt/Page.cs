using LMS_API.Models.Hwc.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMS_API.Models.Xrt
{
    public class Page
    {
        public List<Client> List1 { get; set; }
        public int PageCurrent { get; set; }
        public int PageIndex { get; set; }
        public int PageCount { get; set; }
    }
}
