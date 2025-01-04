using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using c___Api_Example.Data.Map;
using c___Api_Example.Infrastructure.Repository.Data.Map;
using c___Api_Example.Models;
using Microsoft.EntityFrameworkCore;

namespace c___Api_Example.data
{
    public class IbpvDataBaseContext : DbContext
    {
        public IbpvDataBaseContext (DbContextOptions<IbpvDataBaseContext> options)
            :base(options) //base é usado para passar para o contrutor da classe pai
        {

        }

        public DbSet<UsuarioModel> Usuarios{get; set;}
        public DbSet<ContribuicaoModel> Contribuicao{get; set;}
        public DbSet<CaixaModel> Caixa{get; set;}
        public DbSet<GastoModel> Gasto{get; set;}
        public DbSet<GastoModel> Desligamento{get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new CaixaMap());
            modelBuilder.ApplyConfiguration(new GastoMap());
            modelBuilder.ApplyConfiguration(new ContribuicaoMap());
            modelBuilder.ApplyConfiguration(new DesligamentoMap());
            base.OnModelCreating(modelBuilder);
        }



    }
}