using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IbpvDtos;
using c___Api_Example.Models;

namespace c___Api_Example.Repository.Interfaces
{
    public interface IGastoRepositorio
    {
        public Task<PaginetedResultDTO<GastoModel>> GetPageGastos(int pageNumber, int pageQuantity, string? descricao = null, int? idCaixa = null, DateTime? initialDate = null, DateTime? finalDate = null);
        public Task<int> Addgasto (GastoModel gasto);
        public Task<bool> DeleteGasto(int id);
    }
}