using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace EmployeeManagement.Service.Helper
{
    public static class SqlHelper
    {
        /// <summary>
        /// the input parameter for SQL.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <param name="sqlType"></param>
        /// <returns></returns>
        public static SqlParameter SqlInputParam(string name, object value, SqlDbType sqlType)
        {
            SqlParameter input = new SqlParameter(name, value == null ? DBNull.Value : value);
            input.SqlDbType = sqlType;
            input.Direction = ParameterDirection.Input;

            return input;
        }
    }
}
