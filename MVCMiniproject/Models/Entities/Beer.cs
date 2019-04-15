using System;
using System.Collections.Generic;

namespace MVCMiniproject.Models.Entities
{
    public partial class Beer
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
    }
}
