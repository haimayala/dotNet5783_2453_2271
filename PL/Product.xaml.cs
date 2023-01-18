
using System;
using System.Windows;
using System.Windows.Media;
using System.Text.RegularExpressions;
using System.Globalization;
using System.Windows.Data;
using static BO.Enums;
using System.Windows.Input;
using System.Windows.Controls;
using DO;
using BO;

namespace PL;

/// <summary>
/// Interaction logic for Product.xaml
/// </summary>
public partial class Product : Window
{
    private static readonly BlApi.IBl bl = BlApi.Factory.Get()!;

    public BO.Product? product
    {
        get { return (BO.Product?)GetValue(productProperty); }
        set { SetValue(productProperty, value); }
    }

    // Using a DependencyProperty as the backing store for product.  This enables animation, styling, binding, etc...
    public static readonly DependencyProperty productProperty =
        DependencyProperty.Register("product", typeof(BO.Product), typeof(Window), new PropertyMetadata(null));

    public bool addOrUpdate
    {
        get { return (bool)GetValue(addOrUpdateProperty); }
        set { SetValue(addOrUpdateProperty, value); }
    }

    // Using a DependencyProperty as the backing store for addOrUpdate.  This enables animation, styling, binding, etc...
    public static readonly DependencyProperty addOrUpdateProperty =
        DependencyProperty.Register("addOrUpdate", typeof(bool), typeof(Window), new PropertyMetadata(null));


    
    public string addupdate
    {
        get { return (string)GetValue(addupdateProperty); }
        set { SetValue(addupdateProperty, value); }
    }

    // Using a DependencyProperty as the backing store for addupdate.  This enables animation, styling, binding, etc...
    public static readonly DependencyProperty addupdateProperty =
        DependencyProperty.Register("addupdate", typeof(string), typeof(Window), new PropertyMetadata(null));




    public Array Categories { get { return Enum.GetValues(typeof(Category)); } }

    // ctor for add case
    public Product(bool flag)
    {
        InitializeComponent();
        addOrUpdate = flag;
        if (!addOrUpdate)
            addupdate = "Add";
        categoryComboBox.ItemsSource = Enum.GetValues(typeof(BO.Enums.Category));
    }
    // ctor for update case
    public Product(int id, bool flag)
    {
        InitializeComponent();
        addOrUpdate = flag;
        if (addOrUpdate)
            addupdate = "Update";
        product = bl.Product.GetProductById(id);
        categoryComboBox.ItemsSource = Enum.GetValues(typeof(BO.Enums.Category));
    }

    //ctor for display mode

    private void btnAddOrUpdate_Click(object sender, RoutedEventArgs e)
    {
        //  in case of adding a product
        if (!addOrUpdate)
        {
            //Checking that the input is correct and appropriate
            BO.Product product = new BO.Product();
       
           //Initialize the product according The text boxes

            product.ID = int.Parse(iDTextBox.Text);
            product.Name = nameTextBox.Text;
            product.Price = int.Parse(priceTextBox.Text);
            product.Category = (BO.Enums.Category)categoryComboBox.SelectedItem;
            product.InStock = int.Parse(inStockTextBox.Text);

            // try to add the product
            try
            {
                bl?.Product.Add(product);
                Close();
            }
            // in case the adding faild
            catch (Exception ed)
            {
                MessageBox.Show(ed.Message);
            }
        }
        // in case of updating a product
        else
        {
            // make the match product
            BO.Product product = new BO.Product();
            //Initialize the product according The text boxes
            product.ID = int.Parse(iDTextBox.Text);
            product.Name = nameTextBox.Text;
            product.Price = int.Parse(priceTextBox.Text);
            product.Category = (BO.Enums.Category)categoryComboBox.SelectedItem;
            product.InStock = int.Parse(inStockTextBox.Text);
            try
            {
                bl?.Product.Uppdate(product);
                Close();
            }
            // in case the updatung faild
            catch (Exception ed)
            {
                MessageBox.Show(ed.Message);
           }
        }
    }

    
   

    private void btndl_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            bl.Product.Delete(product!.ID);  
            Close();
        }
        catch(BlNotExsistExeption ex)
        {
            MessageBox.Show(ex.Message);
        }
    }
}
