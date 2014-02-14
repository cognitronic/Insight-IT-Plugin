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

namespace Insight.Accounts.Web.Views
{
    [PresenterType(typeof(AccountNotePropertiesPresenter))]
    public partial class AccountNotePropertiesView : BaseWebUserControl, IAccountNotePropertiesView
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            base.SelfRegister(this);
            if (!IsPostBack)
            {
                if (this.OnLoad != null)
                {
                    this.OnLoad(this, EventArgs.Empty);
                }
            }
        }

        protected override void OnUnload(EventArgs e)
        {
            base.OnUnload(e);
            if (this.UnloadView != null)
            {
                this.UnloadView(this, EventArgs.Empty);
            }
        }

        #region INotePropertiesView Members

        public void LoadNote(AccountNote note)
        {
            if (note == null || note.ID == 0)
            {
                ddlAccount.SelectedValue = note.Description;
            }
            else
            {
                ddlAccount.SelectedValue = note.AccountID.ToString();
            }
            lblDateCreated.Text = note.DateCreated.ToString();
            lblID.Text = note.ID.ToString();
            lblLastUpdated.Text = note.LastUpdated.ToString();
            tbTitle.Text = note.Title;
            tbNote.Text = note.Body;
        }

        public void NavigateTo(string url)
        {
            HttpContext.Current.Response.Redirect(url);
        }

        public new event EventHandler OnLoad;
        public new event EventHandler UnloadView;

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

        #region IAccountAddress Members

        public int AccountID
        {
            get
            {
                int i = 0;
                if (int.TryParse(ddlAccount.SelectedValue, out i))
                    return i;
                return i;
            }
            set
            {
                int i = (int)value;
                if (i == 0)
                    ddlAccount.SelectedValue = "";
                else
                    ddlAccount.SelectedValue = i.ToString();
            }
        }

        public string Title
        {
            get
            {
                return tbTitle.Text;
            }
            set
            {
                tbTitle.Text = value;
            }
        }

        public string Body
        {
            get
            {
                return tbNote.Text;
            }
            set
            {
                tbNote.Text = value;
            }
        }

        public string URL
        {
            get;
            set;
        }
        #endregion

        #region IItem Members

        public new int ID
        {
            get
            {
                int i = 0;
                if (int.TryParse(lblID.Text, out i))
                    return i;
                return i;
            }
            set
            {
                int i = value;
                lblID.Text = i.ToString();
            }
        }

        public string Name
        {
            get;
            set;
        }

        public string Description
        {
            get;
            set;
        }

        public ItemType TypeOfItem
        {
            get { return ItemType.ACCOUNT; }
        }

        #endregion

        #region IAuditable Members

        public int EnteredBy
        {
            get;
            set;
        }

        public int ChangedBy
        {
            get;
            set;
        }

        public DateTime DateCreated
        {
            get
            {
                return DateTime.Parse(lblDateCreated.Text);
            }
            set
            {
                lblDateCreated.Text = value.ToString();
            }
        }

        public DateTime LastUpdated
        {
            get
            {
                return DateTime.Parse(lblLastUpdated.Text);
            }
            set
            {
                lblLastUpdated.Text = value.ToString();
            }
        }

        public bool MarkedForDeletion
        {
            get;
            set;
        }

        public object ItemReference
        {
            get;
            set;
        }

        #endregion
    }
}