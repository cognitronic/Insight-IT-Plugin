using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Insight.Presenters;
using Insight.Accounts.Presenters.ViewInterfaces;
using Insight.Core.Security;
using Insight.Core.Domain;
using Insight.Core.Domain.Interfaces;
using Insight.Accounts.Core.Domain;
using Insight.Accounts.Services;

namespace Insight.Accounts.Presenters
{
    public class EquipmentPropertiesPresenter: Presenter
    {
        IEquipmentPropertiesView _view;

        public EquipmentPropertiesPresenter(IEquipmentPropertiesView view, ISessionProvider session, ISecurityContext securityContext)
            : base(view, session, securityContext)
        {
            _view = base.GetView<IEquipmentPropertiesView>();
            MessageBus<InsightToolBarButtonClickedArg>.MessageReceived += new EventHandler<InsightToolBarButtonClickedArg>(Presenter_MessageReceived);
            _view.LoadView += new EventHandler(_view_LoadView);
            _view.UnloadView += new EventHandler(_view_UnloadView);
        }

        void _view_UnloadView(object sender, EventArgs e)
        {
            MessageBus<InsightToolBarButtonClickedArg>.MessageReceived -= Presenter_MessageReceived;
        }

        void _view_LoadView(object sender, EventArgs e)
        {
            _view.ViewTitle = ((IItem)SessionManager.Current[ResourceStrings.Session_CurrentItem]).Name;
            if (!IsInsert<Equipment>())
            {
                _view.LoadItem(GetCurrentItemReference<Equipment>());
            }
            else
            {
                _view.AccountID = GetCurrentItemReference<Account>().ID;
            }
        }

        void Presenter_MessageReceived(object sender, InsightToolBarButtonClickedArg e)
        {
            switch (e.CommandName)
            {
                case "Save":
                    SaveItem();
                    break;
                case "SaveReturn":
                    SaveItem();
                    NavigateBack();
                    break;
                case "Undo":
                    //Undo is going to clear out all changes to the account object and attempt to reset it to the Current Item's values.  If it's a new object then it will just reset the entered data to default values.
                    if (!IsInsert<Contact>())
                    {
                        _view.LoadItem(GetCurrentItemReference<Equipment>());
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

        void SaveItem()
        {
            var item = new Equipment();
            bool isInsert = false;
            string url = "";
            if (!IsInsert<Equipment>())
            {
                item = GetCurrentItemReference<Equipment>();
            }
            else
            {
                item.DateCreated = DateTime.Now;
                item.EnteredBy = _view.EnteredBy;
                isInsert = true;
                url = SecurityContextManager.Current.CurrentURL.Replace("New", "ID=");
            }
            item.ChangedBy = SecurityContextManager.Current.CurrentUser.ID;
            item.AccountID = _view.AccountID;
            item.Description = _view.Description;
            item.LastUpdated = DateTime.Now;
            item.MarkedForDeletion = _view.MarkedForDeletion;
            item.Name = _view.Name;
            item.EquipmentTypeID = _view.EquipmentTypeID;
            item.IPAddress = _view.IPAddress;
            item.KeyFunctions = _view.KeyFunctions;
            item.Model = _view.Model;
            item.OperatingSystemID = _view.OperatingSystemID;
            item.OtherInfo = _view.OtherInfo;
            item.Password = _view.Password;
            item.PhysicalLocationDescription = _view.PhysicalLocationDescription;
            item.PurchaseDate = (DateTime?)_view.PurchaseDate;
            item.SupportExpirationDate = (DateTime?)_view.SupportExpirationDate;
            item.Username = _view.Username;
            item.WarrantyExpirationDate = (DateTime?)_view.WarrantyExpirationDate;
            item.WarrantyNotes = _view.WarrantyNotes;
            new EquipmentServices().Save(item);
            if (isInsert)
                _view.NavigateTo(url + item.ID.ToString());
            else
                _view.LoadItem(item);

        }

        void ClearControls()
        {
            _view.EquipmentTypeID = 0;
            _view.IPAddress = "";
            _view.Description = "";
            _view.KeyFunctions = "";
            _view.Model = "";
            _view.AccountID = 0;
            _view.ItemReference = null;
            _view.OperatingSystemID = 0;
            _view.OtherInfo = "";
            _view.MarkedForDeletion = false;
            _view.Message = "";
            _view.Name = "";
            _view.Password = "";
            _view.PhysicalLocationDescription = "";
            _view.PurchaseDate = null;
            _view.SupportExpirationDate = null;
            _view.WarrantyExpirationDate = null;
            _view.Username = "";
            _view.WarrantyNotes = "";
        }

        void NavigateBack()
        {
            _view.NavigateTo(SecurityContextManager.Current.PreviousURL);
        }
    }
}