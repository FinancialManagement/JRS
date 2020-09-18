using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AD_LMS.Models.Cxy
{
    public class UrInfo//用户角色类
    {
        [Key]
        public int Id { get; set; }//用户角色主键
        public int UId { get; set; }//用户外键
        public int RId { get; set; }//角色外键
    }
}
