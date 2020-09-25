using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMS_API.Models.Finances
{
    public class Leiyui2
    {
        public int code { get; set; }
        public string msg { get; set; }
        public int count { get; set; }

        public List<HuanMoney> data { get; set; }
    }
}
