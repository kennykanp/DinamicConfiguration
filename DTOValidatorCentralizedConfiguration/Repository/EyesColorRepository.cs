using DTOValidatorCentralizedConfiguration.Configurations;
using System.ComponentModel.DataAnnotations;

using System;
using System.Reflection;
using Microsoft.Extensions.Localization;
using DTOValidatorCentralizedConfiguration.Resources;


namespace DTOValidatorCentralizedConfiguration.Repository
{
    public interface IEyesColorRepository
    {
        EyesColor GetEyesColor();
    }

    public class EyesColorRepository : IEyesColorRepository
    {
        private readonly IStringLocalizer _stringLocalizer;

        public EyesColorRepository(IStringLocalizer stringLocalizer)
        {
            this._stringLocalizer = stringLocalizer;
        }
        public EyesColor GetEyesColor()
        {
            var eyesColor = new EyesColor
            {
                Id = 1,
                Value = "Noting"
            };

            var wrapper = new LocalizedWrapper<EyesColor>(_stringLocalizer);
            return wrapper.ApplyLocalization(eyesColor);
        }
    }

    public class EyesColor
    {
        public int Id { get; set; }

        [LocalizedValue("msg_hello")]
        public string Value { get; set; }
    }

    public class LocalizedWrapper<T> where T : new()
    {
        private readonly IStringLocalizer _stringLocalizer;

        public LocalizedWrapper(IStringLocalizer stringLocalizer)
        {
            this._stringLocalizer = stringLocalizer;
        }

        public T ApplyLocalization(T instance)
        {
            var type = typeof(T);
            foreach (var property in type.GetProperties())
            {
                var attribute = property.GetCustomAttribute<LocalizedValueAttribute>();
                if (attribute != null)
                {
                    var localizedValue = _stringLocalizer[attribute.KeyResource].Value;
                    if (localizedValue != null && property.CanWrite)
                    {
                        property.SetValue(instance, localizedValue);
                    }
                }
            }
            return instance;
        }
    }

    // Que pasaria si la entidad tiene varios valores que necesita traducir?
    // Que pasaria que si el valor cambia de nombre de acuerdo a su necesidad?

}
