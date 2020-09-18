using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AD_LMS.Models.Cxy
{
    public class RaInfo//角色权限类
    {
        [Key]
        public int Id { get; set; }//角色权限主键
        public int RId { get; set; }//角色外键
        public int MId { get; set; }//菜单权限外键
        public int AId { get; set; }//分配权限外键
    }
}
