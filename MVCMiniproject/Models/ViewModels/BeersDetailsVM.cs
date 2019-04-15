using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCMiniproject.Models.ViewModels
{
    [Bind(Prefix = nameof(BeersIndexVM.ItemDetailsVM))]
    public class BeersDetailsVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CompanyName { get; set; }
        public string OriginCountry { get; set; }
        public decimal Price { get; set; }
        public string Container { get; set; }
        public string ImgFilePath { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public override string ToString()
        {
            return $"{Name}, {CompanyName}, {Type}, {OriginCountry}, {Price}, {Container}";
        }
    }
}
