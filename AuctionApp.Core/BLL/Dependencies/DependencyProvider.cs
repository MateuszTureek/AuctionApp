using AuctionApp.Core.BLL.Mapper;
using AuctionApp.Core.BLL.Service.Contract;
using AuctionApp.Core.BLL.Service.Implement;
using AuctionApp.Core.DAL.Data.AuctionContext.Domain;
using AuctionApp.Core.DAL.Repository.Contract;
using AuctionApp.Core.DAL.Repository.Implement;
using AuctionApp.Core.DAL.UnitOfWork;
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
            services.AddTransient<IUnitOfWork, AuctionUnitOfWork>();

            services.AddTransient<IGenericRepo<Delivery>, GenericRepo<Delivery>>();
            services.AddTransient<IItemRepo, ItemRepo>();
            services.AddTransient<ICategoryRepo, CategoryRepo>();

            services.AddTransient<IPhotoService, PhotoService>();
            services.AddTransient<IDeliveryService, DeliveryService>();
            services.AddTransient<IItemService, ItemService>();
            services.AddTransient<ICategoryService, CategoryService>();

            services.AddTransient<ICartService, CartService>();
        }
    }
}
