using BLL.Interfaces;
using BLL.Models;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class MainCategoryService : IMainCategory
    {
        IUnitOfWork _uow;
        public MainCategoryService(IUnitOfWork uow)
        {
            _uow = uow;
        }
        public List<MMainCategory> GetMainCategories()
        {
            var mains = _uow.MainCategories.GetList()
                .Select(i => new MMainCategory { Id = i.id, Name = i.name }).ToList();
            foreach(var main in mains)
            {
                var categories = _uow.Categories.GetList().Where(i => i.main == main.Id)
                    .Select(i => new MCategory { Id = i.id, Name = i.name, Main = i.main }).ToList();
                main.Categories = new System.Collections.ObjectModel.ObservableCollection<MCategory>();
                foreach (var category in categories)
                {
                    main.Categories.Add(category);
                }
            }
            return mains;
        }
    }
}
