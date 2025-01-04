using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using c___Api_Example.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace c___Api_Example.Data.Map
{
    public class GastoMap : IEntityTypeConfiguration<GastoModel>
    {
        public void Configure(EntityTypeBuilder<GastoModel> builder)
        {
            builder.HasKey((u) => u.Id);
            builder.Property((u) => u.Data).IsRequired();
            builder.Property((u) => u.Descricao).HasMaxLength(255).IsRequired();
            builder.Property((u) => u.NumeroFiscal).HasMaxLength(255);
            builder.Property((u) => u.UrlComprovante).HasMaxLength(255);
            builder.Property((u) => u.Valor).IsRequired();

            /*se relaciona com caixa*/
            builder.HasOne((g) => g.Caixa)
                   .WithMany()
                   .HasForeignKey((g) => g.IdCaixa);

        }
    }
}