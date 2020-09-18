using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AD_LMS.Models.Cxy
{
    public class AuthorityJurisdiction//分配权限类
    {
        [Key]
        public int Id { get; set; }//分配主键
        public int C { get; set; }//添加权限
        public int R { get; set; }//查询权限
        public int U { get; set; }//修改权限
        public int D { get; set; }//删除权限
        public int A { get; set; }//随机权限
        public int B { get; set; }//随机权限
    }
}
