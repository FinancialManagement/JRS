using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AD_LMS.Models.Cxy
{
    public class UserInfo//用户类
    {
        [Key]
        public int Id { get; set; }//用户主键
        public string UserName { get; set; }//用户名
        public string UserPwd { get; set; }//用户密码
        public int PId { get; set; }//职位外键
        public int States { get; set; }//状态
        public string Phone { get; set; }//手机号码
        public DateTime CreateTime { get; set; }//创建时间
    }
}
