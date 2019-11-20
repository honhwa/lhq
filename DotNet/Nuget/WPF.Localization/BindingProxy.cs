using System.Windows;

namespace ScaleHQ.WPF.LHQ
{
    /// <summary>
    /// TODO: missing comment
    /// </summary>
    public class BindingProxy : Freezable
    {
        /// <summary>
        /// TODO: missing comment
        /// </summary>
        public static readonly DependencyProperty DataProperty = DependencyProperty.Register(nameof(Data), typeof(object), typeof(BindingProxy), new UIPropertyMetadata(null));

        /// <summary>
        /// TODO: missing comment
        /// </summary>
        public object Data
        {
            get { return GetValue(DataProperty); }
            set { SetValue(DataProperty, value); }
        }

        protected override Freezable CreateInstanceCore()
        {
            return new BindingProxy();
        }
    }
}
