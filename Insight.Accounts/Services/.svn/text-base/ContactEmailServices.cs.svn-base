using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Insight.Core.Domain.Interfaces.Services;
using Insight.Accounts.Core.Domain;
using Insight.Accounts.Persistence.Repositories;

namespace Insight.Accounts.Services
{
    public class ContactEmailServices
    {
        public ContactEmail GetByID(int id)
        {
            return new ContactEmailRepository().GetByID(id, false);
        }

        public IOrderedEnumerable<ContactEmail> GetPagedList(int startRow, int pageSize, out int count)
        {
            return new ContactEmailRepository().GetPagedList(startRow, pageSize, out count).OrderBy(o => o.Email);
        }

        public IOrderedEnumerable<ContactEmail> GetAll()
        {
            return new ContactEmailRepository().GetAll().OrderBy(o => o.Email);
        }

        public ContactEmail Save(ContactEmail account)
        {
            return new ContactEmailRepository().SaveOrUpdate(account);
        }

        public void Delete(ContactEmail account)
        {
            account.MarkedForDeletion = true;
            Save(account);
        }
    }
}