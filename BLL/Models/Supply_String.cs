using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class MSupply_String 
    {
        public int Amount { get; set; }
        public decimal Cost { get; set; }
        public int SSGood { get; set; }
        public int SSSupply { get; set; }
        public int Id { get; set; }
        public MSupply_String() { }
        public MSupply_String(Supply_String ss)
        {
            Amount = ss.amount;
            Cost = ss.cost;
            SSGood = ss.good;
            SSSupply = ss.supply;
            Id = ss.id;
        }

        public string GoodName { get; set; }
        public string ShowCost { get; set; }
        public string ShowAmount { get; set; }
    }
}
