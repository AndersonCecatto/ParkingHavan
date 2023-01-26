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
    public class ClienteService : ServiceBase<ClienteModel>, IClienteService<ClienteModel>
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IMapper _mapper;

        public ClienteService(IMapper mapper, IClienteRepository clienteRepository)
        {
            _mapper = mapper;
            _clienteRepository = clienteRepository;
        }

        public override async Task<ResponseBase<string>> Insert(ClienteModel entity)
        {
            try
            {
                await _clienteRepository.AddAndSaveAsync(_mapper.Map<Cliente>(entity));

                return new ResponseBase<string> { Dados = "Salvo com Sucesso!", Sucesso = true };
            }
            catch (Exception ex)
            {
                return new ResponseBase<string> { Sucesso = false, Dados = "Erro ao Salvar!", Mensagens = new List<string> { ex.Message } };
            }
        }
    }
}
