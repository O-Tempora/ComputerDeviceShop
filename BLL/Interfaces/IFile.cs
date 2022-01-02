using BLL.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IFile
    {
        void PrintChck(int orderID);
        void ManagerOrdersReport(ObservableCollection<MOrder> orders, DateTime startDate, DateTime endDate);
        void ManagerSuppliesReport(ObservableCollection<MSupply> supplies, DateTime startDate, DateTime endDate);
    }
}
 