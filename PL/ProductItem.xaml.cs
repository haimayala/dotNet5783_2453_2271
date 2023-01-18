using BO;
using DO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        private static readonly BlApi.IBl bl = BlApi.Factory.Get()!;


        public Array Categories { get { return Enum.GetValues(typeof(Category)); } }

       
        private static Cart cart = new Cart()
        {            
            Items = new List<BO.OrderItem?>(),      
        };

        public ProductItem()
        {
            InitializeComponent();
            productItemListView.ItemsSource = bl.Product.GetProductItems();

            ////cmbProItem.ItemsSource = Enum.GetValues(typeof(Category));

        }

        private void cmbProItem_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var choise = cmbProItem.SelectedItem;
            // in case the user enter the NONE coise- show all the list
            if (choise.Equals(Category.None))
                productItemListView.ItemsSource = bl?.Product.GetProductItems();
            else
                productItemListView.ItemsSource = bl?.Product.GetProductItemsByCategory((Category)choise);

        }

        private void btnhowCart_Click(object sender, RoutedEventArgs e)
        {
            new ComplateCart(cart).ShowDialog();
        }

      

        private void productItemListView_MouseDoubleClick_1(object sender, MouseButtonEventArgs e)
        {
            int id = ((BO.ProductItem)productItemListView.SelectedItem).ID;
            new CustomerProductItemWindow(id, cart).ShowDialog();
        }

        private void popularGroup_Click(object sender, RoutedEventArgs e)
        {
            productItemListView.ItemsSource = bl.Product.MostPopular(cart);
        }

        private void expensiveGroup_Click(object sender, RoutedEventArgs e)
        {
            productItemListView.ItemsSource = bl.Product.MostExpensive(cart);
        }

        private void cheapGroup_Click(object sender, RoutedEventArgs e)
        {
            productItemListView.ItemsSource = bl.Product.MostCheap(cart);
        }
    }
}
