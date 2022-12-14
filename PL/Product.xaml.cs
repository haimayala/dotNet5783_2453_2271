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


namespace PL
{
    /// <summary>
    /// Interaction logic for Product.xaml
    /// </summary>
    public partial class Product : Window
    {

        private IBl bl = new BlImplementation.Bl();
        public Product()
        {
            InitializeComponent();
            CategoryAdd.ItemsSource = Enum.GetValues(typeof(BO.Enums.Category));
            btnAdd.Content = "Add";
        }
        public Product(int id)
        {
            InitializeComponent();
            CategoryAdd.ItemsSource = Enum.GetValues(typeof(BO.Enums.Category));

            btnAdd.Content = "Update";
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (btnAdd.Content == "Add")
            {
                BO.Product product = new BO.Product()
                {
                    ID = int.Parse(IDTextBoxAdd.Text),
                    Name = NameTextBoxAdd.Text,
                    Category = (BO.Enums.Category)CategoryAdd.SelectedItem,
                    Price = int.Parse(PriceTextBoxAdd.Text),
                    InStock = int.Parse(InStockTextBoxAdd.Text),
                };
                bl.Product.Add(product);
            }
            else if(btnAdd.Content=="Update")
            {
                
            }
           
        }
    }
}
