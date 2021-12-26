
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class Supply_StringRep : IRepository<Supply_String>
    {
        private CourseContext _cc;
        public Supply_StringRep(CourseContext cc)
        {
            _cc = cc;
        }

        public void Create(Supply_String item)
        {
            _cc.Supply_String.Add(item);
        }

        public void Delete(int id)
        {
            Supply_String item = _cc.Supply_String.Find(id);
            if (item != null)
            {
                _cc.Supply_String.Remove(item);
            }
        }

        public Supply_String Get(int id)
        {
            return _cc.Supply_String.Find(id);
        }

        public List<Supply_String> GetList()
        {
            return _cc.Supply_String.ToList();
        }

        public void Update(Supply_String item)
        {
            _cc.Entry(item).State = EntityState.Modified;
        }
        public bool Save()
        {
            return _cc.SaveChanges() > 0;
        }
    }
}

