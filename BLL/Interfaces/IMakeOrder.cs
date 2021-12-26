using BLL.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IMakeOrder
    {
        List<MBasket> GetBasket(int id);
        int MakeOrder(int customerID, decimal totalCost, ObservableCollection<MBasket> basket);
    }
}
