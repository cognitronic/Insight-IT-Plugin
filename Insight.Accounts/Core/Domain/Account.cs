using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Insight.Accounts.Core.Interfaces;
using Insight.Core.Domain;

namespace Insight.Accounts.Core.Domain
{
    public class Account : IAccount
    {
        public virtual int ID { get; set; }
        public virtual string Name { get; set; }
        public virtual ItemType TypeOfItem { get; private set; }
        public virtual string Description { get; set; }
        public virtual string Phone { get; set; }
        public virtual string Fax { get; set; }
        public virtual string Website { get; set; }
        public virtual bool IsActive { get; set; }
        public virtual string EmailDomain { get; set; }
        public virtual int IndustryTypeID { get; set; }
        public virtual int EnteredBy { get; set; }
        public virtual int ChangedBy { get; set; }
        public virtual DateTime DateCreated { get; set; }
        public virtual DateTime LastUpdated { get; set; }
        public virtual bool MarkedForDeletion { get; set; }
        public virtual int? ParentAccountID { get; set; }
        public virtual int AccountManagerID { get; set; }
        public virtual int? ServiceLevelAgreementID { get; set; }
        public virtual Account ParentAccount { get; set; }
        public virtual User AccountManager { get; set; }
        public virtual object ItemReference { get; set; }
        public virtual string URL { get; set; }
        private IList<IAccountAddress> _addresses = new List<IAccountAddress>();
        public virtual IList<IAccountAddress> Addresses { get { return _addresses; } set { _addresses= value; } }

        public Account()
        { 
            this.TypeOfItem = ItemType.ACCOUNT;
        }

        public virtual IList<AccountSearchProperty> GetItemSearchProperties()
        {
            var list = new List<AccountSearchProperty>();

            //Name
            var ops = new Dictionary<string, Operators>();
            ops.Add("Is", Operators.EQUALS);
            ops.Add("Contains", Operators.LIKE);
            ops.Add("Is not", Operators.NOT_EQUALS);
            var criteria = new List<string>();
            criteria.Add("");
            list.Add(new AccountSearchProperty("Name", ops, criteria, ResourceStrings.ViewFilter_ControlTypes_Text));

            //Status
            ops = new Dictionary<string, Operators>();
            ops.Add("Is", Operators.EQUALS);
            ops.Add("Is not", Operators.NOT_EQUALS);
            criteria = new List<string>();
            criteria.Add("Active");
            criteria.Add("InActive");
            list.Add(new AccountSearchProperty("Status", ops, criteria, ResourceStrings.ViewFilter_ControlTypes_DDL));

            return list;
        }
    }
}
