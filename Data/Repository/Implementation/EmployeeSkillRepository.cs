using Data.EmployeeData.Context;
using Data.EmployeeData.Entities;
using Data.Repository.Contract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository.Implementation
{
    public class EmployeeSkillRepository : RepositoryBase<EmployeeSkill>, IEmployeeSkillRepository
    {
        public EmployeeSkillRepository(EmployeeManagementContext context) : base(context)
        {
            this._context = context;
        }
        private EmployeeManagementContext _context { get; }

        public async Task UpdateSkillsAsync(IEnumerable<EmployeeSkill> skills)
        {
            await this._context.Set<EmployeeSkill>().AddRangeAsync(skills);
        }
    }
}
