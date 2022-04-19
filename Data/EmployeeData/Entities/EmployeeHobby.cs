using System;
using System.Collections.Generic;

#nullable disable

namespace Data.EmployeeData.Entities
{
    public partial class EmployeeHobby
    {
        public int Id { get; set; }
        public int IdEmployee { get; set; }
        public int IdHobby { get; set; }

        public virtual Employee IdEmployeeNavigation { get; set; }
        public virtual Hobby IdHobbyNavigation { get; set; }
    }
}
