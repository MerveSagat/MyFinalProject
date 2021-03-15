using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //Autofac, NinjectiCastleWindsor, StructureMap, LightInject, DryInject -->IoC Container //bunlar�n hepsi birbirinin alternatifi
            //AOP --b�t�n methodlar� loglamak istedi�inde bir service yaz�p methodunu �a��r�r�z normalde, onun yerine burada AOP kullanaca��z.
            //AOP bir methodun �n�nde, sonunda, bir method hata verdi�inde �al��an kod par�ac�klar�n� AOP mimarisinde yaz�yoruz
            services.AddControllers();
            services.AddSingleton<IProductService, ProductManager>();//bana arka planda bir referans olu�tur demek bu
            //biir senden IProductServide isterse ona bir tane arka planda ProductManager olu�tur ve onu ver demek istiyoruz
            //arka planda bizim yerimize newleme i�lemi yap�yor
            //singleton i�erisinde data tutulmad��� durumlarda kullan�l�r. Mesela sepeti manager da tutuyosak bunu kullanamay�z, yoksa biri sepete bir �ey ekledi�inde 
            //herkesin sepetine eklenir, ��kard���nda hepsinden ��kar�l�r. Sepet db de tutuluyorsa sorun olmaz.
            services.AddSingleton<IProductDal, EFProductDal>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
