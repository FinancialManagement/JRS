using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AD_LMS.Models.Cxy
{
    public class Position//职位类
    {
        [Key]
        public int Id { get; set; }//职位主键
        public string PName { get; set; }//职位名称
    }
}
