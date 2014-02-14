using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Insight.Accounts.Core.Interfaces;
using Insight.Accounts.Core.Domain;
using Insight.Core.Domain;

namespace Insight.Accounts.Core.Domain
{
    public class AccountAttachment : IAccountAttachment
    {
        public virtual int ID { get; set; }
        public virtual string Description { get; set; }
        public virtual string Name { get; set; }
        public virtual int AccountID { get; set; }
        public virtual string FileName { get; set; }
        public virtual string FullPath { get; set; }
        public virtual string Title { get; set; }
        public virtual int EnteredBy { get; set; }
        public virtual int ChangedBy { get; set; }
        public virtual DateTime DateCreated { get; set; }
        public virtual DateTime LastUpdated { get; set; }
        public virtual bool MarkedForDeletion { get; set; }
        public virtual ItemType TypeOfItem { get; private set; }
        public virtual object ItemReference { get; set; }
        public virtual string URL { get; set; }
        public virtual Account AttachmentAccount { get; set; }

        public AccountAttachment()
        {
            this.TypeOfItem = ItemType.ATTACHMENT;
        }
    }
}