using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCMiniproject.Models.ViewModels
{
    [Bind(Prefix = nameof(BeersIndexVM.BeersList))]
    public class BeersIndexItemVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string ImgFilePath { get; set; }
    }
}
