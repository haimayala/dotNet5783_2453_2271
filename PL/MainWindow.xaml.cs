

using BO;
using System.Collections.Generic;
using System.Windows;


namespace PL;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    
    private static readonly BlApi.IBl bl = BlApi.Factory.Get()!;

    //ctor
    public MainWindow()
    {
        InitializeComponent();
    }


  
    private void ShowProductsButton_Click(object sender, RoutedEventArgs e) => new ProductForListWindow().ShowDialog();

    // Click event response function for the dialog
    private void btnNewOrder_Click(object sender, RoutedEventArgs e)
    {
       
        new ProductItem().ShowDialog();
    }

    //Click event response function for the mannager window
    private void btnMannager_Click(object sender, RoutedEventArgs e)
    {
        new adminWindow().ShowDialog();

    }

  //  Click event response functionfor the order trucking
    private void btnTrucking_Click(object sender, RoutedEventArgs e)
    {

        int id = int.Parse(truckingId.Text);
        try
        {
            // get the order from the BL by the id
            Order or = bl.Order.GetOrderDetails(id);
            new OrderTrackingWindow(id).ShowDialog();
        }
        catch (BlNotExsistExeption be)
        {
            MessageBox.Show(be.Message, "ERROR",MessageBoxButton.OK, MessageBoxImage.Error);
        }
       
    }

   
}
