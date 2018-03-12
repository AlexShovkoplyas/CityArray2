using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;

namespace CityArrayWeb.Components
{
    public static class HtmlExtensionsTableHead
    {
        public static MvcHtmlString TableHeadRowSortable(this HtmlHelper @this, Type type, 
            string controller, string action, 
            string oldSortFilter, string searchFilter, object htmlAttributes = null)
        {
            var rowTag = new TagBuilder("tr");

            var fields = type.GetProperties().Where(p=>p.Name!="Id");

            var sortField = oldSortFilter.Split(' ')[0];
            var sortOrder = oldSortFilter.Split(' ')[1];
            string newSortFilter;

            foreach (var field in fields)
            {
                var dispAtt = field.GetCustomAttribute(typeof(DisplayAttribute)) as DisplayAttribute;
                var dispText = dispAtt?.Name ?? field.Name;

                var cellTag = new TagBuilder("th");

                var aTag = new TagBuilder("a");

                if (sortField != field.Name)
                {
                    newSortFilter = field.Name + " " + "ascending";
                }
                else
                {
                    if (sortOrder == "ascending")
                    {
                        newSortFilter = field.Name + " " + "descending";
                    }
                    else
                    {
                        newSortFilter = field.Name + " " + "ascending";
                    }
                }

                UrlHelper urlHelper = new UrlHelper(@this.ViewContext.RequestContext);
                var aUrl = urlHelper.Action(action, controller, new { sortFilter = newSortFilter, searchFilter = searchFilter });

                aTag.MergeAttribute("href", aUrl);
                aTag.SetInnerText(dispText);
                cellTag.InnerHtml = aTag.ToString();

                rowTag.InnerHtml += cellTag.ToString();
            }

            return MvcHtmlString.Create(rowTag.ToString());
        }


        public static MvcHtmlString TableHeadRowSortable<T>(this HtmlHelper @this, T source, 
            string controller, string action, 
            string oldSortFilter, string searchFilter, object htmlAttributes = null)
        {
            return TableHeadRowSortable(@this, source.GetType(), controller, action, oldSortFilter, searchFilter, htmlAttributes);

        }
    }
}