using AutoMapper;
using ParkingHavan.Data.Interfaces.Repositories;
using ParkingHavan.Domain.Entities;
using ParkingHavan.Domain.Models;
using ParkingHavan.Domain.Models.Common;
using ParkingHavan.Service.Interfaces;
using ParkingHavan.Service.Services.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ParkingHavan.Service.Services
{
    public class TabelaPrecoTipoPeriodoService : ServiceBase<TabelaPrecoTipoPeriodoModel>, ITabelaPrecoTipoPeriodoService<TabelaPrecoTipoPeriodoModel>
    {
        private readonly IMapper _mapper;

        public TabelaPrecoTipoPeriodoService(IMapper mapper, ITabelaPrecoPeriodoVigenciaRepository tabelaPrecoPeriodoVigenciaRepository)
        {
            _mapper = mapper;
        }
        
    }
}
