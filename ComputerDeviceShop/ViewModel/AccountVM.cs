using BLL.Interfaces;
using BLL.Models;
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
        private readonly int _customerID;
        private readonly MCustomer customer;

        public AccountVM(ICRUD crud, int customerID)
        {
            _crud = crud;
            _customerID = customerID;
            customer = _crud.GetCustomer(_customerID);

            _userName = customer.Name;
            _userLogin = customer.Login;
            _userPassword = customer.Password;
            _userPhone = customer.Phone;
            _userType = customer.PersonType;

            _welcomeText = "Добро пожаловать, " + _userLogin;
        }

        private string _userName;
        public string UserName
        {
            get
            {
                return _userName;
            }
            set
            {
                _userName = value;
                NotifyPropertyChanged("UserName");
            }
        }
        private string _userLogin;
        public string UserLogin
        {
            get
            {
                return _userLogin;
            }
            set
            {
                _userLogin = value;
                NotifyPropertyChanged("UserLogin");
            }
        }
        private string _userPassword;
        public string UserPassword
        {
            get
            {
                return _userPassword;
            }
            set
            {
                _userPassword = value;
                NotifyPropertyChanged("UserPassword");
            }
        }
        private string _userPhone;
        public string UserPhone
        {
            get
            {
                return _userPhone;
            }
            set
            {
                _userPhone = value;
                NotifyPropertyChanged("UserPhone");
            }
        }
        private string _userType;
        public string UserType
        {
            get
            {
                return _userType;
            }
            set
            {
                _userType = value;
                NotifyPropertyChanged("UserType");
            }
        }
        private string _welcomeText;
        public string WelcomeText
        {
            get
            {
                return _welcomeText;
            }
            set
            {
                _welcomeText = value;
                NotifyPropertyChanged("WelcomeText");
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
