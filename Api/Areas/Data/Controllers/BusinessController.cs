﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Data;
using System.Linq.Expressions;
using System.Data.Objects.SqlClient;
using System.Data.Spatial;
using Core.Web;
using Core.Geo;
using Core.DataLayer;
using System.Configuration;
using Api.Controllers;
using Core.API;
namespace Api.Areas.Data.Controllers
{
    public class BusinessController : BaseController
    {
        //
        // GET: /Api/Business/


        [APIAuthorize(Role = "Business")]
        public ActionResult Index(long id)
        {
            using (var context = ContextFactory.SizeUpContext)
            {
                var data = Core.DataLayer.Business.Get(context, id);
                return Json(data, JsonRequestBehavior.AllowGet);
            }
        }


        [APIAuthorize(Role = "Business")]
        public ActionResult At(List<long> industryIds, float lat, float lng)
        {
            using (var context = ContextFactory.SizeUpContext)
            {
                var data = Core.DataLayer.Business.GetAt(context, new LatLng() { Lat = lat, Lng = lng }, industryIds);
                return Json(data, JsonRequestBehavior.AllowGet);
            }
        }



        [APIAuthorize(Role = "Business")]
        public ActionResult List(List<long> industryIds, long geographicLocationId, int itemCount = 10, int page = 1, int radius = 100)
        {
            int maxResults = int.Parse(ConfigurationManager.AppSettings["Data.Business.MaxResults"]);
            //itemCount = Math.Min(maxResults, itemCount);
            itemCount = Math.Max(maxResults, itemCount);
            using (var context = ContextFactory.SizeUpContext)
            {
                var centroid = Core.DataLayer.Geography.Get(context)
                    .Where(i => i.GeographicLocationId == geographicLocationId)
                    //.Where(i => i.GeographyClass.Name == Core.Geo.GeographyClass.Calculation)
                    .Select(new Core.DataLayer.Projections.Geography.Centroid().Expression)
                    .Select(i => i.Value)
                    .FirstOrDefault();

                var data = Core.DataLayer.Business.ListNear(context, centroid, industryIds)
                    .Where(i => i.Distance < radius)
                    .OrderBy(i => i.Distance)
                    .ThenBy(i => i.Entity.Name)
                    .Select(i => i.Entity);

                var output = new
                {
                    Page = page,
                    Count = data.Count(),
                    Items = data.Skip((page - 1) * itemCount).Take(itemCount).ToList()
                };

                return Json(output, JsonRequestBehavior.AllowGet);
            }

        }



    }
}
