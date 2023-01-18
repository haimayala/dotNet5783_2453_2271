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
    /// Interaction logic for adminWindow.xaml
    /// </summary>
    public partial class adminWindow : Window
    {
        //ctor 
        public adminWindow()
        {
            InitializeComponent();
        }

        // function for the orders click event
        private void btnOrders_Click(object sender, RoutedEventArgs e)
        {
            new ProductForListWindow().ShowDialog();
        }

        // function for the products click event
        private void btnProducts_Click(object sender, RoutedEventArgs e)
        {
            new orderForListWindow().ShowDialog();
        }
    }
}
