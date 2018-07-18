using AuctionApp.Core.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuctionApp.Core.BLL.Service.Contract
{
    public interface IDeliveryService
    {
        void AddDMethod(DeliveryDTO dto);
        void DeleteMethod(int id);
        void ChangeMethod(DeliveryDTO dto);
        DeliveryDTO GetMethod(int id);
        List<DeliveryDTO> GetAllMethods();
    }
}
