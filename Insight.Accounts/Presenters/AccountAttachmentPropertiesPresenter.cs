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
    public class AccountAttachmentPropertiesPresenter: Presenter
    {
        IAccountAttachmentPropertiesView _view;

        public AccountAttachmentPropertiesPresenter(IAccountAttachmentPropertiesView view, ISessionProvider session, ISecurityContext securityContext)
            : base(view, session, securityContext)
        {
            _view = base.GetView<IAccountAttachmentPropertiesView>();
            MessageBus<InsightToolBarButtonClickedArg>.MessageReceived += new EventHandler<InsightToolBarButtonClickedArg>(Presenter_MessageReceived);
            _view.LoadView += new EventHandler(_view_OnLoad);
            _view.UnloadView += new EventHandler(_view_UnloadView);
        }

        void _view_UnloadView(object sender, EventArgs e)
        {
            MessageBus<InsightToolBarButtonClickedArg>.MessageReceived -= Presenter_MessageReceived;
        }

        void _view_OnLoad(object sender, EventArgs e)
        {
            _view.ViewTitle = ((IItem)SessionManager.Current[ResourceStrings.Session_CurrentItem]).Name;
            LoadAttachment();
        }

        void Presenter_MessageReceived(object sender, InsightToolBarButtonClickedArg e)
        {
            switch (e.CommandName)
            {
                case "New":
                    string url = SecurityContextManager.Current.CurrentURL + "/New";
                    _view.NavigateTo(url);
                    break;
                case "Save":
                    SaveAttachment();
                    break;
                case "SaveReturn":
                    SaveAttachment();
                    NavigateBack();
                    break;
                case "Undo":
                    //Undo is going to clear out all changes to the account object and attempt to reset it to the Current Item's values.  If it's a new object then it will just reset the entered data to default values.
                    if (!IsInsert<AccountAddress>())
                    {
                        _view.LoadAttachment(GetCurrentItemReference<AccountAttachment>());
                    }
                    else
                    {
                        ClearControls();
                    }
                    break;
                case "ExportPDF":
                    
                    break;
                case "ExportExcel":
                    
                    break;
                case "Cancel":
                    NavigateBack();
                    break;
            }
        }

        void SaveAttachment()
        {
            var attach = new AccountAttachment();
            bool isInsert = false;
            string url = "";
            if (!IsInsert<AccountAttachment>())
            {
                attach = GetCurrentItemReference<AccountAttachment>();
            }
            else
            {
                attach.DateCreated = DateTime.Now;
                attach.EnteredBy = SecurityContextManager.Current.CurrentUser.ID;
                isInsert = true;
                url = SecurityContextManager.Current.CurrentURL.Replace("New", "ID=");
            }
            attach.ChangedBy = SecurityContextManager.Current.CurrentUser.ID;
            attach.Description = _view.Description;
            attach.LastUpdated = DateTime.Now;
            attach.MarkedForDeletion = _view.MarkedForDeletion;
            attach.Name = _view.Name;
            attach.AccountID = _view.AccountID;
            attach.FileName = _view.FileName;
            attach.FullPath = _view.FullPath;
            attach.Title = _view.Title;
            new AccountAttachmentServices().Save(attach);
            if (isInsert)
                _view.NavigateTo(url + attach.ID.ToString());
            else
                _view.LoadAttachment(attach);
        }

        void LoadAttachment()
        {
            if (!IsInsert<AccountAttachment>())
            {
                _view.LoadAttachment(GetCurrentItemReference<AccountAttachment>());
            }
            else
            {
                _view.AccountID = Convert.ToInt32(((IItem)SessionManager.Current[ResourceStrings.Session_CurrentItem]).Description);
            }
        }

        void ClearControls()
        {
            _view.AccountID = 0;
            _view.FullPath = "";
            _view.FileName = "";
            _view.Title= "";
            _view.Description = "";
        }

        void NavigateBack()
        {
            _view.NavigateTo(SecurityContextManager.Current.PreviousURL);
        }
    }
}