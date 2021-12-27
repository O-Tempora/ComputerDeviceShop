using BLL.Interfaces;
using ComputerDeviceShop.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ComputerDeviceShop.ViewModel
{
    public class UserVM : INotifyPropertyChanged
    {
        #region Поля и свойства
        public delegate void DialogHandler();
        public event DialogHandler Notify;

        private readonly ICRUD _crud;
        private readonly ICatalog _catalog;
        private readonly IMainCategory _maincat;
        private readonly IUser _user;
        private readonly IDialogService _dialog;
        private readonly IMakeOrder _order;
        private readonly IAccount _account;

        private string _actualLogin;
        public string ActualLogin //Поле логина
        {
            get
            {
                return _actualLogin;
            }
            set
            {
                _actualLogin = value;
                NotifyPropertyChanged("ActualLogin");
            }
        }
        private string _actualPassword;
        public string ActualPassword //Поле пароля
        {
            get
            {
                return _actualPassword;
            }
            set
            {
                _actualPassword = value;
                NotifyPropertyChanged("ActualPassword");
            }
        }
        private string _hintAssistTextLogin;
        public string HintAssistTextLogin //Подсказка логина
        {
            get
            {
                return _hintAssistTextLogin;
            }
            set
            {
                _hintAssistTextLogin = value;
                NotifyPropertyChanged("HintAssistTextLogin");
            }
        }
        private string _hintAssistTextPassword;
        public string HintAssistTextPassword //Подсказка пароля
        {
            get
            {
                return _hintAssistTextPassword;
            }
            set
            {
                _hintAssistTextPassword = value;
                NotifyPropertyChanged("HintAssistTextPassword");
            }
        }
        #endregion

        public UserVM(ICRUD crud, ICatalog catalog, IMainCategory maincat, IAccount account, IUser user, IDialogService dialog, IMakeOrder order)
        {
            _crud = crud;
            _catalog = catalog;
            _maincat = maincat;
            _user = user;
            _dialog = dialog;
            _order = order;
            _account = account;

            _actualLogin = "";
            _actualPassword = "";

            _creationWasChosen = "Hidden";
            _creationIsContinued = "Hidden";
            _newLogin = "";
            _newLoginAssist = "";
            _newPassword = "";
            _newPasswordAssist = "";
            _newPasswordRepeat = "";
            _passwordRepeatAssist = "";
            _newName = "";
            _newPhone = "";
            _newNameAssist = "";
            _newPhoneAssist = "";
            _newType = "Физическое";
        }
        #region Авторизация пользователя (при наличии логина/пароля)

        private ICommand _userValidation;
        public ICommand UserValidation
        {
            get
            {
                if (_userValidation == null)
                    _userValidation = new RelayCommand(args => Validate(args));
                return _userValidation;
            }
        }

        private void Validate(object args)
        {
            int validatedCustomerID;
            //Проверка логина
            if (ActualLogin == "")
            {
                HintAssistTextLogin = "Логин не может быть пустым";
                return;
            }
            else HintAssistTextLogin = null;

            if (!_user.LoginVerification(ActualLogin))
            {
                HintAssistTextLogin = "Неверный логин";
                return;
            }
            else HintAssistTextLogin = null;

            //Проверка пароля
            if (ActualPassword == "")
            {
                HintAssistTextPassword = "Пароль не может быть пустым";
                return;
            }
            else HintAssistTextPassword = null;

            if (!_user.PasswordVerification(ActualLogin, ActualPassword))
            {
                HintAssistTextPassword = "Неверный пароль";
                return;
            }
            else HintAssistTextPassword = null;

            validatedCustomerID = _user.GetIdByLogin(ActualLogin);
            _dialog.MW(_crud, _catalog, _maincat, _account, _order, _user, _dialog, validatedCustomerID);
            Notify?.Invoke();
            //Добавить открытие главного окна (+ передать ID пользователя)
        }

        private ICommand _createNewAccount;
        public ICommand CreateNewAccount
        {
            get
            {
                if (_createNewAccount == null)
                    _createNewAccount = new RelayCommand(args => StartRegistration(args));
                return _createNewAccount;
            }
        }

        private void StartRegistration(object args)
        {
            CreationWasChosen = "Visible";
        }

        #endregion

        #region Регистрация нового пользователя

        private string _creationWasChosen;
        public string CreationWasChosen
        {
            get
            {
                return _creationWasChosen;
            }
            set
            {
                _creationWasChosen = value;
                NotifyPropertyChanged("CreationWasChosen");
            }
        }
        private string _newLogin;
        public string NewLogin
        {
            get
            {
                return _newLogin;
            }
            set
            {
                _newLogin = value;
                NotifyPropertyChanged("NewLogin");
            }
        }
        private string _newPassword;
        public string NewPassword
        {
            get
            {
                return _newPassword;
            }
            set
            {
                _newPassword = value;
                NotifyPropertyChanged("NewPassword");
            }
        }
        private string _newPasswordRepeat;
        public string NewPasswordRepeat
        {
            get
            {
                return _newPasswordRepeat;
            }
            set
            {
                _newPasswordRepeat = value;
                NotifyPropertyChanged("NewPasswordRepeat");
            }
        }
        private string _newLoginAssist;
        public string NewLoginAssist
        {
            get
            {
                return _newLoginAssist;
            }
            set
            {
                _newLoginAssist = value;
                NotifyPropertyChanged("NewLoginAssist");
            }
        }
        private string _newPasswordAssist;
        public string NewPasswordAssist
        {
            get
            {
                return _newPasswordAssist;
            }
            set
            {
                _newPasswordAssist = value;
                NotifyPropertyChanged("NewPasswordAssist");
            }
        }
        private string _passwordRepeatAssist;
        public string PasswordRepeatAssist
        {
            get
            {
                return _passwordRepeatAssist;
            }
            set
            {
                _passwordRepeatAssist = value;
                NotifyPropertyChanged("PasswordRepeatAssist");
            }
        }
        private ICommand _hideRegistration;
        public ICommand HideRegistration
        {
            get
            {
                if (_hideRegistration == null)
                    _hideRegistration = new RelayCommand(args => DoHideRegistration(args));
                return _hideRegistration;
            }
        }

        private void DoHideRegistration(object args)
        {
            CreationWasChosen = "Hidden";
        }

        private ICommand _continueRegistration;
        public ICommand ContinueRegistration
        {
            get
            {
                if (_continueRegistration == null)
                    _continueRegistration = new RelayCommand(args => DoContinueRegistration(args));
                return _continueRegistration;
            }
        }
        private string _creationIsContinued;
        public string CreationIsContinued
        {
            get
            {
                return _creationIsContinued;
            }
            set
            {
                _creationIsContinued = value;
                NotifyPropertyChanged("CreationIsContinued");
            }
        }

        private void DoContinueRegistration(object args)
        {
            if (NewLogin == "")
            {
                NewLoginAssist = "Логин не может быть пустым";
                return;
            }
            else NewLoginAssist = null;

            if (NewPassword == "")
            {
                NewPasswordAssist = "Пароль не может быть пустым";
                return;
            }
            else NewPasswordAssist = null;

            if (NewPasswordRepeat != NewPassword)
            {
                PasswordRepeatAssist = "Пароли не совпадают";
                return;
            }
            else PasswordRepeatAssist = null;

            if (_user.LoginVerification(NewLogin))
            {
                NewLoginAssist = "Введенный логин занят";
                return;
            }
            else NewLoginAssist = null;

            CreationIsContinued = "Visible";
        }

        private string _newName;
        public string NewName
        {
            get
            {
                return _newName;
            }
            set
            {
                _newName = value;
                NotifyPropertyChanged("NewName");
            }
        }

        private string _newPhone;
        public string NewPhone
        {
            get
            {
                return _newPhone;
            }
            set
            {
                _newPhone = value;
                NotifyPropertyChanged("NewPhone");
            }
        }

        private string _newNameAssist;
        public string NewNameAssist
        {
            get
            {
                return _newNameAssist;
            }
            set
            {
                _newNameAssist = value;
                NotifyPropertyChanged("NewNameAssist");
            }
        }

        private string _newPhoneAssist;
        public string NewPhoneAssist
        {
            get
            {
                return _newPhoneAssist;
            }
            set
            {
                _newPhoneAssist = value;
                NotifyPropertyChanged("NewPhoneAssist");
            }
        }

        private string _newType;
        public string NewType
        {
            get
            {
                return _newType;
            }
            set
            {
                _newType = value;
                NotifyPropertyChanged("NewType");
            }
        }

        private ICommand _hideRegistrationData;
        public ICommand HideRegistrationData
        {
            get
            {
                if (_hideRegistrationData == null)
                    _hideRegistrationData = new RelayCommand(args => DoHideRegistrationData(args));
                return _hideRegistrationData;
            }
        }

        private void DoHideRegistrationData(object args)
        {
            CreationIsContinued = "Hidden";
        }

        private ICommand _finishRegistration;
        public ICommand FinishRegistration
        {
            get
            {
                if (_finishRegistration == null)
                    _finishRegistration = new RelayCommand(args => ConfirmNewUser(args));
                return _finishRegistration;
            }
        }

        private void ConfirmNewUser(object args)
        {
            if (NewPhone == "")
            {
                NewPhoneAssist = "Номер телефона не может быть пустым";
                return;
            }
            else NewPhoneAssist = null;

            if (NewName == "")
            {
                NewNameAssist = "Имя не может быть пустым";
                return;
            }
            else NewNameAssist = null;

            _crud.CreateCustomer(new BLL.Models.MCustomer
            {
                Name = NewName,
                Login = NewLogin,
                Password = NewPassword,
                Phone = NewPhone,
                PersonType = NewType
            });

            NewLogin = "";
            NewPassword = "";
            NewPasswordRepeat = "";
            NewName = "";

            CreationWasChosen = "Hidden";
            CreationIsContinued = "Hidden";
        }

        #endregion

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
