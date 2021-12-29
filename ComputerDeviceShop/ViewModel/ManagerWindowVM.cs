using BLL.Interfaces;
using ComputerDeviceShop.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerDeviceShop.ViewModel
{
    public class ManagerWindowVM : INotifyPropertyChanged
    {
        public Manager_OrdersVM Manager_Orders_View_M { get; set; }
        public Manager_SuppliesVM Manager_Supplies_View_M { get; set; }
        public ManagerWindowVM(ICRUD crud, ICatalog catalog, IMainCategory maincateg, IAccount account, IMakeOrder order, IUser user, IDialogService dialog, int id, IFile file)
        {
            Manager_Orders_View_M = new Manager_OrdersVM(crud, account, order, file);
            Manager_Supplies_View_M = new Manager_SuppliesVM(crud, account, order, file);
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
