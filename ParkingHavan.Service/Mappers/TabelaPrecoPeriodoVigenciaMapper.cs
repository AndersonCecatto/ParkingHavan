using AutoMapper;
using ParkingHavan.Domain.Entities;
using ParkingHavan.Domain.Models;

namespace ParkingHavan.Service.Mappers
{
    public class TabelaPrecoPeriodoVigenciaMapper : Profile
    {
        public TabelaPrecoPeriodoVigenciaMapper()
        {
            CreateMap<TabelaPrecoPeriodoVigenciaModel, TabelaPrecoPeriodoVigencia>().ReverseMap();
        }
    }
}
