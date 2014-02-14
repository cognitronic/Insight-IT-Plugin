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
            HttpPageHelper.IsValidRequest = true;
            HttpPageHelper.CurrentItem = null;
            var p = new PageServices().GetPageByURL(VirtualPath);
            HttpPageHelper.CurrentPage = p;

            var item = new Item();
            item.Description = p.Name;
            item.Name = p.Title;
            item.ItemReference = item;
            HttpPageHelper.CurrentItem = item;

            InsightBasePage page;
            page = (InsightBasePage)BuildManager.CreateInstanceFromVirtualPath(VirtualPath, typeof(System.Web.UI.Page));
            HttpPageHelper.IsValidRequest = true;
            return page;
        }

        #endregion
    }
}
