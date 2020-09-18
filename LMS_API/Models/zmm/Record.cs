using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AD_LMS.Models.zmm
{
    //催收记录表
    public class Record
    {
        [Key]
        public int Id { get; set; }
        public string Content { get; set; }//内容
        public DateTime RecordTime { get; set; }//记录时间
        public string Operator { get; set; }//操作人员
    }
}
