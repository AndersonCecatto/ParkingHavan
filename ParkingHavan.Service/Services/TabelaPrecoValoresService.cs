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
    public class TabelaPrecoValoresService : ServiceBase<TabelaPrecoValoresModel>, ITabelaPrecoValoresService<TabelaPrecoValoresModel>
    {
        private readonly IMapper _mapper;

        public TabelaPrecoValoresService(IMapper mapper, IClienteRepository clienteRepository)
        {
            _mapper = mapper;
        }
    }
}
