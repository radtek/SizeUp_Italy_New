﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Core;
using Core.Serialization;
using System.Dynamic;
using Data;
using System.Web.Security;
//using Data.UserData;
using Core.Web;
using Core.API;
//using Data.Analytics;
//using Core.Analytics;

namespace Web.Areas.Api.Controllers
{
    public class ProfileController : BaseController
    {
        //
        // GET: /Api/User/
        //[HttpGet]
        //public ActionResult GetDashboardValues(long placeId, long industryId)
        //{
        //    dynamic obj = new System.Dynamic.ExpandoObject();
        //    string key = string.Format("dv-{0}-{1}", placeId, industryId);
        //    var cookie = Request.Cookies[key] != null ? Request.Cookies[key] : Core.Web.CookieFactory.Create(key);
        //    Data.UserData.BusinessAttribute attr = new Data.UserData.BusinessAttribute();

        //    if (User.Identity.IsAuthenticated)
        //    {
        //        using (var context = ContextFactory.UserDataContext)
        //        {
        //            var user = Membership.GetUser(User.Identity.Name);
        //            Guid userid = (Guid)user.ProviderUserKey;
        //            attr = context.BusinessAttributes.Where(i => i.UserId == userid && i.PlaceId == placeId && i.IndustryId == industryId).FirstOrDefault();
        //            if (attr == null)
        //            {
        //                attr = new Data.UserData.BusinessAttribute();
        //            }
        //        }
        //    }

            

        //    if (!string.IsNullOrEmpty(attr.BusinessSize))
        //    {
        //        obj.businessSize = attr.BusinessSize;
        //    }
        //    if (!string.IsNullOrEmpty(attr.BusinessType))
        //    {
        //        obj.businessType = attr.BusinessType;
        //    }
        //    if (attr.Employees.HasValue)
        //    {
        //        obj.employees = attr.Employees;
        //    }
        //    if (attr.HealthcareCost.HasValue)
        //    {
        //        obj.healthcareCost = attr.HealthcareCost;
        //    }
        //    if (attr.Revenue.HasValue)
        //    {
        //        obj.revenue = attr.Revenue;
        //    }
        //    if (attr.AverageSalary.HasValue)
        //    {
        //        obj.salary = attr.AverageSalary;
        //    }
        //    if (attr.WorkersComp.HasValue)
        //    {
        //        obj.workersComp = attr.WorkersComp;
        //    }
        //    if (attr.YearStarted.HasValue)
        //    {
        //        obj.yearStarted = attr.YearStarted;
        //    }

        //    if (cookie.Values.AllKeys.Contains("businessSize") && User.Identity.IsAuthenticated)
        //    {
        //        obj.businessSize = cookie.Values["businessSize"];
        //    }
        //    if (cookie.Values.AllKeys.Contains("businessType"))
        //    {
        //        obj.businessType = cookie.Values["businessType"];
        //    }
        //    if (cookie.Values.AllKeys.Contains("employees") && User.Identity.IsAuthenticated)
        //    {
        //        obj.employees = cookie.Values["employees"];
        //    }
        //    if (cookie.Values.AllKeys.Contains("healthcareCost") && User.Identity.IsAuthenticated)
        //    {
        //        obj.healthcareCost = cookie.Values["healthcareCost"];
        //    }
        //    if (cookie.Values.AllKeys.Contains("revenue"))
        //    {
        //        obj.revenue = cookie.Values["revenue"];
        //    }
        //    if (cookie.Values.AllKeys.Contains("salary"))
        //    {
        //        obj.salary = cookie.Values["salary"];
        //    }
        //    if (cookie.Values.AllKeys.Contains("workersComp") && User.Identity.IsAuthenticated)
        //    {
        //        obj.workersComp = cookie.Values["workersComp"];
        //    }
        //    if (cookie.Values.AllKeys.Contains("yearStarted"))
        //    {
        //        obj.yearStarted = cookie.Values["yearStarted"];
        //    }

        //    object output = ((ExpandoObject)obj).ToDictionary(item => item.Key, item => item.Value);
        //    return Json(output, JsonRequestBehavior.AllowGet);
        //}

        //[HttpPost]
        //public ActionResult SetDashboardValues(long placeId, long industryId)
        //{
        //    string key = string.Format("dv-{0}-{1}", placeId, industryId);
        //    HttpCookie cookie = Core.Web.CookieFactory.Create(key);
        //    Data.UserData.BusinessAttribute attr = new Data.UserData.BusinessAttribute();
        //    Data.Analytics.BusinessAttribute analyticsAttr = new Data.Analytics.BusinessAttribute();
        //    attr.PlaceId = placeId;
        //    attr.IndustryId = industryId;

        //    analyticsAttr.PlaceId = placeId;
        //    analyticsAttr.IndustryId = industryId;

        //    if (Request.Form.AllKeys.Contains("businessSize"))
        //    {
        //        cookie.Values.Add("businessSize", Request["businessSize"]);
        //        attr.BusinessSize = Request["businessSize"];
        //    }
        //    if (Request.Form.AllKeys.Contains("businessType"))
        //    {
        //        cookie.Values.Add("businessType", Request["businessType"]);
        //        attr.BusinessType = Request["businessType"];
        //    }
        //    if (Request.Form.AllKeys.Contains("employees"))
        //    {
        //        cookie.Values.Add("employees", Request["employees"]);
        //        attr.Employees = int.Parse(Request["employees"]);
        //    }
        //    if (Request.Form.AllKeys.Contains("healthcareCost"))
        //    {
        //        cookie.Values.Add("healthcareCost", Request["healthcareCost"]);
        //        attr.HealthcareCost = int.Parse(Request["healthcareCost"]);
        //    }
        //    if (Request.Form.AllKeys.Contains("revenue"))
        //    {
        //        cookie.Values.Add("revenue", Request["revenue"]);
        //        attr.Revenue = int.Parse(Request["revenue"]);
        //    }
        //    if (Request.Form.AllKeys.Contains("salary"))
        //    {
        //        cookie.Values.Add("salary", Request["salary"]);
        //        attr.AverageSalary = int.Parse(Request["salary"]);
        //    }
        //    if (Request.Form.AllKeys.Contains("workersComp"))
        //    {
        //        cookie.Values.Add("workersComp", Request["workersComp"]);
        //        attr.WorkersComp = decimal.Parse(Request["workersComp"]);
        //    }
        //    if (Request.Form.AllKeys.Contains("yearStarted"))
        //    {
        //        cookie.Values.Add("yearStarted", Request["yearStarted"]);
        //        attr.YearStarted = int.Parse(Request["yearStarted"]);
        //    }



        //    if (User.Identity.IsAuthenticated)
        //    {
        //        using (var context = ContextFactory.UserDataContext)
        //        {
        //            var user = Membership.GetUser(User.Identity.Name);
        //            Guid userid = (Guid)user.ProviderUserKey;
        //            attr.UserId = userid;
        //            analyticsAttr.UserId = userid;
                    

        //            var item = context.BusinessAttributes.Where(i => i.UserId == userid && i.PlaceId == placeId && i.IndustryId == industryId).FirstOrDefault();
        //            if (item != null)
        //            {
        //                //test for changes... update if there are and then insert into analytics else ignore
        //                if (item.AverageSalary != attr.AverageSalary ||
        //                    item.BusinessSize != attr.BusinessSize ||
        //                    item.BusinessType != attr.BusinessType ||
        //                    item.Employees != attr.Employees ||
        //                    item.HealthcareCost != attr.HealthcareCost ||
        //                    item.Revenue != attr.Revenue ||
        //                    item.WorkersComp != attr.WorkersComp ||
        //                    item.YearStarted != attr.YearStarted)
        //                {
        //                    item.AverageSalary = attr.AverageSalary;
        //                    item.BusinessSize = attr.BusinessSize;
        //                    item.BusinessType = attr.BusinessType;
        //                    item.Employees = attr.Employees;
        //                    item.HealthcareCost = attr.HealthcareCost;
        //                    item.Revenue = attr.Revenue;
        //                    item.WorkersComp = attr.WorkersComp;
        //                    item.YearStarted = attr.YearStarted;
        //                    context.SaveChanges();
        //                }
        //            }
        //            else
        //            {
        //                context.BusinessAttributes.AddObject(attr);
        //                context.SaveChanges();
        //            }
        //        }
        //    }

        //    analyticsAttr.AverageSalary = attr.AverageSalary;
        //    analyticsAttr.BusinessSize = attr.BusinessSize;
        //    analyticsAttr.BusinessType = attr.BusinessType;
        //    analyticsAttr.Employees = attr.Employees;
        //    analyticsAttr.HealthcareCost = attr.HealthcareCost;
        //    analyticsAttr.Revenue = attr.Revenue;
        //    analyticsAttr.WorkersComp = attr.WorkersComp;
        //    analyticsAttr.YearStarted = attr.YearStarted;
        //    Singleton<Tracker>.Instance.BusinessAttribute(analyticsAttr);

        //    Response.Cookies.Add(cookie);
        //    return Json(true, JsonRequestBehavior.AllowGet);
        //}





        [HttpGet]
        public ActionResult GetCompetitionValues(long placeId, long industryId)
        {
            //dynamic obj = new System.Dynamic.ExpandoObject();
            //string key = string.Format("cv-{0}-{1}", placeId, industryId);
            //var cookie = Request.Cookies[key] != null ? Request.Cookies[key] : Core.Web.CookieFactory.Create(key);
            //Data.UserData.CompetitorAttribute attr = new Data.UserData.CompetitorAttribute();

            //if (User.Identity.IsAuthenticated)
            //{
            //    using (var context = ContextFactory.UserDataContext)
            //    {
            //        var user = Membership.GetUser(User.Identity.Name);
            //        Guid userid = (Guid)user.ProviderUserKey;
            //        attr = context.CompetitorAttributes.Where(i => i.UserId == userid && i.PlaceId == placeId && i.IndustryId == industryId).FirstOrDefault();
            //        if (attr == null)
            //        {
            //            attr = new Data.UserData.CompetitorAttribute();
            //        }
            //    }
            //}



            //if (!string.IsNullOrEmpty(attr.Competitors))
            //{
            //    obj.competitor = attr.Competitors.Split(',').Select(i => long.Parse(i)).ToList();
            //}
            //if (!string.IsNullOrEmpty(attr.Suppliers))
            //{
            //    obj.supplier = attr.Suppliers.Split(',').Select(i => long.Parse(i)).ToList();
            //}
            //if (!string.IsNullOrEmpty(attr.Buyers))
            //{
            //    obj.buyer = attr.Buyers.Split(',').Select(i => long.Parse(i)).ToList();
            //}
            //if (attr.ComsumerExpenditureId.HasValue && attr.RootId.HasValue)
            //{
            //    obj.consumerExpenditureVariable = attr.ComsumerExpenditureId;
            //    obj.rootId = attr.RootId;
            //}

            //if (cookie.Values.AllKeys.Contains("competitor"))
            //{
            //    obj.competitor = cookie.Values["competitor"].Split(',').Select(i => long.Parse(i)).ToList();
            //}
            //if (cookie.Values.AllKeys.Contains("supplier"))
            //{
            //    obj.supplier = cookie.Values["supplier"].Split(',').Select(i => long.Parse(i)).ToList();
            //}
            //if (cookie.Values.AllKeys.Contains("buyer"))
            //{
            //    obj.buyer = cookie.Values["buyer"].Split(',').Select(i => long.Parse(i)).ToList();
            //}
            //if (cookie.Values.AllKeys.Contains("consumerExpenditureVariable") && cookie.Values.AllKeys.Contains("rootId"))
            //{
            //    obj.consumerExpenditureVariable = long.Parse(cookie.Values["consumerExpenditureVariable"]);
            //    obj.rootId = long.Parse(cookie.Values["rootId"]);
            //}

            //object output = ((ExpandoObject)obj).ToDictionary(item => item.Key, item => item.Value);
            object output = null;
            return Json(output, JsonRequestBehavior.AllowGet);
        }



        //[HttpPost]
        //public ActionResult SetCompetitionValues(long placeId, long industryId)
        //{
        //    string key = string.Format("cv-{0}-{1}", placeId, industryId);
        //    HttpCookie cookie = Core.Web.CookieFactory.Create(key);
        //    Data.UserData.CompetitorAttribute attr = new Data.UserData.CompetitorAttribute();
        //    Data.Analytics.CompetitorAttribute analyticsAttr = new Data.Analytics.CompetitorAttribute();
        //    attr.PlaceId = placeId;
        //    attr.IndustryId = industryId;
        //    analyticsAttr.PlaceId = placeId;
        //    analyticsAttr.IndustryId = industryId;

        //    if (Request.Form.AllKeys.Contains("competitor"))
        //    {
        //        var ids = Form.IntValues("competitor");
        //        cookie.Values.Add("competitor", string.Join(",", ids));
        //        attr.Competitors = string.Join(",", ids);
        //    }
        //    if (Request.Form.AllKeys.Contains("supplier"))
        //    {
        //        var ids = Form.IntValues("supplier");
        //        cookie.Values.Add("supplier", string.Join(",", ids));
        //        attr.Suppliers = string.Join(",", ids);
        //    }
        //    if (Request.Form.AllKeys.Contains("buyer"))
        //    {
        //        var ids = Form.IntValues("buyer");
        //        cookie.Values.Add("buyer", string.Join(",", ids));
        //        attr.Buyers = string.Join(",", ids);
        //    }
        //    if (Request.Form.AllKeys.Contains("rootId") && Request.Form.AllKeys.Contains("consumerExpenditureVariable"))
        //    {
        //        var id = Form.StringValue("rootId");
        //        cookie.Values.Add("rootId", id);
        //        attr.RootId = int.Parse(id);
        //        id = Form.StringValue("consumerExpenditureVariable");
        //        cookie.Values.Add("consumerExpenditureVariable", id);
        //        attr.ComsumerExpenditureId = int.Parse(id);
        //    }




        //    if (User.Identity.IsAuthenticated)
        //    {
        //        using (var context = ContextFactory.UserDataContext)
        //        {                
        //            var user = Membership.GetUser(User.Identity.Name);
        //            Guid userid = (Guid)user.ProviderUserKey;
        //            attr.UserId = userid;
        //            analyticsAttr.UserId = userid;

        //            var item = context.CompetitorAttributes.Where(i => i.UserId == userid && i.PlaceId == placeId && i.IndustryId == industryId).FirstOrDefault();
        //            if (item != null)
        //            {
        //                Func<string[], string[], bool> tester = (string[] a, string[] b) => (a.Length == b.Length && a.Intersect(b).Count() == a.Length);

        //                if (!tester(item.Competitors != null ? item.Competitors.Split(',') : "".Split(','), attr.Competitors != null ? attr.Competitors.Split(',') : "".Split(',')) ||
        //                    !tester(item.Suppliers != null ? item.Suppliers.Split(',') : "".Split(','), attr.Suppliers != null ? attr.Suppliers.Split(',') : "".Split(',')) ||
        //                    !tester(item.Buyers != null ? item.Buyers.Split(',') : "".Split(','), attr.Buyers != null ? attr.Buyers.Split(',') : "".Split(',')) ||
        //                    item.RootId != attr.RootId ||
        //                    item.ComsumerExpenditureId != attr.ComsumerExpenditureId)
        //                {
        //                    item.Competitors = attr.Competitors;
        //                    item.Buyers = attr.Buyers;
        //                    item.Suppliers = attr.Suppliers;
        //                    item.RootId = attr.RootId;
        //                    item.ComsumerExpenditureId = attr.ComsumerExpenditureId;
        //                    context.SaveChanges();
        //                }
        //            }
        //            else
        //            {
        //                context.CompetitorAttributes.AddObject(attr);
        //                context.SaveChanges();
                        
        //            }
        //        }
        //    }
        //    analyticsAttr.Competitors = attr.Competitors;
        //    analyticsAttr.Buyers = attr.Buyers;
        //    analyticsAttr.Suppliers = attr.Suppliers;
        //    analyticsAttr.RootId = attr.RootId;
        //    analyticsAttr.ComsumerExpenditureId = attr.ComsumerExpenditureId;
        //    Singleton<Tracker>.Instance.CompetitorAttribute(analyticsAttr);


        //    Response.Cookies.Add(cookie);
        //    return Json(true, JsonRequestBehavior.AllowGet);
        //}
    }
}
