using BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerDeviceShop.ViewModel
{
    public class AccountVM : INotifyPropertyChanged
    {
        private readonly ICRUD _crud;
        private readonly IAccount _account;
        private readonly ICatalog _catalog;
        private readonly IMainCategory _maincateg;
        private readonly IMakeOrder _order;
        private readonly int _userID;
        public Account_AboutVM Account_About_View_M { get; set; }
        public Account_OrdersVM Account_Orders_View_M { get; set; }
        public Account_StatsVM Account_Stats_View_M { get; set; }

        public AccountVM(ICRUD crud, IAccount account, ICatalog catalog, IMainCategory maincateg, IMakeOrder order, int userID)
        {
            _crud = crud;
            _account = account;
            _catalog = catalog;
            _maincateg = maincateg;
            _order = order;
            _userID = userID;

            Account_About_View_M = new Account_AboutVM(_crud, _userID);
            Account_Orders_View_M = new Account_OrdersVM(_crud, _account, _userID);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
