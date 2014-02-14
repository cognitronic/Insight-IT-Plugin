using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Insight.Core.Domain.Interfaces;

namespace Insight.Accounts.Core.Interfaces
{
    public interface IAccountAddress : IAuditable, IItem, IBaseAddress
    {
        int AccountID { get; set; }
        string Title { get; set; }
        string AddressType { get; set; }
    }
}
