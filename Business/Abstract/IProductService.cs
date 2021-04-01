﻿using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IProductService
    {
        IDataResult<List<Product>> GetAll();
        IDataResult<List<Product>> GetAllByCategoryId(int id);
        IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max);
        IDataResult<List<ProductDetailDto>> GetProductDetails();
        IDataResult<Product> GetById(int productId);

        //üsttekilerin hepsinde data olduğu için IDataResult yaptık, alttakinde voidde data olmadığı için onu IResult yaptık
        IResult Add(Product product);
        IResult Update(Product product);
        IResult AddTransactionalTest(Product product);

    }
}
