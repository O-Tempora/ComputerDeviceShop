
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class GoodRep : IRepository<Good>
    {
        private CourseContext _cc;
        public GoodRep(CourseContext cc)
        {
            _cc = cc;
        }

        public void Create(Good item)
        {
            _cc.Good.Add(item);
        }

        public void Delete(int id)
        {
            Good item = _cc.Good.Find(id);
            if (item != null)
            {
                _cc.Good.Remove(item);
            }
        }

        public Good Get(int id)
        {
            return _cc.Good.Find(id);
        }

        public List<Good> GetList()
        {
            return _cc.Good.ToList();
        }

        public void Update(Good item)
        {
            _cc.Entry(item).State = EntityState.Modified;
        }
        public bool Save()
        {
            return _cc.SaveChanges() > 0;
        }
    }
}
