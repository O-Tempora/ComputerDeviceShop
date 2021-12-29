using BLL;
using BLL.Interfaces;
using BLL.Services;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerDeviceShop.Util
{
    public class NinjectRegistration : NinjectModule
    {
        public override void Load()
        {
            Bind<ICRUD>().To<CRUD>();
            Bind<ICatalog>().To<CatalogService>();
            Bind<IMainCategory>().To<MainCategoryService>();
            Bind<IUser>().To<UserService>();
            Bind<IMakeOrder>().To<MakeOrderService>();
            Bind<IAccount>().To<AccountService>();
            Bind<IFile>().To<FileService>();
        }
    }
}
