using BlApi;
using BO;
using System;
using static BO.Enums;

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
using System.Text.RegularExpressions;

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
            btnAddOrUpdate.Content = "Add";
        }
        public Product(int id)
        {
            InitializeComponent();
            CategoryAdd.ItemsSource = Enum.GetValues(typeof(BO.Enums.Category));
            CategoryAdd.ItemsSource = Enum.GetValues(typeof(BO.Enums.Category));
            btnAddOrUpdate.Content = "Update";
            BO.Product pro=bl.Product.GetProductById(id);           
            IDTextBoxAdd.Text = pro.ID.ToString();
            NameTextBoxAdd.Text = pro.Name;
            PriceTextBoxAdd.Text = pro.Price.ToString();
            InStockTextBoxAdd.Text = pro.InStock.ToString();
            CategoryAdd.Text = pro.Category.ToString();
            IDTextBoxAdd.IsReadOnly = true;
            Regex regex = new("[0-9]+");

        }
        private void ShowProductsButton_Click(object sender, RoutedEventArgs e) => new Window1().ShowDialog();
        private void btnAddOrUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (btnAddOrUpdate.Content == "Add")
            {

                BO.Product product = new BO.Product()
                {
                    ID = int.Parse(IDTextBoxAdd.Text),
                    Name = NameTextBoxAdd.Text,
                    Category = (BO.Enums.Category)CategoryAdd.SelectedItem,
                    Price = int.Parse(PriceTextBoxAdd.Text),
                    InStock = int.Parse(InStockTextBoxAdd.Text),
                };
                if (product.ID <= 0)
                    MessageBox.Show("Please enter a correct id", "Add a new Product");
                if (product.Name == "")
                    MessageBox.Show("Please enter a product name", "Add a new Product");
                if (product.Category == Category.None)
                    MessageBox.Show("Please enter a product category", "Add a new Product");
                if (product.Price <= 0)
                    MessageBox.Show("Uncorrect price, please enter a correct number", "Add a new Product");
                if (product.InStock <= 0)
                    MessageBox.Show("Uncorrect number, please enter a correct number for in stock", "Add a new Product");

                try
                {
                    bl.Product.Add(product);
                    Close();
                    
                }
               catch(BO.BlUncorrectDetailsExeption)
                {
                   
                }
               
            }
            else if (btnAddOrUpdate.Content == "Update")
            {

             
                BO.Product product = new BO.Product()
                {
                    ID = int.Parse(IDTextBoxAdd.Text),
                    Name = NameTextBoxAdd.Text,
                    Category = (BO.Enums.Category)CategoryAdd.SelectedItem,
                    Price = int.Parse(PriceTextBoxAdd.Text),
                    InStock = int.Parse(InStockTextBoxAdd.Text),
                };
                if (product.ID <= 0)
                    MessageBox.Show("Please enter a correct id", "Add a new Product");
                if (product.Name == "")
                    MessageBox.Show("Please enter a product name", "Add a new Product");
                if (product.Category == Category.None)
                    MessageBox.Show("Please enter a product category", "Add a new Product");
                if (product.Price <= 0)
                    MessageBox.Show("Uncorrect price, please enter a correct number", "Add a new Product");
                if (product.InStock < 0)
                    MessageBox.Show("Uncorrect number, please enter a correct number for in stock", "Add a new Product");
                try
                {
                    bl.Product.Uppdate(product);
                }
                catch(BO.BlUncorrectDetailsExeption)
                {

                }
     
            }

            Close();
        }
    }
}
