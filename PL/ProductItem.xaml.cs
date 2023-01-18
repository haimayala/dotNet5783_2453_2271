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

        // ctor
        public ProductItem()
        {
            InitializeComponent();
            productItemListView.ItemsSource = bl.Product.GetProductItems();
        }

        //event response function select of איק בםצנםנםס
        private void cmbProItem_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var choise = cmbProItem.SelectedItem;
            // in case the user enter the NONE coise- show all the list
            if (choise.Equals(Category.None))
                productItemListView.ItemsSource = bl?.Product.GetProductItems();
            else
                // another choise
                productItemListView.ItemsSource = bl?.Product.GetProductItemsByCategory((Category)choise);

        }

        //Click event response function for the cart window
        private void btnhowCart_Click(object sender, RoutedEventArgs e)
        {
            new ComplateCart(cart).ShowDialog();
        }



        //Response to a double-click event on a product in the list
        private void productItemListView_MouseDoubleClick_1(object sender, MouseButtonEventArgs e)
        {
            // gets the match id from the list
            int id = ((BO.ProductItem)productItemListView.SelectedItem).ID;
            new CustomerProductItemWindow(id, cart).ShowDialog();
        }

        //Response to a grouping by popular product selection event
        private void popularGroup_Click(object sender, RoutedEventArgs e)
        {
            productItemListView.ItemsSource = bl.Product.MostPopular(cart);
        }
        //Response to a grouping by expensive product selection event
        private void expensiveGroup_Click(object sender, RoutedEventArgs e)
        {
            productItemListView.ItemsSource = bl.Product.MostExpensive(cart);
        }
        //Response to a grouping by cheap product selection event
        private void cheapGroup_Click(object sender, RoutedEventArgs e)
        {
            productItemListView.ItemsSource = bl.Product.MostCheap(cart);
        }
    }
}
