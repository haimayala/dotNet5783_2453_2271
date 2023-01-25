using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Dal;

internal static class DalConfig
{

    static string s_config = "configuration";
    // run number for products

    internal static int GetNextProductId()
    {
        return (int)XMLTools.LoadListFromXMLElement(s_config).Element("s_nextProductNumber")!;
    }
    internal static void SaveNextProductID(int productNumber)
    {
        XElement root = XMLTools.LoadListFromXMLElement(s_config);
        root.Element("s_nextProductNumber")!.SetValue(productNumber.ToString());
        XMLTools.SaveListToXMLElement(root, s_config);
    }

    internal static int GetNextOrderId()
    {
        return (int)XMLTools.LoadListFromXMLElement(s_config).Element("s_nextOrderNumber")!;
    }
    internal static void SaveNextOrderID(int orderNumber)
    {
        XElement root = XMLTools.LoadListFromXMLElement(s_config);
        root.Element("s_nextOrderNumber")!.SetValue(orderNumber.ToString());
        XMLTools.SaveListToXMLElement(root, s_config);
    }
    internal static int GetOrderItemId()
    {
        return (int)XMLTools.LoadListFromXMLElement(s_config).Element("s_nextOrderItemNumber")!;
    }
    internal static void SaveNextOrderItemId(int orderItemNumber)
    {
        XElement root = XMLTools.LoadListFromXMLElement(s_config);
        root.Element("s_nextOrderItemNumber")!.SetValue(orderItemNumber.ToString());
        XMLTools.SaveListToXMLElement(root, s_config);
    }
}

