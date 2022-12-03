using BlApi;
using BO;
using System.Collections.Specialized;

namespace BlImplementation;

internal class Product : IProduct
{
    DalApi.IDal dal = new Dal.DalList();

    // A function that shows the manager a list of products
    public IEnumerable<BO.ProductForList?> GetListedProducts()
    {
        // get the list of products from the data layer
        return from DO.Product? doProduct in dal.Product.GetAll()
               select new BO.ProductForList
               {
                   Id = (int)(doProduct?.ID),
                   Name = doProduct?.Name,
                   category = (Enums.Category)(doProduct?.Category),
                   Price = (int)(doProduct?.Price)
               };
    }

   // A function that shows the product details to the manager based on a product code
    public BO.Product GetProductById(int productId )
    {
        if (productId > 0)
        {
            // Get the product from the data layer
            DO.Product prod = dal.Product.GetByID(productId);
            // Constructing an object of type BO פרםגובא
            BO.Product product = new BO.Product()
            {
                //Copy the respective fields
                ID = prod.ID,
                Name = prod.Name,
                InStock = prod.InStock,
                Category = (Enums.Category)prod.Category,
                Price = prod.Price
            };
            // return the BO product
            return product;
        }
        throw new Exception("negative id");
    }

    // A function that gets a product id and shopping cart, the function show the buyer the product details
    public BO.ProductItem GetProductDetails(int productId/*, BO.Cart cart*/)
    {
        if(productId>0)
        {
            // get the product from the data layer
            DO.Product product=dal.Product.GetByID(productId);
            BO.ProductItem productItem = new BO.ProductItem()
            {
                ID = product.ID,
                Name = product.Name,
                Category = (Enums.Category)product.Category,
                Price = (int)product.Price,
            };
            if (product.InStock > 0)
                productItem. Availability = true;
            else
                productItem.Availability = false;
            // !!!לבדוק!!!
            productItem.AmountInCart=product.InStock;
            return productItem;
        }
        throw new NotImplementedException();
    }


    // A function that gets a BO product, check the data integrity and add this product to the products list by the data layer
    public void Add(BO.Product product)//Copy the respective fields
    {
        // Checks that all data is correct
        if (product.ID>0 && product.Name!="" && product.InStock>0)
        {
            // Creating an product that belongs to the data layer 
            DO.Product prod = new DO.Product()
            {
                //Copy the respective fields
                Price = product.Price,
                Name = product.Name,
                InStock = product.InStock,
                Category = product.Category,
                ID = product.ID
            }; 
            // add the DO product
            dal.Product.Add(prod);
        }
    }

    /* A function that deletes a product according to a product id 
    in case of incorrect input an exception will be thrown*/

    public void Delete(int ProductId)
    {
        // get all the orders from the data layer
        IEnumerable<DO.Order> orders = (IEnumerable<DO.Order>)dal.order.GetAll();
        // check if the product not exsist in any order
       if( CheckExsist(orders ,ProductId)==true)
        {
            dal.Product.Delete(ProductId);
        }
    }

    /*A function that receives a product and, if everything is in order,
    updates the product by the the data layer
    in case of incorrect input an exception will be thrown*/
    public void Uppdate(BO.Product product)
    {
        // Checks that all data is correct
        if (product.ID>0 && product.Name!= "" && product.InStock>0 && product.Price>0)
        { 
            //Copy the respective fields
            DO.Product prod = new DO.Product
            {
                Price = product.Price,
                Name = product.Name,
                InStock = product.InStock,
                ID = product.ID,
                Category = product.Category,
            }; 
            //uppdate the DO product
            dal.Product.Uppdate(prod);
        }
    }

   
    // a help function for checking that the product not exsist in any order for delee
    private bool CheckExsist(IEnumerable<DO.Order> orders , int productId)
    {
        foreach (DO.Order order in orders)
        {
            IEnumerable<DO.OrderItem> orderItems = (IEnumerable<DO.OrderItem>)dal.orderItem.GetByOrderId(order.ID);
            foreach (DO.OrderItem item in orderItems)
            {
                if (item.ProductID == productId)
                    return false;
            }
        }
        return true;
    }

    
}

