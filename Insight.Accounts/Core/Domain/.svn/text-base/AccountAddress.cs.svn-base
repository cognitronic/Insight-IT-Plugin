using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Insight.Core.Domain;
using Insight.Accounts.Core.Interfaces;

namespace Insight.Accounts.Core.Domain
{
    [Serializable]
    public class AccountAddress : IAccountAddress
    {
        public virtual int ID { get; set; }
        public virtual int AccountID { get; set; }
        public virtual Account Account { get; set; }
        public virtual string Title { get; set; }
        public virtual string AddressType { get; set; }
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
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual ItemType TypeOfItem { get; set; }
        public virtual object ItemReference { get; set; }
        public virtual string URL { get; set; }

        public AccountAddress()
        {
            this.TypeOfItem = ItemType.ACCOUNTADDRESS;
        }
    }
}