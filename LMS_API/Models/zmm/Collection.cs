using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AD_LMS.Models.zmm
{
    //分页
    public class Page1
    {
        public List<Collection> Collection { get; set; }
        public int totalCount { get; set; }//总记录数
        public int totalPage { get; set; }//总页数
        public int currentPage { get; set; }//当前页
    }

    //催收显示列表
    public class Collection
    {
        [Key]
        public int Id { get; set; }
        public string Code { get; set; }//借款订单编号1
        public string Name { get; set; }//客户姓名
        public int Status { get; set; }//催收状态0:催收中 1:已完成
        public string Record { get; set; }//催收记录
        public DateTime RecordTime { get; set; }//委派催收时间
        public string Collector { get; set; }//催收人员
    }

}
