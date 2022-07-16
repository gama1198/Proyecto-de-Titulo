using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Tesismvc.Helpers
{
    public static class Helper
    {

        public static MvcHtmlString ActionLinkAllow(this HtmlHelper helper, string Url, string Text, int Rol)
        {
            string html = "";
          

            if (Rol == 1)
            {

                html = "<a href=" + Url + " " + Text + "</a>";

            }
            else
            {

            }
            return new MvcHtmlString(html);

        }

    }
}