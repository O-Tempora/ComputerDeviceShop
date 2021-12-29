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
    public class Manager_SuppliesVM : INotifyPropertyChanged
    {
        private readonly ICRUD _crud;
        private readonly IAccount _account;
        private readonly IMakeOrder _order;
        private readonly IFile _file;
        private ObservableCollection<MSupply> _supplies;
        public ObservableCollection<MSupply> Supplies
        {
            get
            {
                return _supplies;
            }
            set
            {
                _supplies = value;
                NotifyPropertyChanged("Supplies");
            }
        }

        private ObservableCollection<MSupplier> _suppliers;
        public ObservableCollection<MSupplier> Suppliers
        {
            get
            {
                return _suppliers;
            }
            set
            {
                _suppliers = value;
                NotifyPropertyChanged("Suppliers");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public Manager_SuppliesVM(ICRUD crud, IAccount account, IMakeOrder order, IFile file)
        {
            _crud = crud;
            _account = account;
            _order = order;
            _file = file;

            _selectedSupplier = 1;
            _startDate = DateTime.Parse("01/01/2010", System.Globalization.CultureInfo.InvariantCulture);
            _endDate = DateTime.Now;
            Supplies = new ObservableCollection<MSupply>();
            _suppliers = new ObservableCollection<MSupplier>();

            var sups = _crud.GetSuppliers();
            foreach(var item in sups)
            {
                _suppliers.Add(item);
            }
            Reevaluate();
        }

        private void Reevaluate()
        {
            Supplies.Clear();
            var supplies = _account.ManagerSuppliesByDateAndSupplier(StartDate, EndDate, SelectedSupplier + 1);
            foreach (var i in supplies)
            {
                Supplies.Add(i);
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

        private int _selectedSupplier;
        public int SelectedSupplier
        {
            get
            {
                return _selectedSupplier;
            }
            set
            {
                _selectedSupplier = value;
                NotifyPropertyChanged("SelectedSupplier");
            }
        }
        private ICommand _filter;
        public ICommand Filter
        {
            get
            {
                if (_filter == null)
                    _filter = new RelayCommand(args => FilterSupplies(args));
                return _filter;
            }
        }

        private void FilterSupplies(object args)
        {
            Reevaluate();
        }
    }
}
