using System;
using System.Collections.Generic;
using System.Text;

namespace NetCoreBestPractices.Core.Settings
{
    public interface IMongoDbSettings
    {
        //Mongodb bağlantısı için kullanacağım parametrelerimin interfaceini tanımladım. Interfacelerimi core katmanında tanımlamalıyım.(++abstraction)...
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }

    }
}
