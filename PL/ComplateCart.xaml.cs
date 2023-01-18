using BO;
using DO;
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
    /// Interaction logic for ComplateCart.xaml
    /// </summary>
    public partial class ComplateCart : Window
    {

        private static readonly BlApi.IBl bl = BlApi.Factory.Get()!;

        // depentency property for the cart
        public BO.Cart cart
        {
            get { return (BO.Cart)GetValue(cartProperty); }
            set { SetValue(cartProperty, value); }
        }

        // Using a DependencyProperty as the backing store for cart.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty cartProperty =
            DependencyProperty.Register("cart", typeof(BO.Cart), typeof(Window), new PropertyMetadata(null));


        // depentency property for the total price
        public int tPrice
        {
            get { return (int)GetValue(tPriceProperty); }
            set { SetValue(tPriceProperty, value); }
        }

        // Using a DependencyProperty as the backing store for tPrice.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty tPriceProperty =
            DependencyProperty.Register("tPrice", typeof(int), typeof(Window), new PropertyMetadata(0));




        //ctor 
        public ComplateCart(BO.Cart Cart)
        {
            InitializeComponent();
            cart = Cart;
            tPrice = (int)cart.TotalPrice;
        }


        // The response to the text change event when the customer changes the quantity of a product in his shopping cart
        private void TextBox_TextChanged(object sender, RoutedEventArgs e)
        {
            try
            {
                // get the details from the cart
                BO.OrderItem orderItem = (BO.OrderItem)((TextBox)sender).DataContext;
                // update the new amount
                cart = bl.Cart.Uppdate(cart, orderItem.ProductId, orderItem.Amount);
                //refresh the new cart
                orderItemListView.Items.Refresh();
                // update the total price
                tPrice = (int)cart.TotalPrice;
            }
            // in case the update not ceceeded
            catch (BlNotEnoughInStockExeption es)
            {
                MessageBox.Show(es.Message);
            }
            catch (BO.BlUncorrectDetailsExeption ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        //Function as a response to clicking to finish shopping
        private void btnFinishAll_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                // make the order
                bl.Cart.OrderConfirmation(cart);
                MessageBox.Show("The order is complete", "complete", MessageBoxButton.OK, MessageBoxImage.Information);
                //Emptying the cart
                cart.Items = new List<BO.OrderItem?>();
                cart.TotalPrice = 0;
                cart.CustomerEmail = null;
                cart.CustonerAddres = null;
                cart.CustomerName = null;
                orderItemListView.ItemsSource = null;
                Close();
            }
            //In case the order was not successful
            catch (BlUncorrectEmailExeption ex)
            {
                MessageBox.Show(ex.Message);

            }
            catch (BlUncorrectAddres ex)
            {
                MessageBox.Show(ex.Message);

            }
            catch (BlUncorrectName ex)
            {
                MessageBox.Show(ex.Message);

            }
            catch (BlNullPropertyException ex)
            {
                MessageBox.Show(ex.Message);

            }


        }
    }
}
