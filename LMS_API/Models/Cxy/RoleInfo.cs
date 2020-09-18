using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AD_LMS.Models.Cxy
{
    public class RoleInfo//角色类
    {
        [Key]
        public int Id { get; set; }//角色主键
        public string RoleName { get; set; }//角色名称
        public int States { get; set; }//状态
        public string Creator { get; set; }//创建人
        public DateTime CreateTime { get; set; }//创建时间
    }
}
