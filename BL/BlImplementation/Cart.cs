
using BlApi;
using BO;
using MailChimp.Net.Interfaces;

namespace BlImplementation;

internal class Cart : ICart
{
    DalApi.IDal dal = new Dal.DalList();

    // A function that gets a cart and product id and add the match product to the cart 
    public BO.Cart Add(BO.Cart cart, int ProductID)
    {
        try
        {
            DO.Product product = dal.Product.GetByID(ProductID);

            BO.OrderItem orderItem = cart.Items.FirstOrDefault(item => item.ProductId == ProductID);
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
                        //Id = orderItem.Id,
                        ProductName = product.Name,
                        Price = (int)product.Price,
                        Amount = 1,
                        TotalPrice = product.Price,
                        ProductId = product.ID
                    };
                    cart.Items.Add(newOrderItem);
                }
            }


            cart.TotalPrice += product.Price;
            return cart;
        }
        catch(DO.DalDoesNotExsist de)
        {
            throw new DO.DalDoesNotExsist(" product not exsist");
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


            foreach (var item in cart.Items)
            {
                if (item.ProductId == ProductId)
                {
                    // In the case of increasing the quantity
                    if (item.Amount < NewAmount)
                    {
                        if (product.InStock >= NewAmount - item.Amount)
                        {
                            product.InStock -= NewAmount - item.Amount;
                            item.Amount += NewAmount;
                            cart.TotalPrice += (NewAmount - item.Amount) * product.Price;
                            return cart;
                        }
                        else
                            throw new BlNotEnoughInStock("Cannot add, Not enough in stock ");

                    }
                    // In the case of reducing the quantity
                    else if (item.Amount > NewAmount && NewAmount!=0)
                    {
                        product.InStock += item.Amount - NewAmount;
                        item.Amount -= NewAmount;
                        cart.TotalPrice -= (item.Amount - NewAmount) * product.Price;
                        return cart;
                    }
                    //In case of deletion of the product
                    else if (NewAmount == 0)
                    {
                        cart.TotalPrice -= item.Price;
                        cart.Items.Remove(item);
                        return cart;
                        //dal.orderItem.Delete(item.Id);
                    }
                }
            }
            return cart;
        }
        catch (DO.DalDoesNotExsist de)
        {
            throw new DO.DalDoesNotExsist("product not exsist");
        }



    }

    //A function that places the order that is in the customer's shopping cart
    public void OrderConfirmation(BO.Cart cart, string CusName, string CusEmail, string CusAddres)
    {
        //Data integrity check
        if (CusName != "" && CusEmail != "" && CusAddres != "" && CheckData(cart) == true)
        {
            
            DO.Order doOrder = new DO.Order()
            {
                CustomerName = CusName,
                CustomerAdress = CusAddres,
                CustomerEmail = CusEmail,
                OrderDate = DateTime.Now,
                ShipDate = DateTime.MinValue,
                DeliveryDate = DateTime.MinValue,
            };
            try
            {
                int OrderNumber = dal.order.Add(doOrder);
                foreach (var item in cart.Items)
                {
                    DO.OrderItem DoOrderItem = new DO.OrderItem()
                    {
                        ID = item.Id,
                        ProductID = item.ProductId,
                        OrderID = OrderNumber,
                        Price = item.Price,
                        Amount = item.Amount,
                    };

                    dal.orderItem.Add(DoOrderItem);

                    DO.Product updateProduct = dal.Product.GetByID(item.ProductId);
                    updateProduct.InStock -= item.Amount;
                    dal.Product.Uppdate(updateProduct);


                }
            }
            catch (DO.DalDoesNotExsist de)
            {
                throw new DO.DalDoesNotExsist("order item not exsist");
            }
           
        }
        else
        {
            throw new  BO.BlUncorrectDetails("unncorect details");
        }
    }

    // A help functioin that ckeck that all the data cart are correct
    private bool CheckData(BO.Cart cart)
    {
        foreach (var item in cart.Items)
        {

            DO.Product doProduct = dal.Product.GetByID(item.ProductId);
            if (doProduct.InStock < item.Amount || item.Amount < 0)
                return false;

        }
        return true;
    }

    //A help function that check if some product exsist in the product list in the order 
    private bool Exsist(BO.Cart cart, int productId)
    {
        if (cart.Items.Count() == 0)
            return false;
        foreach (var item in cart.Items)
        {
            if (item.ProductId == productId)
                return true;
        }
        return false;
    }

   
}



   

