using Auth0API.Domain.Seedwork;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Auth0API.Domain.Entities
{
    public class Article : Entity
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "The name is required")]
        [Display(Name = "Name")]
        public string Name { get; set; }

        public string Description { get; set; }

        [Display(Name = "Creation Date")]
        public string CreationDate { get; set; }

        [DataType(DataType.ImageUrl)]
        [Display(Name = "URL Image")]
        public string UrlImage { get; set; }

      
    }
}
