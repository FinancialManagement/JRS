using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AD_LMS.Models //11
{
    public class RepaymentSchedule
    {
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// 期数
        /// </summary>
        public int Periods { get; set; }
        /// <summary>
        /// 账单日期
        /// </summary>
        public DateTime BullDate { get; set; }
        /// <summary>
        /// 本金
        /// </summary>
        [StringLength(50)]
        public string Capital { get; set; }
        /// <summary>
        /// 利息
        /// </summary>
        [StringLength(50)]
        public string Interest { get; set; }
        /// <summary>
        /// 罚息
        /// </summary>
        [StringLength(50)]
        public string DefaultInterest { get; set; }
        /// <summary>
        /// 待还金额
        /// </summary>
        [StringLength(50)]
        public string AmountMonry { get; set; }
        /// <summary>
        /// 还款状态
        /// </summary>
        public int RepaymentMoney { get; set; }
        /// <summary>
        /// 还款时间
        /// </summary>
        public DateTime RepaymentDate { get; set; } = DateTime.Now;
        /// <summary>
        /// 订单外键
        /// </summary>
        public int DingWai { get; set; }
    }
}
