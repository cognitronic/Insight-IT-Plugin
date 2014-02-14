using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Insight.Core.Domain.Interfaces.Services;
using Insight.Accounts.Persistence.Repositories;
using Insight.Accounts.Core.Domain;
using Insight.Core.Domain.Interfaces;

namespace Insight.Accounts.Services
{
    public class EquipmentServices : IEquipmentServices<Equipment>
    {
        #region IEquipmentServices Members

        public IOrderedEnumerable<Equipment> GetByAccountID(int accountID)
        {
            throw new NotImplementedException();
        }

        public Equipment GetByID(int id)
        {
            return new EquipmentRepository().GetByID(id, false);
        }

        public IOrderedEnumerable<Equipment> GetPagedList(int startRow, int pageSize, out int count)
        {
            return new EquipmentRepository().
                GetPagedList(startRow, pageSize, out count).
                OrderBy(o => o.Name);
        }

        #endregion
    }
}
