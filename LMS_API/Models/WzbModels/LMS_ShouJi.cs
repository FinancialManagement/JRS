using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AD_LMS.Models.WzbModels
{
    public class LMS_ShouJi
    {
        /// <summary>
        /// 主键
        /// </summary>
        [Key]
        public int JId { get; set; }
        /// <summary>
        /// 订单外键
        /// </summary>
        public int SJId { get; set; }
        /// <summary>
        /// 审核人
        /// </summary>
        public int JName { get; set; }
        /// <summary>
        /// 审核内容
        /// </summary>
        public int JNei { get; set; }
        /// <summary>
        /// 审核时间
        /// </summary>
        public int JTime { get; set; }
    }
}
