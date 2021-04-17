using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using VH.Currency;
using VH.Data;
using VH.Data.EFCore;
using VH.Data.Repository;
using VH.Services;
using VH.Services.Interfaces;

namespace VH.DataService
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
            //Add currency service with base address;
            Uri endpoint = new Uri(Configuration[Const.CurrencyBaseUrl]); // this is the endpoint HttpClient will hit
            HttpClient httpClient = new HttpClient()
            {
                BaseAddress = endpoint,
            };
            services.AddTransient<ICurrencyService>(s => new CurrencyService(httpClient, Configuration[Const.CurrencyApiKey]));

            //EF Repositories:
            services.AddScoped<OrderRepository>();
            services.AddScoped<CustomerRepository>();
            services.AddScoped<LocationRepository>();
            services.AddScoped<AssetRepository>();
            services.AddScoped<PaymentRepository>();

            //Logic services:
            services.AddScoped<IOrderService, OrderService>();
            //services.AddScoped<IAssetService, AssetService>();
            //services.AddScoped<IPaymentService, PaymentService>();

            //Add automapper
            services.AddAutoMapper(typeof(AutoMapping).Assembly);
            //Other
            services.AddDbContext<VHDbmodelContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"))
                );
            services.AddSwaggerGen();
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IMapper mapper)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

            }
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                c.RoutePrefix = string.Empty;

            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            //Check automapper validity
            mapper.ConfigurationProvider.AssertConfigurationIsValid();

        }
    }
}
