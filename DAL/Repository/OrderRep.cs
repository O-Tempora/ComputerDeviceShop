
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class OrderRep : IRepository<Order>
    {
        private CourseContext _cc;
        public OrderRep(CourseContext cc)
        {
            _cc = cc;
        }

        public void Create(Order item)
        {
            _cc.Order.Add(item);
        }

        public void Delete(int id)
        {
            Order item = _cc.Order.Find(id);
            if (item != null)
            {
                _cc.Order.Remove(item);
            }
        }

        public Order Get(int id)
        {
            return _cc.Order.Find(id);
        }

        public List<Order> GetList()
        {
            return _cc.Order.ToList();
        }

        public void Update(Order item)
        {
            _cc.Entry(item).State = EntityState.Modified;
        }
        public bool Save()
        {
            return _cc.SaveChanges() > 0;
        }
    }
}
