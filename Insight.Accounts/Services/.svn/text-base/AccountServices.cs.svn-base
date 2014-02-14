using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Insight.Core.Domain.Interfaces.Services;
using Insight.Accounts.Core.Domain;
using Insight.Accounts.Persistence.Repositories;
using System.ServiceModel;

namespace Insight.Accounts.Services
{
    public class AccountServices : IAccountServices<Account>
    {

        #region IAccountServices<Account> Members

        public Account GetByAccountName(string name)
        {
            return new AccountRepository().GetByName(name);
        }

        public Account GetByID(int id)
        {
            return new AccountRepository().GetByID(id, false);
        }

        public IOrderedEnumerable<Account> GetPagedList(int startRow, int pageSize, out int count)
        {
            return new AccountRepository().GetPagedList(startRow, pageSize, out count).OrderBy( o => o.Name);
        }

        public IOrderedEnumerable<Account> GetFilteredPagedList(int startRow, int pageSize, out int count)
        {
            int cnt = 0;
            count = cnt;
            return new AccountRepository().GetByFilters(startRow, pageSize, out cnt).OrderBy(o => o.Name);
        }

        public IOrderedEnumerable<Account> GetAll()
        {
            return new AccountRepository().GetAll().OrderBy(o => o.Name);
        }

        public IOrderedEnumerable<Account> GetByStatus(bool isActive)
        {
            return new AccountRepository().GetByStatus(isActive).OrderBy(o => o.Name);
        }

        public Account Save(Account account)
        {
            return new AccountRepository().SaveOrUpdate(account);
        }

        public void Delete(Account account)
        { 
            account.MarkedForDeletion = true;
            Save(account);
        }

        #endregion
    }
}