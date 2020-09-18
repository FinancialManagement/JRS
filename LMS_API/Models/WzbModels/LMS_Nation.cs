using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AD_LMS.Models.WzbModels
{
    public class LMS_Nation
    {
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// 民族
        /// </summary>
        public string Name { get; set; }
    }
}
