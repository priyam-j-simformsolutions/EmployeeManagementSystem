using System;

namespace EmployeeManagement.Service.Helper
{
    public static class Utility
    {
        public static string DateToString(this DateTime? Date, string formate = "")
        {
            return string.IsNullOrEmpty(formate) ? Date?.ToString("MM/dd/yyyy") : Date?.ToString(formate);
        }
    }
}
