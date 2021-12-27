using BLL.Interfaces;
using BLL.Models;
using GalaSoft.MvvmLight.Messaging;
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
    public class BasketVM : INotifyPropertyChanged
    {
        private readonly ICRUD _crud;
        private readonly ICatalog _catalog;
        private readonly IMainCategory _maincat;
        private readonly IMakeOrder _order;
        private readonly int _userID;
        public delegate void DialogHandler(int id);
        public event DialogHandler OrderSuccessfullyMade;
        public BasketVM(ICRUD crud, ICatalog catalog, IMainCategory maincat, IMakeOrder order, int userID)
        {
            _crud = crud;
            _catalog = catalog;
            _maincat = maincat;
            _userID = userID;
            _order = order;

            OrderShowVisibility = "Hidden";
            OrderIsAvailable = false;
            _resultingText = "";
            _resultingMessageVisibility = "Hidden";

            ReevaluateOrder();

            Messenger.Default.Register<GenericMessage<MBasket>>(this, Update);
        }

        private void Update(GenericMessage<MBasket> obj)
        {
            ReevaluateOrder();
        }

        #region Свойства и поля
        private ObservableCollection<MBasket> _basket;
        public ObservableCollection<MBasket> Basket
        {
            get
            {
                return _basket;
            }
            set
            {
                _basket = value;
                NotifyPropertyChanged("Basket");
            }
        }
        private string _orderShowVisibility;
        public string OrderShowVisibility
        {
            get
            {
                return _orderShowVisibility;
            }
            set
            {
                _orderShowVisibility = value;
                NotifyPropertyChanged("OrderShowVisibility");
            }
        }
        private bool _orderIsAvailable;
        public bool OrderIsAvailable
        {
            get
            {
                return _orderIsAvailable;
            }
            set
            {
                _orderIsAvailable = value;
                NotifyPropertyChanged("OrderIsAvailable");
            }
        }
        private string _viewTotal;
        public string ViewTotal
        {
            get
            {
                return _viewTotal;
            }
            set
            {
                _viewTotal = value;
                NotifyPropertyChanged("ViewTotal");
            }
        }
        private decimal _totalCost;
        #endregion
        private void ReevaluateOrder()
        {
            Basket = new ObservableCollection<MBasket>();
            var items = _order.GetBasket(_userID);
            _totalCost = 0;
            if (Basket.Count != 0) //Есть ли товары в корзине
            {
                OrderIsAvailable = true;
            }
            else
            {
                OrderIsAvailable = false;
            }
            foreach (var item in items)
            {
                MGood good = _crud.GetGood(item.Good);
                if (item.Amount == good.Amount) //Можно добавить
                {
                    item.CanBeAdded = false;
                }
                else item.CanBeAdded = true;

                if (item.Amount == 1) //Можно убрать
                {
                    item.CanBeRemoved = false;
                }
                else item.CanBeRemoved = true;

                item.ShowTotalCost = $"Всего: {item.TotalCost:0.#} руб.";
                item.ShowSingleCost = $"Стоимость 1: {item.SingleCost:0.#} руб.";
                Basket.Add(item);
                _totalCost += item.TotalCost;
            }
            ViewTotal = $"Итого: {_totalCost:0.#} руб.";
        }

        #region Операции с товаром

        private ICommand _increaseGoodCommand;
        public ICommand IncreaseGoodCommand //Товар + 1
        {
            get
            {
                if (_increaseGoodCommand == null)
                    _increaseGoodCommand = new RelayCommand(args => Increase(args));
                return _increaseGoodCommand;
            }
        }

        private void Increase(object args)
        {
            Basket[(int)args].Amount++;
            _crud.UpdateBasket(Basket[(int)args]);
            ReevaluateOrder();
        }

        private ICommand _decreaseGoodCommand;
        public ICommand DecreaseGoodCommand //Товар -1
        {
            get
            {
                if (_decreaseGoodCommand == null)
                    _decreaseGoodCommand = new RelayCommand(args => Decrease(args));
                return _decreaseGoodCommand;
            }
        }

        private void Decrease(object args)
        {
            if (Basket[(int)args].Amount > 0)
            {
                Basket[(int)args].Amount--;
                _crud.UpdateBasket(Basket[(int)args]);
                ReevaluateOrder();
            }
        }

        private ICommand _clearCommand;
        public ICommand ClearCommand //Удалить
        {
            get
            {
                if (_clearCommand == null)
                    _clearCommand = new RelayCommand(args => Clear(args));
                return _clearCommand;
            }
        }

        private void Clear(object args)
        {
            _crud.DeleteBasket(Basket[(int)args].Id);
            ReevaluateOrder();
        }

        #endregion

        #region Сделать заказ

        private ICommand _makeOrder;
        public ICommand MakeOrder
        {
            get
            {
                if (_makeOrder == null)
                    _makeOrder = new RelayCommand(args => ShowMakeOrder(args));
                return _makeOrder;
            }
        }

        private void ShowMakeOrder(object args)
        {
            OrderShowVisibility = "Visible";
        }
        private ICommand _undoOrder;
        public ICommand UndoOrder
        {
            get
            {
                if (_undoOrder == null)
                    _undoOrder = new RelayCommand(args => HideMakeOrder(args));
                return _undoOrder;
            }
        }

        private void HideMakeOrder(object args)
        {
            OrderShowVisibility = "Hidden";
        }

        private ICommand _finishOrder;
        public ICommand FinishOrder
        {
            get
            {
                if (_finishOrder == null)
                    _finishOrder = new RelayCommand(args => Finish(args));
                return _finishOrder;
            }
        }

        private void Finish(object args)
        {
            try
            {
                ResultingMessageVisibility = "Visible";
                if (Basket == null || Basket.Count == 0)
                {
                    ResultingText = "Ваша корзина пуста!";
                    return;
                }
                if (_order.MakeOrder(_userID, _totalCost, Basket) == 1)
                {
                    ResultingText = "Заказ успешно создан";
                    OrderSuccessfullyMade?.Invoke(0);
                }
            }
            catch (Exception e)
            {
                ResultingText = "Ошибка в создании заказа";
            }
            finally
            {
                ReevaluateOrder();
            }
        }

        private string _resultingText;
        public string ResultingText
        {
            get
            {
                return _resultingText;
            }
            set
            {
                _resultingText = value;
                NotifyPropertyChanged("ResultingText");
            }
        }
        private string _resultingMessageVisibility;
        public string ResultingMessageVisibility
        {
            get
            {
                return _resultingMessageVisibility;
            }
            set
            {
                _resultingMessageVisibility = value;
                NotifyPropertyChanged("ResultingMessageVisibility");
            }
        }

        private ICommand _return;
        public ICommand Return
        {
            get
            {
                if (_return == null)
                    _return = new RelayCommand(args => ReturnToBasket(args));
                return _return;
            }
        }

        private void ReturnToBasket(object args)
        {
            ResultingMessageVisibility = "Hidden";
        }

        #endregion

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
