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
    public class ContactEmailRouteHandler : IRouteHandler
    {
        public string VirtualPath { get; set; }

        public ContactEmailRouteHandler(string virtualPath)
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
            string emailID = HttpUtility.HtmlDecode((string)requestContext.RouteData.Values["emailID"]);
            string isnew = HttpUtility.HtmlDecode((string)requestContext.RouteData.Values["new"]);
            if (!string.IsNullOrEmpty(contactID))
            {

                var contact = new ContactServices().GetByID(Convert.ToInt32(contactID));
                var contactEmail = new ContactEmail();
                if (contact != null && contact.ID > 0)
                {
                    if (!string.IsNullOrEmpty(emailID))
                    {
                        foreach (var email in contact.ContactEmail)
                        {
                            if (email.ID.ToString().Equals(emailID))
                            {
                                contactEmail = (ContactEmail)email;
                            }
                        }
                        var item = new Item();
                        item.Description = "Accounts/Name=" + contact.ContactAccount.Name.Replace(" ", "-") + "/Contacts/ID=" + contact.ID.ToString();
                        item.URL = "/Accounts/Name=" + contact.ContactAccount.Name.Replace(" ", "-") + "/Contacts/ID=" + contact.ID.ToString() + "/Email/ID=" + emailID;
                        item.Name = contact.FirstName + " " + contact.LastName + " - " + contact.ContactAccount.Name + " Email Account";
                        item.ItemReference = contactEmail;
                        HttpPageHelper.CurrentItem = item;
                    }
                    else if (!string.IsNullOrEmpty(isnew))
                    {
                        var item = new Item();
                        item.Description = "Accounts/Name=" + contact.ContactAccount.Name.Replace(" ", "-") + "/Contacts/ID=" + contact.ID.ToString();
                        item.URL = "/Accounts/Name=" + contact.ContactAccount.Name.Replace(" ", "-") + "/Contacts/ID=" + contact.ID.ToString() + "/Email/New";
                        item.Name = contact.FirstName + " " + contact.LastName + " - New Email Address";
                        item.ID = contact.ID;
                        item.ItemReference = item;
                        HttpPageHelper.CurrentItem = item;
                    }
                    else // Email List
                    {
                        var item = new Item();
                        item.Description = "Accounts/Name=" + contact.ContactAccount.Name.Replace(" ", "-") + "/Contacts/ID=" + contact.ID.ToString();
                        item.URL = "/Accounts/Name=" + contact.ContactAccount.Name.Replace(" ", "-") + "/Contacts/ID=" + contact.ID.ToString();
                        item.Name = contact.FirstName + " " + contact.LastName + " - " + contact.ContactAccount.Name + " Email List";
                        item.ItemReference = contact;
                        HttpPageHelper.CurrentItem = item;
                    }
                }
            }
            else
            {
                var item = new Item();
                item.Description = p.Name;
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