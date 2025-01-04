using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using c___Api_Example.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace c___Api_Example.Infrastructure.Repository.Data.Map
{
    public class DesligamentoMap : IEntityTypeConfiguration<DesligamentoModel>
    {
        public void Configure(EntityTypeBuilder<DesligamentoModel> builder)
        {
            builder.HasKey((d) => d.id);
            builder.Property((d) => d.descricao);
            builder.Property((d) => d.data);

            builder.HasOne((d) => d.membro)
                    .WithMany((m)=> m.HistDesligamento)
                    .HasForeignKey((d)=> d.idMembro);

        }
    }
}