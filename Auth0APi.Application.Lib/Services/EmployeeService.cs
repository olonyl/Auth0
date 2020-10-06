﻿using Auth0API.Application.DTO;
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
        readonly IEmployeeRepository _employeeRepository;
        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            this._employeeRepository = employeeRepository ?? throw new ArgumentNullException(nameof(employeeRepository));
        }
        public List<EmployeeDTO>  GetEmployeesByCity(string city)
        {
            var retVal = _employeeRepository.GetFiltered(EmployeeSpecifications.ByPersonCity(city));
            return retVal.ProjectedAsCollection<EmployeeDTO>();

        }
        public List<EmployeeDTO> GetEmployees()
        {
            var retVal = _employeeRepository.GetAll();
            return retVal.ProjectedAsCollection<EmployeeDTO>();

        }
    }
}
