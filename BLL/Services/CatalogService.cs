using BLL.Interfaces;
using BLL.Models;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class CatalogService : ICatalog
    {
        IUnitOfWork _uow;
        public CatalogService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public List<MGood> GoodsCategoryFilter(string category)
        {
            return _uow.Services.GetGoodsByCategory(category)
                .Select(i => new MGood { Id = i.Id, Name = i.Name, Discount = i.Discount, Picture = i.Picture, Cost = i.Price}).ToList();
        }
    }
}
