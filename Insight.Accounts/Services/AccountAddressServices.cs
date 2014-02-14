using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Insight.Core.Domain.Interfaces.Services;
using Insight.Accounts.Core.Domain;
using Insight.Accounts.Persistence.Repositories;

namespace Insight.Accounts.Services
{
    public class AccountAddressServices
    {
        public IOrderedEnumerable<AccountAddress> GetByAccountID(int accountID)
        {
            return new AccountAddressRepository().GetByAccountID(accountID).OrderBy(o => o.Title);
        }

        public AccountAddress GetByID(int id)
        {
            return new AccountAddressRepository().GetByID(id, false);
        }

        public IOrderedEnumerable<AccountAddress> GetPagedList(int startRow, int pageSize, out int count)
        {
            return new AccountAddressRepository().GetPagedList(startRow, pageSize, out count).OrderBy(o => o.Title);
        }

        public IOrderedEnumerable<AccountAddress> GetAll()
        {
            return new AccountAddressRepository().GetAll().OrderBy(o => o.Title);
        }

        public AccountAddress Save(AccountAddress account)
        {
            return new AccountAddressRepository().SaveOrUpdate(account);
        }

        public void Delete(AccountAddress account)
        {
            account.MarkedForDeletion = true;
            Save(account);
        }
    }
}