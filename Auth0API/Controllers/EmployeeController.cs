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
            try
            {
                var employee = this._employeeService.GetEmployees();
                if (employee == null) return NotFound();

                return Ok(employee);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("{city}")]
        public IActionResult GetByCity(string city)
        {
            try
            {
                var employee = this._employeeService.GetEmployeesByCity(city);
                if (employee == null) return NotFound(employee);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}