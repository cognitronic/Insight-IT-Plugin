using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IdeaSeed.Web.UI;
using Insight.Accounts.Core.Domain;
using Insight.Accounts.Services;
using Telerik.Web.UI;

namespace Insight.Accounts.Web.Controls
{
    public class ServiceLevelAgreementsDDL : IdeaSeed.Web.UI.DropDownList
    {
        public ServiceLevelAgreementsDDL()
        {
            this.Items.Clear();
            this.EmptyMessage = "-- Select Agreement --";
            this.Items.Add(new RadComboBoxItem("", ""));
            this.Skin = "Windows7";
            foreach (var i in new ServiceLevelAgreementServices().GetAll())
            {
                this.Items.Add(new RadComboBoxItem(i.Name, i.ID.ToString()));
            }
        }
    }
}