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
    public class AccountService : IAccount
    {
        private IUnitOfWork _uow;
        public AccountService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public List<MOrder> GetAllOrders(int customerID)
        {
            var allOrders = _uow.Orders.GetList();
            var allStrings = _uow.OrdStrings.GetList();
            List<MOrder> specOrders = allOrders
                .Where(i => i.customer == customerID)
                .Select(i => new MOrder { Id = i.id, OCustomer = i.customer, Cost = i.total_cost, OStatus = i.status, ArrOrder = (DateTime)i.arrival_date, OrdOrder = i.order_date, Ostrings = new System.Collections.ObjectModel.ObservableCollection<MOrder_String>() }).ToList();
            foreach (var order in specOrders)
            {
                foreach (var oString in allStrings)
                {
                    if (oString.ord == order.Id)
                    {
                        var good = _uow.Goods.Get(oString.good);
                        var newString = new MOrder_String
                        {
                            Cost = oString.cost,
                            Amount = oString.amount,
                            GoodName = good.name,
                            Picture = good.picture,
                            ShowCost = "Стоимость: " + oString.cost + " руб.",
                            ShowAmount = "Всего: " + oString.amount + " шт."
                        };
                        order.Ostrings.Add(newString);
                    }
                }
                order.StatusName = _uow.Statuses.Get(order.OStatus).name;
            }
            return specOrders;
        }

        public List<MOrder> GetAllOrdersByStatus(int customerID, int statusID)
        {
            var allOrders = _uow.Orders.GetList();
            var allStrings = _uow.OrdStrings.GetList();
            List<MOrder> specOrders = allOrders
                .Where(i => i.customer == customerID && i.status == statusID)
                .Select(i => new MOrder { Id = i.id, OCustomer = i.customer, Cost = i.total_cost, OStatus = i.status, ArrOrder = (DateTime)i.arrival_date, OrdOrder = i.order_date, Ostrings = new System.Collections.ObjectModel.ObservableCollection<MOrder_String>()}).ToList();
            foreach (var order in specOrders)
            {
                foreach (var oString in allStrings)
                {
                    if (oString.ord == order.Id)
                    {
                        var good = _uow.Goods.Get(oString.good);
                        var newString = new MOrder_String
                        {
                            Cost = oString.cost,
                            Amount = oString.amount,
                            GoodName = good.name,
                            Picture = good.picture,
                            ShowCost = "Стоимость: " + oString.cost + " руб.",
                            ShowAmount = "Всего: " + oString.amount + " шт."
                        };
                        order.Ostrings.Add(newString);
                    }
                }
                order.StatusName = _uow.Statuses.Get(order.OStatus).name;
            }
            return specOrders;
        }
    }
}
