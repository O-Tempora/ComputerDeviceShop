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
                .Select(i => new MOrder { Id = i.id, 
                    OCustomer = i.customer, 
                    Cost = i.total_cost, 
                    OStatus = i.status, 
                    ArrOrder = (DateTime)i.arrival_date, 
                    OrdOrder = i.order_date, 
                    Ostrings = new ObservableCollection<MOrder_String>() 
                }).ToList();

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
                .Select(i => new MOrder { 
                    Id = i.id, 
                    OCustomer = i.customer, 
                    Cost = i.total_cost, 
                    OStatus = i.status, 
                    ArrOrder = (DateTime)i.arrival_date, 
                    OrdOrder = i.order_date, 
                    Ostrings = new System.Collections.ObjectModel.ObservableCollection<MOrder_String>()
                }).ToList();
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

        public List<MOrder> ManagerOrdersByDateAndStatus(DateTime start, DateTime end, int status, string id)
        {
            var orders = _uow.Orders.GetList();
            var strings = _uow.OrdStrings.GetList();

            List<MOrder> res = orders
                .Where(i => (start <= i.order_date) && (end >= i.order_date) && ((status == 0 && i.status == 3) || (status == 1 && (i.status == 2 || i.status == 1))) && i.id.ToString().Contains(id))
                .Join(_uow.Customers.GetList(), i => i.customer, j => j.id, (i, j) => new MOrder
                {
                    Ostrings = new ObservableCollection<MOrder_String>(),
                    Id = i.id,
                    OrdOrder = i.order_date,
                    ArrOrder = (DateTime)i.arrival_date,
                    OStatus = i.status,
                    Cost = i.total_cost,
                    ShowCustomer = $"Покупатель: { j.name }"
                }).ToList();
            foreach (var item in res)
            {
                foreach (var st in strings)
                {
                    if (st.ord == item.Id)
                    {
                        var good = _uow.Goods.Get(st.good);
                        item.Ostrings.Add(new MOrder_String { 
                            ShowAmount = $"Всего: {st.amount} шт.", 
                            GoodName = good.name, 
                            Cost = st.cost, 
                            Amount = st.amount });
                    }
                }
                item.ShowStatus = _uow.Statuses.Get(item.OStatus).name;
            }
            return res;
        }

        public List<MSupply> ManagerSuppliesByDateAndSupplier(DateTime start, DateTime end, int supplierID)
        {
            var supplies = _uow.Supplies.GetList();
            var strings = _uow.SupStrings.GetList();

            List<MSupply> res = supplies
                .Where(i => i.supplier == supplierID && i.order_date >= start && i.order_date <= end)
                .Join(_uow.Suppliers.GetList(), i => i.supplier, s => s.id, (i, s) => new MSupply
                {
                    Sstrings = new ObservableCollection<MSupply_String>(),
                    Id = i.id,
                    OrdSupply = i.order_date,
                    ArrSupply = (DateTime)i.arrival_date,
                    ShowSupplier = $"Поставщик: {s.name}",
                    ShowSupplierAccount = $"Счет поставщика: {s.account_number}",
                    ShowNumber = $"Номер поставки: {i.id}",
                    ShowTotal = $"Итого: {i.total_cost} руб.",
                }).ToList();
            foreach (var item in res)
            {
                foreach (var st in strings)
                {
                    if (st.supply == item.Id)
                    {
                        var good = _uow.Goods.Get(st.good);
                        item.Sstrings.Add(new MSupply_String
                        {
                            ShowCost = $"Стоимость: {st.cost} руб.",
                            GoodName = good.name,
                            Cost = st.cost,
                            Amount = st.amount,
                            ShowAmount = $"Всего товаров: {st.amount} шт."
                        });
                    }
                }
            }
            return res;
        }
    }
}
