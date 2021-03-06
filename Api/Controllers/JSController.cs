﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Core.API;
using System.Security.Cryptography;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Data;

namespace Api.Controllers
{
    public class JSController : Controller
    {
        //
        // GET: /JS/

        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            base.Initialize(requestContext);
            requestContext.HttpContext.Response.AddHeader("Expires", "-1");
            Response.ContentType = "text/javascript";
            APISession.Create();
        }

        public ActionResult Index(Guid apikey, string wt = "")
        {
            APIToken token = null;
            APIToken widgetToken = null;
            if (!string.IsNullOrWhiteSpace(wt))
            {
                widgetToken = APIToken.ParseToken(wt);
            }
            using (var context = ContextFactory.APIContext)
            {
                var k = context.APIKeys.Where(i => i.KeyValue == apikey && i.IsActive).FirstOrDefault();
                if (k == null)
                {
                    throw new HttpException(403, "Invalid API Key");
                }
                token = APIToken.Create(k.Id);
            }
            ViewBag.Token = token.GetToken();
            ViewBag.SessionId = APISession.Current.SessionId;
            ViewBag.InstanceId = RandomString.Get(25);
            ViewBag.WidgetToken = widgetToken != null ? widgetToken.GetToken() : "";
            return View();
        }

        public ActionResult Data()
        {
            if (APIContext.Current.ApiToken.IsValid && !APIContext.Current.ApiToken.IsExpired)
            {
                ViewBag.Permissions = APIContext.Current.APIPermissions;
            }
            else
            {
                throw new HttpException(403, "Invalid API Key");
            }
            return View();
        }

        public ActionResult Range()
        {
            return View();
        }

        public ActionResult Granularity()
        {
            if (APIContext.Current.ApiToken.IsValid && !APIContext.Current.ApiToken.IsExpired)
            {
                ViewBag.Permissions = APIContext.Current.APIPermissions;
            }
            else
            {
                throw new HttpException(403, "Invalid API Key");
            }
            return View();
        }

        public ActionResult Overlay()
        {
            return View();
        }

        public ActionResult Attributes()
        {
            return View();
        }

        public ActionResult OverlayAttributes()
        {
            if (APIContext.Current.ApiToken.IsValid && !APIContext.Current.ApiToken.IsExpired)
            {
                ViewBag.Permissions = APIContext.Current.APIPermissions;
            }
            else
            {
                throw new HttpException(403, "Invalid API Key");
            }
            return View();
        }

    }
}
