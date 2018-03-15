using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace CityArrayWeb.Components
{
    public static class ActionExtension
    {
  
        public static MvcHtmlString Action2(this HtmlHelper htmlHelper, string actionMethodName, object routeValues)
        {
            var parts = actionMethodName.Split('.');
            var controllerName = parts[parts.Count() - 2].Replace("Controller","");
            return htmlHelper.Action(actionMethodName, controllerName, routeValues);
        }

        public static MvcHtmlString Action2(this HtmlHelper htmlHelper, string actionMethodName)
        {
            var parts = actionMethodName.Split('.');
            var controllerName = parts[parts.Count() - 2].Replace("Controller", "");
            return htmlHelper.Action(actionMethodName, controllerName);
        }
    }
}