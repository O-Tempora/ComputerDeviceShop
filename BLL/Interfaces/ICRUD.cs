using BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface ICRUD
    {
        //************Получение списков*************
        List<MGood> GetGoods();
        List<MCategory> GetCategories();
        List<MManufacturer> GetManufacturers();
        List<MOrder> GetOrders();
        List<MStatus> GetStatuses();
        List<MCustomer> GetCustomers();
        List<MSupply> GetSupplies();
        List<MSupplier> GetSuppliers();
        List<MSupply_String> GetSupStrings();
        List<MOrder_String> GetOrdStrings();
        List<MBasket> GetBaskets();

        //************Получение объектов*************
        MGood GetGood(int id);
        MCategory GetCategory(int id);
        MManufacturer GetManufacturer(int id);
        MSupply GetSupply(int id);
        MSupplier GetSupplier(int id);
        MCustomer GetCustomer(int id);
        MOrder GetOrder(int id);
        MMainCategory GetMainCategory(int id);
        MBasket GetBasket(int id);
        void CreateBasket(MBasket basket);
        void UpdateBasket(MBasket basket);
        void DeleteBasket(int id);
        void CreateCustomer(MCustomer customer);
    }
}
