using AutoMapper;
using ParkingHavan.Domain.Entities;
using ParkingHavan.Domain.Models;

namespace ParkingHavan.Service.Mappers
{
    class TabelaPrecoValoresMapper : Profile
    {
        public TabelaPrecoValoresMapper()
        {
            CreateMap<TabelaPrecoValoresModel, TabelaPrecoValores>().ReverseMap();
        }
    }
}
