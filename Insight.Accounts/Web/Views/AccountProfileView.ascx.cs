using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using Insight.Presenters;
using Insight.Presenters.ViewInterfaces;
using Insight.Accounts.Presenters;
using Insight.Accounts.Presenters.ViewInterfaces;
using IdeaSeed.Web.UI;
using Insight.Web.Bases;
using Insight.Accounts.Core.Domain;
using Insight.Core.Domain;
using Insight.Accounts.Web.Controls;

namespace Insight.Accounts.Web.Views
{
    [PresenterType(typeof(AccountProfilePresenter))]
    public partial class AccountProfileView : BaseWebUserControl, IAccountProfileView
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            base.SelfRegister(this);
            if (this.LoadView != null)
            {
                this.LoadView(this, EventArgs.Empty);
            }
        }

        #region IAccountProfileView Members
        public new event EventHandler LoadView;
        public void LoadAccount(Account account)
        {
            
        }

        public void NavigateTo(string url)
        {
            Response.Redirect(url);
        }

        public string ViewTitle
        {
            get
            {
                return lblPropertiesTitle.Text;
            }
            set
            {
                lblPropertiesTitle.Text = value;
            }
        }

        #endregion
    }
}