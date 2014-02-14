using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Insight.Core.Domain.Interfaces;

namespace Insight.Accounts.Core.Interfaces
{
    public interface IAccountApplication : IAuditable, IItem
    {
        string SerialNumber { get; set; }
        string Version { get; set; }
        int ApplicationTypeID { get; set; }
    }
}
