using BLL.Interfaces;
using BLL.Models;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class CRUD : ICRUD
    {
        IUnitOfWork _dbr;
        public CRUD(IUnitOfWork rep)
        {
            _dbr = rep;
        }
        public bool Save()
        {
            return _dbr.Save() > 0;
        }
        public List<MCategory> GetCategories()
        {
            return _dbr.Categories.GetList().Select(i => new MCategory(i)).ToList();
        }

        public MCategory GetCategory(int id)
        {
            throw new NotImplementedException();
        }

        public MCustomer GetCustomer(int id)
        {
            return new MCustomer(_dbr.Customers.Get(id));
        }

        public List<MCustomer> GetCustomers()
        {
            return _dbr.Customers.GetList().Select(i => new MCustomer(i)).ToList();
        }

        public MGood GetGood(int id)
        {
            return new MGood(_dbr.Goods.Get(id));
        }

        public List<MGood> GetGoods()
        {
            return _dbr.Goods.GetList().Select(i => new MGood(i)).ToList();
        }

        public MManufacturer GetManufacturer(int id)
        {
            throw new NotImplementedException();
        }

        public List<MManufacturer> GetManufacturers()
        {
            return _dbr.Manufacturers.GetList().Select(i => new MManufacturer(i)).ToList();
        }

        public MOrder GetOrder(int id)
        {
            throw new NotImplementedException();
        }

        public List<MOrder> GetOrders()
        {
            return _dbr.Orders.GetList().Select(i => new MOrder(i)).ToList();
        }

        public List<MOrder_String> GetOrdStrings()
        {
            throw new NotImplementedException();
        }

        public List<MStatus> GetStatuses()
        {
            return _dbr.Statuses.GetList().Select(i => new MStatus(i)).ToList();
        }

        public MSupplier GetSupplier(int id)
        {
            throw new NotImplementedException();
        }

        public List<MSupplier> GetSuppliers()
        {
            return _dbr.Suppliers.GetList().Select(i => new MSupplier(i)).ToList();
        }

        public List<MSupply> GetSupplies()
        {
            return _dbr.Supplies.GetList().Select(i => new MSupply(i)).ToList();
        }

        public MSupply GetSupply(int id)
        {
            throw new NotImplementedException();
        }

        public List<MSupply_String> GetSupStrings()
        {
            return _dbr.SupStrings.GetList().Select(i => new MSupply_String(i)).ToList();
        }

        public List<MBasket> GetBaskets()
        {
            return _dbr.Baskets.GetList().Select(i => new MBasket(i)).ToList();
        }

        public MMainCategory GetMainCategory(int id)
        {
            throw new NotImplementedException();
        }

        public MBasket GetBasket(int id)
        {
            throw new NotImplementedException();
        }

        public void CreateBasket(MBasket basket)
        {
            Basket b = new Basket();
            var baskets = _dbr.Baskets.GetList()
                .Where(i => i.customer == basket.Customer && i.good == basket.Good).ToList();
            if (baskets.Count != 0)
            {
                return;
            }
            else
            {
                b.customer = basket.Customer;
                b.good = basket.Good;
                b.amount = 1;
                _dbr.Baskets.Create(b);
                Save();
            }
        }

        public void UpdateBasket(MBasket basket)
        {
            Basket b = _dbr.Baskets.Get(basket.Id);
            b.amount = basket.Amount;
            Save();
        }

        public void DeleteBasket(int id)
        {
            Basket b = _dbr.Baskets.Get(id);
            if (b != null)
            {
                _dbr.Baskets.Delete(id);
                Save();
            }
        }

        public void CreateCustomer(MCustomer customer)
        {
            Customer c = new Customer();
            c.login = customer.Login;
            c.name = customer.Name;
            c.password = customer.Password;
            c.person_type = customer.PersonType;
            c.phone = customer.Phone;
            _dbr.Customers.Create(c);
            Save();
        }

        public void UpdateOrder(MOrder order)
        {
            Order o = _dbr.Orders.Get(order.Id);
            o.status = order.OStatus;
            Save();
        }
    }
}
