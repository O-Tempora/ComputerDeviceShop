using BLL.Interfaces;
using BLL.Models;
using ComputerDeviceShop.Util;
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
    public class Manager_OrdersVM : INotifyPropertyChanged
    {
        private readonly ICRUD _crud;
        private readonly IAccount _account;
        private readonly IMakeOrder _order;
        private readonly IFile _file;

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

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public Manager_OrdersVM(ICRUD crud, IAccount account, IMakeOrder order, IFile file)
        {
            _crud = crud;
            _account = account;
            _order = order;
            _file = file;

            _startDate = DateTime.Parse("01/01/2010", System.Globalization.CultureInfo.InvariantCulture);
            _endDate = DateTime.Now;
            _idText = "";
            IdText = "";
            Orders = new ObservableCollection<MOrder>();
            Reevaluate();
        }

        private void Reevaluate()
        {
            Orders.Clear();
            var orders = _account.ManagerOrdersByDateAndStatus(StartDate, EndDate, 1, IdText);
            foreach (var i in orders)
            {
                if (i.OStatus == 2) 
                    i.ButtonStatus = "Доставить";
                else 
                    i.ButtonStatus = "Отметить";

                i.ShowOrderDate = i.OrdOrder.ToShortDateString();
                i.ShowNumber = $"Номер заказа: {i.Id}";
                Orders.Add(i);
            }
        }

        private string _idText;
        public string IdText
        {
            get
            {
                return _idText;
            }
            set
            {
                _idText = value;
                NotifyPropertyChanged("IdText");
            }
        }

        private DateTime _startDate;
        public DateTime StartDate
        {
            get
            {
                return _startDate;
            }
            set
            {
                _startDate = value;
                NotifyPropertyChanged("StartDate");
            }
        }

        private DateTime _endDate;
        public DateTime EndDate
        {
            get
            {
                return _endDate;
            }
            set
            {
                _endDate = value;
                NotifyPropertyChanged("EndDate");
            }
        }
        private string _buttonText;
        public string ButtonText
        {
            get
            {
                return _buttonText;
            }
            set
            {
                _buttonText = value;
                NotifyPropertyChanged("ButtonText");
            }
        }

        private ICommand _change;
        public ICommand Change
        {
            get
            {
                if (_change == null)
                    _change = new RelayCommand(args => ChangeStatus(args));
                return _change;
            }
        }

        private void ChangeStatus(object args)
        {
            if (Orders[(int)args].ShowStatus == "Рассматривается")
            {
                Orders[(int)args].OStatus = 2;
                _crud.UpdateOrder(Orders[(int)args]);
            }
            else if (Orders[(int)args].ShowStatus == "Доставляется")
            {
                Orders[(int)args].OStatus = 4;
                _crud.UpdateOrder(Orders[(int)args]);
            }
            else if (Orders[(int)args].ShowStatus == "Собирается")
            {
                Orders[(int)args].OStatus = 3;
                _crud.UpdateOrder(Orders[(int)args]);
            }
            Reevaluate();
        }

        private ICommand _filter;
        public ICommand Filter
        {
            get
            {
                if (_filter == null)
                    _filter = new RelayCommand(args => FilterOrders(args));
                return _filter;
            }
        }
        private ICommand _pdf;
        public ICommand PDF
        {
            get
            {
                if (_pdf == null)
                    _pdf = new RelayCommand(args => OrdersReport(args));
                return _pdf;
            }
        }

        private void OrdersReport(object args)
        {
            _file.ManagerOrdersReport(Orders, StartDate, EndDate);
        }

        private void FilterOrders(object args)
        {
            Reevaluate();
        }
    }
}
