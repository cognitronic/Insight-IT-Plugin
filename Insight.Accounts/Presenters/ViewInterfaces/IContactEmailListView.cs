using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Insight.Presenters.ViewInterfaces;
using Insight.Accounts.Core.Interfaces;

namespace Insight.Accounts.Presenters.ViewInterfaces
{
    public interface IContactEmailListView : IBaseListView<IContactEmail>
    {
        string AccountName { get; set; }
    }
}
