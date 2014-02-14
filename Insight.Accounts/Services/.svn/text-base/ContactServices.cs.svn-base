using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Insight.Core.Domain.Interfaces.Services;
using Insight.Accounts.Core.Domain;
using Insight.Accounts.Persistence.Repositories;

namespace Insight.Accounts.Services
{
    public class ContactServices : IContactServices<Contact>
    {
        #region IContactServices<Contact> Members

        public void Delete(Contact item)
        {
            item.MarkedForDeletion = true;
            Save(item);
        }

        public IOrderedEnumerable<Contact> GetAll()
        {
            return new ContactRepository().GetAll().OrderBy(o => o.LastName);
        }

        public IOrderedEnumerable<Contact> GetByAccountID(int accountID)
        {
            return new ContactRepository().GetByAccountID(accountID).OrderBy(o => o.LastName);
        }

        public Contact GetByID(int id)
        {
            return new ContactRepository().GetByID(id, false);
        }

        public IOrderedEnumerable<Contact> GetPagedList(int startRow, int pageSize, out int count)
        {
            return new ContactRepository().GetPagedList(startRow, pageSize, out count).OrderBy(o => o.LastName);
        }

        public Contact Save(Contact item)
        {
            return new ContactRepository().SaveOrUpdate(item);
        }

        #endregion
    }
}