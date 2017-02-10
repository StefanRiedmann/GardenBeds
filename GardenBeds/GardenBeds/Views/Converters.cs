using System;
using GardenBeds.Models;
using Xamarin.Forms;

namespace GardenBeds.Views
{
    public class NegateBooleanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return !(bool)value;
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return !(bool)value;
        }
    }
    public class SizeToTextConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is int)
            {
                return $"{(int) value} square metres";
            }
            return "unknown size";
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }
    public class PlantToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is Plants)
            {
                return ((Plants) value).ToString();
            }
            return "unknown plant";
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }
    public class PlantToImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is Plants)
            {
                switch ((Plants)value)
                {
                    case Plants.Eggplant:
                        return ImageSource.FromResource("GardenBeds.Resources.eggplant.jpg");
                    case Plants.Pepper:
                        return ImageSource.FromResource("GardenBeds.Resources.pepper.jpg");
                    case Plants.Lettuce:
                        return ImageSource.FromResource("GardenBeds.Resources.lettuce.jpg");
                    case Plants.Tomatoe:
                        return ImageSource.FromResource("GardenBeds.Resources.tomatoe.jpg");
                }
            }
            return ImageSource.FromResource("GardenBeds.Resources.default.gif");
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }
}