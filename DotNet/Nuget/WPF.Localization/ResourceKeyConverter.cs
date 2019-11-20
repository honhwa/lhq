using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace ScaleHQ.WPF.LHQ
{
    /// <summary>
    /// TODO: missing comment
    /// </summary>
    public class ResourceKeyConverter : Freezable, IValueConverter//, IMultiValueConverter
    {
        private LocalizationConverter _localizationConverter;

        /// <summary>
        /// TODO: missing comment
        /// </summary>
        public static readonly DependencyProperty LocalizationSourceProperty =
            DependencyProperty.Register(
                nameof(LocalizationSource), 
                typeof(IFormattable),
                typeof(ResourceKeyConverter), 
                new UIPropertyMetadata(null));

        /// <summary>
        /// TODO: missing comment
        /// </summary>
        public IFormattable LocalizationSource
        {
            get { return GetValue(LocalizationSourceProperty) as IFormattable; }
            set { SetValue(LocalizationSourceProperty, value); }
        }

        protected override Freezable CreateInstanceCore()
        {
            return new ResourceKeyConverter();
        }

        private void Initialize(string resourceKey, Collection<BindingBase> bindings = null)
        {
            if (_localizationConverter == null)
            {
                _localizationConverter = new LocalizationConverter(LocalizationSource, resourceKey);
            }
            else
            {
                _localizationConverter.Key = resourceKey;
            }
        }

        object IValueConverter.Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Initialize(value as string);
            return (_localizationConverter as IValueConverter).Convert(value, targetType, parameter, culture);
        }

        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Binding.DoNothing;
        }

        /*object IMultiValueConverter.Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            Initialize(value as string);
        }*/
    }
}