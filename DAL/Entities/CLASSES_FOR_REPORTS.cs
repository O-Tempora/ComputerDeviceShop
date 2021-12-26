using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class CatalogGood //Для отображения товаров в каталоге
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Picture { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public string ShowDiscount { get; set; }
        public string ShowCost { get; set; }
    }
    public class BasketReport //Для отображения в корзине
    {
        public int Id { get; set; }
        public int Amount { get; set; }
        public decimal TotalCost { get; set; }
        public decimal SigleCost { get; set; }
        public int Customer { get; set; }
        public int Good { get; set; }
        public string GoodPicture { get; set; }
        public string Goodname { get; set; }
    }
}
