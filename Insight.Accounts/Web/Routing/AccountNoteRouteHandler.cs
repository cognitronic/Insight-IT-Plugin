using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using Insight.Web.Utils;
using System.Web.Compilation;
using Insight.Services;
using Insight.Core.Domain;
using Insight.Accounts.Core.Domain;
using Insight.Web.Bases;
using Insight.Accounts.Services;

namespace Insight.Accounts.Web.Routing
{
    public class AccountNoteRouteHandler : IRouteHandler
    {
        public string VirtualPath { get; set; }

        public AccountNoteRouteHandler(string virtualPath)
        {
            this.VirtualPath = virtualPath;
        }

        #region IRouteHandler Members

        public IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
            HttpPageHelper.IsValidRequest = true;
            HttpPageHelper.CurrentItem = null;

            var p = new PageServices().GetPageByURL(VirtualPath);
            HttpPageHelper.CurrentPage = p;

            string accountName = HttpUtility.HtmlDecode((string)requestContext.RouteData.Values["accountName"]);
            string isnew = HttpUtility.HtmlDecode((string)requestContext.RouteData.Values["new"]);
            string accountID = HttpUtility.HtmlDecode((string)requestContext.RouteData.Values["accountID"]);
            string noteID = HttpUtility.HtmlDecode((string)requestContext.RouteData.Values["noteID"]);

            if (string.IsNullOrEmpty(isnew))
            {
                if (!string.IsNullOrEmpty(noteID)) //We're looking at an address properties
                {
                    if (!string.IsNullOrEmpty(accountID) || !string.IsNullOrEmpty(accountName))
                    {
                        var note = new AccountNoteServices().GetByID(Convert.ToInt32(noteID));
                        var item = new Item();
                        item.Description = note.Description;
                        item.Name = accountName + " " + p.Title;
                        note.Name = accountName;
                        item.ItemReference = note;
                        HttpPageHelper.CurrentItem = item;
                    }
                }
                else //this is the address list page
                {
                    if (!string.IsNullOrEmpty(accountName))
                    {
                        var account = new AccountServices().GetByAccountName(accountName.Replace("-", " "));
                        var item = new Item();
                        item.Name = account.Name + " Note List";
                        item.URL = "/Accounts/Name=" + account.Name.Replace(" ", "-");
                        account.URL = "/Accounts/Name=" + account.Name.Replace(" ", "-");
                        item.ItemReference = account;
                        HttpPageHelper.CurrentItem = item;
                    }
                    if (!string.IsNullOrEmpty(accountID))
                    {
                        var account = new AccountServices().GetByID(Convert.ToInt32(accountID));
                        var item = new Item();
                        item.Name = account.Name + " Note List";
                        item.URL = "/Accounts/Name=" + account.Name.Replace(" ", "-");
                        account.URL = "/Accounts/Name=" + account.Name.Replace(" ", "-");
                        item.ItemReference = account;
                        HttpPageHelper.CurrentItem = item;
                    }
                }
            }
            else
            {
                var note = new AccountNote();
                if (!string.IsNullOrEmpty(accountName))
                {
                    var account = new AccountServices().GetByAccountName(accountName.Replace("-", " "));
                    var item = new Item();
                    item.Description = account.ID.ToString();
                    item.Name = account.Name + " " + p.Title;
                    //address.Name = account.Name;
                    //address.AccountID = account.ID;
                    item.URL = "/Accounts/Name=" + account.Name.Replace(" ", "-");
                    item.ItemReference = item;
                    HttpPageHelper.CurrentItem = item;
                }
                else if (!string.IsNullOrEmpty(accountID))
                {
                    var account = new AccountServices().GetByID(Convert.ToInt16(accountID));
                    var item = new Item();
                    item.Description = "New Note";
                    item.Name = account.Name + " " + p.Title;
                    note.Name = account.Name;
                    item.URL = "/Accounts/Name=" + account.Name.Replace(" ", "-");
                    note.URL = "/Accounts/Name=" + account.Name.Replace(" ", "-");
                    note.AccountID = account.ID;
                    item.ItemReference = note;
                    HttpPageHelper.CurrentItem = item;
                }
            }





            InsightBasePage page;

            page = (InsightBasePage)BuildManager.CreateInstanceFromVirtualPath(ResourceStrings.Page_DefaultVirtualPath, typeof(System.Web.UI.Page));

            HttpPageHelper.IsValidRequest = true;
            return page;
        }

        #endregion
    }
}