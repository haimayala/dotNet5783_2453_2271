
using BO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

using static BO.Enums;

namespace PL;

/// <summary>
/// Interaction logic for Window1.xaml
/// </summary>
public partial class ProductForListWindow : Window
{

    private static readonly BlApi.IBl bl = BlApi.Factory.Get()!;
    public Array Categories { get { return Enum.GetValues(typeof(Category)); } }

   

    //ctor
    public ProductForListWindow()
    {
        InitializeComponent();
        
        //productForListListView.ItemsSource = bl.Product.GetListedProducts();
        //CategorySelector.ItemsSource = Enum.GetValues(typeof(Category));
    }

    // A function that responsible for the combobox event

    private void CategorySelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        
        var choise = CategorySelector.SelectedItem;
        // in case the user enter the NONE coise- show all the products
        if(choise.Equals(Category.None))
            productForListListView.ItemsSource = bl?.Product.GetListedProducts();
        else
            productForListListView.ItemsSource = bl?.Product.GetProductForListsByCategory((Category)choise);
    }

    //A function that responsible for the add product butten event
    private void btnAddProduct_Click(object sender, RoutedEventArgs e)
    {
        // show the addproduct window
        new Product(false).ShowDialog();
        productForListListView.ItemsSource = bl.Product.GetListedProducts();
    }

    //A function that responsible for the updateb productby double click
    private void productForListListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
    {
        // get the match id
        int id = ((ProductForList)productForListListView.SelectedItem).Id;
        // show the matc window
        new Product(id, true).ShowDialog();
        // get the lisst again for howing the updatung list
        productForListListView.ItemsSource = bl.Product.GetListedProducts();

    }

    // function that vdelete a product from the product list
    private void prod_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            BO.ProductForList p = (BO.ProductForList)((Button)sender).DataContext;
            bl.Product.Delete(p.Id);
            productForListListView.ItemsSource = bl.Product.GetListedProducts();
        }

        catch (BlNotExsistExeption ex)
        {
            MessageBox.Show(ex.Message);
        }
    }
        
}


