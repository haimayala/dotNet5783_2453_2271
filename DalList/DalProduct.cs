using DO;
using DalApi;
namespace Dal;

internal class DalProduct :IProduct
{
    public int Add(Product newProduct)
    {//the method adds a product to the products arry

        for (int i = 0; i < DataSource.s_products.Count; i++)
        {//checks if the product's id already exists
            if (DataSource.s_products[i].ID == newProduct.ID)
                throw new Exception("This product is already exists");
        }
        DataSource.s_products.Add(newProduct);
        return newProduct.ID;
    }

    public void Delete(int id)
    {//The method deletes the product with the received ID
        for (int i = 0; i < DataSource.s_products.Count; i++)
        {//Goes through the array

            if (DataSource.s_products[i].ID == id)
            {
                DataSource.s_products.Remove(DataSource.s_products[i]);             
                return;
            }
        }
        //If the product is not found
        throw new Exception("This product is not exsist");
    }

    public Product GetByID(int id)
    {//Finds a product by ID
        for (int i = 0; i < DataSource.s_products.Count; i++)
        {
            if (DataSource.s_products[i].ID == id)
                return DataSource.s_products[i];
        }
        throw new Exception("This product is not exsist");
    }

    public void Uppdate(Product newProduct)
    {//Updates a product according to the ID
        for (int i = 0; i < DataSource.s_products.Count; i++)
        {
            if (DataSource.s_products[i].ID == newProduct.ID)
            {
                DataSource.s_products.Add(newProduct);
                return;
            }
        }
        throw new Exception("This product is not exsist");
    }

    public IEnumerable<Product> GetAll()
    {//Returns an array containing all products

        List<Product> list = new List<Product>();
        list=DataSource.s_products;
        return list;
    }

}
