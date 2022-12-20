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

        // ctor for add case
        public Product()
        {
            InitializeComponent();
            CategoryAdd.ItemsSource = Enum.GetValues(typeof(BO.Enums.Category));
            btnAddOrUpdate.Content = "Add";
        }
        // ctor for update case
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
        //private void ShowProductsButton_Click(object sender, RoutedEventArgs e) => new ProductForListWindow().ShowDialog();
        private void btnAddOrUpdate_Click(object sender, RoutedEventArgs e)
        {
            // in case of adding a product
            if (btnAddOrUpdate.Content == "Add")
            {

                //Checking that the input is correct and appropriate
                BO.Product product = new BO.Product();
                
                if (IDTextBoxAdd.Text.Length == 0)
                {
                    IDTextBoxAdd.BorderBrush = new SolidColorBrush(Colors.Red);
                    return;
                }
                else
                    IDTextBoxAdd.BorderBrush= new SolidColorBrush(Colors.Green);    
                if (CategoryAdd.SelectedValue==null || CategoryAdd.SelectedIndex == 5)
                {
                    MessageBox.Show("Please choose a category");
                    return;
                }
                if (NameTextBoxAdd.Text.Length == 0)
                {
                    NameTextBoxAdd.BorderBrush = new SolidColorBrush(Colors.Red);
                    return;
                }
                else
                    NameTextBoxAdd.BorderBrush = new SolidColorBrush(Colors.Green);
                if (PriceTextBoxAdd.Text.Length == 0)
                {
                    PriceTextBoxAdd.BorderBrush = new SolidColorBrush(Colors.Red);
                    return;
                }
                else
                    PriceTextBoxAdd.BorderBrush = new SolidColorBrush(Colors.Green);
                if (InStockTextBoxAdd.Text.Length == 0)
                {
                    InStockTextBoxAdd.BorderBrush = new SolidColorBrush(Colors.Red);
                    return;
                }
                else
                    InStockTextBoxAdd.BorderBrush = new SolidColorBrush(Colors.Green);
                //Initialize the product according The text boxes
                product.ID = int.Parse(IDTextBoxAdd.Text);
                product.Name= NameTextBoxAdd.Text;
                product.Price = int.Parse(PriceTextBoxAdd.Text);
                product.Category = (BO.Enums.Category)CategoryAdd.SelectedItem;
                product.InStock = int.Parse(InStockTextBoxAdd.Text);

                // try to add the product
                try
                {
                    bl.Product.Add(product);
                    Close();                   
                }
                // in case the adding faild
               catch (Exception ed)
                {
                    MessageBox.Show(ed.Message);
                }
               
            }
            // in case of updating a product
            else if (btnAddOrUpdate.Content == "Update")
            {

                // make the match product
                BO.Product product = new BO.Product();

                //Checking that the input is correct and appropriate

                if (CategoryAdd.SelectedValue == null || CategoryAdd.SelectedIndex==5)
                {
                    MessageBox.Show("Please choose a category");
                    return;
                }
                if (NameTextBoxAdd.Text.Length == 0)
                {
                    NameTextBoxAdd.BorderBrush = new SolidColorBrush(Colors.Red);
                    return;
                }
                else
                    NameTextBoxAdd.BorderBrush = new SolidColorBrush(Colors.Green);
                if (PriceTextBoxAdd.Text.Length == 0)
                {
                    PriceTextBoxAdd.BorderBrush = new SolidColorBrush(Colors.Red);
                    return;
                }
                else
                    PriceTextBoxAdd.BorderBrush = new SolidColorBrush(Colors.Green);
                if (InStockTextBoxAdd.Text.Length == 0)
                {
                    InStockTextBoxAdd.BorderBrush = new SolidColorBrush(Colors.Red);
                    return;
                }
                else
                    InStockTextBoxAdd.BorderBrush = new SolidColorBrush(Colors.Green);

                //Initialize the product according The text boxes
                product.ID = int.Parse(IDTextBoxAdd.Text);
                product.Name = NameTextBoxAdd.Text;
                product.Price = int.Parse(PriceTextBoxAdd.Text);
                product.Category = (BO.Enums.Category)CategoryAdd.SelectedItem;
                product.InStock = int.Parse(InStockTextBoxAdd.Text);
                try
                {
                    bl.Product.Uppdate(product);
                    Close();
                }
                // in case the updatung faild
                catch (Exception ed)
                {
                    MessageBox.Show(ed.Message);
                }
     
            }

            
        }
    }
}
