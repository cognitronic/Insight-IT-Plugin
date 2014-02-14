using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Insight.Core.Domain;
using Insight.Accounts.Core.Interfaces;

namespace Insight.Accounts.Core.Domain
{
    [Serializable]
    public class Equipment : IEquipment
    {
        public virtual int ID { get; set; }
        public virtual string Name { get; set; }
        public virtual ItemType TypeOfItem { get; private set; }
        public virtual string Description { get; set; }
        public virtual int EnteredBy { get; set; }
        public virtual int ChangedBy { get; set; }
        public virtual DateTime DateCreated { get; set; }
        public virtual DateTime LastUpdated { get; set; }
        public virtual bool MarkedForDeletion { get; set; }
        public virtual object ItemReference { get; set; }
        public virtual string URL { get; set; }
        public virtual string IPAddress { get; set; }
        public virtual string Username { get; set; }
        public virtual string Password { get; set; }
        public virtual string Model { get; set; }
        public virtual string KeyFunctions { get; set; }
        public virtual DateTime? PurchaseDate { get; set; }
        public virtual DateTime? SupportExpirationDate { get; set; }
        public virtual DateTime? WarrantyExpirationDate { get; set; }
        public virtual string WarrantyNotes { get; set; }
        public virtual string PhysicalLocationDescription { get; set; }
        public virtual int AccountID { get; set; }
        public virtual IAccount Account { get; set; }
        public virtual string OtherInfo { get; set; }
        public virtual int OperatingSystemID { get; set; }
        public virtual string SerializedProperties { get; set; }
        public virtual int EquipmentTypeID { get; set; }
        public virtual IEquipmentType EquipmentType { get; set; }

        public Equipment()
        {
            this.TypeOfItem = ItemType.EQUIPMENT;
        }
    }
}
