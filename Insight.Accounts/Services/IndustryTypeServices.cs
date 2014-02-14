using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Insight.Core.Domain.Interfaces.Services;
using Insight.Accounts.Core.Domain;
using Insight.Accounts.Persistence.Repositories;

namespace Insight.Accounts.Services
{
    public class IndustryTypeServices : IIndustryTypeServices<IndustryType>
    {
        #region IIndustryTypeServices<IndustryType> Members

        public void Delete(IndustryType item)
        {
            
        }

        public IOrderedEnumerable<IndustryType> GetAll()
        {
            return new IndustryTypeRepository().GetAll().OrderBy(o => o.Name);
        }

        public IndustryType GetByID(int id)
        {
            return new IndustryTypeRepository().GetByID(id, false);
        }

        public IOrderedEnumerable<IndustryType> GetPagedList(int startRow, int pageSize, out int count)
        {
            return new IndustryTypeRepository().GetPagedList(startRow, pageSize, out count).OrderBy(o => o.Name);
        }

        public IndustryType Save(IndustryType item)
        {
            return new IndustryTypeRepository().SaveOrUpdate(item);
        }

        #endregion
    }
}