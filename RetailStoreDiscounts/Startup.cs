using Microsoft.EntityFrameworkCore;
using RetailStoreDiscounts.Domain;
using RetailStoreDiscounts.Domain.Interfaces;
using RetailStoreDiscounts.Domain.Repositories;
using RetailStoreDiscounts.Domain.UnitOfWork;
using RetailStoreDiscounts.Services;
using AutoMapper;
namespace RetailStoreDiscounts
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            //IProductService ile karşılaştığında bir request boyunca bir kez AddScope, her request için AddTransient ProductServiceten bir instance oluşturur
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<IProductRepository, ProductRepository>();

            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            

            services.AddCors(opts =>
            {
                opts.AddDefaultPolicy(builder =>
                {
                    builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                });
            });
            //Mvc .net versiyon uyumsuzluğu nedeniyle EnableEndpointRouting false yapılır
            services.AddMvc(option => option.EnableEndpointRouting = false);
            services.AddOptions();

            services.AddDbContext<RetailStoreDiscountDBContext>(options =>
            {
                options.UseSqlServer(Configuration["ConnectionStrings:DefaultConnectionString"]);
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors();
            app.UseMvc();
        }
    }
}
