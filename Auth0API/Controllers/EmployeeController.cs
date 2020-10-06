using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Auth0API.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Auth0API.Controllers
{
    [Authorize("read:employees")]
    public class EmployeeController : BaseController
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            this._employeeService = employeeService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(this._employeeService.GetEmployees());
        }

        [HttpGet("{city}")]
        public IActionResult GetByCity(string city)
        {
            return Ok(this._employeeService.GetEmployeesByCity(city));
        }
    }
}