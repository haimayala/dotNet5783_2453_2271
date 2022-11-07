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
    private void addNewProduct(Product newProduct)
    {
       
    }

    private void deleteProduct(int id)
    {
        for (int i = 0; i < 50; i++)
        {
            if (DataSource.arr1[i].ID==id)
            {
                
                return;
            }
        }

        throw new Exception("this product is not exsist");
    }

    private Product searchProduct(int id)
    {
        for (int i = 0; i < 50; i++)
        {
            if (DataSource.arr1[i].ID == id)
                return DataSource.arr1[i];
        }
        throw new Exception("this product is not exsist");
    }

    private void updateProduct(Product newOrderItem)
    {
        for(int i=0;i<50;i++)
        {
            if (DataSource.arr1[i].ID == newOrderItem.ID)
            {
                DataSource.arr1[i] = newOrderItem;
                return;
            }  
        }
        throw new Exception("this product is not exsist");
    }

    private void s_Initialize()
    {
        for(int i=0;i<10;i++)
        {

        }
    }

}
