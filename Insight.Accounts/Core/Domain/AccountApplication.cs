using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Insight.Accounts.Core.Interfaces;
using Insight.Accounts.Core.Domain;

namespace Insight.Accounts.Core.Domain
{
    public class AccountApplication : IAccountApplication
    {
        #region IAccountApplication Members

        public virtual string SerialNumber { get; set; }

        public virtual string Version { get; set; }

        public virtual int ApplicationTypeID { get; set; }

        public virtual AccountApplicationType ApplicationType { get; set; }

        #endregion

        #region IAuditable Members

        public virtual int ChangedBy { get; set; }

        public virtual DateTime DateCreated { get; set; }

        public virtual int EnteredBy { get; set; }

        public virtual DateTime LastUpdated { get; set; }

        public virtual bool MarkedForDeletion { get; set; }

        #endregion

        #region IItem Members

        public virtual string Description { get; set; }

        public virtual int ID { get; set; }

        public virtual object ItemReference { get; set; }

        public virtual string Name { get; set; }

        public virtual Insight.Core.Domain.ItemType TypeOfItem { get; private set; }

        public virtual string URL { get; set; }

        #endregion

        
    }
}