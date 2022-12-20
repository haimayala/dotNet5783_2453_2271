  
using BO;
using static BO.Enums;
namespace BlApi;

public interface IProduct
{ 

    // A function that shows the manager a list of products
   public IEnumerable<BO.ProductForList?> GetListedProducts(Func<BO.ProductForList?, bool>? func=null);

    //A function that shows the product details to the manager based on a product code
    public BO.Product GetProductById(int productId);

    // A function that gets a product id and shopping cart , the function show the buyer the product details
    public BO.ProductItem GetProductDetails(int productId/*, Cart cart*/);    

    /*A function that gets a product and try to add this product to the product
      list by the the data layer , in case of incorrect input an exception will be thrown*/
    public void Add(BO.Product product);

    /* A function that deletes a product according to a product id 
     in case of incorrect input an exception will be thrown*/
    public void Delete(int ProductId);

    /*A function that receives a product and, if everything is in order,
    updates the product by the the data layer
    in case of incorrect input an exception will be thrown*/
    public void Uppdate(BO.Product product);

    IEnumerable<ProductForList?> GetProductForListsByCategory(BO.Enums.Category category);
}
