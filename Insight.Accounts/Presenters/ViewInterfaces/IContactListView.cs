using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Insight.Presenters.ViewInterfaces;
using Insight.Accounts.Core.Domain;
namespace Insight.Accounts.Presenters.ViewInterfaces
{
    public interface IContactListView : IBaseListView<Contact>
    {
        string AccountName { get; set; }
    }
}
