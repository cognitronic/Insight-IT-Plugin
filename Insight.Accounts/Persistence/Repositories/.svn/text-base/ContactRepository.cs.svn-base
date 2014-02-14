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

namespace Insight.Accounts.Persistence.Repositories
{
    public class ContactRepository : BaseRepository<Contact, int>, IContactRepository
    {
        public IList<Contact> GetByAccountID(int accountID)
        {
            return Session.CreateCriteria<Contact>()
                .Add(Expression.Eq("AccountID", accountID))
                .List<Contact>();
        }

        public IList<Contact> GetByStatus(bool isActive)
        {
            return Session.CreateCriteria<Contact>()
                .Add(Expression.Eq("IsActive", isActive))
                .Add(Expression.Not(Expression.Eq("MarkedForDeletion", true)))
                .List<Contact>();
        }

        public IList<Contact> GetByMarkedForDeletion(bool delete)
        {
            return Session.CreateCriteria<Contact>()
                .Add(Expression.Eq("MarkedForDeletion", delete))
                .List<Contact>();
        }
    }
}