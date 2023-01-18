using BO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace PL; 


/// <summary>
/// Interaction logic for orderForListWindow.xaml
/// </summary>
public partial class orderForListWindow : Window
{

    private static readonly BlApi.IBl bl = BlApi.Factory.Get()!;



    public List<BO.OrderForList?> orders
    {
        get { return (List<BO.OrderForList?>)GetValue(ordersProperty); }
        set { SetValue(ordersProperty, value); }
    }

    // Using a DependencyProperty as the backing store for orders.  This enables animation, styling, binding, etc...
    public static readonly DependencyProperty ordersProperty =
        DependencyProperty.Register("orders", typeof(List<BO.OrderForList>), typeof(Window), new PropertyMetadata(null));



    public orderForListWindow()
    {
        InitializeComponent();
        orders = bl.Order.GetLitedOrders().ToList();
    }

    private void orderForListListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
    {
        int id = ((OrderForList)orderForListListView.SelectedItem).ID;
        new orderWindow(id,false).ShowDialog();
    }
}
