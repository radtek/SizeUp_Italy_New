﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data;
using System.Web;
using Core.Identity;
using Core.DataLayer.Models;

namespace Core.Web
{
    public class WebContext
    {
        private Core.DataLayer.Models.Place _currentPlace = null;
        private Core.DataLayer.Models.Industry _currentIndustry = null;
        private Feature? _startFeature = null;
        private string _currentBusinessStatus = null;

        public static WebContext Current
        {
            get
            {
                var context = HttpContext.Current.Items["Sizeup.Core.Web.WebContext"] as WebContext;
                if (context == null)
                {
                    context = new WebContext();
                    HttpContext.Current.Items["Sizeup.Core.Web.WebContext"] = context;
                }
                return context;
            }
        }

        private string GetCurrentBusinessStatus()
        {
            var businessStatus = (string)HttpContext.Current.Request.RequestContext.RouteData.Values["businessStatus"];
            var cookie = HttpContext.Current.Request.Cookies["businessStatus"];
            string output = null;

            if (!string.IsNullOrEmpty(businessStatus))
            {
                output = businessStatus;
            }
            else if (cookie != null)
            {
                output = cookie.Value;
            }
            return output;
        }

        private Feature? GetStartFeature()
        {
            var cookie = HttpContext.Current.Request.Cookies["startFeature"];
            Feature? output = null;
            if (cookie != null)
            {
                Feature f;
                if (Enum.TryParse<Feature>(cookie.Value, out f))
                {
                    output = f;
                }
            }
            return output;
        }

        private Core.DataLayer.Models.Industry GetCurrentIndustry()
        {
            var industry = (string)HttpContext.Current.Request.RequestContext.RouteData.Values["industry"];
            var cookie = HttpContext.Current.Request.Cookies["industry"];
            Core.DataLayer.Models.Industry output = null;
            using (var context = ContextFactory.SizeUpContext)
            {
                if (!string.IsNullOrEmpty(industry))
                {
                    output = Core.DataLayer.Industry.Get(context, industry);
                }
                else if (cookie != null)
                {
                    long id;
                    if (long.TryParse(cookie.Value, out id))
                    {
                        output = Core.DataLayer.Industry.Get(context, id);
                    }
                }
            }
            return output;
        }


        private Core.DataLayer.Models.Place GetCurrentPlace()
        {
            var city = (string)HttpContext.Current.Request.RequestContext.RouteData.Values["city"];
            var county = (string)HttpContext.Current.Request.RequestContext.RouteData.Values["county"];
            var state = (string)HttpContext.Current.Request.RequestContext.RouteData.Values["state"];
            //var metro = (string)HttpContext.Current.Request.RequestContext.RouteData.Values["metro"];
            var cookie = HttpContext.Current.Request.Cookies["city"];
            Core.DataLayer.Models.Place output = null;
            using (var context = ContextFactory.SizeUpContext)
            {
                if (!string.IsNullOrEmpty(state) || !string.IsNullOrEmpty(county) || !string.IsNullOrEmpty(city))
                {
                    output = Core.DataLayer.Place.Get(context, state, county, city);
                }
                else if (cookie != null)
                {
                    long id;
                    if (long.TryParse(cookie.Value, out id))
                    {
                        output = Core.DataLayer.Place.Get(context, id);
                    }
                }
            }
            return output == null ? new DataLayer.Models.Place() : output;
        }

        private void SetCurrentBusinessStatus(string businessStatus)
        {
            HttpCookie cookie = CookieFactory.Create("businessStatus");
            if (string.IsNullOrEmpty(businessStatus))
            {
                cookie.Expires = DateTime.Now.AddDays(-1.0);
            }
            else
            {
                cookie.Value = businessStatus;
                cookie.Expires = DateTime.Now.AddDays(7.0);
            }
            HttpContext.Current.Response.Cookies.Add(cookie);
        }

        private void SetCurrentPlace(Core.DataLayer.Models.Place CurrentPlace)
        {
            HttpCookie cookie = CookieFactory.Create("city");
            if (CurrentPlace == null || CurrentPlace.Id == null)
            {
                cookie.Expires = DateTime.Now.AddDays(-1.0);
            }
            else
            {
                cookie.Value = CurrentPlace.Id.ToString();
                cookie.Expires = DateTime.Now.AddDays(7.0);
            }
            HttpContext.Current.Response.Cookies.Add(cookie);
        }

        private void SetCurrentIndustry(Core.DataLayer.Models.Industry CurrentIndustry)
        {
            HttpCookie cookie = CookieFactory.Create("industry");
            if (CurrentIndustry == null)
            {
                cookie.Expires = DateTime.Now.AddDays(-1.0);
            }
            else
            {
                cookie.Value = CurrentIndustry.Id.ToString();
                cookie.Expires = DateTime.Now.AddDays(7.0);
            }
            HttpContext.Current.Response.Cookies.Add(cookie);
        }

        private void SetStartFeature(Core.Web.Feature? feature)
        {
            HttpCookie cookie = CookieFactory.Create("startFeature");
            if (feature == null)
            {
                HttpContext.Current.Request.Cookies.Remove("startFeature");
                cookie.Expires = DateTime.Now.AddDays(-1.0);
            }
            else
            {
                cookie.Value = Enum.GetName(typeof(Feature), feature);
                cookie.Expires = DateTime.Now.AddDays(7.0);
            }
            HttpContext.Current.Response.Cookies.Add(cookie);
        }

        public string CurrentBusinessStatus
        {
            get
            {
                if (_currentBusinessStatus == null)
                {
                    _currentBusinessStatus = GetCurrentBusinessStatus();
                    if (_currentBusinessStatus != null)
                    {
                        //SetCurrentBusinessStatus(_currentBusinessStatus);
                    }
                }
                return _currentBusinessStatus;
            }
            set
            {
                _currentBusinessStatus = value;
                SetCurrentBusinessStatus(value);
            }
        }

        public Feature? StartFeature
        {
            get
            {
                if (_startFeature == null)
                {
                    _startFeature = GetStartFeature();
                    if (_startFeature != null)
                    {
                        SetStartFeature(_startFeature.Value);
                    }
                }
                return _startFeature;
            }
            set
            {
                _startFeature = value;
                SetStartFeature(value);
            }
        }

        public Core.DataLayer.Models.Place CurrentPlace
        {
            get
            {
                if (_currentPlace == null)
                {
                    _currentPlace = GetCurrentPlace();
                    if (_currentPlace.Id != null)
                    {
                        SetCurrentPlace(_currentPlace);
                    }
                }
                return _currentPlace;
            }
            set
            {
                _currentPlace = value;
                SetCurrentPlace(value);
            }
        }

        public Core.DataLayer.Models.Industry CurrentIndustry
        {
            get
            {
                if (_currentIndustry == null)
                {
                    _currentIndustry = GetCurrentIndustry();
                    if (_currentIndustry != null)
                    {
                        SetCurrentIndustry(_currentIndustry);
                    }
                }
                return _currentIndustry;
            }
            set
            {
                _currentIndustry = value;
                SetCurrentIndustry(value);
            }
        }


        public string Domain
        {
            get
            {
                var host = HttpContext.Current.Request.Url.Host;
                return host.StartsWith("www.", StringComparison.CurrentCultureIgnoreCase) ? host.Replace("www.", "") : host;
            }
        }

        public string ClientIP
        {
            get
            {
                string ipList = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                if (!string.IsNullOrEmpty(ipList))
                {
                    return ipList.Split(',')[0];
                }
                return HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            }
        }
    }
}
