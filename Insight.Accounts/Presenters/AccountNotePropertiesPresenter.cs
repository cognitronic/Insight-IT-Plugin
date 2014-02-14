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
    public class AccountNotePropertiesPresenter : Presenter
    {
        IAccountNotePropertiesView _view;

        public AccountNotePropertiesPresenter(IAccountNotePropertiesView view, ISessionProvider session, ISecurityContext securityContext)
            : base(view, session, securityContext)
        {
            _view = base.GetView<IAccountNotePropertiesView>();
            MessageBus<InsightToolBarButtonClickedArg>.MessageReceived += new EventHandler<InsightToolBarButtonClickedArg>(Presenter_MessageReceived);
            _view.OnLoad += new EventHandler(_view_OnLoad);
            _view.UnloadView += new EventHandler(_view_UnloadView);
        }

        void _view_UnloadView(object sender, EventArgs e)
        {
            MessageBus<InsightToolBarButtonClickedArg>.MessageReceived -= Presenter_MessageReceived;
        }

        void _view_OnLoad(object sender, EventArgs e)
        {
            _view.ViewTitle = ((IItem)SessionManager.Current[ResourceStrings.Session_CurrentItem]).Name;
            LoadNote();
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
                    SaveNote();
                    break;
                case "SaveReturn":
                    SaveNote();
                    NavigateBack();
                    break;
                case "Undo":
                    //Undo is going to clear out all changes to the account object and attempt to reset it to the Current Item's values.  If it's a new object then it will just reset the entered data to default values.
                    if (!IsInsert<AccountAddress>())
                    {
                        _view.LoadNote(GetCurrentItemReference<AccountNote>());
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

        void SaveNote()
        {
            var note = new AccountNote();
            bool isInsert = false;
            string url = "";
            if (!IsInsert<AccountNote>())
            {
                note = GetCurrentItemReference<AccountNote>();
            }
            else
            {
                note.DateCreated = DateTime.Now;
                note.EnteredBy = SecurityContextManager.Current.CurrentUser.ID;
                isInsert = true;
                url = SecurityContextManager.Current.CurrentURL.Replace("New", "ID=");
            }
            note.ChangedBy = SecurityContextManager.Current.CurrentUser.ID;
            note.Body = _view.Body;
            note.LastUpdated = DateTime.Now;
            note.MarkedForDeletion = _view.MarkedForDeletion;
            note.AccountID = _view.AccountID;
            note.Title = _view.Title;
            new AccountNoteServices().Save(note);
            if (isInsert)
                _view.NavigateTo(url + note.ID.ToString());
            else
                _view.LoadNote(note);
        }

        void LoadNote()
        {
            if (!IsInsert<AccountNote>())
            {
                _view.LoadNote(GetCurrentItemReference<AccountNote>());
            }
            else
            {
                _view.AccountID = Convert.ToInt32(((IItem)SessionManager.Current[ResourceStrings.Session_CurrentItem]).Description);
            }
        }

        void ClearControls()
        {
            _view.AccountID = 0;
            _view.Title = "";
            _view.Body = "";
        }

        void NavigateBack()
        {
            _view.NavigateTo(SecurityContextManager.Current.PreviousURL);
        }
    }
}