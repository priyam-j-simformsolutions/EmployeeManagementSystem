using Data.EmployeeData.Context;
using Data.Repository.Contract;
using EmployeeManagement.Data.Repository.Contract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EmployeeManagementContext _context;
        public IEmployeeRepository Employees { get; }
        public IRoleRepository Roles { get; }
        public ISkillRepository Skills { get; }
        public IEmployeeSkillRepository EmployeeSkills { get; }
        public IHobbyRepository Hobbies { get; }
        public IEmployeeHobbyRepository EmployeeHobbies { get; }
        public IExceptionLoggerRepository ExceptionLogger { get; }

        public UnitOfWork(EmployeeManagementContext employeeManagementContext,
            IEmployeeRepository employeeRepository,
            IRoleRepository roleRepository,
            ISkillRepository skillRepository,
            IEmployeeSkillRepository employeeSkillRepository,
            IHobbyRepository hobbyRepository,
            IEmployeeHobbyRepository employeeHobbyRepository,
            IExceptionLoggerRepository exceptionLogger
            )
        {
            this._context = employeeManagementContext;
            this.Employees = employeeRepository;
            this.Roles = roleRepository;
            this.Skills = skillRepository;
            this.EmployeeSkills = employeeSkillRepository;
            this.Hobbies = hobbyRepository;
            this.EmployeeHobbies = employeeHobbyRepository;
            this.ExceptionLogger = exceptionLogger;
        }
        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }
    }
}
