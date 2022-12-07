using DO;
using DalApi;
namespace Dal;

internal class DalProduct :IProduct
{
    // A function that gets a new product and in case its allredy not exsist add the product to the product list
    public int Add(Product newProduct)
    {//the method adds a product to the products arry
       if(DataSource.s_products.Exists(x=>x.ID==newProduct.ID))
            throw new DO.DalDoesNotExsist("product allredy exsist");
       else
        {
            DataSource.s_products.Add(newProduct);
            return newProduct.ID;
        }
            
    }

    // A function that gets a product id and delete the match product from the product list
    public void Delete(int id)
    {//The method deletes the product with the received ID
        if (!DataSource.s_products.Exists(x => x.ID == id))
            throw new DO.DalDoesNotExsist("product not exsist");
        else
            DataSource.s_products.Remove(DataSource.s_products.Find(x => x.ID == id));
    }

    // A function that gets a product id and return the match product
    public Product GetByID(int id)
    {
        if (!DataSource.s_products.Exists(x => x.ID == id))
            throw new DO.DalDoesNotExsist("product not exsist");
        else
            return DataSource.s_products.Find(x => x.ID == id);
    }
    
    // A function that gets a new product and update the match product in the product list
    public void Uppdate(Product newProduct)
    {//Updates a product according to the ID
        if (!DataSource.s_products.Exists(x => x.ID == newProduct.ID))
            throw new DO.DalDoesNotExsist("product not exsist");
        else
        {
            DataSource.s_products.Remove(DataSource.s_products.Find(x=>x.ID==newProduct.ID));
            DataSource.s_products.Add(newProduct);
        }
    }

    // A function that return all the product list
    public IEnumerable<Product> GetAll()
    {//Returns an array containing all products

        List<Product> list = new List<Product>();
        list=DataSource.s_products;
        return list;
    }

}
