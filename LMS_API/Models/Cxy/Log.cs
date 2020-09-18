using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AD_LMS.Models.Cxy
{
    public class Log//日志类
    {
        [Key]
        public int Id { get; set; }//日志主键
        public string OperateUser { get; set; }//操作用户
        public DateTime ExecutionTime { get; set; }//执行时间
        public string Operation { get; set; }//操作
        public string RequestMethod { get; set; }//请求方法
        public int ExecutionDura { get; set; }//执行时长
        public string IPAddress { get; set; }//IP地址
        public int ExecutionResult { get; set; }//执行结果
    }
}
