﻿using LMS_API.Models.WzbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMS_API.Models.Finances
{
    public class Leiyui
    {
        public int code { get; set; }
        public string msg { get; set; }
        public int count { get; set; }
        public List<LMS_Ding> data { get; set; }
    }
}
