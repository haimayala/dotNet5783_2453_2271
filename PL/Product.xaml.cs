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
        //private void ShowProductsButton_Click(object sender, RoutedEventArgs e) => new ProductForListWindow().ShowDialog();
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

                try
                {
                    bl.Product.Add(product);
                    Close();                   
                }
               catch (Exception ed)
                {
                    MessageBox.Show(ed.Message);
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
                try
                {
                    bl.Product.Uppdate(product);
                    Close();
                }
                catch (Exception ed)
                {
                    MessageBox.Show(ed.Message);
                }
     
            }

            
        }
    }
}
