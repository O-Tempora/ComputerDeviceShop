
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private CourseContext _cc;
        private SupplyRep supplyRep;
        private SupplierRep supplierRep;
        private CategoryRep categoryRep;
        private ManufacturerRep manufacturerRep;
        private GoodRep goodRep;
        private OrderRep orderRep;
        private StatusRep statusRep;
        private CustomerRep customerRep;
        private BasketRep basketRep;
        private MainCategoryRep mainCategoryRep;
        private Supply_StringRep supply_stringRep;
        private Order_StringRep order_stringRep;
        private REPORTS_REP repRep;
        public UnitOfWork()
        {
            _cc = new CourseContext();
        }
        public IRepository<Good> Goods
        {
            get
            {
                if (goodRep == null)
                    goodRep = new GoodRep(_cc);
                return goodRep;
            }
        }

        public IRepository<Category> Categories
        {
            get
            {
                if (categoryRep == null)
                    categoryRep = new CategoryRep(_cc);
                return categoryRep;
            }
        }

        public IRepository<Manufacturer> Manufacturers
        {
            get
            {
                if (manufacturerRep == null)
                    manufacturerRep = new ManufacturerRep(_cc);
                return manufacturerRep;
            }
        }

        public IRepository<Supplier> Suppliers
        {
            get
            {
                if (supplierRep == null)
                    supplierRep = new SupplierRep(_cc);
                return supplierRep;
            }
        }

        public IRepository<Supply> Supplies
        {
            get
            {
                if (supplyRep == null)
                    supplyRep = new SupplyRep(_cc);
                return supplyRep;
            }
        }

        public IRepository<Supply_String> SupStrings
        {
            get
            {
                if (supply_stringRep == null)
                    supply_stringRep = new Supply_StringRep(_cc);
                return supply_stringRep;
            }
        }


        public IRepository<Order> Orders
        {
            get
            {
                if (orderRep == null)
                    orderRep = new OrderRep(_cc);
                return orderRep;
            }
        }

        public IRepository<Status> Statuses
        {
            get
            {
                if (statusRep == null)
                    statusRep = new StatusRep(_cc);
                return statusRep;
            }
        }

        public IRepository<Order_String> OrdStrings
        {
            get
            {
                if (order_stringRep == null)
                    order_stringRep = new Order_StringRep(_cc);
                return order_stringRep;
            }
        }

        public IRepository<Customer> Customers
        {
            get
            {
                if (customerRep == null)
                    customerRep = new CustomerRep(_cc);
                return customerRep;
            }
        }

        public IRepository<Basket> Baskets
        {
            get
            {
                if (basketRep == null)
                    basketRep = new BasketRep(_cc);
                return basketRep;
            }
        }

        public IRepository<MainCategory> MainCategories
        {
            get
            {
                if (mainCategoryRep == null)
                    mainCategoryRep = new MainCategoryRep(_cc);
                return mainCategoryRep;
            }
        }

        public IService Services
        {
            get
            {
                if (repRep == null)
                    repRep = new REPORTS_REP(_cc);
                return repRep;
            }
        }

        public int Save()
        {
            return _cc.SaveChanges();
        }
    }
}

