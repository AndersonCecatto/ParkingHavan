using Microsoft.AspNetCore.Mvc;
using ParkingHavan.Controllers.Common;
using ParkingHavan.Domain.Models;
using ParkingHavan.Service.Interfaces;
using System;
using System.Threading.Tasks;

namespace ParkingHavan.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RelatorioController : BaseController
    {
        private readonly IEstacionamentoService<EstacionamentoModel> _estacionamentoService;

        public RelatorioController(IEstacionamentoService<EstacionamentoModel> estacionamentoService)
        {
            _estacionamentoService = estacionamentoService;
        }

        [HttpGet]
        [Route("FinalizadosOrEmAberto")]
        public async Task<IActionResult> FinalizadosOrEmAberto(DateTime dataInicial, DateTime dataFinal, bool ehFinalizado)
        {
            return Result(await _estacionamentoService.FinalizadosOrEmAberto(dataInicial, dataFinal, ehFinalizado));
        }

        [HttpGet]
        [Route("HistoricoCondutor")]
        public async Task<IActionResult> HistoricoCondutor(string nome)
        {
            return Result(await _estacionamentoService.HistoricoCondutor(nome));
        }

        [HttpGet]
        [Route("HistoricoVeiculo")]
        public async Task<IActionResult> HistoricoVeiculo(string placa)
        {
            return Result(await _estacionamentoService.HistoricoVeiculo(placa));
        }
    }
}
