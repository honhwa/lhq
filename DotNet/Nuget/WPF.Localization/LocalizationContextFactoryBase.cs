using System;

namespace ScaleHQ.WPF.LHQ
{
    public abstract class LocalizationContextFactoryBase
    {
        public abstract IFormattable GetSingleton();
    }

    public class LocalizationContextFactoryDefault : LocalizationContextFactoryBase
    {
        private readonly Func<IFormattable> _stringsContextFactory;

        public LocalizationContextFactoryDefault(Func<IFormattable> stringsContextFactory)
        {
            _stringsContextFactory = stringsContextFactory ?? throw new ArgumentNullException(nameof(stringsContextFactory));
        }

        public override IFormattable GetSingleton()
        {
            return _stringsContextFactory();
        }
    }
}