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
    public class MakeOrderService : IMakeOrder
    {
        IUnitOfWork _uow;
        public MakeOrderService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public List<MBasket> GetBasket(int id)
        {
            return _uow.Services.GetBasketByUser(id)
                .Select(i => new MBasket { Id = i.Id, Amount = i.Amount, TotalCost = i.TotalCost, Good = i.Good, Customer = i.Customer, Picture = i.GoodPicture, GoodName = i.Goodname, SingleCost = i.SigleCost }).ToList();
        }
    }
}
