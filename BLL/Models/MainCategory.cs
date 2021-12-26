using DAL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class MMainCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ObservableCollection<MCategory> Categories { get; set; }
        public MMainCategory() { }
        public MMainCategory(MMainCategory mc)
        {
            this.Id = mc.Id;
            this.Name = mc.Name;
            Categories = mc.Categories;
        }
    }
}
