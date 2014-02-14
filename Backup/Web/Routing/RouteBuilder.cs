using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Routing;

namespace Insight.Accounts.Web.Routing
{
    public class RouteBuilder
    {
        public RouteCollection Routes { get; private set; }
        public RouteBuilder(RouteCollection routes)
        {
            Routes = routes;
        }

        public void Run()
        {
            BuildEquipmentRoutes();
        }

        #region Equipment Routes

        public void BuildEquipmentRoutes()
        {
            Route equipmentList = new Route("Accounts/Equipment", new EquipmentRouteHandler("~/Accounts/EquipmentList.aspx"));
            Routes.Add(equipmentList);

            Route equipmentDefault = new Route("Accounts/Equipment/{catchall}", new EquipmentRouteHandler("~/Accounts/EquipmentList.aspx"));
            Routes.Add(equipmentDefault);
        }
        #endregion
    }
}
