using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class REPORTS_REP : IService
    {
        private CourseContext _cc;
        public REPORTS_REP(CourseContext cc)
        {
            _cc = cc;
        }

        public List<BasketReport> GetBasketByUser(int id)
        {
            var res = _cc.Basket
                .Where(i => i.customer == id)
                .Join(_cc.Good, basket => basket.good, good => good.id, (basket, good) => new BasketReport
                {
                    Id = basket.id,
                    Amount = basket.amount,
                    SigleCost = (decimal)(good.cost - good.cost * good.discount),
                    TotalCost = basket.amount * (decimal)(good.cost - good.cost * good.discount),
                    Good = basket.good,
                    Customer = basket.customer,
                    GoodPicture = good.picture,
                    Goodname = good.name
                }).ToList();
            return res;
        }

        public List<CatalogGood> GetGoodsByCategory(string category) //Выборка товаров для отображения в каталоге
        {
            if (_cc.MainCategory.Where(i => i.name == category).Count() != 0)
            {
                var res = _cc.Good
                    .Join(_cc.Category, g => g.category, c => c.id, (g, c) => new { Id = g.id, Categ = c.name, MainCateg = c.main, g.name, g.manufacturer, g.picture, g.cost, g.discount, g.warranty, g.category})
                    .Join(_cc.MainCategory, g => g.MainCateg, mc => mc.id, (g, mc) => new { MC = mc.name, g.Id, g.name, g.picture, g.discount, g.cost })
                    .Where(i => i.MC == category)
                    .Select(i => new CatalogGood { Id = i.Id, Name = i.name, Discount = (decimal)i.discount, Picture = i.picture, Price = i.cost}).ToList();
                return res;
            }
            else
            {
                var res = _cc.Good
                    .Join(_cc.Category, g => g.category, c => c.id, (g, c) => new { Id = g.id, Categ = c.name, g.name, g.picture, g.cost, g.discount})
                    .Where(i => i.Categ == category)
                    .Select(i => new CatalogGood { Id = i.Id, Name = i.name, Discount = (decimal)i.discount, Picture = i.picture, Price = i.cost }).ToList();
                return res;
            }
        }

        public int GetIdByLogin(string login)
        {
            return _cc.Customer.Where(i => login == i.login).ToList()[0].id;
        }

        public bool LoginVerification(string login)
        {
            if (_cc.Customer.Where(i => login == i.login).Count() == 0)
            {
                return false;
            }
            else return true;
        }

        public bool PasswordVerification(string login, string password)
        {
            if (_cc.Customer.Where(i => login == i.login && password == i.password).Count() == 0)
            {
                return false;
            }
            else return true;
        }
    }
}
