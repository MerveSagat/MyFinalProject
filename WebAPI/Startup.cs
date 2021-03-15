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
            //Autofac, NinjectiCastleWindsor, StructureMap, LightInject, DryInject -->IoC Container //bunlarýn hepsi birbirinin alternatifi
            //AOP --bütün methodlarý loglamak istediðinde bir service yazýp methodunu çaðýrýrýz normalde, onun yerine burada AOP kullanacaðýz.
            //AOP bir methodun önünde, sonunda, bir method hata verdiðinde çalýþan kod parçacýklarýný AOP mimarisinde yazýyoruz
            services.AddControllers();
            services.AddSingleton<IProductService, ProductManager>();//bana arka planda bir referans oluþtur demek bu
            //biir senden IProductServide isterse ona bir tane arka planda ProductManager oluþtur ve onu ver demek istiyoruz
            //arka planda bizim yerimize newleme iþlemi yapýyor
            //singleton içerisinde data tutulmadýðý durumlarda kullanýlýr. Mesela sepeti manager da tutuyosak bunu kullanamayýz, yoksa biri sepete bir þey eklediðinde 
            //herkesin sepetine eklenir, çýkardýðýnda hepsinden çýkarýlýr. Sepet db de tutuluyorsa sorun olmaz.
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
