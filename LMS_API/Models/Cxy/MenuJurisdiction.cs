using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AD_LMS.Models.Cxy
{
    public class MenuJurisdiction//菜单权限类
    {
        [Key]
        public int Id { get; set; }//菜单主键
        public string MName { get; set; }//菜单名称
        public int PId { get; set; }//父级ID
    }
}
