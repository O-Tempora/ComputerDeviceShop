using DAL;
using DAL.Repository;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Util
{
    public class ServiceModule : NinjectModule
    {
        public ServiceModule() { }

        public override void Load()
        {
            Bind<IUnitOfWork>().To<UnitOfWork>().InSingletonScope();
        }
    }
}
