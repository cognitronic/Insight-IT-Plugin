using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Insight.Presenters;
using Insight.Accounts.Presenters;
using Telerik.Web.UI;
using Insight.Accounts.Core.Domain;
using Insight.Accounts.Presenters.ViewInterfaces;
using Insight.Web.Bases;


namespace Insight.Accounts.Web.Views
{
     [PresenterType(typeof(EquipmentListPresenter))]
    public partial class EquipmentListView : BaseWebUserControl, IEquipmentListView
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            base.SelfRegister(this);
            if (!IsPostBack)
            {
                if (this.LoadView != null)
                {
                    this.LoadView(this, EventArgs.Empty);
                }
                if (this.OnGetItems != null)
                {
                    var args = new InsightGridArg();
                    args.BindData = true;
                    args.ListType = GridListType.LIST;
                    this.OnGetItems(this, args);
                }
            }
        }

        protected void ToggleGridSelectedState(object o, EventArgs e)
        {

        }

        protected override void OnUnload(EventArgs e)
        {
            base.OnUnload(e);
            if (this.UnloadView != null)
            {
                this.UnloadView(this, EventArgs.Empty);
            }
        }

        protected void NeedDataSource(object o, GridNeedDataSourceEventArgs e)
        {
            var args = new InsightGridArg();
            args.BindData = false;
            if (this.OnGetItems != null)
            {
                this.OnGetItems(this, args);
            }
            //LoadAccounts(false);
        }

        protected void DetailsNeedDataSource(object o, RadListViewNeedDataSourceEventArgs e)
        {
            var args = new InsightGridArg();
            args.BindData = false;
            if (this.OnGetItems != null)
            {
                this.OnGetItems(this, args);
            }
        }

        protected void ItemCommand(object o, GridCommandEventArgs e)
        {

        }

        protected void ItemDataBound(object o, GridItemEventArgs e)
        {

        }

        protected void DetailsItemDataBound(object o, RadListViewItemEventArgs e)
        {

        }

        protected void ViewItemClicked(object o, EventArgs e)
        {
            var lb = o as IdeaSeed.Web.UI.LinkButton;
            var args = new InsightLinkButtonArgs();
            args.ObjectID = Convert.ToInt32(lb.Attributes["itemid"]);
            args.ObjectName = lb.Attributes["itemname"];
            if (OnItemSelected != null)
            {
                OnItemSelected(this, args);
            }
        }

        #region IBaseListView<IEquipment> Members

        public new event EventHandler InitView;
        public new event EventHandler LoadView;
        public new event EventHandler UnloadView;

        public string ViewTitle
        {
            get
            {
                return lblListTitle.Text;
            }
            set
            {
                lblListTitle.Text = value;
            }
        }

        public int CurrentPageIndex
        {
            get
            {
                return rgList.CurrentPageIndex;
            }
            set
            {
                rgList.CurrentPageIndex = value;
            }
        }

        public GridListType ListType
        {
            get;
            set;
        }

        public void LoadResultSet(InsightGridArg args)
        {
            if (args.ListType == GridListType.LIST)
            {
                rgList.Visible = true;
                dlDetails.Visible = false;
                dlDetails.DataSource = null;
                rgList.DataSource = null;
                rgList.PageSize = this.PageSize;
                //rgAccounts.VirtualItemCount = this.VirtualItemCount;
                rgList.DataSource = ResultSet;
                if (args.BindData)
                {
                    rgList.DataBind();
                }
                //divListView.Visible = true;
                //divDetailView.Visible = false;
            }
            else
            {
                rgList.Visible = false;
                dlDetails.Visible = true;
                dlDetails.DataSource = null;
                rgList.DataSource = null;
                dlDetails.PageSize = this.PageSize;
                dlDetails.DataSource = ResultSet;
                dlDetails.DataBind();
                //divListView.Visible = false;
                //divDetailView.Visible = true;
            }
        }

        public void NavigateTo(string url)
        {
            HttpContext.Current.Response.Redirect(url);
        }

        public event EventHandler<InsightGridArg> OnGetItems;

        public event EventHandler<InsightLinkButtonArgs> OnItemSelected;

        public event EventHandler<InsightGridItemEventArgs> OnItemsDataBound;

        public int PageSize
        {
            get
            {
                return rgList.PageSize;
            }
            set
            {
                rgList.PageSize = value;
            }
        }

        public void RebindGrid()
        {
            rgList.PageSize = this.PageSize;
            rgList.Rebind();
        }

        public IList<Equipment> ResultSet
        {
            get;
            set;
        }

        public int VirtualItemCount
        {
            get
            {
                return rgList.VirtualItemCount;
            }
            set
            {
                rgList.VirtualItemCount = value;
            }
        }

        #endregion
    }
}