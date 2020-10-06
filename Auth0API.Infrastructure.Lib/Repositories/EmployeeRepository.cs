using Auth0API.Domain.Entities;
using Auth0API.Domain.Repositories;
using Auth0API.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Auth0API.Infrastructure
{
   public class EmployeeRepository :  Repository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(ApplicationContext unitOfWork) : base(unitOfWork) { }
    }
}
