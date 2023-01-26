using ParkingHavan.Domain.Entities.Common;

namespace ParkingHavan.Domain.Entities
{
    public class PeriodoVigenciaTipoPeriodo : EntityBase
    {
        public long TabelaPrecoPeriodoVigenciaId { get; set; }
        public TabelaPrecoPeriodoVigencia TabelaPrecoPeriodoVigencia { get; set; }
        public long TabelaPrecoTipoPeriodoId { get; set; }
        public TabelaPrecoTipoPeriodo TabelaPrecoTipoPeriodo { get; set; }
    }
}
