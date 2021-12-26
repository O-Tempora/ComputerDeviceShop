using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IUnitOfWork
    {
        IRepository<Good> Goods { get; }
        IRepository<Basket> Baskets { get; }
        IRepository<Category> Categories { get; }
        IRepository<Manufacturer> Manufacturers { get; }
        IRepository<MainCategory> MainCategories { get; }
        IRepository<Supplier> Suppliers { get; }
        IRepository<Supply> Supplies { get; }
        IRepository<Supply_String> SupStrings { get; }
        IRepository<Order> Orders { get; }
        IRepository<Status> Statuses { get; }
        IRepository<Order_String> OrdStrings { get; }
        IRepository<Customer> Customers { get; }
        IService Services { get; }
        int Save();
    }
}
