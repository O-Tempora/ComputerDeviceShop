using BLL.Interfaces;
using BLL.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerDeviceShop.ViewModel
{
    public class Account_OrdersVM : INotifyPropertyChanged
    {
        private readonly ICRUD _crud;
        private readonly IAccount _account;
        private int _customerID;
        public Account_OrdersVM(ICRUD crud, IAccount account, int id)
        {
            _crud = crud;
            _account = account;
            _customerID = id;
            Orders = new ObservableCollection<MOrder>();
            Statuses = new ObservableCollection<MStatus>();
            var stats = _crud.GetStatuses();
            foreach (var item in stats)
            {
                Statuses.Add(item);
            }
        }

        private ObservableCollection<MOrder> _orders;
        public ObservableCollection<MOrder> Orders
        {
            get
            {
                return _orders;
            }
            set
            {
                _orders = value;
                NotifyPropertyChanged("Orders");
            }
        }
        public ObservableCollection<MStatus> Statuses;

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
