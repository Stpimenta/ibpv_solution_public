using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IbpvDtos;
using c___Api_Example.Models;

namespace c___Api_Example.Repository.Interfaces
{
    public interface IContribuicaoRepositorio
    {
        public Task<PaginetedResultDTO<ContribuicaoModel>> GetPagContribuicoes(int pageNumber, int pageQuantity, string? descricao = null, int? idCaixa = null, DateTime? initialDate  = null, DateTime? finalDate  = null);
        public Task<int> AddContribuicao(ContribuicaoModel contribuicao);
        public Task<bool> DeleteContribuicao(int id);
    }   
}