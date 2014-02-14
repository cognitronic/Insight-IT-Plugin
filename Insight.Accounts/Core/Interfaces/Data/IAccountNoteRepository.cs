using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IdeaSeed.Core.Data;
using Insight.Accounts.Core.Domain;

namespace Insight.Accounts.Core.Interfaces.Data
{
    public interface IAccountNoteRepository : IRepository<AccountNote, int>
    {
    }
}