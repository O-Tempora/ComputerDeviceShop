using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using BLL.Interfaces;
using ComputerDeviceShop.Util;
using ComputerDeviceShop.ViewModel;

namespace ComputerDeviceShop
{
    /// <summary>
    /// Логика взаимодействия для SignIn.xaml
    /// </summary>
    public partial class SignIn : Window
    {
        public SignIn(ICRUD crud, ICatalog catalog, IMainCategory maincat, IAccount account, IUser user, IMakeOrder order, IFile file)
        {
            InitializeComponent();
            UserVM uvm = new UserVM(crud, catalog, maincat, account, user, new DialogService(), order, file);
            DataContext = uvm;
            uvm.Notify += CloseThis;
        }

        private void CloseThis()
        {
            this.Close();
        }
    }
}
