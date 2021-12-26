using BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IAccount
    {
        List<MOrder> GetAllOrdersByStatus(int customerID, int statusID);
        List<MOrder> GetAllOrders(int customerID);
    }
}
