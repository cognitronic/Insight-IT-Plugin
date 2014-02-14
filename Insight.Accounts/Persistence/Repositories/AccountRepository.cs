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
    public class AccountRepository : BaseRepository<Account, int>, IAccountRepository
    {
        public IList<Account> GetByEmailDomain(string emailDomain)
        {
            return Session.CreateCriteria<Account>()
                .Add(Expression.Eq("EmailDomain", emailDomain))
                .Add(Expression.Not(Expression.Eq("MarkedForDeletion", true)))
                .List<Account>();
        }

        public Account GetByName(string name)
        {
            return Session.CreateCriteria<Account>()
                .Add(Expression.Eq("Name", name))
                .UniqueResult<Account>();
        }

        public IList<Account> GetSubAccountsByAccountID(int accountID)
        {
            return Session.CreateCriteria<Account>()
                .Add(Expression.Eq("ParentAccountID", accountID))
                .Add(Expression.Not(Expression.Eq("MarkedForDeletion", true)))
                .List<Account>();
        }

        public IList<Account> GetByAccountManagerID(int accountManagerID)
        {
            return Session.CreateCriteria<Account>()
                .Add(Expression.Eq("AccountManagerID", accountManagerID))
                .Add(Expression.Not(Expression.Eq("MarkedForDeletion", true)))
                .List<Account>();
        }

        public IList<Account> GetByIndustryTypeID(int industryTypeID)
        {
            return Session.CreateCriteria<Account>()
                .Add(Expression.Eq("IndustryTypeID", industryTypeID))
                .Add(Expression.Not(Expression.Eq("MarkedForDeletion", true)))
                .List<Account>();
        }

        public Account GetParentAccountByEmailDomain(string emailDomain)
        {
            return Session.CreateCriteria<Account>()
                .Add(Expression.Eq("EmailDomain", emailDomain))
                .Add(Expression.IsNull("ParentAccountID"))
                .UniqueResult<Account>();
        }

        public IList<Account> GetByStatus(bool isActive)
        {
            return Session.CreateCriteria<Account>()
                .Add(Expression.Eq("IsActive", isActive))
                .Add(Expression.Not(Expression.Eq("MarkedForDeletion", true)))
                .List<Account>();
        }

        public IList<Account> GetByMarkedForDeletion(bool delete)
        {
            return Session.CreateCriteria<Account>()
                .Add(Expression.Eq("MarkedForDeletion", delete))
                .List<Account>();
        }

        public IList<Account> GetByFilters(int startRow, int pageSize, out int count)
        {
            // Get the total row count in the database.
            var rowCount = this.Session.CreateCriteria(typeof(Account))
                .SetProjection(Projections.Count(Projections.Id()))
                .FutureValue<int>();
            var list = new List<ISearchCriterion>();
            //list.Add(new SearchCriterion("Phone", Operators.NOT_NULL, ""));
            //list.Add(new SearchCriterion("IsActive", Operators.EQUALS, false));

            ICriteria query = Session.CreateCriteria<Account>();
            foreach (var l in list)
            {
                switch (l.Operator)
                {
                    case Operators.EQUALS:
                        query.Add(Restrictions.Eq(l.SearchColumn, l.SearchCriteria));
                        break;
                    case Operators.NOT_NULL:
                        query.Add(Restrictions.IsNotNull(l.SearchColumn));
                        break;
                }
            }
            count = rowCount.Value;
            return query.List<Account>();
        }
    }
}