using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Insight.Accounts.Core.Domain;
using IdeaSeed.Core.Data.NHibernate;
using NHibernate.Criterion;
using Insight.Accounts.Core.Interfaces.Data;

namespace Insight.Accounts.Persistence.Repositories
{
    public class AccountAddressRepository : BaseRepository<AccountAddress, int>, IAccountAddressRepository
    {
        public IList<AccountAddress> GetByAccountID(int accountID)
        {
            return Session.CreateCriteria<AccountAddress>()
                .Add(Expression.Eq("AccountID", accountID))
                .Add(Expression.Not(Expression.Eq("MarkedForDeletion", true)))
                .List<AccountAddress>();
        }
    }
}