
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class Order_StringRep : IRepository<Order_String>
    {
        private CourseContext _cc;
        public Order_StringRep(CourseContext cc)
        {
            _cc = cc;
        }

        public void Create(Order_String item)
        {
            _cc.Order_String.Add(item);
        }

        public void Delete(int id)
        {
            Order_String item = _cc.Order_String.Find(id);
            if (item != null)
            {
                _cc.Order_String.Remove(item);
            }
        }

        public Order_String Get(int id)
        {
            return _cc.Order_String.Find(id);
        }

        public List<Order_String> GetList()
        {
            return _cc.Order_String.ToList();
        }

        public void Update(Order_String item)
        {
            _cc.Entry(item).State = EntityState.Modified;
        }
        public bool Save()
        {
            return _cc.SaveChanges() > 0;
        }
    }
}

