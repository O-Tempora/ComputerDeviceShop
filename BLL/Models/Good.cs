using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class MGood : INotifyPropertyChanged
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }
        public decimal Cost { get; set; }
        public string Specifications { get; set; }
        public decimal ActualCost { get; set; } //Реальная стоимость
        public string ShowCost { get; set; } //Для отображения(!) цены
        public decimal? Discount { get; set; }
        public string ShowDiscount { get; set; } //Для отображения(!) скидки
        public int GManufacturer { get; set; }
        public int Warranty { get; set; }
        public int GCategory { get; set; }
        public string Picture { get; set; }
        public MGood() { }
        public MGood(Good g)
        {
            Id = g.id;
            Name = g.name;
            Amount = g.current_amount;
            Cost = g.cost;
            GManufacturer = g.manufacturer;
            Discount = g.discount;
            Warranty = g.warranty;
            GCategory = g.category;
            Picture = g.picture;
            ActualCost = (decimal)(Cost - Cost * Discount);
            Specifications = g.specifications;
            ShowCost = $"{this.Cost:0.#} руб.";
            if (this.Discount != 0)
            {
                ShowDiscount = $"Скидка: {this.Discount * 100:0.#}%";
            }
            else
            {
                ShowDiscount = "";
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
