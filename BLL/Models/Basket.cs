using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class MBasket
    {
        public int Id { get; set; }
        public int Amount { get; set; }
        public int Customer { get; set; }
        public int Good { get; set; }
        public MBasket() { }
        public MBasket(Basket b)
        {
            Id = b.id;
            Amount = b.amount;
            Customer = b.customer;
            Good = b.good;
        }

        //Стоимости
        public decimal TotalCost { get; set; }
        public string ShowTotalCost { get; set; }
        public decimal SingleCost { get; set; }
        public string ShowSingleCost { get; set; }

        //Товар в корзине
        public string GoodName { get; set; }
        public string Picture { get; set; }

        //Добавление и удаление
        public bool CanBeAdded { get; set; }
        public bool CanBeRemoved { get; set; }
    }
}
