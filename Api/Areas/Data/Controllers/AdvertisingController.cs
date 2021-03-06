using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Data;
using Core.Web;
using Core.Extensions;
using System.Data.Spatial;
using Core;
using Core.Geo;
using Core.DataLayer.Models;
using Api.Controllers;
using System.Configuration;
using Core.API;
using Core.Web;

namespace Api.Areas.Data.Controllers
{
    public class AdvertisingController : BaseController
    {
        //
        // GET: /Api/Advertising/


        private AdvertisingFilters BuildFilters()
        {
            AdvertisingFilters f = new AdvertisingFilters();
            f.AverageRevenue = ParseQueryString("averageRevenue");
            f.TotalRevenue = ParseQueryString("totalRevenue");
            f.TotalEmployees = ParseQueryString("totalEmployees");
            f.RevenuePerCapita = ParseQueryString("revenuePerCapita");
            f.HouseholdIncome = ParseQueryString("householdIncome");
            f.HouseholdExpenditures = ParseQueryString("householdExpenditures");
            f.MedianAge = ParseQueryString("medianAge");
            f.BachelorOrHigher = QueryString.IntValue("bachelorsDegreeOrHigher");
            f.HighSchoolOrHigher = QueryString.IntValue("highSchoolOrHigher");
            f.WhiteCollarWorkers = QueryString.IntValue("whiteCollarWorkers");
            f.Sort = QueryString.StringValue("sort");
            f.Attribute = QueryString.StringValue("attribute");
            f.Distance = QueryString.IntValue("distance");
            f.SortAttribute = QueryString.StringValue("sortAttribute");
            f.Order = QueryString.StringValue("order");
            return f;
        }

        private Band<int?> ParseQueryString(string index)
        {
            Band<int?> v = null;
            int?[] ar = QueryString.IntValues(index);

            if (ar != null)
            {
                v = new Band<int?>();
                v.Min = ar[0];
                v.Max = ar[1];
            }
            return v;
        }


        [APIAuthorize(Role = "Advertising")]
        public ActionResult Index(int industryId, long geographicLocationId, int page = 1, int itemCount = 20)
        {
            int maxResults = int.Parse(ConfigurationManager.AppSettings["Data.Advertising.MaxResults"]);
            itemCount = Math.Min(maxResults, itemCount);


            AdvertisingFilters filters = BuildFilters();
            using (var context = ContextFactory.SizeUpContext)
            {
                var data = Core.DataLayer.Advertising.Get(context, industryId, geographicLocationId, filters);
                var output = new
                {
                    Total = data == null ? 0 : data.Count(),
                    Items = data == null ? null : data
                        .Skip((page - 1) * itemCount)
                        .Take(itemCount)
                        .ToList()
                };

                return Json(output, JsonRequestBehavior.AllowGet);
            }
        }


        [APIAuthorize(Role = "Advertising")]
        public ActionResult MinimumDistance(int industryId, long geographicLocationId, int itemCount)
        {
            AdvertisingFilters filters = BuildFilters();
            using (var context = ContextFactory.SizeUpContext)
            {
                var data = Core.DataLayer.Advertising.MinimumDistance(context, industryId, geographicLocationId, itemCount, filters);
                return Json(data, JsonRequestBehavior.AllowGet);
            }
        }


        [APIAuthorize(Role = "Advertising")]
        public ActionResult Bands(int industryId, long geographicLocationId, int bands)
        {
            AdvertisingFilters filters = BuildFilters();

            using (var context = ContextFactory.SizeUpContext)
            {
                var output = Core.DataLayer.Advertising.Bands(context, industryId, geographicLocationId, bands, filters);
                return Json(output, JsonRequestBehavior.AllowGet);
            }
        }
    }
}