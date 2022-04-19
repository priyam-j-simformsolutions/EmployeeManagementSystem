using Data.Repository.Contract;
using Data.Repository.Implementation;
using Data.UnitOfWork;
using EmployeeManagement.Data.Repository.Contract;
using EmployeeManagement.Data.Repository.Implementation;
using EmployeeManagement.Service.Contract;
using EmployeeManagement.Service.Implementation;
using Microsoft.Extensions.DependencyInjection;

namespace EmployeeManagement
{
    public static class ConfigureServiceExtension
    {
        public static void RegisterDependency(this IServiceCollection services)
        {
            //repository Dependency
            services.AddTransient(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
            services.AddTransient<IEmployeeRepository, EmployeeRepository>();
            services.AddTransient<IEmployeeHobbyRepository, EmployeeHobbyRepository>();
            services.AddTransient<IEmployeeSkillRepository, EmployeeSkillRepository>();
            services.AddTransient<ISkillRepository, SkillRepository>();
            services.AddTransient<IRoleRepository, RoleRepository>();
            services.AddTransient<IHobbyRepository, HobbyRepository>();
            services.AddTransient<IExceptionLoggerRepository, ExceptionLoggerRepository>();
            services.AddTransient<ILogService, LogService>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();


            //Service Dependency

            services.AddTransient<IEmployeeService, EmployeeService>();
        }
    }
}
