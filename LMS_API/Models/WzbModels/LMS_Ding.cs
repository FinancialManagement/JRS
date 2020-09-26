using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LMS_API.Models.WzbModels
{
    public class LMS_Ding
    {
        /// <summary>
        /// 订单主键
        /// </summary>
        [Key]
        public int DId { get; set; }
        /// <summary>
        /// 编号
        /// </summary>
        public string DNo { get; set; }
        /// <summary>
        /// 客户
        /// </summary>
        public string DName { get; set; }
        /// <summary>
        /// 申请状态
        /// </summary>
        //[JsonConverter(typeof(StringEnumConverter))]
        public int DSzt { get; set; }
        /// <summary>
        /// 贷款金额
        /// </summary>
        public int DMoney { get; set; }
        /// <summary>
        /// 期数
        /// </summary>
        public int DCount { get; set; }
        /// <summary>
        /// 贷款用途
        /// </summary>
        public string DTu { get; set; }
        /// <summary>
        /// 还款来源
        /// </summary>
        public string DHuan { get; set; }
        /// <summary>
        /// 借贷担保
        /// </summary>
        public string DDan { get; set; }
        /// <summary>
        /// 借人是否知晓
        /// </summary>
        public string DJia { get; set; }
        /// <summary>
        /// 申请时间
        /// </summary>
        public DateTime SDTime { get; set; }
        /// <summary>
        /// 放款时间
        /// </summary>
        public DateTime DFTime { get; set; }
        /// <summary>
        /// 业务经理
        /// </summary>
        public string DJing { get; set; }
        /// <summary>
        /// 负责人
        /// </summary>
        public string DFu { get; set; }
        /// <summary>
        /// 放款金额
        /// </summary>
        public string DFMoney { get; set; }
        /// <summary>
        /// 利率
        /// </summary>
        public int DLi { get; set; }
        /// <summary>
        /// 服务费
        /// </summary>
        public int DFei { get; set; }
        /// <summary>
        /// 审核意见
        /// </summary>
        public string DYi { get; set; }
        /// <summary>
        /// 贷后管理建议
        /// </summary>
        public string DJy { get; set; }

    }
    public enum DSzt 
    {
        初审中 = 1 ,
        初审通过 = 2,
        初审驳回 = 3,
        复审中 = 4,
        复审通过 = 5,
        复审驳回 = 6,
        终审中 = 7,
        终审通过 = 8,
        终审驳回 = 9,
        放款中 = 10,
        还款中 = 11,
        逾期中 = 12,
        已还清 = 13,
        合同签订 = 14,
        等待放款 = 15,
        未还款 = 16,
    }
}
