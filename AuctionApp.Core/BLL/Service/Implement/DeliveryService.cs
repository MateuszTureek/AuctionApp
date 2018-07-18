using AuctionApp.Core.BLL.DTO;
using AuctionApp.Core.BLL.Service.Contract;
using AuctionApp.Core.DAL.Data.AuctionContext.Domain;
using AuctionApp.Core.DAL.Repository.Contract;
using AuctionApp.Core.DAL.UnitOfWork;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AuctionApp.Core.BLL.Service.Implement
{
    public class DeliveryService : IDeliveryService
    {
        readonly IGenericRepo<Delivery> _deliveryRepo;
        readonly IUnitOfWork _unitOfWork;
        readonly IMapper _mapper;

        public DeliveryService(IGenericRepo<Delivery> deliveryRepo, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _deliveryRepo = deliveryRepo;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public void AddDMethod(DeliveryDTO dto)
        {
            Delivery delivery = _mapper.Map<DeliveryDTO, Delivery>(dto);
            _deliveryRepo.Add(delivery);
            _unitOfWork.Save();
        }

        public void ChangeMethod(DeliveryDTO dto)
        {
            Delivery delivery = _deliveryRepo.GetById(dto.Id);

        }

        public void DeleteMethod(int id)
        {
            Delivery delivery = _deliveryRepo.GetById(id);
            _deliveryRepo.Remove(delivery);
            _unitOfWork.Save();
        }

        public List<DeliveryDTO> GetAllMethods()
        {
            var delieryMethods = _deliveryRepo.GetAll().ToList();
            return _mapper.Map<List<Delivery>, List<DeliveryDTO>>(delieryMethods);
        }

        public DeliveryDTO GetMethod(int id)
        {
            var delivery = _deliveryRepo.GetById(id);
            return _mapper.Map<Delivery, DeliveryDTO>(delivery);
        }
    }
}
