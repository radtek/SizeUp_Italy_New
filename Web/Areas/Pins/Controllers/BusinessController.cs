﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Drawing;
namespace Web.Areas.Pins.Controllers
{
    public class BusinessController : Controller
    {
        //
        // GET: /Pins/Business/

        public ActionResult Marker(int index, string section)
        {
            Image template = Image.FromFile(Server.MapPath(string.Format("/content/images/marker{0}.png", section)));
            Core.Pins.Marker marker = new Core.Pins.Marker(index, template);
            var stream = new System.IO.MemoryStream();
            marker.Bitmap.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
            return File(stream.GetBuffer(), "image/png");
        }

        public ActionResult MarkerHighlight(int index, string section)
        {
            Image template = Image.FromFile(Server.MapPath(string.Format("/content/images/markerHighlight{0}.png", section)));
            Core.Pins.Marker marker = new Core.Pins.Marker(index, template);
            var stream = new System.IO.MemoryStream();
            marker.Bitmap.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
            return File(stream.GetBuffer(), "image/png");
        }

        public ActionResult MarkerShadow()
        {
            return File(Server.MapPath("/content/images/markerShadow.png"), "image/png");
        }

        public ActionResult Pin(string color)
        {
            Core.Pins.PushPin pin = new Core.Pins.PushPin(ColorTranslator.FromHtml("#" + color));
            var stream = new System.IO.MemoryStream();
            pin.Bitmap.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
            return File(stream.GetBuffer(), "image/png");
        }

        public ActionResult PinShadow()
        {
            return File(Server.MapPath("/content/images/pinShadow.png"), "image/png");
        }



    }
}
