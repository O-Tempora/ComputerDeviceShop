using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class CategoryRep : IRepository<Category>
    {
        private CourseContext _cc;
        public CategoryRep(CourseContext cc)
        {
            _cc = cc;
        }

        public void Create(Category item)
        {
            _cc.Category.Add(item);
        }

        public void Delete(int id)
        {
            Category item = _cc.Category.Find(id);
            if (item != null)
            {
                _cc.Category.Remove(item);
            }
        }

        public Category Get(int id)
        {
            return _cc.Category.Find(id);
        }

        public List<Category> GetList()
        {
            return _cc.Category.ToList();
        }

        public void Update(Category item)
        {
            _cc.Entry(item).State = EntityState.Modified;
        }
        public bool Save()
        {
            return _cc.SaveChanges() > 0;
        }
    }
}
