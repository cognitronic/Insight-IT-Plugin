using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Insight.Accounts.Core.Interfaces;
using Insight.Accounts.Core.Domain;
using Insight.Presenters.ViewInterfaces;

namespace Insight.Accounts.Presenters.ViewInterfaces
{
    public interface IAccountPropertiesView : IView, IAccount
    {
        void LoadAccount(Account account);
        void NavigateTo(string url);
        event EventHandler OnLoad;
    }
}
