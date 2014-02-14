using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Insight.Core.Domain.Interfaces;

namespace Insight.Accounts.Core.Interfaces
{
    public interface IAccount : IBaseAccount
    {
        string EmailDomain { get; set; }
        int IndustryTypeID { get; set; }
        int? ParentAccountID { get; set; }
        int AccountManagerID { get; set; }
        int? ServiceLevelAgreementID { get; set; }
    }
}
