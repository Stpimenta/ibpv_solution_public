using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IbpvDtos;
using c___Api_Example.data;
using c___Api_Example.Models;
using c___Api_Example.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Npgsql.Internal;

namespace c___Api_Example.Repository
{
    public class ContribuicaoRepositorio : IContribuicaoRepositorio
    {
        readonly private IbpvDataBaseContext _ibpvDataBaseContext;

        public ContribuicaoRepositorio(IbpvDataBaseContext ibpvDataBaseContext)
        {
            _ibpvDataBaseContext = ibpvDataBaseContext;
        }

        public async Task<int> AddContribuicao(ContribuicaoModel contribuicao)
        {
            using var transction = await _ibpvDataBaseContext.Database.BeginTransactionAsync(System.Data.IsolationLevel.RepeatableRead);
            
            try
            {
                var caixa = await _ibpvDataBaseContext.Caixa.FindAsync(contribuicao.IdCaixa);

                caixa!.ValorTotal += contribuicao.Valor;

                await _ibpvDataBaseContext.Contribuicao.AddAsync(contribuicao);
                await _ibpvDataBaseContext.SaveChangesAsync();
                await transction.CommitAsync();
                return contribuicao.Id;
            }

            catch
            {
                await transction.RollbackAsync();
                throw new Exception ("erro ao  adicionar contribuicao");  // Re-throw the exception so it can be handled upstream
            }
        
        }

        public async Task<PaginetedResultDTO<ContribuicaoModel>> GetPagContribuicoes(int pageNumber, int pageQuantity, string? descricao = null, int? idCaixa = null, DateTime? initialDate  = null, DateTime? finalDate  = null)
        {
            var query = _ibpvDataBaseContext.Contribuicao.AsQueryable();
            
            if(descricao is not null)
            {
                query = query.Where(g => g.Descricao!.ToLower().Trim().Contains(descricao.ToLower().Trim()));
            }

             if(idCaixa is not null)
            {
                query = query.Where(g => g.IdCaixa == idCaixa);
            }

            if(initialDate is not null) // ou has value
            {
                query = query.Where(g => g.Data >= initialDate.Value);
            }

            if(finalDate is not null) // ou has value
            {
                query = query.Where(g => g.Data <= finalDate.Value);
            }   
            
            List<ContribuicaoModel> contribuicoes = await query
            .Include(c => c.Caixa)
            .Include(c => c.Membro)
            .OrderBy(c => c.Data)
            .Skip((pageNumber-1)  * pageQuantity)
            .Take(pageQuantity)
            .ToListAsync();


            int pagesTotal = (int)Math.Ceiling((double)await query.CountAsync() / pageQuantity);
            return new PaginetedResultDTO<ContribuicaoModel>{
                items = contribuicoes,
                pages = pagesTotal
            };
        }

        public async Task<bool> DeleteContribuicao(int id)
        {  
            using var transaction = await _ibpvDataBaseContext.Database.BeginTransactionAsync(System.Data.IsolationLevel.RepeatableRead); 
            
            try
            {
                var contribuicao = await _ibpvDataBaseContext.Contribuicao.FindAsync(id);
                if(contribuicao is null)
                {
                    throw new Exception("Caixa não encontrado");
                }
                var caixa = await _ibpvDataBaseContext.Caixa.FindAsync(contribuicao.IdCaixa);
                caixa!.ValorTotal -= contribuicao.Valor;
                _ibpvDataBaseContext.Contribuicao.Remove(contribuicao);
                await _ibpvDataBaseContext.SaveChangesAsync();
                await transaction.CommitAsync();
                return true;
            }
            catch
            {
                await transaction.RollbackAsync();
                throw new Exception ("erro ao  adicionar contribuicao");  // Re-throw the exception so it can be handled upstream
            }
           
        }
    }
}