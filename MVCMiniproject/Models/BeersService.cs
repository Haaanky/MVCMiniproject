using MVCMiniproject.Models.Entities;
using MVCMiniproject.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
        public BeersIndexVM GetAllBeers()
        {
            return new BeersIndexVM
            {
                BeersList = beerDBContext.Beer
                                .Select(o => new BeersIndexItemVM
                                {
                                    Name = o.Name,
                                    Id = o.Id,
                                    ImgFilePath = o.ImgFilePath
                                })
                                .OrderBy(p => p.Name)
                                .ToArray()
            };
        }

        internal bool AddBeer(BeersCreateVM beersCreateVM)
        {
            beerDBContext.Beer.Add(new Beer
            {
                Name = beersCreateVM.Name,
                CompanyName = beersCreateVM.CompanyName,
                OriginCountry = beersCreateVM.OriginCountry,
                Price = beersCreateVM.Price,
                Container = beersCreateVM.Container,
                ImgFilePath = beersCreateVM.Image.FileName
            });
            try
            {
                beerDBContext.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        internal void RemoveBeer(BeersRemoveVM beersRemoveVM)
        {
            beerDBContext.Beer.Remove(new Beer
            {
                Id = beersRemoveVM.ID
            });
            beerDBContext.SaveChanges();
        }

        internal BeersDetailsVM GetBeerByID(int id)
        {
            return beerDBContext.Beer
                .Where(b => b.Id == id)
                .Select(b => new BeersDetailsVM
                {
                    Name = b.Name,
                    CompanyName = b.CompanyName,
                    OriginCountry = b.OriginCountry,
                    Price = b.Price,
                    Container = b.Container,
                    ImgFilePath = b.ImgFilePath
                })
                .Single();
        }
    }
}
