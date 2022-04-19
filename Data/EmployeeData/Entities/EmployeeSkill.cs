﻿using System;
using System.Collections.Generic;

#nullable disable

namespace Data.EmployeeData.Entities
{
    public partial class EmployeeSkill
    {
        public int Id { get; set; }
        public int IdEmployee { get; set; }
        public int IdSkill { get; set; }

        public virtual Employee IdEmployeeNavigation { get; set; }
        public virtual Skill IdSkillNavigation { get; set; }
    }
}
