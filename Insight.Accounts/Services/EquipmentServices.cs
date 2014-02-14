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
            return new EquipmentRepository().GetByAccountID(accountID).OrderBy(o => o.Name);
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

        public IOrderedEnumerable<Equipment> GetFilteredPagedList(int startRow, int pageSize)
        {
            return new EquipmentRepository().GetByFilters(startRow, pageSize).OrderBy(o => o.Name);
        }

        public IOrderedEnumerable<EquipmentType> GetEquipmentTypes()
        {
            return new EquipmentTypeRepository().GetAll().OrderBy(o => o.Name);
        }

        #endregion

        #region IEquipmentServices<Equipment> Members

        public void Delete(Equipment item)
        {
            item.MarkedForDeletion = true;
            Save(item);
        }

        public IOrderedEnumerable<Equipment> GetAll()
        {
            return new EquipmentRepository().GetAll().OrderBy(o => o.Name);
        }

        public Equipment Save(Equipment item)
        {
            return new EquipmentRepository().SaveOrUpdate(item);
        }

        #endregion
    }
}
