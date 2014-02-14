using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Insight.Core.Domain.Interfaces;
using Insight.Accounts.Core.Domain;

namespace Insight.Accounts.Core.Interfaces
{
    public interface IAccountAttachment : IBaseAttachment
    {
        string Title { get; set; }
        int AccountID { get; set; }
        Account AttachmentAccount { get; set; }
    }
}