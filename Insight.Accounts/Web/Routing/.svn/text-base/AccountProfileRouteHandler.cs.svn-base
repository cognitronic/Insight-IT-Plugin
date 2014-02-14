using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using Insight.Web.Bases;
using System.Configuration;
using System.Web.Compilation;
using System.Web.UI;
using System.Collections;
using Insight.Web.Utils;
using Insight.Services;
using Insight.Accounts.Services;
using Insight.Core.Domain;

namespace Insight.Accounts.Web.Routing
{
    public class AccountProfileRouteHandler : IRouteHandler
    {
        public string VirtualPath { get; set; }

        public AccountProfileRouteHandler(string virtualPath)
        {
            this.VirtualPath = virtualPath;
        }

        IHttpHandler IRouteHandler.GetHttpHandler(RequestContext requestContext)
        {
            HttpPageHelper.IsValidRequest = true;
            HttpPageHelper.CurrentItem = null;

            var p = new PageServices().GetPageByURL(VirtualPath);
            HttpPageHelper.CurrentPage = p;

            string accountName = HttpUtility.HtmlDecode((string)requestContext.RouteData.Values["accountname"]);
            string accountID = HttpUtility.HtmlDecode((string)requestContext.RouteData.Values["accountid"]);
            string isNew = HttpUtility.HtmlDecode((string)requestContext.RouteData.Values["new"]);
            if (!string.IsNullOrEmpty(accountID))
            {
                var account = new AccountServices().GetByID(Convert.ToInt16(accountID));
                account.Description = account.EmailDomain;
                var item = new Item();
                item.Description = account.EmailDomain;
                item.URL = "/Accounts/Name=" + account.Name.Replace(" ", "-");
                account.URL = "/Accounts/Name=" + account.Name.Replace(" ", "-");
                item.Name = account.Name + " - " + p.Title;
                item.ItemReference = account;
                HttpPageHelper.CurrentItem = item;
            }
            else if (!string.IsNullOrEmpty(accountName))
            {
                var a = new AccountServices().GetByAccountName(accountName.Replace("-", " "));
                a.Description = a.EmailDomain;
                var item = new Item();
                item.Description = a.ID.ToString();
                item.URL = "/Accounts/Name=" + a.Name.Replace(" ", "-");
                a.URL = "/Accounts/Name=" + a.Name.Replace(" ", "-");
                item.Name = a.Name + " - " + p.Title;
                item.ItemReference = a;
                HttpPageHelper.CurrentItem = item;
            }
            else if (!string.IsNullOrEmpty(isNew))
            {
                var item = new Item();
                item.Description = p.Name;
                item.URL = "/Accounts/New";
                item.Name = p.Title;
                item.ItemReference = item;
                HttpPageHelper.CurrentItem = item;
            }
            else
            {
                var item = new Item();
                item.Description = p.Name;
                item.URL = "/Accounts";
                item.Name = p.Title;
                item.ItemReference = item;
                HttpPageHelper.CurrentItem = item;
            }



            InsightBasePage page;

            page = (InsightBasePage)BuildManager.CreateInstanceFromVirtualPath(ResourceStrings.Page_DefaultVirtualPath, typeof(System.Web.UI.Page));

            HttpPageHelper.IsValidRequest = true;
            return page;
        }
    }
}