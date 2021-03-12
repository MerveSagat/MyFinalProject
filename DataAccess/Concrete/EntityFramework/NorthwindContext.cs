using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    //Context: Db tabloları ile proje classlarını bağlamaktır
    //Sınıfın adını Context belirlememiz onun bir Context sınıfı olduğunu belirlemez. EntityFramework kurunca DbContext adıyla base bir sınıf geliyor. Onu implemente etmek gerekiyor
    //Db tablolarıyla proje classlarını bağlıyoruz. Yani benim veritabanım şurada diyoruz.
    public class NorthwindContext:DbContext
    {
        //bu method projemizin hangi veritabanıyla ilişkili olduğunu belirttiğimiz yer,
        //yazarken override yaz boşluk bırak, On yaz devamını tamamlıyor.
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(@"Server=175.45.2.12");//burada sql server a nasıl bağlanacağını belirtiyoruz.//başa @ işareti koymak, içeride kullanacağımız her slash işaretini normal slash olarak algıla demektir.
            //normal geliştirme ortamında bu şekilde ip vererek db ye bağlanacağı bir connection stringi yazılır. ama biz bu projede development ortamında çalışacağımız için farklı şekilde kullanıyoruz.
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Northwind;Trusted_Connection=true"); //bu ismi view/sql server object explorer ı açarak orada yazan ismi yazıyoruz
        }
        public DbSet<Product> Products { get; set; } //buralarda hangi tabloya hangi classın karşılık geleceğini yazıyoruz. İlk sırada dbSet in içinde olan class adı, 2.sıradaki db deki tablo adı
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }

    }
}
