using BLL.Interfaces;
using BLL.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

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
            //_selectedStatus = 1;
            ReevaluateOrders();
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
        public ObservableCollection<MStatus> Statuses { get; set; }
        private int _selectedStatus;
        public int SelectedStatus
        {
            get
            {
                return _selectedStatus;
            }
            set
            {
                _selectedStatus = value;
                NotifyPropertyChanged("SelectedStatus");
            }
        }

        public void ReevaluateOrders()
        {
            var orders = _account.GetAllOrders(_customerID);
            Orders.Clear();
            foreach (var ord in orders) 
            {
                ord.ShowTotal = "Стоимость: " + ord.Cost + " руб.";
                ord.ShowStatus = "Статус: " + ord.StatusName;
                ord.ShowNumber = "Номер заказа: " + ord.Id;
                ord.ShowOrderDate = "Дата заказа: " + ord.OrdOrder;
                if (ord.ArrOrder == null)
                {
                    ord.ShowArrivalDate = "Дата доставки: в процессе доставки";
                }
                else ord.ShowArrivalDate = "Дата доставки: " + ord.ArrOrder;
                Orders.Add(ord);
            }
        }

        private ICommand _getAllCommand;
        public ICommand GetAllCommand
        {
            get
            {
                if (_getAllCommand == null)
                    _getAllCommand = new RelayCommand(args => GetAll(args));
                return _getAllCommand;
            }
        }

        private void GetAll(object args)
        {
            ReevaluateOrders();
        }

        private ICommand _getByStatusCommand;
        public ICommand GetByStatusCommand
        {
            get
            {
                if (_getByStatusCommand == null)
                    _getByStatusCommand = new RelayCommand(args => GetByStatus(args));
                return _getByStatusCommand;
            }
        }

        private void GetByStatus(object args)
        {
            var orders = _account.GetAllOrdersByStatus(_customerID, SelectedStatus + 1);
            Orders.Clear();
            foreach (var ord in orders)
            {
                ord.ShowTotal = "Стоимость: " + ord.Cost + " руб.";
                ord.ShowStatus = "Статус: " + ord.StatusName;
                ord.ShowNumber = "Номер заказа: " + ord.Id;
                ord.ShowOrderDate = "Дата заказа: " + ord.OrdOrder;
                if (ord.ArrOrder == null)
                {
                    ord.ShowArrivalDate = "Дата доставки: в процессе доставки";
                }
                else ord.ShowArrivalDate = "Дата доставки: " + ord.ArrOrder;
                Orders.Add(ord);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
