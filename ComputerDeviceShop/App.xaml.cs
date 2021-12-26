using BLL.Interfaces;
using BLL.Util;
using ComputerDeviceShop.Util;
using Ninject;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace ComputerDeviceShop
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            var kernel = new StandardKernel(new NinjectRegistration(), new ServiceModule());
            ICRUD _crudServ = kernel.Get<ICRUD>();
            ICatalog _catalogServ = kernel.Get<ICatalog>();
            IMainCategory _mainServ = kernel.Get<IMainCategory>();
            IMakeOrder _orderServ = kernel.Get<IMakeOrder>();
            IUser _userServ = kernel.Get<IUser>();
            //MainWindow mw = new MainWindow(_crudServ, _catalogServ, _mainServ, _orderServ, _userServ);
            //mw.Show();
            SignIn si = new SignIn(_crudServ, _catalogServ, _mainServ, _userServ, _orderServ);
            si.Show();
        }
    }
}
 