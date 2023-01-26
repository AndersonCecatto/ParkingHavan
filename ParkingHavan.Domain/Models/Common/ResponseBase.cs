using System.Collections.Generic;

namespace ParkingHavan.Domain.Models.Common
{
    public class ResponseBase<T>
    {
        public bool Sucesso { get; set; }

        public T Dados { get; set; }

        public List<string> Mensagens { get; set; }
    }
}
