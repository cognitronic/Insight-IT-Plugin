using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Insight.Core.Domain.Interfaces;
using Insight.Core.Domain;

namespace Insight.Accounts.Core.Domain
{
    public class AccountSearchProperty : IItemSearchProperty
    {
        public virtual string SearchColumn { get; set; }
        public virtual string CriteriaSearchControlType { get; set; }
        private IDictionary<string, Operators> _validOperators = new Dictionary<string, Operators>();
        public virtual IDictionary<string, Operators> ValidOperators { get { return _validOperators; } set { _validOperators = value; } }
        private IList<string> _searchCriteria = new List<string>();
        public virtual IList<string> SearchCriteria { get { return _searchCriteria; } set { _searchCriteria = value; } }

        public AccountSearchProperty(string column, IDictionary<string, Operators> ops, IList<string> criteria, string criteriaControlType)
        {
            this.SearchColumn = column;
            this.ValidOperators = ops;
            this.SearchCriteria = criteria;
            this.CriteriaSearchControlType = criteriaControlType;
        }
    }
}