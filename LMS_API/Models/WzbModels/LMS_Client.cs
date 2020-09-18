using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AD_LMS.Models.WzbModels
{
    public class LMS_Client
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
    }
}
