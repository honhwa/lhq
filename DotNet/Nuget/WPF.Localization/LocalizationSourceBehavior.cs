using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Data;

namespace ScaleHQ.WPF.LHQ
{
    public static class LocalizationBindingsBehavior
    {
        public static readonly DependencyProperty BindingsProperty =
            DependencyProperty.RegisterAttached(nameof(BindingsProperty),
                typeof(Collection<BindingBase>), typeof(LocalizationBindingsBehavior),
                new PropertyMetadata());

        public static Collection<BindingBase> GetBindings(DependencyObject element)
        {
            if (element == null)
            {
                throw new ArgumentNullException(nameof(element));
            }

            return element.GetValue(BindingsProperty) as Collection<BindingBase>;
        }

        public static void SetBindings(DependencyObject element, Collection<BindingBase> value)
        {
            if (element == null)
            {
                throw new ArgumentNullException(nameof(element));
            }

            element.SetValue(BindingsProperty, value);
        }
    }

    public static class LocalizationSourceBehavior
    {
        public static readonly DependencyProperty LocalizationSourceProperty =
            DependencyProperty.RegisterAttached("LocalizationSource", typeof(IFormattable), typeof(LocalizationSourceBehavior),
                new PropertyMetadata(LocalizationSourceChanged));

        public static IFormattable GetLocalizationSource(DependencyObject element)
        {
            if (element == null)
            {
                throw new ArgumentNullException(nameof(element));
            }

            return element.GetValue(LocalizationSourceProperty) as IFormattable;
        }

        public static void SetLocalizationSource(DependencyObject element, IFormattable value)
        {
            if (element == null)
            {
                throw new ArgumentNullException(nameof(element));
            }

            element.SetValue(LocalizationSourceProperty, value);
        }

        private static void LocalizationSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            
        }
    }
}
