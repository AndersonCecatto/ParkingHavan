using AutoMapper;
using ParkingHavan.Domain.Entities;
using ParkingHavan.Domain.Models;

namespace ParkingHavan.Service.Mappers
{
    public class EstabelecimentoMapper : Profile
    {
        public EstabelecimentoMapper()
        {
            CreateMap<EstacionamentoModel, Estacionamento>().ReverseMap();
        }
    }
}
