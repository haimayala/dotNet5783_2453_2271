using BO;
namespace BlApi;

public interface ICart
{
    // A function that gets a cart and product id and add the match product to the cart 
    public BO.Cart Add(BO.Cart Cart, int productId);

    /* A function that gets a cart , product id and  new amount for uppdating
      and uppdate the amount od te match product inr the cart 
      and return the  updated cart */
    public Cart Uppdate(BO.Cart cart, int ProductId, int NewAmount);

    /*
     Avoid function thet confirms the order, Checks order integrity and product quantities
    and confirms or throws an exception accordingly*/     
    public void OrderConfirmation (Cart cart);   
}
