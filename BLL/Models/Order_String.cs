using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class MOrder_String
    {
        public int Amount { get; set; }
        public decimal Cost { get; set; }
        public int OSGood { get; set; }
        public int OSOrder { get; set; }
        public int Id { get; set; }
        public MOrder_String() { }
        public MOrder_String(Order_String os)
        {
            Amount = os.amount;
            Cost = os.cost;
            OSGood = os.good;
            OSOrder = os.ord;
            Id = os.id;
        }

        public string GoodName { get; set; }
        public string ShowCost { get; set; }
        public string ShowAmount { get; set; }
        public string Picture { get; set; }
    }
}
