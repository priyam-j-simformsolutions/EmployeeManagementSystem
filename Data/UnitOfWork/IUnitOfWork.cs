using Data.Repository.Contract;
using EmployeeManagement.Data.Repository.Contract;
using System;
using System.Threading.Tasks;

namespace Data.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IEmployeeRepository Employees { get; }
        IRoleRepository Roles { get; }
        ISkillRepository Skills { get; }
        IEmployeeSkillRepository EmployeeSkills { get; }
        IHobbyRepository Hobbies { get; }
        IEmployeeHobbyRepository EmployeeHobbies { get; }
        IExceptionLoggerRepository ExceptionLogger { get; }
        Task<int> CompleteAsync();
    }
}
