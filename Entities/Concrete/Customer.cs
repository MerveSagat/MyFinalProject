using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    //burada ilk etapta IEntity i implement ediyoruz. yani diyoruz ki sen bir veritabanı nesnesisin
    public class Customer:IEntity
    {
        public string CustomerId { get; set; }
        public string ContactName { get; set; }
        public string CompanyName { get; set; }
        public string City { get; set; }
    }
}
