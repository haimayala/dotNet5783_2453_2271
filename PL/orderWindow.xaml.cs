using BO;
using Newtonsoft.Json.Linq;
using PL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Printing.IndexedProperties;
using System.Text;
using System.Threading.Tasks;
using System.Windows;


using System.Windows.Media;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;

using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PL
{
    /// <summary>
    /// Interaction logic for orderWindow.xaml
    /// </summary>
    /// 

    public partial class orderWindow : Window
    {
        private static readonly BlApi.IBl bl = BlApi.Factory.Get()!;

        public BO.Order? Order
        {
            get { return (BO.Order?)GetValue(OrderProperty); }
            set { SetValue(OrderProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Order.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty OrderProperty =
            DependencyProperty.Register("Order", typeof(BO.Order), typeof(Window), new PropertyMetadata(null));

    
        public Visibility visibility { get; set; }


        public bool isenable
        {
            get { return (bool)GetValue(isenableProperty); }
            set { SetValue(isenableProperty, value); }
        }

        // Using a DependencyProperty as the backing store for isenable.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty isenableProperty =
            DependencyProperty.Register("isenable", typeof(bool), typeof(Window), new PropertyMetadata(null));




        public bool isMannager
        {
            get { return (bool)GetValue(isMannagerProperty); }
            set { SetValue(isMannagerProperty, value); }
        }

        // Using a DependencyProperty as the backing store for isMannager.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty isMannagerProperty =
            DependencyProperty.Register("isMannager", typeof(bool), typeof(Window), new PropertyMetadata(null));


        public orderWindow()
        {
            InitializeComponent();
            isenable = true;
           
        }

        public orderWindow(int orderId, bool flag)
        {
            InitializeComponent();
            Order = bl.Order.GetOrderDetails(orderId);
            if(!flag)
            {
                visibility = Visibility.Hidden;
                shipDateDatePicker.IsEnabled = false;
                deliveryDateDatePicker.IsEnabled=false;
            }
            
        }

        private void checkbox_ship_Checked(object sender, RoutedEventArgs e)
        {
            try
            {

                bl.Order.UppdateShipDate(int.Parse(IDTextBlock.Text));
            }
            catch (BlOrderAlredyShiped be)
            {
                MessageBox.Show(be.Message);
               
            }
        }

        private void checkbox_delivery_Checked(object sender, RoutedEventArgs e)
        {
            try
            {
                bl.Order.UppdateDeliveryDate(int.Parse(IDTextBlock.Text));
            }
            catch (BlOrderAlredyDelivered be)
            {
                MessageBox.Show(be.Message);
               
            }

        }

    }
}

