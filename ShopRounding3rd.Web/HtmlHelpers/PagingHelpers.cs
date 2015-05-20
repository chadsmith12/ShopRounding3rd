using System;
using System.Text;
using System.Web.Mvc;
using ShopRounding3rd.Web.Models;

namespace ShopRounding3rd.Web.HtmlHelpers
{
    public static class PagingHelpers
    {
        /// <summary>
        /// HTML Helper Extension
        /// Creates pagination links
        /// Example Usage: Html.PageLinks(Model.PagingInfo, x => Url.Action("List", new {page = x}))
        /// </summary>
        /// <param name="html"></param>
        /// <param name="pagingInfo"></param>
        /// <param name="pageUrl"></param>
        /// <returns></returns>
        public static MvcHtmlString PageLinks(this HtmlHelper html, PagingInfo pagingInfo, Func<int, string> pageUrl)
        {
            StringBuilder result = new StringBuilder();

            // for the number of pages that their will be
            for (int i = 1; i <= pagingInfo.TotalPages; i++)
            {
                // create a new anchor tag for each page
                TagBuilder tag = new TagBuilder("a");

                // set the href to the current page that we are on
                tag.MergeAttribute("href", pageUrl(i));
                // print out the current page we are on
                tag.InnerHtml = i.ToString();

                // add special css to the current page we are on
                if (i == pagingInfo.CurrentPage)
                {
                    tag.AddCssClass("selected");
                    tag.AddCssClass("btn-primary");
                }
                tag.AddCssClass("btn btn-default");
                result.Append(tag.ToString());
            }
            // return the anchor tags that were created
            return MvcHtmlString.Create(result.ToString());
        }
    }
}
