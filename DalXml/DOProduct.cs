
using DalApi;
using DO;
using System.Xml.Linq;

namespace Dal;

internal class DOProduct : IProduct
{

    string s_products = "products";

    static DO.Product? createProductFromElement(XElement P)
    {
        return new DO.Product
        {
            ID = P.ToIntNullable("ID") ?? throw new FormatException("id"),
            Name = (string?)P.Element("Name"),
            Price = P.ToDoubleNullable("Price") ?? throw new FormatException("price"),
            InStock = P.ToIntNullable("InStock") ?? throw new FormatException("inStock"),
            Image=(string?)P.Element("Image"),
            Category=P.ToEnumNullable<DO.Enums.Category>("Category")
            
        };
    }
    public int Add(Product pro)
    {
       
        XElement? rootProducts = XMLTools.LoadListFromXMLElement(s_products);
        XElement? myp=(from p in rootProducts.Elements()
                       where p.ToIntNullable("ID") ==pro.ID
                       select p).FirstOrDefault();
        if (myp != null)
            throw new Exception("is alredy exsist");
        pro.ID = DalConfig.GetNextProductId();
        XElement product = new XElement("Product",
            new XElement("ID", pro.ID),
            new XElement("Name", pro.Name),
            new XElement("Price", pro.Price),
            new XElement("InStock", pro.InStock),
            new XElement("Category", pro.Category)
            );

        rootProducts.Add(product);
        DalConfig.SaveNextProductID(pro.ID+1);
        XMLTools.SaveListToXMLElement(rootProducts, s_products);
        return pro.ID;
    }

    public void Delete(int id)
    {
        XElement? rootProducts = XMLTools.LoadListFromXMLElement(s_products);
        XElement? myp = (from p in rootProducts.Elements()
                         where p.ToIntNullable("ID") ==id
                         select p).FirstOrDefault() ?? throw new Exception("missing id");
        myp.Remove();
        //DalConfig.SaveNextProductID(id-1);
        XMLTools.SaveListToXMLElement(rootProducts, s_products);
       
    }

    public IEnumerable<Product?> GetAll(Func<Product?, bool>? func = null)
    {
        XElement? rootProducts=XMLTools.LoadListFromXMLElement(s_products);
        if(func!=null)
        {
            return from p in rootProducts.Elements()
                   let doPro= createProductFromElement(p)
                   where func(doPro)
                   select doPro;
        }
        else
        {
            return from p in rootProducts.Elements()
                   select createProductFromElement(p);
        }
       
    }

    public Product GetByID(int id)
    {
        XElement product=XMLTools.LoadListFromXMLElement(s_products);
        return (from p in product.Elements()
                where p.ToIntNullable("ID") == id
                select (DO.Product?)createProductFromElement(p)).FirstOrDefault()
                ?? throw new Exception("missing id");
        
    }

    public Product GetItem(Func<Product?, bool>? func)
    {
       
        List<DO.Product?> products = XMLTools.LoadListFromXMLSerializer<DO.Product>(s_products);
        return products.FirstOrDefault(item => func!(item)) ?? throw new DalDoesNotExsistExeption("order not exist");
    }
    public void Uppdate(Product p)
    {
        Delete(p.ID);
        Add(p);
        //List<DO.Product?> products = XMLTools.LoadListFromXMLSerializer<DO.Product>(s_products);
        //if (!products.Exists(x => x?.ID == p.ID))
        //    throw new DO.DalDoesNotExsistExeption("product not exsist");
        //else
        //{
        //    products.Remove(products.Find(x => x?.ID == p.ID));
        //    products.Add(p);
        //    XMLTools.SaveListToXMLElement(products, s_products);
        //}
    }
}
