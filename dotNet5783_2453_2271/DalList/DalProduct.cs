//using DO;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

using DO;

namespace Dal;

public class DalProduct
{
   public void AddProduct(Product newProduct)
    {
        foreach (Product p in DataSource.Products)
        {
            if (p.ID == newProduct.ID)
                throw new Exception("This product is already exists");

        }
           DataSource.Products.Add(newProduct); 
    }

    public void DeleteProduct(int id)
    {
        foreach (Product p in DataSource.Products)
        {
            if (p.ID == id)
                DataSource.Products.Remove(p);  
        }
        throw new Exception("This product is not exsist");
    }

    public Product GetByID(int id)
    {
        foreach (Product p in DataSource.Products)
        {
            if (p.ID == id)
                return p;
        }
        throw new Exception("This product is not exsist");
    }

    public void UpdateProduct(Product newProduct)
    {
        foreach (Product p in DataSource.Products)
        {
            if (p.ID == newProduct.ID)
            {
                DataSource.Products.Remove(p);
                DataSource.Products.Add(newProduct);
                return;
            }
               
        }
        throw new Exception("This product is not exsist");
    }

    public IEnumerable<Product> GetAll()
    {
        return DataSource.Products; 
    }

}
