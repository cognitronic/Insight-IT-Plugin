﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Insight.Accounts.Core.Interfaces
{
    public interface IEquipmentType
    {
        int ID { get; set; }
        string Name { get; set; }
        string Description { get; set; }
    }
}
