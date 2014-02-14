using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Insight.Services.Utils;

namespace Insight.Accounts.Core.Domain
{
    internal class PayrollAccountApplication : AccountApplication
    {
        public string SupportNumber { get; set; }
        public string ClientInstallDir { get; set; }

        public PayrollAccountApplication(string extProperties)
        { 
            
        }
    }
}