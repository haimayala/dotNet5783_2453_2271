using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace PL;

class ConvertBolianToContent : IValueConverter //As long as one of the product details is empty, it will not be possible to update or add a new product
{
     
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value.ToString() != "")
        {
            return "Update";
        }
        else
            return "Add";
       
    }

  
    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}


