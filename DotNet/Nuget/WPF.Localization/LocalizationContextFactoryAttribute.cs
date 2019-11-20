using System;

// ReSharper disable AutoPropertyCanBeMadeGetOnly.Global
// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global

namespace ScaleHQ.WPF.LHQ
{
    [AttributeUsage(AttributeTargets.Assembly)]
    public class LocalizationContextFactoryAttribute : Attribute
    {
        public LocalizationContextFactoryAttribute(string typeName)
        {
            if (string.IsNullOrEmpty(typeName))
            {
                throw new ArgumentException("Value cannot be null or empty.", nameof(typeName));
            }

            TypeName = typeName;
        }

        public LocalizationContextFactoryAttribute(Type type)
        {
            if (type == null)
            {
                throw new ArgumentNullException(nameof(type));
            }

            TypeName = type.AssemblyQualifiedName;
        }

        public string TypeName { get; set; }
    }
}
