using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class SuccessDataResult<T>:DataResult<T>
    {
        //aşağıdaki constructor türleri versiyonşar. ister data ver, istersen sadece data ver, istersen sadece mesaj ver, istersen hiçbir şey verme diyebiliyoruz bu yöntemlerle
        public SuccessDataResult(T data, string message):base(data,true,message)
        {

        }

        public SuccessDataResult(T data):base(data,true)
        {
                
        }
        //default data ya karşılık geliyor. return tipi inttir ama biz orada bişey döndürmek istemiyorsak data nın defaultu neyse onu baz alıyor
        public SuccessDataResult(string message):base(default,true,message)
        {
          
        }

        public SuccessDataResult():base(default,true)
        {

        }
    }
}
