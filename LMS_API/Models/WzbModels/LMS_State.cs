using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AD_LMS.Models.WzbModels
{
    public class LMS_State
    {
        [Key]
        public int Id { get; set; }//11
        /// <summary>
        /// 贷款状态
        /// </summary>
        public string Name { get; set; }
    }
}
