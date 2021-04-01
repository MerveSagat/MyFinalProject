using System;
using System.Collections.Generic;
using System.Text;

namespace Business.CCS
{
    public interface ILogger
    {
        //interface oluşturmamızın sebebi, farklı loglama senaryolarının sisteme entegre etmemize imkan sağlamasıdır
        void Log();
    }
}
