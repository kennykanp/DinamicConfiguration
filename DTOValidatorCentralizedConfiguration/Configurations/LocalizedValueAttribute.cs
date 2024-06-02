using System;

namespace DTOValidatorCentralizedConfiguration.Configurations
{
    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    public sealed class LocalizedValueAttribute : Attribute
    {
        public string KeyResource { get; }

        public LocalizedValueAttribute(string keyResource)
        {
            KeyResource = keyResource;
        }
    }
}
