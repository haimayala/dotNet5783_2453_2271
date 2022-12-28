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
using static BO.Enums;

namespace PL
{
    /// <summary>
    /// Interaction logic for ProductItem.xaml
    /// </summary>
    public partial class ProductItem : Window
    {
        private static readonly BlApi.IBl? bl = BlApi.Factory.Get();
        public ProductItem()
        {
            InitializeComponent();
            ProItemList.ItemsSource = bl.Product.GetListedProducts();
            cmbboxCategory.ItemsSource=Enum.GetValues(typeof(BO.Enums.Category));
        }

        private void cmbboxCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            var choise = cmbboxCategory.SelectedItem;
            // in case the user enter the NONE coise- show all the products
            if (choise.Equals(BO.Enums.Category.None))
                ProItemList.ItemsSource = bl?.Product.GetListedProducts();
            else
                ProItemList.ItemsSource = bl?.Product.GetProductForListsByCategory((Category)choise);
        }
    }
}
