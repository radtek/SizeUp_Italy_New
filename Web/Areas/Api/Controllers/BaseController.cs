﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Core.Web;
using System.Configuration;

namespace Web.Areas.Api.Controllers
{
    public class BaseController : Controller
    {
        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            base.Initialize(requestContext);
            //this tells IE NOT to cache requests becuase good ol microsoft knows best and goes against the grain
            //theres no WAY an ajax request could EVER return different data right?
            //suckit IE
            requestContext.HttpContext.Response.AddHeader("Expires", "-1");
        }
    }
}
