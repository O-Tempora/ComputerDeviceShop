using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class MainCategoryRep : IRepository<MainCategory>
    {
        private CourseContext _cc;
        public MainCategoryRep(CourseContext cc)
        {
            _cc = cc;
        }
        public void Create(MainCategory item)
        {
            _cc.MainCategory.Add(item);
        }

        public void Delete(int id)
        {
            MainCategory item = _cc.MainCategory.Find(id);
            if (item != null)
            {
                _cc.MainCategory.Remove(item);
            }
        }

        public MainCategory Get(int id)
        {
            return _cc.MainCategory.Find(id);
        }

        public List<MainCategory> GetList()
        {
            return _cc.MainCategory.ToList();
        }

        public void Update(MainCategory item)
        {
            _cc.Entry(item).State = EntityState.Modified;
        }
        public bool Save()
        {
            return _cc.SaveChanges() > 0;
        }
    }
}
