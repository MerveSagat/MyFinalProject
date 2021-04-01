using Business.Abstract;
using Business.Concrete;
using Core.DependencyResolvers;
using Core.Extensions;
using Core.Utilities.IoC;
using Core.Utilities.Security.Encryption;
using Core.Utilities.Security.JWT;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
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
            /*services.AddSingleton<IProductService, ProductManager>();*///bana arka planda bir referans oluþtur demek bu
            //biir senden IProductServide isterse ona bir tane arka planda ProductManager oluþtur ve onu ver demek istiyoruz
            //arka planda bizim yerimize newleme iþlemi yapýyor
            //singleton içerisinde data tutulmadýðý durumlarda kullanýlýr. Mesela sepeti manager da tutuyosak bunu kullanamayýz, yoksa biri sepete bir þey eklediðinde 
            //herkesin sepetine eklenir, çýkardýðýnda hepsinden çýkarýlýr. Sepet db de tutuluyorsa sorun olmaz.
            //services.AddSingleton<IProductDal, EFProductDal>();
            //bu 2 satýrlýk kod yerinde AutofacBusinessModule içerisinde farklý bir kod yazdýk.
        
            var tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidIssuer = tokenOptions.Issuer,
                        ValidAudience = tokenOptions.Audience,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey)
                    };
                });
            services.AddDependencyResolvers(new ICoreModule[] { 
            new CoreModule()});
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //buna middleware deniyor
            app.UseHttpsRedirection();

            app.UseRouting();
            
            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
