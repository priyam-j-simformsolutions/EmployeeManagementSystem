using Data.EmployeeData.Context;
using Data.EmployeeData.Entities;
using Data.Repository.Implementation;
using EmployeeManagement.Data.Repository.Contract;

namespace EmployeeManagement.Data.Repository.Implementation
{
    public class ExceptionLoggerRepository : RepositoryBase<ExceptionLogger>, IExceptionLoggerRepository
    {
        public ExceptionLoggerRepository(EmployeeManagementContext context) : base(context)
        {
        }

    }
}
