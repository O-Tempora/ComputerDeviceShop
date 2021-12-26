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
using GalaSoft.MvvmLight.Messaging;
using ComputerDeviceShop.View;

namespace ComputerDeviceShop.ViewModel
{
    public class CatalogVM : INotifyPropertyChanged
    {
        #region Поля и свойства доступа
        private readonly ICRUD _crud;
        private readonly ICatalog _catalog;
        private readonly IMainCategory _maincat;
        private int _id;

        public ObservableCollection<MMainCategory> Mains { get; set; }
        private ObservableCollection<MGood> _Goods { get; set; }
        public ObservableCollection<MGood> Goods
        {
            get
            {
                return _Goods;
            }
            set
            {
                _Goods = value;
                NotifyPropertyChanged("Goods");
            }
        }
        #endregion
        public CatalogVM(ICRUD crud, ICatalog catalog, IMainCategory maincat, int customerID)
        {
            _crud = crud;
            _catalog = catalog;
            _maincat = maincat;
            _id = customerID;

            var mains = _maincat.GetMainCategories(); //Получение главных категорий
            Mains = new ObservableCollection<MMainCategory>();
            foreach(var item in mains)
            {
                Mains.Add(item);
            }

            var goods = _crud.GetGoods(); //Получение всех товаров
            _Goods = new ObservableCollection<MGood>();
            foreach (var item in goods)
            {
                _Goods.Add(item);
            }
        }

        #region Сортировка по категории
        private string _categ;
        private ICommand _SelectedItemChangedCommand;
        public ICommand SelectedItemChangedCommand
        {
            get
            {
                if (_SelectedItemChangedCommand == null)
                {
                    _SelectedItemChangedCommand = new RelayCommand(args => SelectedItemChanged(args));
                }

                return _SelectedItemChangedCommand;
            }
        }

        private void SelectedItemChanged(object args)
        {
            _categ = args.ToString();
            Goods = new ObservableCollection<MGood>();
            var goods = _catalog.GoodsCategoryFilter(_categ);
            foreach (var item in goods)
            {
                item.ShowCost = $"{item.Cost:0.#} руб.";
                if(item.Discount != 0)
                {
                    item.ShowDiscount = $"Скидка: {item.Discount * 100:0.#}%";
                }
                else
                {
                    item.ShowDiscount = "";
                }
                Goods.Add(item);
            }
        }

        #endregion

        #region Информация о товаре
        private ICommand _listViewSelectedCommand;
        public ICommand SelectedIndexChangedCommand
        {
            get
            {
                if (_listViewSelectedCommand == null)
                    _listViewSelectedCommand = new RelayCommand(args => SelectedIndexChanged(args));
                return _listViewSelectedCommand;
            }
        }
        #region Описание товара
        private string _name;
        private string _specific;
        private string _warranty;
        private string _picture;
        private string _cost;
        private string _discount;
        private int _goodID;
        private string _amount;
        private string _actualCost;
        private bool _isAddable;

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                NotifyPropertyChanged("Name");
            }
        }
        public string Specific
        {
            get
            {
                return _specific;
            }
            set
            {
                _specific = value;
                NotifyPropertyChanged("Specific");
            }
        }
        public string Warranty
        {
            get
            {
                return _warranty;
            }
            set
            {
                _warranty = value;
                NotifyPropertyChanged("Warranty");
            }
        }
        public string Picture
        {
            get
            {
                return _picture;
            }
            set
            {
                _picture = value;
                NotifyPropertyChanged("Picture");
            }
        }
        public string Cost
        {
            get
            {
                return _cost;
            }
            set
            {
                _cost = value;
                NotifyPropertyChanged("Cost");
            }
        }
        public string ActualCost
        {
            get
            {
                return _actualCost;
            }
            set
            {
                _actualCost = value;
                NotifyPropertyChanged("ActualCost");
            }
        }
        public string Discount
        {
            get
            {
                return _discount;
            }
            set
            {
                _discount = value;
                NotifyPropertyChanged("Discount");
            }
        }
        public string Amount
        {
            get
            {
                return _amount;
            }
            set
            {
                _amount = value;
                NotifyPropertyChanged("Amount");
            }
        }
        public bool IsAddable
        {
            get
            {
                return _isAddable;
            }
            set
            {
                _isAddable = value;
                NotifyPropertyChanged("Amount");
            }
        }
        #endregion

        private void SelectedIndexChanged(object args)
        {
            if ((int)args != -1)
            {
                _goodID = Goods[(int)args].Id;
                var selectedGood = _crud.GetGood(_goodID);

                //Описание свойств
                Name = selectedGood.Name;
                Specific = "Описание:\n" + selectedGood.Specifications;
                Amount = "Доступно на складе: " + $"{selectedGood.Amount:0.#}" + " шт.";
                Discount = "Скидка: " + $"{selectedGood.Discount * 100:0.#}" + "%";
                Cost = "Стоимость: " + $"{selectedGood.Cost:0.#}" + " руб.";
                ActualCost = "Стоимость со скидкой: " + $"{selectedGood.ActualCost:0.#}" + " руб.";
                Picture = selectedGood.Picture;
                Warranty = "Гарантия: " + $"{ selectedGood.Warranty:0.#}" + " мес.";
                IsAddable = (selectedGood.Amount > 0);
            }
        }
        #endregion

        #region Добавить выбранный товар в корзину
        private ICommand _Add;
        public ICommand Add
        {
            get
            {
                if (_Add == null)
                    _Add = new RelayCommand(args => ReevaluateBasket(args));
                return _Add;
            }
        }

        private void ReevaluateBasket(object args)
        {
            MBasket basket = new MBasket();
            basket.Good = _goodID;
            basket.Customer = _id;
            _crud.CreateBasket(basket);
            Messenger.Default.Send(new GenericMessage<MBasket>(null));
        }
        #endregion

        //private bool _infoIsVisible;
        //public bool InfoIsVisible
        //{
        //    get
        //    {
        //        return _infoIsVisible;
        //    }
        //    set
        //    {
        //        _infoIsVisible = value;
        //        NotifyPropertyChanged("InfoIsVisible");
        //    }
        //}
        //private ICommand _backToCatalog;
        //public ICommand BackToCatalog
        //{
        //    get
        //    {
        //        if (_backToCatalog == null)
        //        {
        //            _backToCatalog = new RelayCommand(args => ToCatalog(args));
        //        }

        //        return _backToCatalog;
        //    }
        //}

        //private void ToCatalog(object args)
        //{
        //    InfoIsVisible = false;
        //}
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}