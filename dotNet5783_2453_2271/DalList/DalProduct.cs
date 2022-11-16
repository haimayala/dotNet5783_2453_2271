

using DO;

namespace Dal;

public class DalProduct
{
    public int Add(Product newProduct)
    {//the method adds a product to the products arry

        for (int i = 0; i < DataSource._numOfProducts; i++)
        {//checks if the product's id already exists
            if (DataSource._products[i].ID == newProduct.ID)
                throw new Exception("This product is already exists");
        }
        DataSource._products[DataSource._numOfProducts] = newProduct;
        DataSource._numOfProducts++;
        return newProduct.ID;
    }

    public void Delete(int id)
    {//The method deletes the product with the received ID
        for (int i = 0; i < DataSource._numOfProducts; i++)
        {//Goes through the array

            if (DataSource._products[i].ID == id)
            {
                DataSource._products[i] = DataSource._products[DataSource._numOfProducts - 1];
                DataSource._numOfProducts--;
                return;
            }

        }
        //If the product is not found
        throw new Exception("This product is not exsist");
    }

    public Product GetByID(int id)
    {//Finds a product by ID
        for (int i = 0; i < DataSource._numOfProducts; i++)
        {
            if (DataSource._products[i].ID == id)
                return DataSource._products[i];
        }
        throw new Exception("This product is not exsist");
    }

    public void Uppdate(Product newProduct)
    {//Updates a product according to the ID
        for (int i = 0; i < DataSource._numOfProducts; i++)
        {
            if (DataSource._products[i].ID == newProduct.ID)
            {
                DataSource._products[i] = newProduct;
                return;
            }
        }
        throw new Exception("This product is not exsist");
    }

    public Product[] GetAll()
    {//Returns an array containing all products
        int size = DataSource._numOfProducts;
        Product[] prr = new Product[DataSource._numOfProducts];
        for (int i = 0; i < DataSource._numOfProducts; i++)
        {
            prr[i] = DataSource._products[i];
        }
        return prr;
    }

}
