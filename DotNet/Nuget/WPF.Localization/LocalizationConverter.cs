using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Globalization;
using System.Windows.Data;

namespace ScaleHQ.WPF.LHQ
{
    public class LocalizationConverter : IValueConverter, IMultiValueConverter
    {
        private readonly IFormattable _localizationContext;
        private string _key;
        private readonly Collection<BindingBase> _bindings;

        public LocalizationConverter(IFormattable localizationContext, string key, Collection<BindingBase> bindings = null)
        {
            _localizationContext = localizationContext ?? throw new ArgumentNullException(nameof(localizationContext));
            _key = key ?? throw new ArgumentNullException(nameof(key));
            _bindings = bindings;
        }

        internal string Key
        {
            get => _key;
            set => _key = value;
        }

        object IValueConverter.Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //return _localizationContext.ToString(_key, null);
            return _localizationContext.ToString(_key, culture);
        }

        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Binding.DoNothing;
        }

        object IMultiValueConverter.Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            //string translatedString = _localizationContext.ToString(_key, null);
            string translatedString = _localizationContext.ToString(_key, culture);

            int parametersCount = values.Length;
            if (parametersCount > 1) // must be more than 1 because 1st value is 'binding' itself.
            {
                parametersCount--;

                //object[] parameters = new object[parametersCount];
                //Array.Copy(values, values.Length - parametersCount, parameters, 0, parameters.Length);

                List<object> parameters = new List<object>();
                for (int i = 0; i < parametersCount; i++)
                {
                    object param = values[i + 1];
                    string stringFormat = _bindings[i].StringFormat;
                    if (!string.IsNullOrEmpty(stringFormat))
                    {
                        param = string.Format(culture, stringFormat, param);
                    }
                    parameters.Add(param);
                }

                try
                {
                    translatedString = string.Format(culture, translatedString, parameters.ToArray());
                }
                catch (FormatException fex)
                {
                    Debug.WriteLine($"[LHQ] LocalizationConverter failed to format text {translatedString}");
                    translatedString = fex.Message;
                }
            }

            return translatedString;
        }

        object[] IMultiValueConverter.ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            return new object[0];
        }
    }
}
