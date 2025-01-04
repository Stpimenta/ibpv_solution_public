using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using IbpvDtos;
using c___Api_Example.data;
using c___Api_Example.Models;
using Microsoft.EntityFrameworkCore;

namespace c___Api_Example.Repository.Interfaces
{

    public class GastoRepositorio : IGastoRepositorio
    {
        readonly private IbpvDataBaseContext _ibpvDataBaseContext;

        public GastoRepositorio(IbpvDataBaseContext ibpvDataBaseContext)
        {
            _ibpvDataBaseContext = ibpvDataBaseContext;
        }

        public async Task<int> Addgasto(GastoModel gasto)
        {
            using var transction = await _ibpvDataBaseContext.Database.BeginTransactionAsync(System.Data.IsolationLevel.RepeatableRead);
            
            try
            {
                var caixa = await _ibpvDataBaseContext.Caixa.FindAsync(gasto.IdCaixa);
                caixa!.ValorTotal -= gasto.Valor;
                await _ibpvDataBaseContext.Gasto.AddAsync(gasto);
                await _ibpvDataBaseContext.SaveChangesAsync();
                await transction.CommitAsync();
                return  gasto.Id;
            }

            catch
            {
                await transction.RollbackAsync();
                throw new Exception("erro ao adicionar gasto");
            }
            
           
        }


        public async Task<PaginetedResultDTO<GastoModel>> GetPageGastos(int pageNumber, int pageQuantity, string? descricao = null, int? idCaixa = null, DateTime? initialDate = null, DateTime? finalDate = null)
        {
            var query = _ibpvDataBaseContext.Gasto.AsQueryable();
            if(initialDate is not null) // ou has value
            {
                query = query.Where(g => g.Data >= initialDate.Value);
            }

            if(idCaixa is not null) // ou has value
            {
                query = query.Where(g => g.IdCaixa == idCaixa);
            }

            if(finalDate is not null) // ou has value
            {
                query = query.Where(g => g.Data <= finalDate.Value);
            }

            if(descricao is not null) // ou has value
            {
                //tolower para garantir tudo minuscula na comparacao e trim remove espacoes em branco
                query = query.Where(g => g.Descricao!.ToLower().Trim().Contains(descricao.ToLower().Trim()));
            }

            List<GastoModel> gastos = await query.Include(g=>g.Caixa)
            .OrderBy(g => g.Data)
            .Skip(pageQuantity * (pageNumber-1))
            .Take(pageQuantity)
            .ToListAsync();

            //transformo em ponto flutuante depois em int novamente
            int pagesTotal = (int)Math.Ceiling((double)await query.CountAsync() / pageQuantity);

            return new PaginetedResultDTO<GastoModel>{
                items = gastos,
                pages = pagesTotal
            };
        }



        public async Task<bool> DeleteGasto(int id)
        {
            using var transaction = await _ibpvDataBaseContext.Database.BeginTransactionAsync(System.Data.IsolationLevel.RepeatableRead);
            try
            {
                var gasto = await _ibpvDataBaseContext.Gasto.FindAsync(id);
               
                if(gasto is null)
                {
                    throw new Exception("gasto nao encontrado");
                }
                var caixa = await _ibpvDataBaseContext.Caixa.FindAsync(gasto.IdCaixa);
                caixa!.ValorTotal += gasto.Valor;
                _ibpvDataBaseContext.Gasto.Remove(gasto);
                await _ibpvDataBaseContext.SaveChangesAsync();
                await transaction.CommitAsync();
                return true;
            }  

            catch
            {
                await transaction.RollbackAsync();
                throw new Exception ("rollback erro ao remover gasto");
            }
            
        }
       
    }
}