using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IUser
    {
        bool LoginVerification(string login);
        bool PasswordVerification(string login, string password);
        int GetIdByLogin(string login);
    }
}
