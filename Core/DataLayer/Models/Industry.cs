﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Core.DataLayer.Models
{
    public class Industry 
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string SICCode { get; set; }
        public string SEOKey { get; set; }
        public string ParentName { get; set; }
        public NAICS NAICS4 { get; set; }
        public NAICS NAICS6 { get; set; }
    }
}