using Auth0API.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Auth0API.Domain.Aggregates
{
    public static class EmployeeSpecifications
    {
        public static Specification<Employees> ByPersonCity(string city)
        {
            return new AdHocSpecification<Employees>(p=> p.City == city);
        }
        public static Specification<Employees> All()
        {
            return new AdHocSpecification<Employees>(p => true);
        }

    }
}
