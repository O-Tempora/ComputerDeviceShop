using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class BasketRep : IRepository<Basket>
    {
        private CourseContext _cc;
        public BasketRep(CourseContext cc)
        {
            _cc = cc;
        }
        public void Create(Basket item)
        {
            _cc.Basket.Add(item);
        }

        public void Delete(int id)
        {
            Basket item = _cc.Basket.Find(id);
            if (item != null)
            {
                _cc.Basket.Remove(item);
            }
        }

        public Basket Get(int id)
        {
            return _cc.Basket.Find(id);
        }

        public List<Basket> GetList()
        {
            return _cc.Basket.ToList();
        }

        public void Update(Basket item)
        {
            _cc.Entry(item).State = EntityState.Modified;
        }
        public bool Save()
        {
            return _cc.SaveChanges() > 0;
        }
    }
}
