

using System.Windows;


namespace PL;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private static readonly BlApi.IBl? bl = BlApi.Factory.Get();
  


    //ctor
    public MainWindow()
    {
        InitializeComponent();
    }

    
    // A function for the main butten click
    private void Press_here_Click(object sender, RoutedEventArgs e)
    {
        ShowProductsButton_Click(sender, e);
    }

    private void ShowProductsButton_Click(object sender, RoutedEventArgs e) => new ProductForListWindow().ShowDialog();

    private void btnNewOrder_Click(object sender, RoutedEventArgs e)
    {
        new ProductItem().ShowDialog();
    }
}
