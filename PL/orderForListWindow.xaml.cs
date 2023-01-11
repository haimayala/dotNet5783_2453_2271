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


    

         



    public orderForListWindow()
    {
        InitializeComponent();

        orderForListListView.ItemsSource = bl.Order.GetLitedOrders();

    }

    private void orderForListListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
    {
        int id = ((OrderForList)orderForListListView.SelectedItem).ID;
        new orderWindow(id,true).ShowDialog();
    }
}
