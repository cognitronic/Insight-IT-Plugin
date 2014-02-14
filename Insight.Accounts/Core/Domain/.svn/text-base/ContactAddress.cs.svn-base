using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Insight.Accounts.Core.Domain;
using Insight.Core.Domain;
using Insight.Accounts.Core.Interfaces;

namespace Insight.Accounts.Core.Domain
{
    [Serializable]
    public class ContactAddress : IContactAddress
    {
        public virtual int ID { get; set; }
        public virtual int ContactID { get; set; }
        public virtual string Title { get; set; }
        public virtual int AddressTypeID { get; set; }
        public virtual string Address1 { get; set; }
        public virtual string Address2 { get; set; }
        public virtual string City { get; set; }
        public virtual string State { get; set; }
        public virtual string Zip { get; set; }
        public virtual int EnteredBy { get; set; }
        public virtual int ChangedBy { get; set; }
        public virtual DateTime DateCreated { get; set; }
        public virtual DateTime LastUpdated { get; set; }
        public virtual bool MarkedForDeletion { get; set; }
        public virtual Contact ContactReference { get; set; }
        public virtual string AddressType { get; set; }
    }
}