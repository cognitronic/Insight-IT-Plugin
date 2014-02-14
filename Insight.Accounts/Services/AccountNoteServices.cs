using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Insight.Core.Domain.Interfaces.Services;
using Insight.Accounts.Core.Domain;
using Insight.Accounts.Persistence.Repositories;

namespace Insight.Accounts.Services
{
    public class AccountNoteServices
    {
        public IOrderedEnumerable<AccountNote> GetByAccountID(int accountID)
        {
            return new AccountNoteRepository().GetByAccountID(accountID).OrderBy(o => o.Title);
        }

        public AccountNote GetByID(int id)
        {
            return new AccountNoteRepository().GetByID(id, false);
        }

        public IOrderedEnumerable<AccountNote> GetPagedList(int startRow, int pageSize, out int count)
        {
            return new AccountNoteRepository().GetPagedList(startRow, pageSize, out count).OrderBy(o => o.Title);
        }

        public IOrderedEnumerable<AccountNote> GetAll()
        {
            return new AccountNoteRepository().GetAll().OrderBy(o => o.Title);
        }

        public AccountNote Save(AccountNote account)
        {
            return new AccountNoteRepository().SaveOrUpdate(account);
        }

        public void Delete(AccountNote account)
        {
            account.MarkedForDeletion = true;
            Save(account);
        }
    }
}