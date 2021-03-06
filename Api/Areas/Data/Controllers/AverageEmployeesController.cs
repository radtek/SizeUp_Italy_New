﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Data;
using Core;
using Core.Web;
using Core.Geo;
using Core.Extensions;
using Core.DataLayer;
using Core.API;
using Api.Controllers;
namespace Api.Areas.Data.Controllers
{
    public class AverageEmployeesController : BaseController
    {
        //
        // GET: /Api/Employee/



        [APIAuthorize(Role = "IndustryData")]
        public ActionResult Chart(long industryId, long geographicLocationId)
        {
            using (var context = ContextFactory.SizeUpContext)
            {
                var data = Core.DataLayer.AverageEmployees.Chart(context, industryId, geographicLocationId);
                return Json(data, JsonRequestBehavior.AllowGet);
            }
        }


        [APIAuthorize(Role = "IndustryData")]
        public ActionResult Percentile(long industryId, long geographicLocationId, long value)
        {
            using (var context = ContextFactory.SizeUpContext)
            {
                var data = Core.DataLayer.AverageEmployees.Percentile(context, industryId, geographicLocationId, value);
                return Json(data, JsonRequestBehavior.AllowGet);
            }
        }


        [APIAuthorize(Role = "IndustryData")]
        public ActionResult Bands(long industryId, long boundingGeographicLocationId, int bands, Core.DataLayer.Granularity granularity)
        {
            using (var context = ContextFactory.SizeUpContext)
            {
                var data = Core.DataLayer.AverageEmployees.Bands(context, industryId, boundingGeographicLocationId, bands, granularity);
                return Json(data, JsonRequestBehavior.AllowGet);
            }
        }
    }
}
