using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AD_LMS.Models
{
    public class UpdateRecord
    {
        /// <summary>
        /// 主键
        /// </summary>
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 修改内容
        /// </summary>
        public string UpdateContext { get; set; }
        /// <summary>
        /// 修改时间
        /// </summary>
        public int UpdateDate { get; set; }
    }
}
