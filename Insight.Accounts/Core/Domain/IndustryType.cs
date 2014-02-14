using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Insight.Accounts.Core.Interfaces;

namespace Insight.Accounts.Core.Domain
{
    public class IndustryType : IIndustryType
    {
        public virtual int ID { get; set; }
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
    }
}