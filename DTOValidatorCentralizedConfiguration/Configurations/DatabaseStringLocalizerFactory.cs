using Microsoft.Extensions.Localization;
using System.Globalization;

namespace DTOValidatorCentralizedConfiguration.Configurations
{
    public class DatabaseStringLocalizerFactory : IStringLocalizerFactory
    {
        private readonly LocalizationDbContext _localizationDbContext;

        public DatabaseStringLocalizerFactory(LocalizationDbContext localizationDbContext)
        {
            this._localizationDbContext = localizationDbContext;
        }
        public IStringLocalizer Create(Type resourceSource)
        {
            return new DatabaseStringLocalizer(_localizationDbContext);
        }

        public IStringLocalizer Create(string baseName, string location)
        {
            return new DatabaseStringLocalizer(_localizationDbContext);
        }
    }

    public class DatabaseStringLocalizer : IStringLocalizer
    {
        private readonly LocalizationDbContext _localizationDbContext;

        public DatabaseStringLocalizer(LocalizationDbContext localizationDbContext)
        {
            _localizationDbContext = localizationDbContext;
        }
        public LocalizedString this[string name]
        {
            get
            {
                var value = _localizationDbContext.LocalizationResources.Where(x => x.Key == name && x.Culture == CultureInfo.CurrentCulture.Name).FirstOrDefault();
                return new LocalizedString(name, value?.Value ?? name, value == null);
            }
        }

        public LocalizedString this[string name, params object[] arguments]
        {
            get
            {
                var value = _localizationDbContext.LocalizationResources.Where(x => x.Key == name && x.Culture == CultureInfo.CurrentCulture.Name).FirstOrDefault();
                return new LocalizedString(name, value?.Value ?? name, value == null);
            }
        }

        public IEnumerable<LocalizedString> GetAllStrings(bool includeParentCultures)
        {
            return _localizationDbContext.LocalizationResources.Select(x => new LocalizedString(x.Key, x.Value));
        }
    }
}
