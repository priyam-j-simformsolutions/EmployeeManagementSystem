using System;
using System.Collections.Generic;

#nullable disable

namespace Data.EmployeeData.Entities
{
    public partial class Employee
    {
        public Employee()
        {
            EmployeeHobbies = new HashSet<EmployeeHobby>();
            EmployeeSkills = new HashSet<EmployeeSkill>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public DateTime? Dob { get; set; }
        public DateTime? JoiningDate { get; set; }
        public string Gender { get; set; }
        public string About { get; set; }
        public int? Role { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Modified { get; set; }

        public virtual ICollection<EmployeeHobby> EmployeeHobbies { get; set; }
        public virtual ICollection<EmployeeSkill> EmployeeSkills { get; set; }
    }
}
