using Auth0API.Application.DTO;
using Auth0API.Application.Interfaces;
using Auth0API.Application.SeedWork;
using Auth0API.Domain;
using Auth0API.Domain.Aggregates;
using Auth0API.Domain.Repositories;
using Auth0API.Domain.Seedwork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Auth0API.Application.Services
{
    public class EmployeeService : IEmployeeService
    {
        readonly IUnitOfWork _unitOfWork;
        public EmployeeService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }
        public List<EmployeeDTO>  GetEmployees()
        {
            var retVal = _unitOfWork.Employee.GetFiltered(EmployeeSpecifications.ByPersonCity("Managua"));
            return retVal.ProjectedAsCollection<EmployeeDTO>();

        }
    }
}
