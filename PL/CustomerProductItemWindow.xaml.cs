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
    /// Interaction logic for CustomerProductItemWindow.xaml
    /// </summary>
    public partial class CustomerProductItemWindow : Window
    {
        private static readonly BlApi.IBl bl = BlApi.Factory.Get()!;


        public BO.Cart  Cart
        {
            get { return (BO.Cart )GetValue(CartProperty); }
            set { SetValue(CartProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Cart.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CartProperty =
            DependencyProperty.Register("Cart", typeof(BO.Cart ), typeof(Window), new PropertyMetadata(null));


        

        public BO.ProductItem ProductItem
        {
            get { return (BO.ProductItem)GetValue(ProductItemProperty); }
            set { SetValue(ProductItemProperty, value); }
            
        }

        // Using a DependencyProperty as the backing store for ProductItem.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ProductItemProperty =
            DependencyProperty.Register("ProductItem", typeof(BO.ProductItem), typeof(Window), new PropertyMetadata(null));



        public CustomerProductItemWindow(int id, BO.Cart cart)
        {
            InitializeComponent();
            ProductItem=bl.Product.GetProductDetails(id);
            Cart=cart;
        }

        private void btnAddToTheCart_Click(object sender, RoutedEventArgs e)
        {
            int id = int.Parse(iDTextBlock.Text);
            try
            {
                bl.Cart.Add(Cart, id);
                Close();
            }
            catch (BO.BlNotExsistExeption es)
            {
                MessageBox.Show(es.Message); 
            }
            
        }
    }
}
