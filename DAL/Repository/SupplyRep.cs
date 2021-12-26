
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class SupplyRep : IRepository<Supply>
    {
        private CourseContext _cc;
        public SupplyRep(CourseContext cc)
        {
            _cc = cc;
        }

        public void Create(Supply item)
        {
            _cc.Supply.Add(item);
        }

        public void Delete(int id)
        {
            Supply item = _cc.Supply.Find(id);
            if (item != null)
            {
                _cc.Supply.Remove(item);
            }
        }

        public Supply Get(int id)
        {
            return _cc.Supply.Find(id);
        }

        public List<Supply> GetList()
        {
            return _cc.Supply.ToList();
        }

        public void Update(Supply item)
        {
            _cc.Entry(item).State = EntityState.Modified;
        }
        public bool Save()
        {
            return _cc.SaveChanges() > 0;
        }
    }
}
