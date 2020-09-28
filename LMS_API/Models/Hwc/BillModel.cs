using AD_LMS.Models;
using AD_LMS.Models.WzbModels;
using LMS_API.Models.Hwc.Product;
using LMS_API.Models.WzbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMS_API.Models.Hwc
{
    public class BillModel
    {
        public int code { get; set; }
        public string msg { get; set; }
        public int count { get; set; }
        public List<LMS_Ding> Ding { get; set; }
        public List<LMS_Client> Client { get; set; }
        public List<RepaymentSchedule> Repayment { get; set; }
    }
}
