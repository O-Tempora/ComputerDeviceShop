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
using System.Windows.Shapes;

namespace ComputerDeviceShop.View
{
    /// <summary>
    /// Логика взаимодействия для ManagerWindow.xaml
    /// </summary>
    public partial class ManagerWindow : Window
    {
        public ManagerWindow(ICRUD crudServ, ICatalog catalogServ, IMainCategory mainServ, IAccount account, IMakeOrder order, IUser user, IDialogService dialog, int id, IFile file)
        {
            InitializeComponent();
            DataContext = new ManagerWindowVM(crudServ, catalogServ, mainServ, account, order, user, dialog, id, file);
        }
    }
}
