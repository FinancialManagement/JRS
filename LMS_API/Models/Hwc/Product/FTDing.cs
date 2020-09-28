using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LMS_API.Models.Hwc.Product
{
    public class FTDing
    {
        /// <summary>
        /// 主键
        /// </summary>
        [Key]
        public int SId { get; set; }
        /// <summary>
        /// 客户名称
        /// </summary>
        public string SName { get; set; }
        /// <summary>
        /// 客户电话
        /// </summary>
        public string SPhone { get; set; }
        /// <summary>
        /// 身份证
        /// </summary>
        public string SCard { get; set; }
        /// <summary>
        /// 民族
        /// </summary>
        public int SNation { get; set; }
        /// <summary>
        /// 学历
        /// </summary>
        public int SXueli { get; set; }
        /// <summary>
        /// 所在地区
        /// </summary>
        public string SSfrom { get; set; }
        /// <summary>
        /// 详细地址
        /// </summary>
        public string SXFrom { get; set; }
        /// <summary>
        /// 身份证正面
        /// </summary>
        public string SImg1 { get; set; }
        /// <summary>
        /// 身份证反面
        /// </summary>
        public string SImg2 { get; set; }
        /// <summary>
        /// 工作单位
        /// </summary>
        public string SWorks { get; set; }
        /// <summary>
        /// 月薪
        /// </summary>
        public int SMonthly { get; set; }
        /// <summary>
        /// 企业地址
        /// </summary>
        public string SQFrom { get; set; }
        /// <summary>
        /// 单位电话
        /// </summary>
        public string SQPhone { get; set; }
        /// <summary>
        /// 健康情况
        /// </summary>
        public string SJian { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string SBei { get; set; }
        /// <summary>
        /// 银行卡号
        /// </summary>
        public string SYin { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string SMm { get; set; }
        /// <summary>
        /// 有无贷款
        /// </summary>
        public int SKuan { get; set; }
        /// <summary>
        /// 黑名单
        /// </summary>
        public int SHei { get; set; }
        /// <summary>
        /// 注册时间
        /// </summary>
        public DateTime STime { get; set; }
        /// <summary>
        /// 电子邮箱
        /// </summary>
        public string SEmail { get; set; }
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
}
