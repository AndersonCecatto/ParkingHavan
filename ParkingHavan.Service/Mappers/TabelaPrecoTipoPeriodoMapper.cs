using AutoMapper;
using ParkingHavan.Domain.Entities;
using ParkingHavan.Domain.Models;

namespace ParkingHavan.Service.Mappers
{
    public class TabelaPrecoTipoPeriodoMapper : Profile
    {
        public TabelaPrecoTipoPeriodoMapper()
        {
            CreateMap<TabelaPrecoTipoPeriodoModel, TabelaPrecoTipoPeriodo>().ReverseMap();
        }
    }
}
