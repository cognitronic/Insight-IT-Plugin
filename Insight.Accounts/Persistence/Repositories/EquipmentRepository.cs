using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Insight.Accounts.Core.Interfaces.Data;
using NHibernate.Criterion;
using NHibernate;
using IdeaSeed.Core.Data.NHibernate;
using Insight.Accounts.Core.Domain;
using Insight.Accounts.Core.Interfaces;
using Insight.Core.Domain.Interfaces;
using Insight.Core.Domain;

namespace Insight.Accounts.Persistence.Repositories
{
    public class EquipmentRepository : BaseRepository<Equipment, int>, IEquipmentRepository
    {
        public IList<Equipment> GetByAccountID(int accountID)
        {
            return Session.CreateCriteria<Equipment>()
                .Add(Expression.Eq("AccountID", accountID))
                .Add(Expression.Not(Expression.Eq("MarkedForDeletion", true)))
                .List<Equipment>();
        }

        public IList<Equipment> GetByFilters(int startRow, int pageSize)
        {
            var list = new List<ISearchCriterion>();
            list.Add(new SearchCriterion("Phone", Operators.NOT_NULL, ""));
            list.Add(new SearchCriterion("Status", Operators.EQUALS, "False"));

            ICriteria query = Session.CreateCriteria<Equipment>();
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
            return query.List<Equipment>();
        }
    }
}
