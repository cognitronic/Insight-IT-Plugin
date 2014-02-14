using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Insight.Core.Domain.Interfaces.Services;
using Insight.Accounts.Core.Domain;
using Insight.Accounts.Persistence.Repositories;

namespace Insight.Accounts.Services
{
    public class AccountAttachmentServices : IAttachmentServices<AccountAttachment>
    {
        #region IAttachmentServices<AccountAttachment> Members

        public void Delete(AccountAttachment item)
        {
            item.MarkedForDeletion = true;
            Save(item);
        }

        public IOrderedEnumerable<AccountAttachment> GetAll()
        {
            return new AccountAttachmentRepository().GetAll().OrderBy(o => o.DateCreated);
        }

        public AccountAttachment GetByID(int id)
        {
            return new AccountAttachmentRepository().GetByID(id, false);
        }

        public IOrderedEnumerable<AccountAttachment> GetPagedList(int startRow, int pageSize, out int count)
        {
            return new AccountAttachmentRepository().GetPagedList(startRow, pageSize, out count).OrderBy(o => o.DateCreated);
        }

        public AccountAttachment Save(AccountAttachment item)
        {
            return new AccountAttachmentRepository().SaveOrUpdate(item);
        }

        public IList<AccountAttachment> GetByAccountID(int accountID)
        {
            return new AccountAttachmentRepository().GetByAccountID(accountID);
        }

        #endregion
    }
}