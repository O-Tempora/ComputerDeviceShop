using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class MCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Main { get; set; }
        public MCategory() { }
        public MCategory(Category c)
        {
            Id = c.id;
            Name = c.name;
            Main = c.main;
        }
    }
}
