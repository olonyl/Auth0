using System;
using System.Collections.Generic;
using System.Text;

namespace Auth0API.Application.DTO
{
    public class EmployeeDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string City { get; set; }
        public string Country{ get; set; }
    }
}
