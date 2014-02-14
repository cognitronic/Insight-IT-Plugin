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
    public class EquipmentTypesDDL : IdeaSeed.Web.UI.DropDownList
    {
        public EquipmentTypesDDL()
        {
            this.EmptyMessage = "-- Select Type --";
            this.Items.Add(new RadComboBoxItem("", ""));
            this.Skin = "Windows7";
            foreach (var item in new EquipmentServices().GetEquipmentTypes())
            {
                this.Items.Add(new RadComboBoxItem(item.Name, item.ID.ToString()));
            }
        }
    }
}