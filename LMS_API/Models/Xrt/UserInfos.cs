using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LMS_API.Models
{
    /// <summary>
    /// 客户登录注册表
    /// </summary>
   
    public class UserInfos
    {
        /// <summary>
        /// 主键
        /// </summary>
        [Key]
        public int UId { get; set; }

        public string UName { get; set; }
        public string UPwd { get; set; }
    }
}
