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
        public ProductForListWindow()
        {
            InitializeComponent();
            ProductListView.ItemsSource = bl.Product.GetListedProducts();
            CategorySelector.ItemsSource = Enum.GetValues(typeof(BO.Enums.Category));
        }

        

        private void CategorySelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Category category = (BO.Enums.Category)CategorySelector.SelectedItem;
            ProductListView.ItemsSource = bl?.Product.GetListedProducts(x => x?.category == category);
            if (CategorySelector.SelectedIndex == 5)
                ProductListView.ItemsSource = bl?.Product.GetListedProducts();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new Product().ShowDialog();
            ProductListView.ItemsSource = bl.Product.GetListedProducts().OrderBy(item=>item.Id);
        }
       

        private void ProductListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

            int id = ((ProductForList)ProductListView.SelectedItem).Id;
            new Product(id).ShowDialog();
            ProductListView.ItemsSource=bl.Product.GetListedProducts().OrderBy(item => item.Id); 

           
        }
    }
}


