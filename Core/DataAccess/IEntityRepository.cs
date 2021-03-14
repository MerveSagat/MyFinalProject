using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess
{
    //modelden data access object oluştururken, her bir model için ayrı bir dal oluşturmamak için bir tane generic oluşturuyoruz. O da bu interface oluyor.
    //burada T tipinde herhangi bir değer gelirse ona göre şekillendireceğiz dedik ama her türlü verinin gelmesini istemediğimiz için constraint oluşturuyoruz.
    //buna generic constraint deniyor.
    //burada class demek, class tipinde olsun demek değildir! referans tip olmalı demektir. 
    //IEntity ise, IEntity de olabilir, onu implemente eden herhangi bir nesne de olabilir demektir.
    //new(): ise newlenebilir olması gerektiğini belirtir. IEntity bir interface olduğu için newlenemez. Dolayısıyla IEntity'yi çağırsak bile hata verir. O yüzden bunu kullanıyoruz.
    public interface IEntityRepository<T> where T:class,IEntity,new()
        //T tipinde bir şey gelecek ve gelen tipe göre işlem yapacağız demek buradaki T
    {
        //Aşağıdaki expression advance sevye bir kullanım ama herhangi bir veriyi filtrelerken, şuna göre getir buna göre getir diye filtreler yazabilmemizi sağlar.
        //filter ı null a eşitlememizin sebebi, filtre olmayadabilir demek içindir
        List<T> GetAll(Expression<Func<T,bool>> filter=null);
        T Get(Expression<Func<T,bool>> filter);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        List<T> GetAllByCategory(int categoryId);
    }
}
