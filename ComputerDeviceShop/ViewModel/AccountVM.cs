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
        public AccountVM(ICRUD crud)
        {
            _crud = crud;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
