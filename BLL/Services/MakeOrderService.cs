using BLL.Interfaces;
using BLL.Models;
using DAL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        public int MakeOrder(int customerID, decimal totalCost, ObservableCollection<MBasket> basket)
        {
            Order order = new Order();
            order.customer = customerID;
            order.order_date = DateTime.Now.Date;
            order.status = 1;
            order.total_cost = totalCost;
            order.arrival_date = null;
            _uow.Orders.Create(order);
            if (_uow.Save() <= 0)
                return 0;

            var allOrders = _uow.Orders.GetList();
            int newID = allOrders[allOrders.Count - 1].id;

            foreach(var item in basket)
            {
                Order_String os = new Order_String();
                os.good = item.Good;
                os.ord = newID;
                os.amount = item.Amount;
                os.cost = item.SingleCost * item.Amount;

                Good good = _uow.Goods.Get(item.Good);
                good.current_amount -= item.Amount;

                _uow.Goods.Update(good);
                _uow.OrdStrings.Update(os);
            }

            var baskets = _uow.Baskets.GetList();
            foreach(var item in baskets)
            {
                if (item.customer == customerID)
                    _uow.Baskets.Delete(item.id);
            }

            if (_uow.Save() <= 0)
                return 0;

            return 1;
        }
    }
}
