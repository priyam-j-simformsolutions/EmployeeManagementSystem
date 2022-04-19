using Data.EmployeeData.Entities;
using Data.UnitOfWork;
using EmployeeManagement.Service.Contract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Service.Implementation
{
    public class LogService : ILogService
    {
        private readonly IUnitOfWork _unitOfWork;

        public LogService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Log exception into database.
        /// </summary>
        /// <param name="exception">exception details object</param>
        public async Task SaveLog(ExceptionLogger exception)
        {
            await _unitOfWork.ExceptionLogger.AddAsync(exception);
            await _unitOfWork.CompleteAsync();
        }
    }
}
