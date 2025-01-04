using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using c___Api_Example.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace c___Api_Example.Data.Map
{
    public class UsuarioMap : IEntityTypeConfiguration<UsuarioModel>
    {
        public void Configure(EntityTypeBuilder<UsuarioModel> builder)
        {   
            builder.HasKey((u) => u.Id);
            builder.Property((u)=>u.Nome).HasMaxLength(255).IsRequired();
            builder.Property((u)=>u.Data_nascimento).IsRequired();
            builder.Property((u)=>u.Senha).HasMaxLength(255).IsRequired();
            builder.Property((u)=>u.BairroEdereco).HasMaxLength(255).IsRequired();
            builder.Property((u)=>u.CepEndereco).HasMaxLength(255).IsRequired();
            builder.Property((u)=>u.CidadeEndereco).HasMaxLength(255).IsRequired();
            builder.Property((u)=>u.RuaEdereco).HasMaxLength(255).IsRequired();
            builder.Property((u)=>u.NumeroEndereco).HasMaxLength(255).IsRequired();
            builder.Property((u)=>u.UfEndereco).HasMaxLength(255).IsRequired();
            builder.Property((u) => u.ComplementoEndereco).HasMaxLength(255);
            builder.Property((u)=>u.Cpf).HasMaxLength(255);
            builder.Property((u)=>u.RGnumero).HasMaxLength(255);
            builder.Property((u)=>u.Telefone_pais).HasMaxLength(50);
            builder.Property((u)=>u.TelefoneNumero).HasMaxLength(50);
            builder.Property((u)=>u.TokenContribuicao).HasMaxLength(255).IsRequired();//
            builder.Property((u)=>u.status).IsRequired();
            builder.Property((u)=>u.Rule).IsRequired();;
            builder.Property((u)=>u.dataBatismo);
            builder.Property((u)=>u.pastorBatismo);
            builder.Property((u)=>u.igrejaBatismo);
            builder.Property((u)=>u.filhos);
            builder.Property((u)=>u.profissao);
            builder.Property((u)=>u.estadoCivil);
            builder.Property((u)=>u.urlImage);
            builder.Property((u)=>u.genero).HasConversion<int>();
            builder.HasIndex(u => u.TokenContribuicao).IsUnique();
            builder.HasIndex(u => u.Email).IsUnique();
        }   
    }
}