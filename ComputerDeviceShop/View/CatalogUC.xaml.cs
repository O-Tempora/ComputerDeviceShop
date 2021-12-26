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

namespace ComputerDeviceShop.View
{
    /// <summary>
    /// Логика взаимодействия для CatalogUC.xaml
    /// </summary>
    public partial class CatalogUC : UserControl
    {
        public CatalogUC()
        {
            InitializeComponent();
        }

        private void Goods_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (Goods.SelectedIndex != -1)
            {
                this.GoodGrid.Visibility = Visibility.Visible;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.GoodGrid.Visibility = Visibility.Hidden;
        }
    }
}
