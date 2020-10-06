using Auth0API.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Auth0API.Domain.Aggregates
{
    public static class EmployeeSpecifications
    {
        public static Specification<Employee> ByPersonCity(string city)
        {
            return new AdHocSpecification<Employee>(p=> p.City == city);
        }
        public static Specification<Employee> All()
        {
            return new AdHocSpecification<Employee>(p => true);
        }

    }
}
