using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;
        //ben CategoryManager olarak veri erişim katmanına bağımlıyım ama biraz zayıf bağımlıyım. Çünkü interface üzerinden, yani referans üzerinden bağımlıyım. Bu yüzden sen DataAccess katmanında istediğini yapabilirsin ama kurallarıma uymak zorundasın demek oluyor.
        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        //dış dünyaya servis etmek istediğimiz methodları interface vasıtasıyla buraya implemente ediyoruz
        public List<Category> GetAll()
        {
            //iş kodları
            return _categoryDal.GetAll();
        }

        public Category GetById(int categoryId)
        {
            return _categoryDal.Get(c=>c.CategoryId == categoryId); //buradaki c yi categoryid olduğu için böyle verdik, rastgele bir ad kullanılabilir.Burası bir nevi where koşulu eklemiş oluyor
        }
    }
}
