using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class MManufacturer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public MManufacturer() { }
        public MManufacturer(Manufacturer m)
        {
            Id = m.id;
            Name = m.name;
        }
    }
}
