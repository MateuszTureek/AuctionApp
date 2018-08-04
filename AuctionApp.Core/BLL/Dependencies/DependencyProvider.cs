using AuctionApp.Core.BLL.Mapper;
using AuctionApp.Core.BLL.Service.Contract;
using AuctionApp.Core.BLL.Service.Implement;
using AuctionApp.Core.DAL.Data.AuctionContext.Domain;
using AuctionApp.Core.DAL.Repository.Contract;
using AuctionApp.Core.DAL.Repository.Implement;
using AuctionApp.Core.DAL.UnitOfWork;
using AuctionApp.Core.DAL.UnitOfWork.Contract;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuctionApp.Core.BLL.Dependencies
{
    public static class DependencyProvider
    {
        public static void SetupAuctionDependency(IServiceCollection services)
        {
            services.AddTransient<IUnitOfWork,UnitOfWork>();

            services.AddTransient<IItemRepo, ItemRepo>();
            services.AddTransient<ICategoryRepo, CategoryRepo>();
            services.AddTransient<IOrderRepo, OrderRepo>();
            services.AddTransient<IPaymentRepo, PaymentRepo>();
            services.AddTransient<IBidRepo,BidRepo>();
            
            services.AddTransient<IPhotoService, PhotoService>();
            services.AddTransient<IItemService, ItemService>();
            services.AddTransient<ICategoryService, CategoryService>();
            services.AddTransient<IOrderService, OrderService>();
            services.AddTransient<ICartService, CartService>();
            services.AddTransient<ICustomerService,CustomerService>();
        }
    }
}
