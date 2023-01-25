using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace PL;

class ConvertEnumToText : IValueConverter //the status of the order at the simulator
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {

        BO.Enums.OrderStatus Value = (BO.Enums.OrderStatus)value;
        if (Value == BO.Enums.OrderStatus.Ordered)
        {
            return "Ordered";
        }
        return "Shipped";
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}

class ConvertEnumToTextAfter : IValueConverter //the status of the order at the simulator
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {

        BO.Enums.OrderStatus Value = (BO.Enums.OrderStatus)value;
        if (Value == BO.Enums.OrderStatus.Ordered)
        {
            return "Shipped";
        }
        return "Delivered";
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}

