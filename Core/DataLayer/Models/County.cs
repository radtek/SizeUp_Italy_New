﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Core.DataLayer.Models
{
    public class County : GeographicLocation
    {
        public long? Id { get; set; }
        public string Name { get; set; }
        public string SEOKey { get; set; }
    }
}