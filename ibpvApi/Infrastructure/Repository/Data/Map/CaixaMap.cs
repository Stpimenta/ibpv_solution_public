using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using c___Api_Example.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace c___Api_Example.Data.Map
{
    public class CaixaMap : IEntityTypeConfiguration<CaixaModel>
    {
        public void Configure(EntityTypeBuilder<CaixaModel> builder)
        {
            builder.HasKey((u) => u.Id);
            builder.Property((u) => u.Nome).HasMaxLength(255).IsRequired();
            builder.Property((u) => u.ValorTotal).IsRequired();

            /*relacionamento com gasto 1,1 0,n*/
            builder.HasMany((c)=>c.Gastos)
                   .WithOne((g)=>g.Caixa)
                   .HasForeignKey((g)=>g.IdCaixa)
                   .OnDelete(DeleteBehavior.Cascade); // Exclusão em cascata;
            
            builder.HasMany((caixa)=>caixa.Contribuicoes)
                   .WithOne((contribuicao) => contribuicao.Caixa)
                   .HasForeignKey((contribuicao) => contribuicao.IdCaixa)
                   .OnDelete(DeleteBehavior.Cascade);
        }          
    }
}