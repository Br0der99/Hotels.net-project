using System.Collections.Generic;
using Microsoft.Extensions.Configuration;

namespace DataAccess.Test
{
    public class Config
    {
        private static IConfiguration _config;

        public static IConfiguration Instance
        {
            get
            {
                if (_config != null) return _config;

                var configDictionary = new Dictionary<string, string>
                {
                    {
                        "ConnectionStrings:DefaultConnection",
                        "Server=hildur.ucn.dk;Database=dmaa0220_1083750;User Id=dmaa0220_1083750;Password=Password1!;Trusted_Connection=False;"
                    }
                };
                _config = new ConfigurationBuilder()
                    .AddInMemoryCollection(configDictionary)
                    .Build();

                return _config;
            }
        }
    }
}