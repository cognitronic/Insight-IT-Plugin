using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IdeaSeed.Web.UI;
using Insight.Accounts.Core.Domain;
using Insight.Accounts.Services;
using Telerik.Web.UI;
using Insight.Core.Domain;

namespace Insight.Accounts.Web.Controls
{
    public class AccountTypesDDL : IdeaSeed.Web.UI.DropDownList
    {
        public AccountTypesDDL()
        {
            this.Items.Clear();
            this.EmptyMessage = "-- Select Type --";
            this.Items.Add(new RadComboBoxItem("", ""));
            this.Skin = "Windows7";
            this.Items.Add(new RadComboBoxItem("Account", ((int)ItemType.ACCOUNT).ToString()));
            this.Items.Add(new RadComboBoxItem("Vendor", ((int)ItemType.VENDOR).ToString()));
            this.Items.Add(new RadComboBoxItem("Lead", ((int)ItemType.LEAD).ToString()));
        }
    }
}