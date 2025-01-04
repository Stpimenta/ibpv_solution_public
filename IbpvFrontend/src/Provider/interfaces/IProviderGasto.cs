using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IbpvDtos;
using IbpvFrontend.src.Components.Pages;

namespace IbpvFrontend.src.Provider.interfaces
{
    public interface IProviderGasto
    {
        public Task<PaginetedResultDTO<GastoPagDTO>> getPageGastos(int pageNumber, int pageQuantity, int? idCaixa = null, string? descricao = null, DateTime? initialDate = null, DateTime? finalDate = null);
        public Task<int> addGasto (DtoGastoPost dtoGasto);
        public Task<bool>deleteGasto(int id);
    }
}