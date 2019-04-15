using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCMiniproject.Models.ViewModels
{
    public class BeersUpdateVM
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Display(Name = "Producer")]
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
        [Display(Name = "Type of beer, e.g. IPA/Stout/Lager etc")]
        [Required]
        public string Type { get; set; }
        [Display(Name = "Enter a fitting discription (optional)")]
        public string Description { get; set; }
        public string ImgFilePath { get; set; } // sparar namnet på den uppladdade bilden i databasen
        [Display(Name = "Image of beer to upload (optional)")]
        public IFormFile Image { get; set; } // interface för att kunna ta emot en bilduppladdning i form
    }
}
