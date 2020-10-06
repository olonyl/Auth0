using Auth0API.Domain.Seedwork;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Auth0API.Domain.Entities
{
    public class Employee: Entity
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "The name is required")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName{ get; set; }

        public string Address{ get; set; }

        [Required]
        public string PhoneNumber { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}
