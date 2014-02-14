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
    public class AccountContactAddressRouteHandler : IRouteHandler
    {
        public string VirtualPath { get; set; }

        public AccountContactAddressRouteHandler(string virtualPath)
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
            string contactID = HttpUtility.HtmlDecode((string)requestContext.RouteData.Values["contactID"]);
            string addressID = HttpUtility.HtmlDecode((string)requestContext.RouteData.Values["addressID"]);
            string isNew = HttpUtility.HtmlDecode((string)requestContext.RouteData.Values["new"]);

            if (!string.IsNullOrEmpty(contactID))
            {
                var contact = new ContactServices().GetByID(Convert.ToInt32(contactID));
                if (contact != null && contact.ID > 0)
                {
                    if (!string.IsNullOrEmpty(addressID))
                    {

                        var item = new Item();
                        item.Description = "";
                        item.URL = "/Accounts/Name=" + contact.ContactAccount.Name.Replace(" ", "-") + "/Contacts/ID=" + contact.ID.ToString() + "/Addresses/ID=" + addressID;
                        var address = (from a in contact.ContactAddress
                                       where a.ID.ToString().Equals(addressID)
                                       select a).First();
                        address.ContactReference = contact;
                        item.ItemReference = address;

                        item.Name = contact.FirstName + " " + contact.LastName + " - Address";
                        contact.Name = item.Name;
                        HttpPageHelper.CurrentItem = item;
                    }
                    else if (!string.IsNullOrEmpty(isNew))
                    {
                        var item = new Item();
                        item.Description = "";
                        item.URL = "/Accounts/Name=" + contact.ContactAccount.Name.Replace(" ", "-") + "/Contacts/ID=" + contact.ID.ToString() + "/Addresses/New";
                        item.ID = contact.ID;
                        item.ItemReference = item;
                        item.Name = contact.FirstName + " " + contact.LastName + " - New Address";
                        contact.Name = item.Name;
                        HttpPageHelper.CurrentItem = item;
                    }
                }
            }


            InsightBasePage page;

            page = (InsightBasePage)BuildManager.CreateInstanceFromVirtualPath(ResourceStrings.Page_DefaultVirtualPath, typeof(System.Web.UI.Page));

            HttpPageHelper.IsValidRequest = true;
            return page;
        }
    }
}