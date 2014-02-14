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
    public class AccountsDDL : IdeaSeed.Web.UI.DropDownList
    {
        public AccountsDDL()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #region Properties
        public bool? ShowByStatus { get; set; }
        #endregion

        #region Events
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            LoadAccounts();
        }

        #endregion

        #region Methods
        public void LoadAccounts()
        {
            this.EmptyMessage = "-- Select Account --";
            this.Items.Add(new RadComboBoxItem("", ""));
            this.Skin = "Windows7";
            if (ShowByStatus != null)
            {
                foreach (var a in new AccountServices().GetByStatus((bool)ShowByStatus).OrderBy(a => a.Name))
                {
                    this.Items.Add(new RadComboBoxItem(a.Name, a.ID.ToString()));
                }
            }
            else
            {
                foreach (var a in new AccountServices().GetAll().OrderBy(a => a.Name))
                {
                    this.Items.Add(new RadComboBoxItem(a.Name, a.ID.ToString()));
                }
            }
        }

        #endregion
    }
}