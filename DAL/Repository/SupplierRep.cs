
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class SupplierRep : IRepository<Supplier>
    {
        private CourseContext _cc;
        public SupplierRep(CourseContext cc)
        {
            _cc = cc;
        }

        public void Create(Supplier item)
        {
            _cc.Supplier.Add(item);
        }

        public void Delete(int id)
        {
            Supplier item = _cc.Supplier.Find(id);
            if (item != null)
            {
                _cc.Supplier.Remove(item);
            }
        }

        public Supplier Get(int id)
        {
            return _cc.Supplier.Find(id);
        }

        public List<Supplier> GetList()
        {
            return _cc.Supplier.ToList();
        }

        public void Update(Supplier item)
        {
            _cc.Entry(item).State = EntityState.Modified;
        }
        public bool Save()
        {
            return _cc.SaveChanges() > 0;
        }
    }
}
