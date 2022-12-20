using BlApi;
using BO;
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
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class ProductForListWindow : Window
    {
        private IBl bl = new BlImplementation.Bl();

        //ctor
        public ProductForListWindow()
        {
            InitializeComponent();
            ProductListView.ItemsSource = bl.Product.GetListedProducts();
            CategorySelector.ItemsSource = Enum.GetValues(typeof(BO.Enums.Category));
        }


        // A function that responsible for the combobox event
        
        private void CategorySelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            var choise = CategorySelector.SelectedItem;
            // in case the user enter the NONE coise- show all the products
            if(choise.Equals(BO.Enums.Category.None))
                ProductListView.ItemsSource = bl?.Product.GetListedProducts();
            else
                ProductListView.ItemsSource = bl.Product.GetProductForListsByCategory((Category)choise);


        }

        //A function that responsible for the add product butten event
        private void btnAddProduct_Click(object sender, RoutedEventArgs e)
        {
            // show the addproduct window
            new Product().ShowDialog();
            ProductListView.ItemsSource = bl.Product.GetListedProducts();
        }

        //A function that responsible for the updateb productby double click
        private void ProductListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            // get the match id
            int id = ((ProductForList)ProductListView.SelectedItem).Id;
            // show the matc window
            new Product(id).ShowDialog();
            // get the lisst again for howing the updatung list
            ProductListView.ItemsSource = bl.Product.GetListedProducts(); 

           
        }
    }
}


