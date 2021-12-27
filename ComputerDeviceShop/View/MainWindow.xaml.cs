using BLL.Interfaces;
using ComputerDeviceShop.Util;
using ComputerDeviceShop.ViewModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ComputerDeviceShop
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(ICRUD crudServ, ICatalog catalogServ, IMainCategory mainServ, IAccount account, IMakeOrder order, IUser user, IDialogService dialog, int id)
        {
            InitializeComponent();
            DataContext = new MainWindowVM(crudServ, catalogServ, mainServ, account, order, user, dialog, id);
        }
    }
}
