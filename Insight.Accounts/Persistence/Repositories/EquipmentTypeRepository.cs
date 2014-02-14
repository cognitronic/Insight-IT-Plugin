using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Insight.Accounts.Core.Interfaces.Data;
using NHibernate.Criterion;
using IdeaSeed.Core.Data.NHibernate;
using Insight.Accounts.Core.Domain;
using Insight.Accounts.Core.Interfaces;

namespace Insight.Accounts.Persistence.Repositories
{
    public class EquipmentTypeRepository : BaseRepository<EquipmentType, int>, IEquipmentTypeRepository
    {
    }
}