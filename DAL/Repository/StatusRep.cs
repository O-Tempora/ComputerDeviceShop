
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class StatusRep : IRepository<Status>
    {
        private CourseContext _cc;
        public StatusRep(CourseContext cc)
        {
            _cc = cc;
        }

        public void Create(Status item)
        {
            _cc.Status.Add(item);
        }

        public void Delete(int id)
        {
            Status item = _cc.Status.Find(id);
            if (item != null)
            {
                _cc.Status.Remove(item);
            }
        }

        public Status Get(int id)
        {
            return _cc.Status.Find(id);
        }

        public List<Status> GetList()
        {
            return _cc.Status.ToList();
        }

        public void Update(Status item)
        {
            _cc.Entry(item).State = EntityState.Modified;
        }
        public bool Save()
        {
            return _cc.SaveChanges() > 0;
        }
    }
}

