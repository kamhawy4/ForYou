using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Resources;
using ForYou.SharedServices.Services;
using ForYou.SharedServices.Constants;

namespace ForYou.Resources
{
    public class ResourceHandler : IResourceHandler
    {
        public string GetError(string key)
        {
            var resourceManger = new ResourceManager(typeof(Error));
            return resourceManger.GetString(key);
        }

        public string GetError(string key, string culture = SupportedLanguage.Ar)
        {
            var resourceManger = new ResourceManager(typeof(Error));
            return resourceManger.GetString(key, new System.Globalization.CultureInfo(culture));
        }

    }
}
