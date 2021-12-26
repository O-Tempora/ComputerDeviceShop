using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IService
    {
        List<CatalogGood> GetGoodsByCategory(string category);
        List<BasketReport> GetBasketByUser(int id);
        bool LoginVerification(string login);
        bool PasswordVerification(string login, string password);
        int GetIdByLogin(string login);
    }
}
