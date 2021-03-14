using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICategoryService
    {
        List<Category> GetAll();
        Category GetById(int categoryId); //yukarıdaki birden çok veri getireceği için List tipinde, ama getbyid diyoruz, yani tek bir id ye göre veri getirmesini istiyoruz. Bu yüzden Catrgory tipinde veriyi getirmesini istiyoruz.

    }
}
