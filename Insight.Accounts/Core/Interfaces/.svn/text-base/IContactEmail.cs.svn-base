using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Insight.Core.Domain.Interfaces;
using Insight.Accounts.Core.Domain;

namespace Insight.Accounts.Core.Interfaces
{
    public interface IContactEmail : IBaseEmailAddress, IAuditable
    {
        int ID { get; set; }
        int ContactID { get; set; }
        int EmailTypeID { get; set; }
        Contact ContactReference { get; set; }
    }
}
