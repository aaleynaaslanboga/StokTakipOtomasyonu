﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StokTakipOtomasyonu.ActiveFolder
{
    public static class ActiveClass
    {
        public static string ActivePage (this HtmlHelper html, string control, string action) 
        {
            string active = "";
            var routeData = html.ViewContext.RouteData;
            string routeControl = (string) routeData.Values["controller"];
            string routeAction = (string) routeData.Values["action"]; // go to home controller to check which actionresult 

            if(control == routeControl && action == routeAction)
            {
                active = "active";
            }
            return active;
        }
    }
}