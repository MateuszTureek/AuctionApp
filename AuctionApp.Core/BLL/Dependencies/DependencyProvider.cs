using AuctionApp.Core.BLL.Mapper;
using AuctionApp.Core.BLL.Service.Contract;
using AuctionApp.Core.BLL.Service.Implement;
using AuctionApp.Core.BLL.Static;
using AuctionApp.Core.BLL.Strategy.AuctionOrderBy;
using AuctionApp.Core.DAL.Repository.Contract;
using AuctionApp.Core.DAL.Repository.Implement;
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
            services.AddTransient<IAuctionContext, AuctionContext>();
            services.AddTransient<IStrategy, AuctionByCategoryOrderByEndDateStartegy>();
            services.AddTransient<IStrategy, AuctionByCategoryOrderByPriceBuyNowStartegy>();
            services.AddTransient<IStrategy, AuctionByCategoryOrderByNameStartegy>();
            services.AddTransient<IStrategy, AuctionBySubcategoryOrderByEndDateStartegy>();
            services.AddTransient<IStrategy, AuctionBySubcategoryOrderByPriceBuyNowStartegy>();
            services.AddTransient<IStrategy, AuctionBySubcategoryOrderByNameStartegy>();

            services.AddTransient<IAuctionRepo, AuctionRepo>();
            services.AddTransient<ICategoryRepo, CategoryRepo>();

            services.AddTransient<IPaginationService, PaginationService>();
            services.AddTransient<IAuctionService, AuctionService>();
            services.AddTransient<ICategoryService, CategoryService>();

            services.AddAutoMapper(typeof(MapperProfile));

            services.AddTransient<ICartService, CartService>();
        }
    }
}
