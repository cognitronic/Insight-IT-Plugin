using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Insight.Core.Domain.Interfaces.Services;
using Insight.Accounts.Core.Domain;
using Insight.Accounts.Persistence.Repositories;

namespace Insight.Accounts.Services
{
    public class ContactAddressServices
    {
        public ContactAddress GetByID(int id)
        {
            return new ContactAddressRepository().GetByID(id, false);
        }

        public IOrderedEnumerable<ContactAddress> GetPagedList(int startRow, int pageSize, out int count)
        {
            return new ContactAddressRepository().GetPagedList(startRow, pageSize, out count).OrderBy(o => o.Title);
        }

        public IOrderedEnumerable<ContactAddress> GetAll()
        {
            return new ContactAddressRepository().GetAll().OrderBy(o => o.Title);
        }

        public ContactAddress Save(ContactAddress account)
        {
            return new ContactAddressRepository().SaveOrUpdate(account);
        }

        public void Delete(ContactAddress account)
        {
            account.MarkedForDeletion = true;
            Save(account);
        }
    }
}