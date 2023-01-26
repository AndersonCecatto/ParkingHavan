using Microsoft.AspNetCore.Mvc;
using ParkingHavan.Controllers.Common;
using ParkingHavan.Domain.Models;
using ParkingHavan.Service.Interfaces;
using System.Threading.Tasks;

namespace ParkingHavan.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TabelaPrecoController : BaseController
    {
        private readonly ITabelaPrecoPeriodoVigenciaService<TabelaPrecoPeriodoVigenciaModel> _tabelaPrecoPeriodoVigenciaService;

        public TabelaPrecoController(
            ITabelaPrecoPeriodoVigenciaService<TabelaPrecoPeriodoVigenciaModel> tabelaPrecoPeriodoVigenciaService)
        {
            _tabelaPrecoPeriodoVigenciaService = tabelaPrecoPeriodoVigenciaService;
        }

        [HttpPost]
        [Route("Insert")]
        public async Task<IActionResult> Insert(TabelaPrecoPeriodoVigenciaModel entity)
        {
            return Result(await _tabelaPrecoPeriodoVigenciaService.Insert(entity));
        }

        [HttpPost]
        [Route("InsertTipoPeriodo")]
        public async Task<IActionResult> InsertTipoPeriodo(TabelaPrecoTipoPeriodoModel entity)
        {
            return Result(await _tabelaPrecoPeriodoVigenciaService.InsertTipoPeriodo(entity));
        }

        [HttpPost]
        [Route("InsertValores")]
        public async Task<IActionResult> InsertValores(TabelaPrecoValoresModel entity)
        {
            return Result(await _tabelaPrecoPeriodoVigenciaService.InsertValores(entity));
        }

    }
}
