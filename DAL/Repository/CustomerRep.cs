
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class CustomerRep : IRepository<Customer>
    {
        private CourseContext _cc;
        public CustomerRep(CourseContext cc)
        {
            _cc = cc;
        }

        public void Create(Customer item)
        {
            _cc.Customer.Add(item);
        }

        public void Delete(int id)
        {
            Customer item = _cc.Customer.Find(id);
            if (item != null)
            {
                _cc.Customer.Remove(item);
            }
        }

        public Customer Get(int id)
        {
            return _cc.Customer.Find(id);
        }

        public List<Customer> GetList()
        {
            return _cc.Customer.ToList();
        }

        public void Update(Customer item)
        {
            _cc.Entry(item).State = EntityState.Modified;
        }
        public bool Save()
        {
            return _cc.SaveChanges() > 0;
        }
    }
}
