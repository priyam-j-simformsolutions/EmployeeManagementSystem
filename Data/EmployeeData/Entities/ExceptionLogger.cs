using System;

namespace Data.EmployeeData.Entities
{
    public partial class ExceptionLogger
    {

        public int Id { get; set; }
        public string ExceptionMessage { get; set; }
        public string ControllerName { get; set; }
        public string ExceptionStackTrace { get; set; }
        public DateTime LogTime { get; set; }

    }
}
