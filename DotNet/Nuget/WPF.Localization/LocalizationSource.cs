using System;
using System.Windows;

namespace ScaleHQ.WPF.LHQ
{
    /// <summary>
    ///     Source binding for localization context.
    /// </summary>
    /// <seealso cref="System.Windows.Freezable" />
    public class LocalizationContextSource : Freezable
    {
        public static readonly DependencyProperty SourceProperty =
            DependencyProperty.Register(nameof(Source), typeof(object), typeof(LocalizationContextSource), null);

        /// <summary>
        /// Source binding to <c>StringsContext.Instance</c>.
        /// </summary>
        public IFormattable Source
        {
            get => GetValue(SourceProperty) as IFormattable;
            set => SetValue(SourceProperty, value);
        }

        protected override Freezable CreateInstanceCore()
        {
            return new LocalizationContextSource();
        }
    }
}
