using Microsoft.AspNetCore.Mvc;
using ParkingHavan.Controllers.Common;
using ParkingHavan.Domain.Models;
using ParkingHavan.Service.Interfaces;
using System.Threading.Tasks;

namespace ParkingHavan.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EstacionamentoController : BaseController
    {
        private readonly IEstacionamentoService<EstacionamentoModel> _estacionamentoService;

        public EstacionamentoController(IEstacionamentoService<EstacionamentoModel> estacionamentoService)
        {
            _estacionamentoService = estacionamentoService;
        }


        [HttpPost]
        [Route("Insert")]
        public async Task<IActionResult> Insert(EstacionamentoModel entity)
        {
            return Result(await _estacionamentoService.Insert(entity));
        }

        [HttpGet]
        [Route("GetByPlaca")]
        public async Task<IActionResult> GetByPlaca(string placa)
        {
            return Result(await _estacionamentoService.GetByPlaca(placa));
        }

        [HttpPost]
        [Route("Pagamento")]
        public async Task<IActionResult> Pagamento(string placa)
        {
            return Result(await _estacionamentoService.Pagamento(placa));
        }
    }
}
