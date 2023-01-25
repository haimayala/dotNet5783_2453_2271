using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace PL;

class ConvertImagePathToBitmap : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        try
        {
            string imageRelatuveName = (string)value;
            string currentDir = Environment.CurrentDirectory[..^4];
            string imageFullName = currentDir + imageRelatuveName;
            BitmapImage bitmapImage = new BitmapImage(new Uri(imageFullName));
            return bitmapImage;
        }
        catch (Exception ex)
        {
            string imageRelatuveName = @"\picss\noImg.jpg";
            string currentDir = Environment.CurrentDirectory[..^4];
            string imageFullName = currentDir + imageRelatuveName;
            BitmapImage bitmapImage = new BitmapImage(new Uri(imageFullName));
            return bitmapImage;
        }

    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }

}

class ConvertImageicon1 : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        try
        {
            string imageRelatuveName = (string)value;
            string currentDir = Environment.CurrentDirectory[..^4];
            string imageFullName = currentDir + imageRelatuveName;
            BitmapImage bitmapImage = new BitmapImage(new Uri(imageFullName));
            return bitmapImage;
        }
        catch (Exception ex)
        {
            string imageRelatuveName = @"\picss\finishOrder.jpg";
            string currentDir = Environment.CurrentDirectory[..^4];
            string imageFullName = currentDir + imageRelatuveName;
            BitmapImage bitmapImage = new BitmapImage(new Uri(imageFullName));
            return bitmapImage;
        }

    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }

}

class ConvertImageicon2 : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        try
        {
            string imageRelatuveName = (string)value;
            string currentDir = Environment.CurrentDirectory[..^4];
            string imageFullName = currentDir + imageRelatuveName;
            BitmapImage bitmapImage = new BitmapImage(new Uri(imageFullName));
            return bitmapImage;
        }
        catch (Exception ex)
        {
            string imageRelatuveName = @"\picss\shipped.jpg";
            string currentDir = Environment.CurrentDirectory[..^4];
            string imageFullName = currentDir + imageRelatuveName;
            BitmapImage bitmapImage = new BitmapImage(new Uri(imageFullName));
            return bitmapImage;
        }

    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }

}


