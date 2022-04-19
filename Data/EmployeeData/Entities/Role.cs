using System;
using System.Collections.Generic;

#nullable disable

namespace Data.EmployeeData.Entities
{
    public partial class Role
    {
        public int Id { get; set; }
        public string Role1 { get; set; }
        public bool? IsActive { get; set; }
    }
}
