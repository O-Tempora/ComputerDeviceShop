using BLL.Interfaces;
using ComputerDeviceShop.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerDeviceShop.ViewModel
{
    public class MainWindowVM : INotifyPropertyChanged
    {
        public CatalogVM CatalogViewM { get; set; }
        public BasketVM BasketViewM { get; set; }
        public AccountVM AccountViewM { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public MainWindowVM(ICRUD crud, ICatalog catalog, IMainCategory maincateg, IAccount account, IMakeOrder order, IUser user, IDialogService dialog, int id, IFile file)
        {
            CatalogViewM = new CatalogVM(crud, catalog, maincateg, id);
            BasketViewM = new BasketVM(crud, catalog, maincateg, order, id, file);
            AccountViewM = new AccountVM(crud, account, catalog, maincateg, order, id);
        }
    }
}
