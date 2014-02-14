using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Routing;
using Insight.Accounts.Core.Utils;

namespace Insight.Accounts.Web.Routing
{
    public class RouteBuilder
    {
        public RouteCollection Routes { get; private set; }
        public RouteBuilder(RouteCollection routes)
        {
            Routes = routes;
        }

        public void Run()
        {
            BuildEquipmentRoutes();
            BuildAccountRoutes();
            BuildProfileRoutes();
            BuildAttachmentRoutes();
        }

        #region Routing Methods

        public void BuildEquipmentRoutes()
        {
            Route equipmentPropRoute = new Route("Accounts/Name={accountname}/Equipment/ID={equipmentID}", new EquipmentRouteHandler("~/Accounts/EquipmentProperties.aspx"));
            equipmentPropRoute.Constraints = new RouteValueDictionary { { "accountname", @"^\D+" } };
            equipmentPropRoute.Constraints = new RouteValueDictionary { { "equipmentID", @"^\d+" } };
            Routes.Add(equipmentPropRoute);

            Route equipmentPropByAccountIDRoute = new Route("Accounts/ID={accountid}/Equipment/ID={equipmentID}", new EquipmentRouteHandler("~/Accounts/EquipmentProperties.aspx"));
            equipmentPropByAccountIDRoute.Constraints = new RouteValueDictionary { { "accountid", @"^\d+" } };
            equipmentPropByAccountIDRoute.Constraints = new RouteValueDictionary { { "equipmentID", @"^\d+" } };
            Routes.Add(equipmentPropByAccountIDRoute);

            var newEquipmentRoute = new Route("Accounts/Name={accountname}/Equipment/{new}", new EquipmentRouteHandler("~/Accounts/EquipmentProperties.aspx"));
            newEquipmentRoute.Constraints = new RouteValueDictionary { { "accountname", @"^\D+" } };
            newEquipmentRoute.Constraints = new RouteValueDictionary { { "new", @"(?i:^new)" } };
            Routes.Add(newEquipmentRoute);

            var accountEquipmentListRoute = new Route("Accounts/Name={accountname}/Equipment", new EquipmentRouteHandler("~/Accounts/AccountEquipmentList.aspx"));
            accountEquipmentListRoute.Constraints = new RouteValueDictionary { { "accountname", @"^\D+" } };
            Routes.Add(accountEquipmentListRoute);

            var accountEquipmentListByIDRoute = new Route("Accounts/ID={accountid}/Equipment", new EquipmentRouteHandler("~/Accounts/AccountEquipmentList.aspx"));
            accountEquipmentListByIDRoute.Constraints = new RouteValueDictionary { { "accountid", @"^\d+" } };
            Routes.Add(accountEquipmentListByIDRoute);


            Route equipmentList = new Route("Accounts/Equipment", new EquipmentRouteHandler(ResourceStrings.BASEURLPATH + "EquipmentList.aspx"));
            Routes.Add(equipmentList);

            Route equipmentDefault = new Route("Accounts/Equipment/{catchall}", new EquipmentRouteHandler(ResourceStrings.BASEURLPATH + "EquipmentList.aspx"));
            Routes.Add(equipmentDefault);
        }

        public void BuildAccountRoutes()
        {
            //PROPERTIES
            Route accountRoute = new Route("Accounts/Name={accountname}/Properties", new AccountRouteHandler("~/Accounts/AccountProperties.aspx"));
            accountRoute.Constraints = new RouteValueDictionary { { "accountname", @"^\D+" } };
            Routes.Add(accountRoute);

            var accountByIDRoute = new Route("Accounts/ID={accountid}/Properties", new AccountRouteHandler("~/Accounts/AccountProperties.aspx"));
            accountByIDRoute.Constraints = new RouteValueDictionary { { "accountid", @"^\d+" } };
            Routes.Add(accountByIDRoute);

            //NOTES
            Route accountNoteRoute = new Route("Accounts/Name={accountname}/Notes/ID={noteID}", new AccountNoteRouteHandler("~/Accounts/NoteProperties.aspx"));
            accountNoteRoute.Constraints = new RouteValueDictionary { { "accountname", @"^\D+" } };
            accountNoteRoute.Constraints = new RouteValueDictionary { { "noteID", @"^\d+" } };
            Routes.Add(accountNoteRoute);

            var accountNoteByIDRoute = new Route("Accounts/ID={accountid}/Notes/ID={NoteID}", new AccountNoteRouteHandler("~/Accounts/NoteProperties.aspx"));
            accountNoteByIDRoute.Constraints = new RouteValueDictionary { { "accountid", @"^\d+" } };
            accountNoteByIDRoute.Constraints = new RouteValueDictionary { { "noteID", @"^\d+" } };
            Routes.Add(accountNoteByIDRoute);

            var accountNoteDefaultRoute = new Route("Accounts/Name={accountname}/Notes/{new}", new AccountNoteRouteHandler("~/Accounts/NoteProperties.aspx"));
            accountNoteDefaultRoute.Constraints = new RouteValueDictionary { { "accountname", @"^\D+" } };
            accountNoteDefaultRoute.Constraints = new RouteValueDictionary { { "new", @"(?i:^new)" } };
            Routes.Add(accountNoteDefaultRoute);

            var accountNoteDefaultByIDRoute = new Route("Accounts/ID={accountid}/Notes/New", new AccountNoteRouteHandler("~/Accounts/NoteProperties.aspx"));
            accountNoteDefaultByIDRoute.Constraints = new RouteValueDictionary { { "accountid", @"^\d+" } };
            accountNoteDefaultByIDRoute.Constraints = new RouteValueDictionary { { "new", "new" } };
            Routes.Add(accountNoteDefaultByIDRoute);

            var accountNoteListRoute = new Route("Accounts/Name={accountname}/Notes", new AccountNoteRouteHandler("~/Accounts/NoteList.aspx"));
            accountNoteListRoute.Constraints = new RouteValueDictionary { { "accountname", @"^\D+" } };
            Routes.Add(accountNoteListRoute);

            var accountNoteIDListRoute = new Route("Accounts/ID={accountid}/Notes", new AccountNoteRouteHandler("~/Accounts/NoteList.aspx"));
            accountNoteIDListRoute.Constraints = new RouteValueDictionary { { "accountid", @"^\d+" } };
            Routes.Add(accountNoteIDListRoute);

            //ADDRESSES
            Route accountAddressRoute = new Route("Accounts/Name={accountname}/Addresses/ID={addressID}", new AccountAddressRouteHandler("~/Accounts/AddressProperties.aspx"));
            accountAddressRoute.Constraints = new RouteValueDictionary { { "accountname", @"^\D+" } };
            accountAddressRoute.Constraints = new RouteValueDictionary { { "addressID", @"^\d+" } };
            Routes.Add(accountAddressRoute);

            var accountAddressByIDRoute = new Route("Accounts/ID={accountid}/Addresses/ID={addressID}", new AccountAddressRouteHandler("~/Accounts/AddressProperties.aspx"));
            accountAddressByIDRoute.Constraints = new RouteValueDictionary { { "accountid", @"^\d+" } };
            accountAddressByIDRoute.Constraints = new RouteValueDictionary { { "addressID", @"^\d+" } };
            Routes.Add(accountAddressByIDRoute);

            var accountAddressDefaultRoute = new Route("Accounts/Name={accountname}/Addresses/{new}", new AccountAddressRouteHandler("~/Accounts/AddressProperties.aspx"));
            accountAddressDefaultRoute.Constraints = new RouteValueDictionary { { "accountname", @"^\D+" } };
            accountAddressDefaultRoute.Constraints = new RouteValueDictionary { { "new", @"(?i:^new)" } };
            Routes.Add(accountAddressDefaultRoute);

            var accountAddressDefaultByIDRoute = new Route("Accounts/ID={accountid}/Addresses/New", new AccountAddressRouteHandler("~/Accounts/AddressProperties.aspx"));
            accountAddressDefaultByIDRoute.Constraints = new RouteValueDictionary { { "accountid", @"^\d+" } };
            accountAddressDefaultByIDRoute.Constraints = new RouteValueDictionary { { "new", "new" } };
            Routes.Add(accountAddressDefaultByIDRoute);

            var accountAddressListRoute = new Route("Accounts/Name={accountname}/Addresses", new AccountAddressRouteHandler("~/Accounts/AddressList.aspx"));
            accountAddressListRoute.Constraints = new RouteValueDictionary { { "accountname", @"^\D+" } };
            Routes.Add(accountAddressListRoute);

            var accountAddressIDListRoute = new Route("Accounts/ID={accountid}/Addresses", new AccountAddressRouteHandler("~/Accounts/AddressList.aspx"));
            accountAddressIDListRoute.Constraints = new RouteValueDictionary { { "accountid", @"^\d+" } };
            Routes.Add(accountAddressIDListRoute);

            //CONTACTS LIST
            Route accountContactRoute = new Route("Accounts/Name={accountname}/Contacts/ID={contactID}", new AccountContactRouteHandler("~/Accounts/ContactProperties.aspx"));
            accountContactRoute.Constraints = new RouteValueDictionary { { "accountname", @"^\D+" } };
            accountContactRoute.Constraints = new RouteValueDictionary { { "contactID", @"^\d+" } };
            Routes.Add(accountContactRoute);

            Route accountContactByNameRoute = new Route("Accounts/Name={accountname}/Contacts/Name={contactName}", new AccountContactRouteHandler("~/Accounts/ContactProperties.aspx"));
            accountContactByNameRoute.Constraints = new RouteValueDictionary { { "accountname", @"^\D+" } };
            accountContactByNameRoute.Constraints = new RouteValueDictionary { { "contactName", @"^\D+" } };
            Routes.Add(accountContactByNameRoute);

            Route accountContactEmailRoute = new Route("Accounts/Name={accountname}/Contacts/ID={contactID}/Email/ID={emailid}", new ContactEmailRouteHandler("~/Accounts/ContactEmailProperties.aspx"));
            accountContactEmailRoute.Constraints = new RouteValueDictionary { { "accountname", @"^\D+" } };
            accountContactEmailRoute.Constraints = new RouteValueDictionary { { "contactID", @"^\d+" } };
            accountContactEmailRoute.Constraints = new RouteValueDictionary { { "emailid", @"^\d+" } };
            Routes.Add(accountContactEmailRoute);

            Route accountContactEmailListRoute = new Route("Accounts/Name={accountname}/Contacts/ID={contactID}/Email", new ContactEmailRouteHandler("~/Accounts/ContactEmailList.aspx"));
            accountContactEmailListRoute.Constraints = new RouteValueDictionary { { "accountname", @"^\D+" } };
            accountContactEmailListRoute.Constraints = new RouteValueDictionary { { "contactID", @"^\d+" } };
            Routes.Add(accountContactEmailListRoute);

            Route accountContactEmailListNewRoute = new Route("Accounts/Name={accountname}/Contacts/ID={contactID}/Email/{new}", new ContactEmailRouteHandler("~/Accounts/ContactEmailProperties.aspx"));
            accountContactEmailListNewRoute.Constraints = new RouteValueDictionary { { "accountname", @"^\D+" } };
            accountContactEmailListNewRoute.Constraints = new RouteValueDictionary { { "contactID", @"^\d+" } };
            accountContactEmailListNewRoute.Constraints = new RouteValueDictionary { { "new", @"(?i:^new)" } };
            Routes.Add(accountContactEmailListNewRoute);

            Route accountContactAddressRoute = new Route("Accounts/Name={accountname}/Contacts/ID={contactID}/Addresses/ID={addressID}", new AccountContactAddressRouteHandler("~/Accounts/ContactAddressProperties.aspx"));
            accountContactAddressRoute.Constraints = new RouteValueDictionary { { "accountname", @"^\D+" } };
            accountContactAddressRoute.Constraints = new RouteValueDictionary { { "contactID", @"^\d+" } };
            accountContactAddressRoute.Constraints = new RouteValueDictionary { { "addressID", @"^\d+" } };
            Routes.Add(accountContactAddressRoute);

            Route accountContactAddressNewRoute = new Route("Accounts/Name={accountname}/Contacts/ID={contactID}/Addresses/{new}", new AccountContactAddressRouteHandler("~/Accounts/ContactAddressProperties.aspx"));
            accountContactAddressNewRoute.Constraints = new RouteValueDictionary { { "accountname", @"^\D+" } };
            accountContactAddressNewRoute.Constraints = new RouteValueDictionary { { "contactID", @"^\d+" } };
            accountContactAddressNewRoute.Constraints = new RouteValueDictionary { { "new", @"(?i:^new)" } };
            Routes.Add(accountContactAddressNewRoute);

            Route accountContactAddressListRoute = new Route("Accounts/Name={accountname}/Contacts/ID={contactID}/Addresses", new AccountContactRouteHandler("~/Accounts/ContactAddressList.aspx"));
            accountContactAddressListRoute.Constraints = new RouteValueDictionary { { "accountname", @"^\D+" } };
            accountContactAddressListRoute.Constraints = new RouteValueDictionary { { "contactID", @"^\d+" } };
            Routes.Add(accountContactAddressListRoute);

            var accountContactByIDRoute = new Route("Accounts/ID={accountid}/Contacts/ID={contactID}", new AccountContactRouteHandler("~/Accounts/ContactProperties.aspx"));
            accountContactByIDRoute.Constraints = new RouteValueDictionary { { "accountid", @"^\d+" } };
            accountContactByIDRoute.Constraints = new RouteValueDictionary { { "contactID", @"^\d+" } };
            Routes.Add(accountContactByIDRoute);

            var accountContactByIDByNameRoute = new Route("Accounts/ID={accountid}/Contacts/Name={contactName}", new AccountContactRouteHandler("~/Accounts/ContactProperties.aspx"));
            accountContactByIDByNameRoute.Constraints = new RouteValueDictionary { { "accountid", @"^\d+" } };
            accountContactByIDByNameRoute.Constraints = new RouteValueDictionary { { "contactName", @"^\D+" } };
            Routes.Add(accountContactByIDByNameRoute);

            var accountContactDefaultRoute = new Route("Accounts/Name={accountname}/Contacts/{new}", new AccountContactRouteHandler("~/Accounts/ContactProperties.aspx"));
            accountContactDefaultRoute.Constraints = new RouteValueDictionary { { "accountname", @"^\D+" } };
            accountContactDefaultRoute.Constraints = new RouteValueDictionary { { "new", @"(?i:^new)" } };
            Routes.Add(accountContactDefaultRoute);

            var accountContactDefaultByIDRoute = new Route("Accounts/ID={accountid}/Contacts/New", new AccountContactRouteHandler("~/Accounts/AddressProperties.aspx"));
            accountContactDefaultByIDRoute.Constraints = new RouteValueDictionary { { "accountid", @"^\d+" } };
            accountContactDefaultByIDRoute.Constraints = new RouteValueDictionary { { "new", "new" } };
            Routes.Add(accountContactDefaultByIDRoute);

            var accountContactsRoute = new Route("Accounts/Name={accountname}/Contacts", new AccountContactRouteHandler("~/Accounts/AccountContactList.aspx"));
            accountContactsRoute.Constraints = new RouteValueDictionary { { "accountname", @"^\D+" } };
            Routes.Add(accountContactsRoute);

            var accountContactsByIDRoute = new Route("Accounts/ID={accountid}/Contacts", new AccountContactRouteHandler("~/Accounts/AccountContactList.aspx"));
            accountContactsByIDRoute.Constraints = new RouteValueDictionary { { "accountid", @"^\d+" } };
            Routes.Add(accountContactsByIDRoute);

            Route contactListRoute = new Route("Accounts/Contacts", new AccountContactRouteHandler("~/Accounts/ContactList.aspx"));
            Routes.Add(contactListRoute);

            //ACCOUNTS LIST
            Route accountListRoute = new Route("Accounts/List", new AccountRouteHandler("~/Accounts/AccountsList.aspx"));
            Routes.Add(accountListRoute);

            var accountNewRoute = new Route("Accounts/{new}", new AccountRouteHandler("~/Accounts/AccountProperties.aspx"));
            accountNewRoute.Constraints = new RouteValueDictionary { { "new", @"(?i:^new)" } };
            Routes.Add(accountNewRoute);

            //ACCOUNTS DASHBOARD
            Route accountDashboardRoute = new Route("Accounts/Dashboard/{*value}", new AccountRouteHandler("~/Accounts/Dashboard.aspx"));
            Routes.Add(accountDashboardRoute);
        }

        public void BuildProfileRoutes()
        {
            Route route = new Route("Accounts/ID={accountid}/Profile", new AccountProfileRouteHandler("~/Accounts/AccountProfile.aspx"));
            route.Constraints = new RouteValueDictionary { { "accountid", @"^\d+" } };
            Routes.Add(route);

            route = new Route("Accounts/Name={accountname}/Profile", new AccountProfileRouteHandler("~/Accounts/AccountProfile.aspx"));
            route.Constraints = new RouteValueDictionary { { "accountname", @"^\D+" } };
            Routes.Add(route);
        }

        public void BuildAttachmentRoutes()
        {
            Route route = new Route("Accounts/ID={accountid}/Attachments", new AccountProfileRouteHandler("~/Accounts/AccountAttachments.aspx"));
            route.Constraints = new RouteValueDictionary { { "accountid", @"^\d+" } };
            Routes.Add(route);

            route = new Route("Accounts/Name={accountname}/Attachments", new AccountProfileRouteHandler("~/Accounts/AccountAttachments.aspx"));
            route.Constraints = new RouteValueDictionary { { "accountname", @"^\D+" } };
            Routes.Add(route);

            route = new Route("Accounts/Name={accountname}/Attachments/ID={attachID}", new AccountProfileRouteHandler("~/Accounts/AccountAttachmentProperties.aspx"));
            route.Constraints = new RouteValueDictionary { { "accountname", @"^\D+" } };
            route.Constraints = new RouteValueDictionary { { "attachID", @"^\d+" } };
            Routes.Add(route);

            route = new Route("Accounts/ID={accountid}/Attachments/ID={attachID}", new AccountProfileRouteHandler("~/Accounts/AccountAttachmentProperties.aspx"));
            route.Constraints = new RouteValueDictionary { { "accountid", @"^\d+" } };
            route.Constraints = new RouteValueDictionary { { "attachID", @"^\d+" } };
            Routes.Add(route);

            route = new Route("Accounts/Name={accountname}/Attachments/{new}", new AccountProfileRouteHandler("~/Accounts/AccountAttachmentProperties.aspx"));
            route.Constraints = new RouteValueDictionary { { "accountname", @"^\D+" } };
            route.Constraints = new RouteValueDictionary { { "new", @"(?i:^new)" } };
            Routes.Add(route);
        }

        #endregion
    }
}
