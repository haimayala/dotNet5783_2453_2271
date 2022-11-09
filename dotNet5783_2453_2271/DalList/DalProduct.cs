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
   public void Add(Product newProduct)
    {
       for(int i=0;i<DataSource.Config.NumOfProducts;i++)
        {
            if (DataSource.Products[i].ID == newProduct.ID)
                throw new Exception("This product is already exists");
        }
        DataSource.Products[DataSource.Config.NumOfProducts] = newProduct;
        DataSource.Config.NumOfProducts++;
    }

    public void Delete(int id)
    {
        for (int i = 0; i < DataSource.Config.NumOfProducts; i++)
        {

            if (DataSource.Products[i].ID == id)
            {
                DataSource.Products[i] = DataSource.Products[DataSource.Config.NumOfProducts - 1];
                DataSource.Config.NumOfProducts--;
            }
                
        }
        throw new Exception("This product is not exsist");
    }

    public Product GetByID(int id)
    {
       for(int i=0;i<DataSource.Config.NumOfProducts;i++)
        {
            if (DataSource.Products[i].ID==id)
                return DataSource.Products[i];
        }
        throw new Exception("This product is not exsist");
    }

    public void Uppdate(Product newProduct)
    {
        for(int i=0;i<DataSource.Config.NumOfProducts;i++)
        {
            if (DataSource.Products[i].ID==newProduct.ID)
            {
                DataSource.Products[i] = newProduct;
                return;
            }    
        }
        throw new Exception("This product is not exsist");
    }

    public IEnumerable<Product> GetAll()
    {
        Product[] prr = new Product[DataSource.Config.NumOfProducts];  
        for(int i=0;i< DataSource.Config.NumOfProducts;i++)
        {
            prr[i]=DataSource.Products[i];
        }
        return prr; 
    }

}
