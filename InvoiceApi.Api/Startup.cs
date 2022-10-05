using AutoMapper;
using InvoiceApi.Api.ViewModels;
using InvoiceApi.Domain.Entities;
using InvoiceApi.Infrastructure.Context;
using InvoiceApi.Infrastructure.Interfaces;
using InvoiceApi.Infrastructure.Repositories;
using InvoiceApi.Services.DTO;
using InvoiceApi.Services.Interfaces;
using InvoiceApi.Services.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvoiceApi.Api
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

            #region AutoMapper

            var autoMapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Contact, ContactDTO>().ReverseMap();
                cfg.CreateMap<CreateContactViewModel, ContactDTO>().ReverseMap();
                cfg.CreateMap<UpdateContactViewModel, ContactDTO>().ReverseMap();

                cfg.CreateMap<Client, ClientDTO>().ReverseMap();
                cfg.CreateMap<CreateClientViewModel, ClientDTO>().ReverseMap();
                cfg.CreateMap<UpdateClientViewModel, ClientDTO>().ReverseMap();

                cfg.CreateMap<Address, AddressDTO>().ReverseMap();
                cfg.CreateMap<CreateAddressViewModel, AddressDTO>().ReverseMap();
                cfg.CreateMap<UpdateAddressViewModel, AddressDTO>().ReverseMap();

                cfg.CreateMap<Invoice, InvoiceDTO>().ReverseMap();
                cfg.CreateMap<CreateInvoiceViewModel, InvoiceDTO>().ReverseMap();
                cfg.CreateMap<UpdateInvoiceViewModel, InvoiceDTO>().ReverseMap();

                cfg.CreateMap<Payment, PaymentDTO>().ReverseMap();
                cfg.CreateMap<CreatePaymentViewModel, PaymentDTO>().ReverseMap();
                cfg.CreateMap<UpdatePaymentViewModel, PaymentDTO>().ReverseMap();

                cfg.CreateMap<Product, ProductDTO>().ReverseMap();
                cfg.CreateMap<CreateProductViewModel, ProductDTO>().ReverseMap();
                cfg.CreateMap<UpdateProductViewModel, ProductDTO>().ReverseMap();

                cfg.CreateMap<Item, ItemDTO>().ReverseMap();
                cfg.CreateMap<CreateItemViewModel, ItemDTO>().ReverseMap();
                cfg.CreateMap<UpdateItemViewModel, ItemDTO>().ReverseMap();
            });

            services.AddSingleton(autoMapperConfig.CreateMapper());

            #endregion


            #region DI

            services.AddSingleton(d => Configuration);
            services.AddDbContext<InvoiceContext>(options => options.UseSqlServer(Configuration["ConnectionStrings:INVOICE"]), ServiceLifetime.Transient);

            services.AddScoped<IContactService, ContactService>();
            services.AddScoped<IContactRepository, ContactRepository>();

            services.AddScoped<IClientService, ClientService>();
            services.AddScoped<IClientRepository, ClientRepository>();

            services.AddScoped<IAddressService, AddressService>();
            services.AddScoped<IAddressRepository, AddressRepository>();

            services.AddScoped<IInvoiceService, InvoiceService>();
            services.AddScoped<IInvoiceRepository, InvoiceRepository>();

            services.AddScoped<IPaymentService, PaymentService>();
            services.AddScoped<IPaymentRepository, PaymentRepository>();

            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IProductRepository, ProductRepository>();

            services.AddScoped<IItemService, ItemService>();
            services.AddScoped<IItemRepository, ItemRepository>();


            #endregion

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "InvoiceApi.Api", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "InvoiceApi.Api v1"));
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
