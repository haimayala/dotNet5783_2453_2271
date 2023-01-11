using BlApi;
using BO;
using System.Data;

namespace BlImplementation;

internal class Product : IProduct
{
    private static readonly DalApi.IDal dal = DalApi.Factory.Get()!;

    // A function that shows the manager a list of products
    public IEnumerable<ProductForList?> GetListedProducts(Func<BO.ProductForList?, bool>? func)
    {
        // get the list of products from the data layer
        IEnumerable<BO.ProductForList?> list = from DO.Product? doProduct in dal.Product.GetAll()
                                               select new BO.ProductForList
                                               {
                                                   Id = (int)(doProduct?.ID)!,
                                                   Name = doProduct?.Name,
                                                   category = (Enums.Category)(doProduct?.Category)!,
                                                   Price = (int)(doProduct?.Price)!,
                                                  ImageRelativeName=@"\picss\IMG"+doProduct.Value.ID+".jpg"
                                               };
        return func is null ? list : list.Where(func);
    }

    // A function that shows the product details to the manager based on a product code
    public BO.Product GetProductById(int productId)
    {

        if (productId > 0)
        {
            //try to get the product from the data layer
            try
            {
                DO.Product prod = dal.Product.GetByID(productId);
                BO.Product product = new BO.Product()
                {
                    //Copy the respective fields
                    ID = prod.ID,
                    Name = prod.Name,
                    InStock = prod.InStock,
                    Category = (Enums.Category)prod.Category!,
                    Price = prod.Price,
                     ImageRelativeName = @"\picss\IMG" + prod.ID + ".jpg"

                };
                return product;
            }
            catch (DO.DalDoesNotExsistExeption)
            {
                throw new DO.DalDoesNotExsistExeption(" this product not exsist");
            }
            // Constructing an object of type BO

        }
        else
        {
            throw new BO.BlUnCorrectIDExeption("uncorrect id");
        }

    }

    // A function that gets a product id and shopping cart, the function show the buyer the product details
    public BO.ProductItem GetProductDetails(int productId)
    {
        try
        {
            if (productId > 0)
            {
                // get the product from the data layer

                DO.Product product = dal.Product.GetByID(productId);

                BO.ProductItem productItem = new BO.ProductItem()
                {
                    ID = product.ID,
                    Name = product.Name,
                    Category = (Enums.Category)product.Category!,
                    Price = (int)product.Price,
                    ImageRelativeName = @"\picss\IMG" + product.ID + ".jpg"

                };
                if (product.InStock > 0)
                    productItem.Availability = true;
                else
                    productItem.Availability = false;

                productItem.Amount = 0;
                return productItem;
            }
            else
            {
                throw new BO.BlUnCorrectIDExeption("uncorrect id");
            }
        }
        catch (DO.DalDoesNotExsistExeption)
        {
            throw new DO.DalDoesNotExsistExeption("product not exsist");
        }


    }


    // A function that gets a BO product, check the data integrity and add this product to the products list by the data layer
    public void Add(BO.Product product)//Copy the respective fields
    {
        // Checks that all data is correct
        if (product.ID > 0 && product.Name != "" && product.InStock > 0 && product.Price >= 0)
        {
            // Creating an product that belongs to the data layer 
            DO.Product prod = new DO.Product()
            {
                //Copy the respective fields
                Price = product.Price,
                Name = product.Name,
                InStock = product.InStock,
                Category = (DO.Enums.Category?)product.Category,
                ID = product.ID
            };
            // add the DO product
            try
            {
                dal.Product.Add(prod);
            }
            catch (DO.DalAllredyExsisExeption)
            {
                throw new DO.DalAllredyExsisExeption("cannnot add, product alredy exsit");
            }

        }
        else if (product.ID <= 0)
        {
            throw new BlUnCorrectIDExeption("uncorrect id, please enter a correct id");
        }
        else if (product.Name == "")
        {
            throw new BlUncorrectName("uncorrect name, please enter a correct name");
        }
        else if (product.InStock < 0)
        {
            throw new BlNotEnoughInStockExeption("uncorrect in stock, please enter a correct number");
        }
        else if (product.Price <= 0)
        {
            throw new BlUncorrectPrice("uncorrect in Price, please enter a correct Price");
        }
    }

    /* A function that deletes a product according to a product id 
    in case of incorrect input an exception will be thrown*/

    public void Delete(int ProductId)
    {
        try
        {
            dal.Product.GetByID(ProductId);
        }
        catch (DO.DalDoesNotExsistExeption e)
        {
            Console.WriteLine(e);
        }
        // get all the orders from the data layer
        IEnumerable<DO.Order?> orders = dal.order.GetAll();
        // check if the product not exsist in any order
        if (CheckExsist(orders, ProductId) == true)
        {
            try
            {
                dal.Product.Delete(ProductId);
            }
            catch (DO.DalDoesNotExsistExeption)
            {
                throw new DO.DalDoesNotExsistExeption("cannot delete,product not exist");
            }
        }
        else
        {
            throw new BlNotExsistExeption("product exsist in some order");
        }
    }

    /*A function that receives a product and, if everything is in order,
    updates the product by the the data layer
    in case of incorrect input an exception will be thrown*/
    public void Uppdate(BO.Product product)
    {
        // Checks that all data is correct
        if (product.ID > 0 && product.Name != "" && product.InStock > 0 && product.Price > 0)
        {
            //Copy the respective fields
            DO.Product prod = new DO.Product
            {
                Price = product.Price,
                Name = product.Name,
                InStock = product.InStock,
                ID = product.ID,
                Category = (DO.Enums.Category?)product.Category,
            };
            //uppdate the DO product
            try
            {
                dal.Product.Uppdate(prod);
            }
            catch (DO.DalDoesNotExsistExeption)
            {
                throw new DO.DalDoesNotExsistExeption("cannot uppdate, product not exsist");
            }

        }
        else if (product.ID <= 0)
        {
            throw new BlUnCorrectIDExeption("uncorrect id, please enter a correct id");
        }
        else if (product.Name == "")
        {
            throw new BlUncorrectName("uncorrect name, please enter a correct name");
        }
        else if (product.InStock < 0)
        {
            throw new BlNotEnoughInStockExeption("uncorrect in stock, please enter a correct number");
        }
        else if (product.Price <= 0)
        {
            throw new BlUncorrectPrice("uncorrect in Price, please enter a correct Price");
        }
    }


    // a help function for checking that the product not exsist in any order for delee
    private bool CheckExsist(IEnumerable<DO.Order?> orders, int productId)
    {
        foreach (DO.Order order in orders)
        {
            IEnumerable<DO.OrderItem?> orderItems = dal.orderItem.GetByOrderId(order.ID);
            foreach (DO.OrderItem item in orderItems)
            {
                if (item.ProductID == productId)
                    return false;
            }
        }
        return true;
    } // למחוק את הפור איצ

    public IEnumerable<ProductForList?> GetProductForListsByCategory(Enums.Category category)
    {
        return GetListedProducts(p => p?.category == category);
    }

  

    // A function that shows the customer a list of productsItem
    public IEnumerable<ProductItem?> GetProductItems(Func<ProductItem?, bool>? func = null)
    {

        IEnumerable<ProductItem?> productItems = from DO.Product? pro in dal.Product.GetAll()
                                                 select new ProductItem
                                                 {
                                                     ID = pro.Value.ID,
                                                     Name = pro.Value.Name,
                                                     Price = (int)pro.Value.Price,
                                                     Category = (Enums.Category?)pro.Value.Category,
                                                     Amount = 0,
                                                     Availability = GetAvailability(pro),
                                                     ImageRelativeName = @"\picss\IMG" + pro.Value.ID + ".jpg"
                                                 };

        return func is null ? productItems : productItems.Where(func);

    }

    bool GetAvailability(DO.Product? p)
    {
        return p.Value.InStock > 0;
    }

    IEnumerable<ProductItem?> IProduct.GetProductItemsByCategory(Enums.Category category)
    {
        return GetProductItems(p => p?.Category == category);
    }
}