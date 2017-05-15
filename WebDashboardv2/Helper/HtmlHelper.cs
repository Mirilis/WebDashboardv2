using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace WebDashboardv2
{
    [HtmlTargetElement("li", Attributes = IsSelectedTagHelperAttributeName)]
    public class IsSelectedTagHelper : TagHelper
    {

        private const string IsSelectedTagHelperAttributeName = "isSelected";
        private const string IsSelectedTagHelperController = "controller";
        private const string IsSelectedTagHelperAction = "action";
        private const string IsSelectedTagHelperCss = "cssClass";

        [HtmlAttributeName(IsSelectedTagHelperController)]
        public string IsSelectedController { get; set; }

      
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            throw new NotImplementedException();
        }
    }

    public static class HtmlHelpers
    {

        public static string IsSelected(this IHtmlHelper html, string controller = null, string action = null, string id = null, string cssClass = null)
        {
            if (String.IsNullOrEmpty(cssClass))
                cssClass = "active";

            string currentId = (string)html.ViewContext.RouteData.Values["id"];
            string currentAction = (string)html.ViewContext.RouteData.Values["action"];
            string currentController = (string)html.ViewContext.RouteData.Values["controller"];

            if (String.IsNullOrEmpty(controller))
                controller = currentController;

            if (String.IsNullOrEmpty(action))
                action = currentAction;

            return controller == currentController && action == currentAction ?
                cssClass : String.Empty;
        }

        public static string PageClass(this IHtmlHelper htmlHelper)
        {
            string currentAction = (string)htmlHelper.ViewContext.RouteData.Values["action"];
            return currentAction;
        }

    }
}
