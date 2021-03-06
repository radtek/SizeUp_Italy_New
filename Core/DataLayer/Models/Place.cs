﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Core.DataLayer.Models
{
    public class Place : GeographicLocation
    {
        public long? Id { get; set; }
        public string DisplayName { get; set; }
        public City City { get; set; }
        public County County { get; set; }
        public Metro Metro { get; set; }
        public State State { get; set; }
        public Division Region { get; set; }
        public Nation Nation { get; set; }
    }
}