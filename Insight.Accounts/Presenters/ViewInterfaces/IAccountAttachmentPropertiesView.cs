using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Insight.Accounts.Core.Interfaces;
using Insight.Accounts.Core.Domain;
using Insight.Presenters.ViewInterfaces;

namespace Insight.Accounts.Presenters.ViewInterfaces
{
    public interface IAccountAttachmentPropertiesView : IView, IAccountAttachment
    {
        void LoadAttachment(AccountAttachment attachment);
        void NavigateTo(string url);
    }
}