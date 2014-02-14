using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Routing;

namespace Insight.Accounts.Web.Routing
{
    public class AccountsHTTPModule : IHttpModule
    {
        #region IHttpModule Members

        public void Dispose()
        {
            
        }

        public void Init(HttpApplication context)
        {
            context.BeginRequest += new EventHandler(context_BeginRequest);
        }

        void context_BeginRequest(object sender, EventArgs e)
        {
            if (HttpContext.Current.Request.Url.AbsolutePath.IndexOf('.') < 0)
            {
                RouteBuilder builder = new RouteBuilder(RouteTable.Routes);
                builder.Run();
            }
        }

        #endregion
    }
}
