using AutoMapper;
using ParkingHavan.Domain.Entities;
using ParkingHavan.Domain.Models;

namespace ParkingHavan.Service.Mappers
{
    public class ClienteMapper : Profile
    {
        public ClienteMapper()
        {
            CreateMap<ClienteModel, Cliente>().ReverseMap();
        }
    }
}
