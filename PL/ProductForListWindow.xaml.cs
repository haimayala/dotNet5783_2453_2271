
using BO;
using System;

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
    BlApi.IBl? bl = BlApi.Factory.Get();


    //ctor
    public ProductForListWindow()
    {
        InitializeComponent();
        ProductListView.ItemsSource = bl.Product.GetListedProducts();
        CategorySelector.ItemsSource = Enum.GetValues(typeof(BO.Enums.Category));
    }


    // A function that responsible for the combobox event
    
    private void CategorySelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        
        var choise = CategorySelector.SelectedItem;
        // in case the user enter the NONE coise- show all the products
        if(choise.Equals(BO.Enums.Category.None))
            ProductListView.ItemsSource = bl?.Product.GetListedProducts();
        else
            ProductListView.ItemsSource = bl.Product.GetProductForListsByCategory((Category)choise);


    }

    //A function that responsible for the add product butten event
    private void btnAddProduct_Click(object sender, RoutedEventArgs e)
    {
        // show the addproduct window
        new Product().ShowDialog();
        ProductListView.ItemsSource = bl.Product.GetListedProducts();
    }

    //A function that responsible for the updateb productby double click
    private void ProductListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
    {
        // get the match id
        int id = ((ProductForList)ProductListView.SelectedItem).Id;
        // show the matc window
        new Product(id).ShowDialog();
        // get the lisst again for howing the updatung list
        ProductListView.ItemsSource = bl.Product.GetListedProducts(); 

       
    }
}


