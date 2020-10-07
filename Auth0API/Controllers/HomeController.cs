using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Auth0API.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Auth0API.Controllers
{
    public class HomeController : BaseController
    {
        /// <summary>
        /// This is a Public method with a dummy text retorned as Message
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new
            {
                Message = "Hello from a public endpoint! You don't need to be authenticated to see this."
            });
        }
        /// <summary>
        /// This is a private method with a dummy text retorned as Message, authorization is required
        /// </summary>
        /// <returns></returns>
        [HttpGet("private")]
        [Authorize]
        public IActionResult Private()
        {
            return Ok(new
            {
                Message = "Hello from a private endpoint! You don't need to be authenticated to see this."
            });
        }
       
            
    }
}