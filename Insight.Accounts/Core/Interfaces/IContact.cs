using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Insight.Core.Domain.Interfaces;

namespace Insight.Accounts.Core.Interfaces
{
    public interface IContact : IBaseContact
    {
        string Title { get; set; }
        string WorkPhone { get; set; }
        string HomePhone { get; set; }
        string Location { get; set; }
        bool IsActive { get; set; }
        bool IsKeyContact { get; set; }
        string AvatarPath { get; set; }
        int AccountID { get; set; }
    }
}
