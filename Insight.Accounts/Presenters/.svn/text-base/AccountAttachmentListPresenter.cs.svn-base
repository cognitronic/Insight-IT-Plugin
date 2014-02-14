using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Insight.Presenters;
using Insight.Accounts.Presenters.ViewInterfaces;
using Insight.Core.Security;
using Insight.Core.Domain;
using Insight.Core.Domain.Interfaces;
using Insight.Accounts.Services;
using Insight.Accounts.Core.Domain;

namespace Insight.Accounts.Presenters
{
    public class AccountAttachmentListPresenter : Presenter
    {
        IAccountAttachmentListView _view;

        public AccountAttachmentListPresenter(IAccountAttachmentListView view, ISessionProvider session, ISecurityContext securityContext)
            : base(view, session, securityContext)
        {
            _view = base.GetView<IAccountAttachmentListView>();
            _view.OnItemSelected += new EventHandler<InsightLinkButtonArgs>(OnItemSelected);
            _view.OnGetItems += new EventHandler<InsightGridArg>(OnGetItems);
            _view.InitView += new EventHandler(_view_Init);
            _view.LoadView += new EventHandler(_view_Load);
            _view.OnItemsDataBound += new EventHandler<InsightGridItemEventArgs>(_view_OnItemsDataBound);
            _view.UnloadView += new EventHandler(_view_UnloadView);

            MessageBus<InsightToolBarButtonClickedArg>.MessageReceived += new EventHandler<InsightToolBarButtonClickedArg>(Presenter_MessageReceived);

            MessageBus<InsightGridArg>.MessageReceived += new EventHandler<InsightGridArg>(Presenter_MessageReceived);
            MessageBus<InsightFiltersViewArg>.MessageReceived += new EventHandler<InsightFiltersViewArg>(Presenter_MessageReceived);
        }

        void _view_OnItemsDataBound(object sender, InsightGridItemEventArgs e)
        {
            throw new NotImplementedException();
        }

        void Presenter_MessageReceived(object sender, InsightFiltersViewArg e)
        {
            throw new NotImplementedException();
        }

        void _view_UnloadView(object sender, EventArgs e)
        {
            MessageBus<InsightToolBarButtonClickedArg>.MessageReceived -= Presenter_MessageReceived;
            MessageBus<InsightGridArg>.MessageReceived -= Presenter_MessageReceived;
            MessageBus<InsightFiltersViewArg>.MessageReceived -= Presenter_MessageReceived;

            //update the current user's grid page size preference.
            if (SecurityContextManager.Current != null)
                SecurityContextManager.Current.CurrentUser.UserPreferences.GridPageSize = _view.PageSize;
        }

        void Presenter_MessageReceived(object sender, InsightGridArg e)
        {
            _view.PageSize = e.PageSize;
            GetItemResults(e);
        }

        void Presenter_MessageReceived(object sender, InsightToolBarButtonClickedArg e)
        {
            switch (e.CommandName)
            {
                case "New":
                    string url = SecurityContextManager.Current.CurrentURL + "/New";
                    _view.NavigateTo(url);
                    break;
                case "Print":
                    break;
                case "ExportPDF":
                    break;
                case "ExportExcel":
                    break;
                case "Email":
                    break;
                case "ListTypeList":
                    break;
                case "ListTypeDetails":
                    break;
            }
        }

        void _view_Load(object sender, EventArgs e)
        {
            _view.ViewTitle = ((IItem)SessionManager.Current[ResourceStrings.Session_CurrentItem]).Name;
            if (SecurityContextManager.Current.CurrentUser.UserPreferences.GridPageSize > 0)
                _view.PageSize = SecurityContextManager.Current.CurrentUser.UserPreferences.GridPageSize;
            else
                _view.PageSize = 5;
        }

        void _view_Init(object sender, EventArgs e)
        {
            _view.PageSize = SecurityContextManager.Current.CurrentUser.UserPreferences.GridPageSize;
        }

        void OnItemSelected(object o, InsightLinkButtonArgs e)
        {
            string url = SecurityContextManager.Current.BaseURL + "/Accounts/Name=" + e.ObjectName.Replace(" ", "-") + "/Attachment/ID=" + e.ObjectID.ToString();
            _view.NavigateTo(url);
        }

        void OnGetItems(object o, InsightGridArg e)
        {
            if (e.ListType == 0)
                e.ListType = GridListType.LIST;
            GetItemResults(e);
        }

        void GetItemResults(InsightGridArg e)
        {
            // if the current item type is account, then load only contacts associated with that account...otherwise load all contacts.
            if (!IsInsert<Account>())
            {
                _view.ResultSet = new AccountAttachmentServices().
                    GetByAccountID(GetCurrentItemReference<Account>().ID).
                    ToList<AccountAttachment>();
                _view.LoadResultSet(e);
            }
            else
            {
                int count = 0;
                _view.ResultSet = new AccountAttachmentServices().
                    GetPagedList(_view.CurrentPageIndex, _view.PageSize, out count).
                    ToList<AccountAttachment>();
                _view.VirtualItemCount = count;
                _view.LoadResultSet(e);
            }
        }
    }
}