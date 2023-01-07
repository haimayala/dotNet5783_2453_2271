using BO;
using MailChimp.Net.Core;
using System;
using System.Collections.Generic;
using System.Globalization;
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
    /// Interaction logic for MakeAnOrderWindow.xaml
    /// </summary>
    public partial class MakeAnOrderWindow : Window
    {
        private static readonly BlApi.IBl bl = BlApi.Factory.Get()!;




        public BO.Cart MyCart
        {
            get { return (BO.Cart)GetValue(MyCartProperty); }
            set { SetValue(MyCartProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyCart.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MyCartProperty =
            DependencyProperty.Register("MyCart", typeof(BO.Cart), typeof(Window), new PropertyMetadata(null));


      

        public MakeAnOrderWindow(BO.Cart Cart)
        {
            InitializeComponent();
            MyCart = Cart;    
            
            
        }

        private void imgP_MouseUp(object sender, MouseButtonEventArgs e)
        {
            grid2.Visibility = Visibility.Visible;
            btnFinishAll.Visibility = Visibility.Visible;
        }

        private void btnFinishAll_Click(object sender, RoutedEventArgs e)
        {
            try
            {
              
                bl.Cart.OrderConfirmation(MyCart);
                MessageBox.Show("The order is complete", "complete", MessageBoxButton.OK, MessageBoxImage.Information);
                MyCart.Items = new List<OrderItem?>();
                MyCart.TotalPrice = 0;
                MyCart.CustomerEmail = null;
                MyCart.CustonerAddres = null;
                MyCart.CustomerName = null;
               
                Close();
                

             
                

            }
            catch(BlUncorrectEmailExeption ex)
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


        }
    }
}
