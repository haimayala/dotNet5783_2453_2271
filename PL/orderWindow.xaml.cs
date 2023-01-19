using BO;

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

        // depentency property for the ordeer window
        public BO.Order? Order
        {
            get { return (BO.Order?)GetValue(OrderProperty); }
            set { SetValue(OrderProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Order.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty OrderProperty =
            DependencyProperty.Register("Order", typeof(BO.Order), typeof(Window), new PropertyMetadata(null));


        // depentency property for visability
        public Visibility visibility
        {
            get { return (Visibility)GetValue(visibilityProperty); }
            set { SetValue(visibilityProperty, value); }
        }

        // Using a DependencyProperty as the backing store for visibility.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty visibilityProperty =
            DependencyProperty.Register("visibility", typeof(Visibility), typeof(Window), new PropertyMetadata(null));


        //a boolian depentency property for the unable button
        public bool isenable
        {
            get { return (bool)GetValue(isenableProperty); }
            set { SetValue(isenableProperty, value); }
        }

        // Using a DependencyProperty as the backing store for isenable.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty isenableProperty =
            DependencyProperty.Register("isenable", typeof(bool), typeof(Window), new PropertyMetadata(true));




        public bool isenable_2
        {
            get { return (bool)GetValue(isenable_2Property); }
            set { SetValue(isenable_2Property, value); }
        }

        // Using a DependencyProperty as the backing store for isenable_2.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty isenable_2Property =
            DependencyProperty.Register("isenable_2", typeof(bool), typeof(Window), new PropertyMetadata(true));



        public bool isChecked
        {
            get { return (bool)GetValue(isCheckedProperty); }
            set { SetValue(isCheckedProperty, value); }
        }

        // Using a DependencyProperty as the backing store for isChecked.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty isCheckedProperty =
            DependencyProperty.Register("isChecked", typeof(bool), typeof(Window), new PropertyMetadata(null));



        public bool isCheck_2
        {
            get { return (bool)GetValue(isCheck_2Property); }
            set { SetValue(isCheck_2Property, value); }
        }

        // Using a DependencyProperty as the backing store for isCheck_2.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty isCheck_2Property =
            DependencyProperty.Register("isCheck_2", typeof(bool), typeof(Window), new PropertyMetadata(null));



        //ctor
        public orderWindow()
        {
            InitializeComponent();
            visibility = Visibility.Visible;
        }

        //ctor
        public orderWindow(int orderId, bool flag)
        {
            InitializeComponent();
            Order = bl.Order.GetOrderDetails(orderId);
            if (flag)
                visibility = Visibility.Hidden;
            else
                visibility = Visibility.Visible;
        }

        //Response to an order shipping update confirmation event
        private void checkbox_ship_Checked(object sender, RoutedEventArgs e)
        {
            try
            {
                BO.Order order = (BO.Order)((TextBox)sender).DataContext;
                bl.Order.UppdateShipDate(int.Parse(IDTextBlock.Text));
            }
            catch (BlOrderAlredyShiped be)
            {
                MessageBox.Show(be.Message);
                isenable = false;
                isChecked = false;
            }
        }

        //Response to an order delivering update confirmation event
        private void checkbox_delivery_Checked(object sender, RoutedEventArgs e)
        {
            try
            {
                bl.Order.UppdateDeliveryDate(int.Parse(IDTextBlock.Text));
            }
            catch (BlOrderAlredyDelivered be)
            {
                MessageBox.Show(be.Message);
                isenable_2 = false;
                isCheck_2 = false;
            }

        }

    }
}

