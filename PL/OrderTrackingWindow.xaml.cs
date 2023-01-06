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
    /// Interaction logic for OrderTrackingWindow.xaml
    /// </summary>
    public partial class OrderTrackingWindow : Window
    {

        private static readonly BlApi.IBl bl = BlApi.Factory.Get()!;
        public BO.OrderTracking OrderTrucking
        {
            get { return (BO.OrderTracking)GetValue(OrderTruckingProperty); }
            set { SetValue(OrderTruckingProperty, value); }
        }

        // Using a DependencyProperty as the backing store for OrderTrucking.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty OrderTruckingProperty =
            DependencyProperty.Register("OrderTrucking", typeof(BO.OrderTracking), typeof(Window), new PropertyMetadata(null));


        public OrderTrackingWindow(int id)
        {
            InitializeComponent();
          
            OrderTrucking = bl.Order.OrderTracking(id);  

        }

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            new orderWindow(OrderTrucking.Id, false).ShowDialog();
        }
    }
}
