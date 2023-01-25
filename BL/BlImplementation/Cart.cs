
using BlApi;
using BO;
using DO;

using System.ComponentModel.DataAnnotations;

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
                if (product.InStock - orderItem.Amount > 0)
                {
                    orderItem.Amount += 1;
                    orderItem.TotalPrice = product.Price;
                }
                else
                    throw new BlNotEnoughInStockExeption("cannot add, not enoght in stock");
                
            }
            else
            {

                if (product.InStock > 0)
                {
                    BO.OrderItem newOrderItem = new BO.OrderItem()
                    {
                        Id=product.ID,
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
        if (NewAmount < 0)
            throw new BlUncorrectDetailsExeption("error negative amount!");
        DO.Product product = dal.Product.GetByID(ProductId);

        if (product.InStock < NewAmount)
            throw new BlNotEnoughInStockExeption("cannot add, not in stock");

        BO.OrderItem orderItem = cart.Items?.FirstOrDefault(x => x?.ProductId == ProductId)!;

        int x = cart.Items!.ToList().FindIndex(x => x?.Id == ProductId);
        if (orderItem == null)
            throw new BlNotExsistExeption("not exsist in the cart");
        if (NewAmount == 0)
        {
            cart.TotalPrice -= orderItem.TotalPrice;
            cart.Items?.Remove(orderItem);
            return cart;

        }

        else if (NewAmount == orderItem.Amount && NewAmount != 0)
        {
            if (product.InStock >= NewAmount)
            {
                orderItem.Amount = NewAmount;
                cart.TotalPrice = NewAmount * product.Price;
                orderItem.TotalPrice = NewAmount * product.Price;
                return cart;
            }
            else
                throw new BlNotEnoughInStockExeption("Cannot add, Not enough in stock ");
        }

        else if (orderItem.Amount < NewAmount)
        {
            if (product.InStock >= NewAmount + orderItem.Amount)
            {
                product.InStock -= NewAmount - orderItem.Amount;
                orderItem.TotalPrice += NewAmount * product.Price;
                cart.TotalPrice += NewAmount * product.Price;
                orderItem.Amount += NewAmount;

                return cart;
            }
            else
                throw new BlNotEnoughInStockExeption("Cannot add, Not enough in stock ");

        }
        return cart;
    }
   

        //A function that places the order that is in the customer's shopping cart
        public void OrderConfirmation(BO.Cart cart)
    {
       

        if (cart.CustomerName == null)
            throw new BO.BlUncorrectName(" uncorrect name");
        if (!new EmailAddressAttribute().IsValid(cart.CustomerEmail))
            throw new BO.BlUncorrectEmailExeption("uncorrect Email");
        if (cart.CustonerAddres == null)
            throw new BO.BlUncorrectAddres("uncorrect Address");
        if (cart?.Items?.Count() == 0)//no items in cart
            throw new BO.BlNullPropertyException("no items in cart");
        DO.Order order = new DO.Order()
        {
            CustomerName = cart?.CustomerName,
            CustomerEmail = cart?.CustomerEmail,
            CustomerAdress = cart?.CustonerAddres,
            OrderDate = DateTime.Now,
            DeliveryDate = null,
            ShipDate = null,
        };

        try
        {
            int orderID = dal.order.Add(order);

            cart?.Items?.ForEach(item => dal.orderItem.Add(new DO.OrderItem
            {
                OrderID = orderID,
                ProductID = item.ProductId,
                Amount = item.Amount,
                Price = item.Price,
            }));

            var products = from BO.OrderItem item in cart?.Items!
                           let upProduct = dal.Product.GetByID(item.ProductId)
                           select new DO.Product
                           {
                               ID = upProduct.ID,
                               Name = upProduct.Name,
                               Category = upProduct.Category,
                               Price = upProduct.Price,
                               InStock = upProduct.InStock,
                               Image = upProduct.Image,
                           };
            products.ToList().ForEach(item=>dal.Product.Uppdate(item));
           
         
        
        }
        catch (DO.DalDoesNotExsistExeption ex)
        {
            throw new BO.BlNotExsistExeption(ex.Message);
        }
    }
}

 
    

   




   

