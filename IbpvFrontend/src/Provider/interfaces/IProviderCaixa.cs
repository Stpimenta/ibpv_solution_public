using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IbpvDtos;

namespace IbpvFrontend.src.Provider.interfaces
{
    public interface IProviderCaixa
    {
        public Task<List<CaixaDTO>> getCaixa();
        public Task<int> addCaixa (CaixaDTO caixa);
        public Task<bool>deleteCaixa(int id);
    }
}