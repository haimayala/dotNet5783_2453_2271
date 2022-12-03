using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlApi;

namespace BlImplementation;

internal class Cart :ICart
{
   

    public BO.Cart Add(int ProductId)
    {
        throw new NotImplementedException();
    }

    public void OrderConfirmation(BO.Cart cart, string CusName, string CusEmail, string CusAddres)
    {
        throw new NotImplementedException();
    }

   

    public BO.Cart Uppdate(int ProductId, int NewAmount)
    {
        throw new NotImplementedException();
    }
}

