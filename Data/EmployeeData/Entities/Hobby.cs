using System;
using System.Collections.Generic;

#nullable disable

namespace Data.EmployeeData.Entities
{
    public partial class Hobby
    {
        public Hobby()
        {
            EmployeeHobbies = new HashSet<EmployeeHobby>();
        }

        public int Id { get; set; }
        public string Hobby1 { get; set; }
        public bool? IsActive { get; set; }

        public virtual ICollection<EmployeeHobby> EmployeeHobbies { get; set; }
    }
}
