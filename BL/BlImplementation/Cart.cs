
using BlApi;
using BO;


namespace BlImplementation;

internal class Cart : ICart
{
    private static readonly DalApi.IDal dal = DalApi.Factory.Get()!;

    // A function that gets a cart and product id and add the match product to the cart 
    public BO.Cart Add(BO.Cart cart, int ProductID)
    {
        try
        {
            DO.Product product = dal.Product.GetByID(ProductID);

            BO.OrderItem orderItem = cart.Items?.FirstOrDefault(item => item?.ProductId == ProductID)!;
            if (orderItem != null)
            {
                if (product.InStock > 0)
                {
                    orderItem.Amount += 1;
                    orderItem.TotalPrice = product.Price;
                }
                
            }
            else
            {

                if (product.InStock > 0)
                {
                    BO.OrderItem newOrderItem = new BO.OrderItem()
                    {
                        //Id = orderItem!.Id,
                        ProductName = product.Name,
                        Price = (int)product.Price,
                        Amount = 1,
                        ProductId = product.ID,
                        ImageRelativeName = @"\picss\IMG" + product.ID + ".jpg"
                    };
                    newOrderItem.TotalPrice += product.Price;
                    cart.Items!.Add(newOrderItem);
                }
            }


            cart.TotalPrice += product.Price;
            return cart;
        }
        catch(DO.DalDoesNotExsistExeption)
        {
            throw new DO.DalDoesNotExsistExeption(" product not exsist");
        }
        
    }
    /* A function that gets a cart, product id and  new amount for uppdating
       and uppdate the amount od te match product inr the cart
       and return the updated cart*/
    public BO.Cart Uppdate(BO.Cart cart, int ProductId, int NewAmount)
    {
        // get the product from tha data layer for checking the amount in stock
        try
        {
            DO.Product product = dal.Product.GetByID(ProductId);
            // find the product in the cart

            foreach (var item in cart.Items!)
            {
                if (item?.ProductId == ProductId)
                {

                    // In the case of increasing the quantity
                    if (item.Amount < NewAmount)
                    {
                        if (product.InStock >= NewAmount + item.Amount)
                        {
                            product.InStock -= NewAmount - item.Amount;
                            item.TotalPrice += NewAmount * product.Price;
                            cart.TotalPrice += NewAmount * product.Price;
                            item.Amount += NewAmount;

                            return cart;
                        }
                        else
                            throw new BlNotEnoughInStockExeption("Cannot add, Not enough in stock ");

                    }
                    // In the case of reducing the quantity
                    else if (item.Amount > NewAmount && NewAmount != 0)
                    {
                        product.InStock += item.Amount - NewAmount;

                        if (NewAmount > 0)
                        {
                            item.Amount -= NewAmount;
                            item.TotalPrice -= NewAmount * product.Price;
                            cart.TotalPrice -= NewAmount * product.Price;
                        }

                        else
                        {
                            item.Amount += NewAmount;
                            item.TotalPrice += NewAmount * product.Price;
                            cart.TotalPrice += NewAmount * product.Price;
                        }
                        return cart;
                    }

                    else if (NewAmount == item.Amount && NewAmount!=0)
                    {
                        if(product.InStock>= NewAmount)
                        {
                            item.Amount = NewAmount;
                            cart.TotalPrice = NewAmount * product.Price;
                            item.TotalPrice = NewAmount * product.Price;
                        }
                        else
                            throw new BlNotEnoughInStockExeption("Cannot add, Not enough in stock ");
                    }

                    //In case of deletion of the product
                    else if (NewAmount == 0)
                    {
                        cart.TotalPrice -= item.TotalPrice;
                        cart.Items.Remove(item);
                        return cart;
                        //dal.orderItem.Delete(item.Id);
                    }
                   
                }
            }
            return cart;

        }
        catch (DO.DalDoesNotExsistExeption)
        {
            throw new DO.DalDoesNotExsistExeption("product not exsist");
        }


    }

    //A function that places the order that is in the customer's shopping cart
    public void OrderConfirmation(BO.Cart cart)
    {
       // check if the customer email is correct
        string? s = cart.CustomerEmail!;
        if (!s.Contains('@') || s.IndexOf('@') == 0 || s.IndexOf('@') == s.Length)
            throw new BlUncorrectEmailExeption("uncorrect email");
        // check if the customer name is correct
        if (cart.CustomerName == "")
            throw new BlUncorrectName("pleasec enter your name");
        // check if the customer addres is correct
        if (cart.CustonerAddres == "")
            throw new BlUncorrectAddres("pleasec enter your addres");
        if (!CheckData(cart))
            throw new BlUncorrectDetailsExeption("uncorrecr details");
        //make a order entity
        DO.Order doOrder = new DO.Order()
            {
                CustomerName = cart.CustomerName,
                CustomerAdress = cart.CustomerEmail,
                CustomerEmail =cart.CustonerAddres,
                OrderDate = DateTime.Now,
                ShipDate = DateTime.MinValue,
                DeliveryDate = DateTime.MinValue,
            };
            try
            {
                int OrderNumber = dal.order.Add(doOrder);
                foreach (var item in cart.Items!)
                {
                    DO.OrderItem DoOrderItem = new DO.OrderItem()
                    {
                        ID = item!.Id,
                        ProductID = item.ProductId,
                        OrderID = OrderNumber,
                        Price = item.Price,
                        Amount = item.Amount, 
                        
                    };

                    dal.orderItem.Add(DoOrderItem);
                cart.TotalPrice += DoOrderItem.Price;

                    DO.Product updateProduct = dal.Product.GetByID(item.ProductId);
                    updateProduct.InStock -= item.Amount;
                   


                }
            }
            catch (DO.DalDoesNotExsistExeption )
            {
                throw new DO.DalDoesNotExsistExeption("order item not exsist");
            }
        
       
    }

    // A help functioin that ckeck that all the data cart are correct
    private bool CheckData(BO.Cart cart)
    {
        foreach (var item in cart.Items!)
        {

            DO.Product doProduct = dal.Product.GetByID(item!.ProductId);
            if (doProduct.InStock < item.Amount || item.Amount < 0)
                return false;

        }
        return true;
    }  // למחוק את הפוראיצ

    

   
}



   

