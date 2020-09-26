using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMS_API.Models.Finances
{
    public class HuanMoney
    {
        public string Dtn { get; set; }
        public string Name { get; set; }
        public string HuiMoney { get; set; }
        public string LiMoney { get; set; }
        public string FaXi { get; set; }
        public string Dhuan { get; set; }
        public int State { get; set; }
        public DateTime HuanTime { get; set; }



    }
}
