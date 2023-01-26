using Microsoft.AspNetCore.Mvc;
using ParkingHavan.Controllers.Common;
using ParkingHavan.Domain.Models;
using ParkingHavan.Service.Interfaces;
using System.Threading.Tasks;

namespace ParkingHavan.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : BaseController
    {
        private readonly IClienteService<ClienteModel> _clienteService;

        public ClienteController(IClienteService<ClienteModel> clienteService)
        {
            _clienteService = clienteService;
        }


        [HttpPost]
        [Route("Insert")]
        public async Task<IActionResult> Insert(ClienteModel entity)
        {
            return Result(await _clienteService.Insert(entity));
        }
    }
}
