using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IbpvDtos;

namespace IbpvFrontend.src.Provider.interfaces
{
    public interface IProviderContribuicao
    {
        public Task<PaginetedResultDTO<ContribuicaoPagDTO>> getPageContribuicao(int pageNumber, int pageQuantity, string? descricao = null, int? idCaixa = null, DateTime? initialDate = null, DateTime? finalDate = null);
        public Task<int> addContribuicao (ContribuicaoPostDTO gasto);
        public Task<bool>deleteContribuicao(int id);
    }
}