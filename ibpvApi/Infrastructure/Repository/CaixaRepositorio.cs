using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using c___Api_Example.data;
using c___Api_Example.Models;
using c___Api_Example.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace c___Api_Example.Repository
{
    public class CaixaRepositorio : ICaixaRepositorio
    {
        private readonly IbpvDataBaseContext _ibpvDataBaseContext;

        public CaixaRepositorio(IbpvDataBaseContext ibpvDataBaseContext)
        {
            _ibpvDataBaseContext = ibpvDataBaseContext;
        }
        
        public async Task<int> AddCaixa(CaixaModel caixa)
        {
            await _ibpvDataBaseContext.Caixa.AddAsync(caixa);
            await _ibpvDataBaseContext.SaveChangesAsync();
            return caixa.Id;
        }
        public async Task<List<CaixaModel>> GetAllCaixas()
        {
            List<CaixaModel> caixas  = await _ibpvDataBaseContext.Caixa.OrderBy(c => c.Nome).ToListAsync();
            return caixas;
        }


        public async Task<bool> DeleteCaixa(int id)
        {
            var caixa = await _ibpvDataBaseContext.Caixa.FindAsync(id);
            if(caixa is null)
            {
                throw new Exception("caixa não encontrado");
            }
            _ibpvDataBaseContext.Caixa.Remove(caixa);
            await _ibpvDataBaseContext.SaveChangesAsync();
            return true;
        }

    }
}

