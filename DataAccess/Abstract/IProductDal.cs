using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    //Product altı çizili geldi, ampule tıklayıp add reference to Entities'i seçtik. Böyle implement ettik. 
    //Eğer buradan yapamazsan solution da DataAccess sağ tıkla/Add/Project Reference seç. Ordan ihityacın olan seçeneği seç
    public interface IProductDal:IEntityRepository<Product> //aşağıdaki kodları tek tek yazmamak için generic bir entity repository oluşturduk ve 
        //onu burada bu şekilde çağırdık. Sadece bunu yazmış olmamız yeterli. Hangi modele göre şekillendireceksek onu belirtiyoruz
    {
        //aşağıdaki satırları bu şekilde her model için ayrı ayrı yazmaktansa bunu generic class a taşıdık. 
        //List<Product> GetAll();

        //void Add(Product product);
        //void Update(Product product);
        //void Delete(Product product);

        //List<Product> GetAllByCategory(int categoryId);
    }
}
