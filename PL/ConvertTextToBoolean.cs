using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace PL;

class ConvertTextToBoolean : IMultiValueConverter //As long as one of the product details is empty, it will not be possible to update or add a new product
{
    public object Convert(object[] value, Type targetType, object parameter, CultureInfo culture)
    {

        while (value[0].ToString() == "" || value[1].ToString() == "" || value[2].ToString() == "" || value[3].ToString() == "")
        {
            return false;
        }
        return true;

    }

    public object[] ConvertBack(object value, Type[] targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}


//class ConvertEnumToText1 : IValueConverter //the status of the order at the simulator
//{
//    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
//    {

//        BO.OrderStatus Value = (BO.OrderStatus)value;
//        if (Value == BO.OrderStatus.Ordered)
//        {
//            return "Ordered";
//        }
//        return "Shipped";
//    }

//    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
//    {
//        throw new NotImplementedException();
//    }
//}

//class ConvertEnumToTextAfter1 : IValueConverter //the status of the order at the simulator
//{
//    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
//    {

//        BO.Enums.OrderStatus Value = (BO.OrderStatus)value;
//        if (Value == BO.OrderStatus.Ordered)
//        {
//            return "Shipped";
//        }
//        return "Delivered";
//    }

//    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
//    {
//        throw new NotImplementedException();
//    }
//}

class BooleanToColorConverter : IValueConverter //If the product isn't in stock, you will not be given the option of collecting a product into a shopping basket
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        bool boolValue = (bool)value;
        if (boolValue)
        {
            return Colors.Pink;
        }
        else
        {
            return Colors.LightPink;
        }
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}