using AuctionApp.Core.BLL.DTO.Customer;

namespace AuctionApp.Core.BLL.Service.Contract
{
    public interface ICustomerService
    {
         ContactDTO GetContact(string userId);
        void EditContact(ContactDTO dto);
    }
}