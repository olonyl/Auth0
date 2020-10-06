using Auth0API.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Auth0API.Domain.Aggregates
{
    public class EmployeeFactory
    {
        public static Employee CreateEmployee()
        {
            var employee = new Employee();

            return employee;
        }
    }
}
