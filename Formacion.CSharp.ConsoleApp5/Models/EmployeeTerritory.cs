﻿using System;
using System.Collections.Generic;

#nullable disable

namespace Formacion.CSharp.ConsoleApp5.Models
{
    public partial class EmployeeTerritory
    {
        public int EmployeeID { get; set; }
        public string TerritoryID { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual Territory Territory { get; set; }
    }
}
