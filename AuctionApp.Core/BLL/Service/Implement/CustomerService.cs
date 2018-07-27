using AuctionApp.Core.BLL.DTO.Customer;
using AuctionApp.Core.BLL.Service.Contract;
using AuctionApp.Core.DAL.Data.IdentityContext.Domain;
using AutoMapper;
using Microsoft.AspNetCore.Identity;

namespace AuctionApp.Core.BLL.Service.Implement
{
    public class CustomerService : ICustomerService
    {
        readonly UserManager<AppUser> _userManager;
        readonly IMapper _mapper;
        public CustomerService(UserManager<AppUser> userManager,IMapper mapper)
        {
            _userManager=userManager;
            _mapper=mapper;
        }

        public ContactDTO GetContact(string userId)
        {
            var user=_userManager.FindByIdAsync(userId).Result;
            var contactDTO=_mapper.Map<AppUser,ContactDTO>(user);
            return contactDTO;
        }
    }
}