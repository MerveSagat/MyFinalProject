using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Business
{
    public class BusinessRules
    {
        //params kullandığın zaman birden çok kuralı parametre olarak ekleyebilmeni sağlıyor. Yani diğer tarafta bu methodu çağırdığında, istersen 5 tane parametre ekle
        //yani gönderilen ve virgülle ayrılan tüm parametreleri array haline getiriyor 
        public static IResult Run(params IResult[] logics)
        {
            foreach ( var logic in logics)
            {
                if (!logic.Success)
                {
                    return logic;
                }
            }
            return null;

        }
    }
}
