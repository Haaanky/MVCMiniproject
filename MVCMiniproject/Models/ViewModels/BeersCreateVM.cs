using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCMiniproject.Models.ViewModels
{
    public class BeersCreateVM
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Display(Name ="Producer")]
        [Required]
        public string CompanyName { get; set; }
        [Display(Name = "Origin Country")]
        [Required]
        public string OriginCountry { get; set; }
        [Display(Name = "Price")]
        [Required]
        public decimal Price { get; set; }
        [Display(Name = "Container, e.g. can or bottle")]
        [Required]
        public string Container { get; set; }
    }
}
