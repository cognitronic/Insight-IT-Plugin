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
    [PresenterType(typeof(EquipmentPropertiesPresenter))]
    public partial class EquipmentPropertiesView : BaseWebUserControl, IEquipmentPropertiesView
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            base.SelfRegister(this);
            if (this.LoadView != null)
            {
                this.LoadView(this, EventArgs.Empty);
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

        public new event EventHandler LoadView;
        public new event EventHandler UnloadView;

        #region IBasePropertiesView<Equipment> Members

        public void LoadItem(Equipment t)
        {
            tbIPAddress.Text = t.IPAddress;
            tbKeyFunctions.Text = t.KeyFunctions;
            tbModel.Text = t.Model;
            tbName.Text = t.Name;
            tbOtherInfo.Text = t.OtherInfo;
            tbPassword.Text = t.Password;
            tbPhysicalLocation.Text = t.PhysicalLocationDescription;
            tbPurchaseDate.SelectedDate = t.PurchaseDate;
            tbSupportExpirationDate.SelectedDate = t.SupportExpirationDate;
            tbUsername.Text = t.Username;
            tbWarrantyExpirationDate.SelectedDate = t.WarrantyExpirationDate;
            tbWarrantyNote.Text = t.WarrantyNotes;
            lblDateCreated.Text = t.DateCreated.ToString();
            lblID.Text = t.ID.ToString();
            lblLastUpdated.Text = t.LastUpdated.ToString();
            ddlAccount.SelectedValue = t.AccountID.ToString();
            ddlEquipmentType.SelectedValue = t.EquipmentTypeID.ToString();
        }

        public void NavigateTo(string url)
        {
            HttpContext.Current.Response.Redirect(url);
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

        #region IEquipment Members

        public string IPAddress
        {
            get
            {
                return tbIPAddress.Text;
            }
            set
            {
                tbIPAddress.Text = value;
            }
        }

        public string Username
        {
            get
            {
                return tbUsername.Text;
            }
            set
            {
                tbUsername.Text = value;
            }
        }

        public string Password
        {
            get
            {
                return tbPassword.Text;
            }
            set
            {
                tbPassword.Text = value;
            }
        }

        public string Model
        {
            get
            {
                return tbModel.Text;
            }
            set
            {
                tbModel.Text = value;
            }
        }

        public string KeyFunctions
        {
            get
            {
                return tbKeyFunctions.Text;
            }
            set
            {
                tbKeyFunctions.Text = value;
            }
        }

        public DateTime? PurchaseDate
        {
            get
            {
                if (tbPurchaseDate.SelectedDate != null)
                    return tbPurchaseDate.SelectedDate;
                else
                    return null;
            }
            set
            {
                tbPurchaseDate.SelectedDate = value;
            }
        }

        public DateTime? SupportExpirationDate
        {
            get
            {
                return tbSupportExpirationDate.SelectedDate;
            }
            set
            {
                tbSupportExpirationDate.SelectedDate = value;
            }
        }

        public DateTime? WarrantyExpirationDate
        {
            get
            {
                return tbWarrantyExpirationDate.SelectedDate;
            }
            set
            {
                tbWarrantyExpirationDate.SelectedDate = value;
            }
        }

        public string WarrantyNotes
        {
            get
            {
                return tbWarrantyNote.Text;
            }
            set
            {
                tbWarrantyNote.Text = value;
            }
        }

        public string PhysicalLocationDescription
        {
            get
            {
                return tbPhysicalLocation.Text;
            }
            set
            {
                tbPhysicalLocation.Text = value;
            }
        }

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

        public Core.Interfaces.IAccount Account
        {
            get;
            set;
        }

        public string OtherInfo
        {
            get
            {
                return tbOtherInfo.Text;
            }
            set
            {
                tbOtherInfo.Text = value;
            }
        }

        public int OperatingSystemID
        {
            get;
            set;
        }

        #endregion

        #region IBaseEquipment Members

        public int EquipmentTypeID
        {
            get
            {
                int i = 0;
                if (int.TryParse(ddlEquipmentType.SelectedValue, out i))
                    return i;
                return i;
            }
            set
            {
                int i = (int)value;
                if (i == 0)
                    ddlEquipmentType.SelectedValue = "";
                else
                    ddlEquipmentType.SelectedValue = i.ToString();
            }
        }

        public string SerializedProperties
        {
            get;
            set;
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

        #endregion

        #region IItem Members

        public string Description
        {
            get;
            set;
        }

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

        public object ItemReference
        {
            get;
            set;
        }

        public string Name
        {
            get
            {
                return tbName.Text;
            }
            set
            {
                tbName.Text = value;
            }
        }

        public ItemType TypeOfItem
        {
            get
            {
                return ItemType.EQUIPMENT;
            }
        }

        public string URL
        {
            get;
            set;
        }

        #endregion
    }
}