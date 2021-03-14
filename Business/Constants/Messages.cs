using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    //biz bu classı sürekli newlemek istemediğimiz için statik belirliyoruz. Statik sınıflar newlenmez.
    public static class Messages
    {
        //publicler PascalCase yazılır. Yani büyük harfle başlar. Eğer bunlar private olsaydı camelcase yazacaktık.
        public static string ProductAdded = "Ürün eklendi";
        public static string ProductNameInvalid = "Ürün ismi geçeriz";
    }
}
