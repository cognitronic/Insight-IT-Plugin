using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Insight.Core.Domain;
using Insight.Core.Domain.Interfaces;

namespace Insight.Accounts.Core.Interfaces
{
    public interface IEquipment : IBaseEquipment
    {
        string IPAddress { get; set; }
        string Username { get; set; }
        string Password { get; set; }
        string Model { get; set; }
        string KeyFunctions { get; set; }
        DateTime PurchaseDate { get; set; }
        DateTime SupportExpirationDate { get; set; }
        DateTime WarrantyExpirationDate { get; set; }
        string WarrantyNotes { get; set; }
        string PhysicalLocationDescription { get; set; }
        int AccountID { get; set; }
        IAccount Account { get; set; }
        string OtherInfo { get; set; }
        int OperatingSystemID { get; set; }
    }
}
