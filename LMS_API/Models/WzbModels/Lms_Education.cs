using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AD_LMS.Models.WzbModels
{
    public class Lms_Education
    {
        /// <summary>
        /// 主键
        /// </summary>
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// 学历
        /// </summary>
        public string Name { get; set; }
    }
}
