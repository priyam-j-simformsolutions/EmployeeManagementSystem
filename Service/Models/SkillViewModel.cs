using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement.Service.Models
{
    public class SkillViewModel
    {
        public int Id { get; set; }
        public string Skill { get; set; }
        public bool IsChecked { get; set; }
    }
}
