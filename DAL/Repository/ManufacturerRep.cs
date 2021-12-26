
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class ManufacturerRep : IRepository<Manufacturer>
    {
        private CourseContext _cc;
        public ManufacturerRep(CourseContext cc)
        {
            _cc = cc;
        }

        public void Create(Manufacturer item)
        {
            _cc.Manufacturer.Add(item);
        }

        public void Delete(int id)
        {
            Manufacturer item = _cc.Manufacturer.Find(id);
            if (item != null)
            {
                _cc.Manufacturer.Remove(item);
            }
        }

        public Manufacturer Get(int id)
        {
            return _cc.Manufacturer.Find(id);
        }

        public List<Manufacturer> GetList()
        {
            return _cc.Manufacturer.ToList();
        }

        public void Update(Manufacturer item)
        {
            _cc.Entry(item).State = EntityState.Modified;
        }
        public bool Save()
        {
            return _cc.SaveChanges() > 0;
        }
    }
}
