using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    //bu bir veritabanı tablosu değil, birden fazla tablo join olabilir. O yüzden IEntity den implemente edemiyoruz. ÇÜNKÜ IENTITY'den IMPLEMENTE ETMEK DEMEK, SEN BİR VERİTABANI TABLOSUSUN DEMEKTİR!!
    public class ProductDetailDto : IDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string CategoryName { get; set; }
        public short UnitsInStock { get; set; }
    }
}
