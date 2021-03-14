using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    //Burada IProductDal dan implement etmiş olmamız şu demek, Product ile ilgili veritabanı işlemleri yapılacak burada demek
    public class EFProductDal : EfEntityRepositoryBase<Product,NorthwindContext>,IProductDal
    {
       
    }
}
