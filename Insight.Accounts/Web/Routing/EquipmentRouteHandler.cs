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
using Insight.Core.Domain;
using Insight.Accounts.Services;

namespace Insight.Accounts.Web.Routing
{
    public class EquipmentRouteHandler : IRouteHandler
    {
        public string VirtualPath { get; set; }

        public EquipmentRouteHandler(string virtualPath)
        {
            this.VirtualPath = virtualPath;
        }

        #region IRouteHandler Members

        IHttpHandler IRouteHandler.GetHttpHandler(RequestContext requestContext)
        {
            string accountName = HttpUtility.HtmlDecode((string)requestContext.RouteData.Values["accountname"]);
            string accountID = HttpUtility.HtmlDecode((string)requestContext.RouteData.Values["accountid"]);
            string equipmentID = HttpUtility.HtmlDecode((string)requestContext.RouteData.Values["equipmentID"]);
            string isNew = HttpUtility.HtmlDecode((string)requestContext.RouteData.Values["new"]);

            HttpPageHelper.IsValidRequest = true;
            HttpPageHelper.CurrentItem = null;
            var p = new PageServices().GetPageByURL(VirtualPath);
            HttpPageHelper.CurrentPage = p;

            if (!string.IsNullOrEmpty(equipmentID))
            {
                var equipment = new EquipmentServices().GetByID(Convert.ToInt32(equipmentID));
                if (equipment != null && equipment.ID > 0)
                {

                    var item = new Item();
                    item.Description = "";
                    item.URL = "/Accounts/Name=" + equipment.Account.Name.Replace(" ", "-") + "/Equipment/ID=" + equipment.ID.ToString();
                    item.Name = equipment.Name + " - " + equipment.Account.Name;
                    equipment.Name = item.Name;
                    item.ItemReference = equipment;
                    HttpPageHelper.CurrentItem = item;
                }
            }
            else if (!string.IsNullOrEmpty(accountName))
            {
                var a = new AccountServices().GetByAccountName(accountName.Replace("-", " "));
                if (!string.IsNullOrEmpty(isNew))
                {
                    var item = new Item();
                    item.Description = "Accounts/Name=" + a.Name.Replace(" ", "-") + "/Equipment/New";
                    item.URL = "Accounts/Name=" + a.Name.Replace(" ", "-") + "/Equipment/New";
                    item.Name = a.Name + " - New Equipment";
                    item.ID = a.ID;
                    item.ItemReference = item;
                    HttpPageHelper.CurrentItem = item;
                }
                else
                {
                    a.Description = a.EmailDomain;
                    var item = new Item();
                    item.Description = a.EmailDomain;
                    item.URL = "/Accounts/Name=" + a.Name.Replace(" ", "-");
                    a.URL = "/Accounts/Name=" + a.Name.Replace(" ", "-");
                    item.Name = a.Name + " - " + p.Title;
                    item.ItemReference = a;
                    HttpPageHelper.CurrentItem = item;
                }
            }
            else if (!string.IsNullOrEmpty(accountID))
            {
                var a = new AccountServices().GetByID(Convert.ToInt32(accountID));
                if (!string.IsNullOrEmpty(isNew))
                {
                    var item = new Item();
                    item.Description = "Accounts/Name=" + a.Name.Replace(" ", "-") + "/Equipment/New";
                    item.URL = "Accounts/Name=" + a.Name.Replace(" ", "-") + "/Equipment/New";
                    item.Name = a.Name + " - New Equipment";
                    item.ID = a.ID;
                    item.ItemReference = item;
                    HttpPageHelper.CurrentItem = item;
                }
                else
                {
                    a.Description = a.EmailDomain;
                    var item = new Item();
                    item.Description = a.EmailDomain;
                    item.URL = "/Accounts/Name=" + a.Name.Replace(" ", "-");
                    a.URL = "/Accounts/Name=" + a.Name.Replace(" ", "-");
                    item.Name = a.Name + " - " + p.Title;
                    item.ItemReference = a;
                    HttpPageHelper.CurrentItem = item;
                }
            }
            else
            {
                var item = new Item();
                item.Description = p.Name;
                item.Name = p.Title;
                item.ItemReference = item;
                item.URL = "/Accounts";
                HttpPageHelper.CurrentItem = item;
            }

            InsightBasePage page;
            page = (InsightBasePage)BuildManager.CreateInstanceFromVirtualPath(ResourceStrings.Page_DefaultVirtualPath, typeof(System.Web.UI.Page));
            HttpPageHelper.IsValidRequest = true;
            return page;
        }

        #endregion
    }
}
