using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class MSupplier
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Account { get; set; }
        public MSupplier() { }
        public MSupplier(Supplier s)
        {
            Id = s.id;
            Name = s.name;
            Account = s.account_number;
        }
    }
}
