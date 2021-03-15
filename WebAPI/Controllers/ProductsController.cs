using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]//bu isteği yaparken insanlar bize nasıl ulaşsın? onu burada belirliyoruz. Lindte yazacak uzantı bu.
    [ApiController] //Buna C# ta attribute, Java'da Annotation denir. Bu bir class ile ilgili bilgi verme, onu imzalamadır.
    //Yani burada şunu diyoruz. Bu class bir controller dır kendini buna göre yapılandır demek istiyoruz.
    public class ProductsController : ControllerBase
    {
        //gevşek bağımlılık -- loosely coupled
        IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("getall")]
        //WEB API, http statü kodlarını döndürebileceğimiz bir altyapı sunuyor bize
        public IActionResult GetAll()
        {
            //Swagger, API için dökümantasyon araştır
            //Dependency chain --
            var result = _productService.GetAll();
            if (result.Success)
            {
                return Ok(result);
                //return Ok(result.Data); bu şekilde de yazılabilir.
            }
            return BadRequest(result);
            //return BadRequest(result.Message); bu şekilde de yazılabilir.
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _productService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Product product)
        {
            //get request bana data ver, post request ben sana data vericem demek.
            var result = _productService.Add(product);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
