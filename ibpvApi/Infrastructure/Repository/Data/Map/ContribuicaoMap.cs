using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using c___Api_Example.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace c___Api_Example.Data.Map
{
    public class ContribuicaoMap : IEntityTypeConfiguration<ContribuicaoModel>
    {
        public void Configure(EntityTypeBuilder<ContribuicaoModel> builder)
        {
            builder.HasKey((u) => u.Id);
            builder.Property((u) => u.Valor).IsRequired();
            builder.Property((u) => u.Descricao).HasMaxLength(255);
            builder.Property((u) => u.Data).IsRequired();
            builder.Property((u) => u.UrlEnvelope).HasMaxLength(255);

            builder.HasOne((contribuicao) => contribuicao.Caixa)
                   .WithMany()
                   .HasForeignKey((contribuicao)=> contribuicao.IdCaixa);
            
            builder.HasOne((Contribuicao) => Contribuicao.Membro)
                   .WithMany((m) => m.Contribuicao)
                   .HasForeignKey((contribuicao) => contribuicao.IdMembro)
                   .IsRequired(false);
        }          
    }
}