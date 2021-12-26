using BLL.Interfaces;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class UserService : IUser
    {
        IUnitOfWork _uow;
        public UserService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public int GetIdByLogin(string login)
        {
            return _uow.Services.GetIdByLogin(login);
        }

        public bool LoginVerification(string login)
        {
            return _uow.Services.LoginVerification(login);
        }

        public bool PasswordVerification(string login, string password)
        {
            return _uow.Services.PasswordVerification(login, password);
        }
    }
}
