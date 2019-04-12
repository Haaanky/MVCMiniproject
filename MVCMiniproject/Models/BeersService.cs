using MVCMiniproject.Models.Entities;
using MVCMiniproject.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCMiniproject.Models
{
    public class BeersService
    {
        BeerDBContext beerDBContext;
        public BeersService(BeerDBContext beerDBContext)
        {
            this.beerDBContext = beerDBContext;
        }
        public BeersIndexVM[] GetAllBeers()
        {
            return beerDBContext.Beer
                .Select(o => new BeersIndexVM {
                    Name = o.Name,
                    Id = o.Id
                })
                .OrderBy(p => p.Name)
                .ToArray();
        }

        internal void AddBeer(BeersCreateVM beersCreateVM)
        {
            beerDBContext.Beer.Add(new Beer {
                Name = beersCreateVM.Name,
                CompanyName = beersCreateVM.CompanyName,
                OriginCountry = beersCreateVM.OriginCountry,
                Price = beersCreateVM.Price,
                Container = beersCreateVM.Container
            });
            beerDBContext.SaveChanges();
        }

        internal void RemoveBeer(BeersRemoveVM beersRemoveVM)
        {
            beerDBContext.Beer.Remove(new Beer
            {
                Id = beersRemoveVM.ID
            });
            beerDBContext.SaveChanges();
        }
    }
}
