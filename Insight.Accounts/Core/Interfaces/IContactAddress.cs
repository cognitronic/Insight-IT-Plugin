using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Insight.Core.Domain.Interfaces;
using Insight.Accounts.Core.Domain;

namespace Insight.Accounts.Core.Interfaces
{
    public interface IContactAddress : IBaseAddress, IAuditable
    {
        int ID { get; set; }
        int ContactID { get; set; }
        string Title { get; set; }
        Contact ContactReference { get; set; }
        int AddressTypeID { get; set; }
    }
}
