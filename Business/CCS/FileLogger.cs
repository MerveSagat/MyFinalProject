using System;
using System.Collections.Generic;
using System.Text;

namespace Business.CCS
{
    //Ilogger türü farklı olabilir, çünkü dosyaya veya veritabanına loglama yapılabilir, mail atılabilir vs. dolayısıyla birbirinin alternatifi olan 
    //durumlarda her zaman interface implemente ediyoruz.
    public class FileLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Dosyaya loglandı");
        }
    }
}
