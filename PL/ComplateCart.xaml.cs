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



        public BO.Cart cart
        {
            get { return (BO.Cart)GetValue(cartProperty); }
            set { SetValue(cartProperty, value); }
        }

        // Using a DependencyProperty as the backing store for cart.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty cartProperty =
            DependencyProperty.Register("cart", typeof(BO.Cart), typeof(Window), new PropertyMetadata(null));


        public ComplateCart(BO.Cart Cart)
        {
            InitializeComponent();
            cart = Cart;
            
        }


        private void btnFinishOrder_Click(object sender, RoutedEventArgs e)
        {
            new MakeAnOrderWindow(cart).ShowDialog();
          
        }

        private void TextBox_TextChanged(object sender, RoutedEventArgs e)
        {
            try
            {
                BO.OrderItem orderItem = (BO.OrderItem)((TextBox)sender).DataContext;
                cart = bl.Cart.Uppdate(cart, orderItem.ProductId, orderItem.Amount);
                orderItemListView.Items.Refresh();
                totalPriceTextBlock.Text = cart.TotalPrice.ToString();
            }
            catch (BlNotEnoughInStockExeption es)
            {
                MessageBox.Show(es.Message);
            }


        }

      
    }
}
