using AuctionApp.Core.DAL.Data.AuctionContext.Domain;
using AuctionApp.Core.DAL.Data.IdentityContext.Domain;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuctionApp.Core.BLL.Mapper.Resolver
{
    public class UsernameOfBidOwnerResolver<TDestination> : IValueResolver<Bid, TDestination, string>
    {
        readonly UserManager<AppUser> _userManager;

        public UsernameOfBidOwnerResolver(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public string Resolve(Bid source, TDestination destination, string destMember, ResolutionContext context)
        {
            var task = _userManager.FindByIdAsync(source.UserId);
            var username = task.Result.UserName;

            return username;
        }
    }
}
