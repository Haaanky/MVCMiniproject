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
                                    Type = o.Type,
                                    ImgFilePath = o.ImgFilePath
                                })
                                .OrderBy(p => p.Name)
                                .ToArray()
            };
        }

        internal bool AddBeer(BeersCreateVM beersCreateVM)
        {
            if (beersCreateVM.Image == null)
                beerDBContext.Beer.Add(new Beer
                {
                    Name = beersCreateVM.Name,
                    CompanyName = beersCreateVM.CompanyName,
                    OriginCountry = beersCreateVM.OriginCountry,
                    Price = beersCreateVM.Price,
                    Container = beersCreateVM.Container,
                    Type = beersCreateVM.Type,
                    Description = beersCreateVM.Description,
                });
            else
                beerDBContext.Beer.Add(new Beer
                {
                    Name = beersCreateVM.Name,
                    CompanyName = beersCreateVM.CompanyName,
                    OriginCountry = beersCreateVM.OriginCountry,
                    Price = beersCreateVM.Price,
                    Container = beersCreateVM.Container,
                    Type = beersCreateVM.Type,
                    Description = beersCreateVM.Description,
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
                    Type = b.Type,
                    Description = b.Description,
                    ImgFilePath = b.ImgFilePath
                })
                .Single();
        }
        internal BeersUpdateVM GetBeersUpdateVMByID(int id)
        {
            return beerDBContext.Beer
                .Where(b => b.Id == id)
                .Select(b => new BeersUpdateVM
                {
                    Name = b.Name,
                    CompanyName = b.CompanyName,
                    OriginCountry = b.OriginCountry,
                    Price = b.Price,
                    Container = b.Container,
                    Type = b.Type,
                    Description = b.Description,
                    ImgFilePath = b.ImgFilePath
                })
                .Single();
        }
        internal void UpdateBeer(BeersUpdateVM beersUpdateVM)
        {
            var result = beerDBContext.Beer.SingleOrDefault(b => b.Id == beersUpdateVM.Id);
            if (result != null)
            {
                result.Name = beersUpdateVM.Name;
                result.CompanyName = beersUpdateVM.CompanyName;
                result.OriginCountry = beersUpdateVM.OriginCountry;
                result.Price = beersUpdateVM.Price;
                result.Container = beersUpdateVM.Container;
                result.Type = beersUpdateVM.Type;
                result.Description = beersUpdateVM.Description;
                result.ImgFilePath = beersUpdateVM.Image.FileName;
                beerDBContext.SaveChanges();
            }
        }
    }
}
