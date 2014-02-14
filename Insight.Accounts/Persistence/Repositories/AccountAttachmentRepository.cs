using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Insight.Accounts.Core.Interfaces.Data;
using IdeaSeed.Core.Data.NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using Insight.Accounts.Core.Domain;
using Insight.Accounts.Core.Interfaces;
using Insight.Core.Domain.Interfaces;
using Insight.Core.Domain;
using NHibernate;

namespace Insight.Accounts.Persistence.Repositories
{
    public class AccountAttachmentRepository : BaseRepository<AccountAttachment, int>
    {
        public IList<AccountAttachment> GetByAccountID(int accountID)
        {
            return Session.CreateCriteria<AccountAttachment>()
                .Add(Expression.Eq("AccountID", accountID))
                .Add(Expression.Not(Expression.Eq("MarkedForDeletion", true)))
                .List<AccountAttachment>();
        }

        public IList<AccountAttachment> GetByMarkedForDeletion(bool delete)
        {
            return Session.CreateCriteria<AccountAttachment>()
                .Add(Expression.Eq("MarkedForDeletion", delete))
                .List<AccountAttachment>();
        }
    }
}