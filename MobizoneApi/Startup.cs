using BusinesLogic.Interface;
using BusinesLogic;
using DomainLayer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using RepositoryLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using BussinessLogic;
using RepositoryLayer.Interface;
using NPOI.SS.Formula.Functions;
using DomainLayer.EmailService;
using MobizoneApi.Models;
using BussinessLogic.Orders;
using Repository;
using BussinessLogic.Orders.Admin;

namespace MobizoneApi
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
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MobizoneApi", Version = "v1" });
            });
            services.AddDbContext<ProductDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped(typeof(IProductCatagory), typeof(ProductCatagory));
            services.AddScoped(typeof(IGenericRepositoryOperation<>), typeof(GenericRepositoryOperation<>));
            services.AddTransient<IUserOperations, UserOperations>();
            services.AddScoped(typeof(IMasterDataOperations), typeof(MasterDataOperations));
            services.AddScoped(typeof(IUserDataoperation), typeof(UserDataoperation));
            services.AddScoped(typeof(IPasswordEncryptDecrypt), typeof(PasswordEncryptDecrypt));
            services.AddScoped(typeof(IAddressOperations), typeof(AddressOperations));
            services.AddScoped(typeof(ICheckOutOperations), typeof(CheckOutOperations));
            services.AddScoped(typeof(IOrderDetailsOperations), typeof(OrderDetailsOperations));
            services.Configure<MailSettings>(Configuration.GetSection("MailSettings"));
            services.AddTransient<IMailService, MailService>();

            services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<ProductDbContext>().AddDefaultTokenProviders();

            //adding authentication
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
             //adding Jwt Bearer
             .AddJwtBearer(options =>
             {
                 options.SaveToken = true;
                 options.RequireHttpsMetadata = false;
                 options.TokenValidationParameters = new TokenValidationParameters()
                 {
                     ValidateIssuer = true,
                     ValidateAudience = true,
                     ValidAudience = Configuration["JWT:ValidAudience"],
                     ValidIssuer = Configuration["JWT:ValidIssuer"],
                     IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWT:Secret"]))
                 };
             });
        }
    

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MobizoneApi v1"));
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
