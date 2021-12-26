using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class MSupply
    {
        public int Id { get; set; }
        public decimal Cost { get; set; }
        public int SSupplier { get; set; }
        public DateTime OrdSupply { get; set; }
        public DateTime ArrSupply { get; set; }
        public MSupply() { }
        public MSupply(Supply s)
        {
            Id = s.id;
            Cost = s.total_cost;
            SSupplier = s.supplier;
            OrdSupply = s.order_date;
            ArrSupply = (DateTime)s.arrival_date;
        }
    }
}
