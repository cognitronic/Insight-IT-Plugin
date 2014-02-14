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
    public class ServiceLevelAgreementServices : IServiceLevelAgreementServices<ServiceLevelAgreement>
    {
        #region IServiceLevelAgreementServices<ServiceLevelAgreement> Members

        public void Delete(ServiceLevelAgreement item)
        {
            item.MarkedForDeletion = true;
            Save(item);
        }

        public IOrderedEnumerable<ServiceLevelAgreement> GetAll()
        {
            return new ServiceLevelAgreementRepository().GetAll().OrderBy(o => o.Name);
        }

        public ServiceLevelAgreement GetByID(int id)
        {
            return new ServiceLevelAgreementRepository().GetByID(id, false);
        }

        public IOrderedEnumerable<ServiceLevelAgreement> GetPagedList(int startRow, int pageSize, out int count)
        {
            return new ServiceLevelAgreementRepository().GetPagedList(startRow, pageSize, out count).OrderBy(o => o.Name);
        }

        public ServiceLevelAgreement Save(ServiceLevelAgreement item)
        {
            return new ServiceLevelAgreementRepository().SaveOrUpdate(item);
        }

        #endregion
    }
}