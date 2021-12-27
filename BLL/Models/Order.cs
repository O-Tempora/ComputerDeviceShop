using DAL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class MOrder
    {
        public int Id { get; set; }
        public decimal Cost { get; set; }
        public DateTime OrdOrder { get; set; }
        public DateTime ArrOrder { get; set; }
        public int OStatus { get; set; }
        public int OCustomer { get; set; }
        public string StatusName { get; set; }
        public ObservableCollection<MOrder_String> Ostrings { get; set; }
        public MOrder() { }
        public MOrder(Order o)
        {
            Id = o.id;
            Cost = o.total_cost;
            OrdOrder = o.order_date;
            ArrOrder = (DateTime)o.arrival_date;
            OStatus = o.status;
            OCustomer = o.customer;
        }

        public string ShowNumber { get; set; }
        public string ShowOrderDate { get; set; }
        public string ShowArrivalDate { get; set; }
        public string ShowStatus { get; set; }
        public string ShowTotal { get; set; }
    }
}
