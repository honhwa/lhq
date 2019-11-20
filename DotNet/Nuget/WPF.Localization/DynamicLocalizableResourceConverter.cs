using System;
using System.ComponentModel;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace ScaleHQ.WPF.LHQ
{
    /// <summary>
    /// Value convertor for dynamic localizable resource.
    /// </summary>
    public class DynamicLocalizableResourceConverter : IValueConverter
    {
        private static readonly Type _supportedType = typeof(DynamicLocalizableResource);

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return string.Empty;
            }

            Type valueType = value.GetType();
            if (!_supportedType.IsAssignableFrom(valueType))
            {
                var inDesignMode = DesignerProperties.GetIsInDesignMode(new DependencyObject());

                if (!inDesignMode)
                {
                    throw new InvalidOperationException(
                        $"Converter '{GetType().Name}' can only be applied to object derived from '{_supportedType.FullName}' where " +
                        $"'{valueType.FullName}' is not!");
                }

                return string.Empty;
            }

            DynamicLocalizableResource resource = (DynamicLocalizableResource)value;
            return resource.GetLocalizedString(parameter as string);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Binding.DoNothing;
        }
    }
}