﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataLayer.Models
{
    public class BarChartItem<T> : ChartItem
    {
        public T Value { get; set; }
        public T Median { get; set; }
    }
}