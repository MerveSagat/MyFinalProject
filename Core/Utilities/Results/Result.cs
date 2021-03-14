using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {
      //normalde constructor 2 parametre gönderdiği için 2 parametre içinde tanımlama yapmıştık ama mecburen overload yaptığımız için
      //kod tekrarı olmaması için successi ilk constructor dan sildik ve yanında this(yani bu olduğumuz classta) result ın constructor ına 
      //tek parametreli olan constructorına success i yolla anlamına gelen kısmı yazıyoruz iki noktadan sonra
        public Result(bool success, string message):this(success)
        {
            Message = message;
        }

        //yukarıdaki constructor 2 parametreli ama biz 1 parametreli kullanmak istediğimiz zamanlar için, aşağıdaki şekilde tekrar aynı contructor ı yazabiliriz. Buna overload deniyor.
        public Result(bool success)
        {
            Success = success;
        }

        public bool Success { get; }

        public string Message { get; }
    }
}
