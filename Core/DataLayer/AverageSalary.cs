﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataLayer.Models;
using Data;
using Core.Extensions;

namespace Core.DataLayer
{
    public class AverageSalary
    {
        public static BarChartItem<long?> Chart(SizeUpContext context, long industryId, long geographicLocationId)
        {
            var data = Core.DataLayer.IndustryData.Get(context)
                .Where(i => i.IndustryId == industryId && i.BusinessCount > CommonFilters.MinimumBusinessCount)
                .Where(i => i.AverageAnnualSalary != null)
                .Where(i => i.GeographicLocationId == geographicLocationId);

            return data
                .Select(new Projections.AverageSalary.Chart().Expression)
                .FirstOrDefault();
        }

        public static PercentageItem Percentage(SizeUpContext context, long industryId, long geographicLocationId, long value)
        {
            var data = Core.DataLayer.IndustryData.Get(context)
                        .Where(i => i.IndustryId == industryId)
                        .Where(i => i.AverageAnnualSalary != null && i.AverageAnnualSalary > 0)
                        .Where(i => i.GeographicLocationId == geographicLocationId);


            return data.Select(i => new PercentageItem
            {
                Name = i.GeographicLocation.LongName,
                Percentage = (long)((((value - i.AverageAnnualSalary) / (decimal)i.AverageAnnualSalary)) * 100)
            })
                .FirstOrDefault();
        }

        public static List<Band<long>> Bands(SizeUpContext context, long industryId, long boundingGeographicLocationId, int bands, Granularity granularity)
        {
            var gran = Enum.GetName(typeof(Granularity), granularity);

            var data = Core.DataLayer.IndustryData.Get(context)
                .Where(i => i.IndustryId == industryId)
                .Where(i => i.GeographicLocation.Granularity.Name == gran)
                .Where(i => i.GeographicLocation.GeographicLocations.Any(g => g.Id == boundingGeographicLocationId));

            var output = data
                .Where(i => i.AverageAnnualSalary != null && i.AverageAnnualSalary > 0)
                .Select(i => i.Bands.Where(b => b.Attribute.Name == IndustryAttribute.AverageAnnualSalary).Select(b => new Band<double> { Min = (double)b.Min.Value, Max = (double)b.Max.Value }).FirstOrDefault())
                .ToList()
                .NTileDescending(i => i.Min, bands)
                .Select(i => new Band<long>() { Min = (long)i.Min(v => v.Min), Max = (long)i.Max(v => v.Max) })
                .ToList();

            output.FormatDescending();
            return output;
        }
    }
}
