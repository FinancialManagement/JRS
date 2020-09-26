using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMS_API.Models.Finances
{
    public class FinanceMingxi  //放款明细
    {
        public string Dno { get; set; }

        public string Name { get; set; }

        public int  DFMoney {get;set;}

        public int Dezt { get; set; }
        public string Dtu { get; set; }

        public DateTime Dfang { get; set; }


    }
}
