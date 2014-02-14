using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Insight.Accounts.Core.Interfaces;
using Insight.Accounts.Core.Domain;

namespace Insight.Accounts.Core.Domain
{
    [Serializable]
    public class ContactEmail : IContactEmail
    {
        public virtual int ID { get; set; }
        public virtual int ContactID { get; set; }
        public virtual string Email { get; set; }
        public virtual int EmailTypeID { get; set; }
        public virtual int EnteredBy { get; set; }
        public virtual int ChangedBy { get; set; }
        public virtual DateTime DateCreated { get; set; }
        public virtual DateTime LastUpdated { get; set; }
        public virtual bool MarkedForDeletion { get; set; }
        public virtual Contact ContactReference { get; set; }
    }
}