using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.JWT
{
    public class AccessToken
    {
        //accesstoken anlamsız karakterlerden oluşan bir anahtardır
        public string Token { get; set; }
        public DateTime Expiration { get; set; }

    }
}
