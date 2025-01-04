﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using c___Api_Example.data;

#nullable disable

namespace c___Api_Example.Migrations
{
    [DbContext(typeof(IbpvDataBaseContext))]
    [Migration("20240509220916_IbpvDabase")]
    partial class IbpvDabase
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("c___Api_Example.Models.CaixaModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<decimal>("ValorTotal")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.ToTable("Caixa");
                });

            modelBuilder.Entity("c___Api_Example.Models.ContribuicaoModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("CaixaModelId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("Data")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Descricao")
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<int>("IdCaixa")
                        .HasColumnType("integer");

                    b.Property<int?>("IdMembro")
                        .HasColumnType("integer");

                    b.Property<string>("UrlEnvelope")
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<decimal>("Valor")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.HasIndex("CaixaModelId");

                    b.HasIndex("IdCaixa");

                    b.HasIndex("IdMembro");

                    b.ToTable("Contribuicao");
                });

            modelBuilder.Entity("c___Api_Example.Models.GastoModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("CaixaModelId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("Data")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<int>("IdCaixa")
                        .HasColumnType("integer");

                    b.Property<string>("NumeroFiscal")
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<string>("UrlComprovante")
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<decimal>("Valor")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.HasIndex("CaixaModelId");

                    b.HasIndex("IdCaixa");

                    b.ToTable("Gasto");
                });

            modelBuilder.Entity("c___Api_Example.Models.UsuarioModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool?>("Active")
                        .IsRequired()
                        .HasColumnType("boolean");

                    b.Property<string>("BairroEdereco")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<string>("CepEndereco")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<string>("CidadeEndereco")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<string>("Cpf")
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<DateTime>("Data_nascimento")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<string>("NumeroEndereco")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<string>("RGEmissor")
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<string>("RGnumero")
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<string>("RuaEdereco")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<int>("Rule")
                        .HasColumnType("integer");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<string>("TelefoneDdd")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("TelefoneNumero")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("Telefone_pais")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("TokenContribuicao")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<string>("UfEndereco")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("TokenContribuicao")
                        .IsUnique();

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("c___Api_Example.Models.ContribuicaoModel", b =>
                {
                    b.HasOne("c___Api_Example.Models.CaixaModel", null)
                        .WithMany("Contribuicoes")
                        .HasForeignKey("CaixaModelId");

                    b.HasOne("c___Api_Example.Models.CaixaModel", "Caixa")
                        .WithMany()
                        .HasForeignKey("IdCaixa")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("c___Api_Example.Models.UsuarioModel", "Membro")
                        .WithMany("Contribuicao")
                        .HasForeignKey("IdMembro");

                    b.Navigation("Caixa");

                    b.Navigation("Membro");
                });

            modelBuilder.Entity("c___Api_Example.Models.GastoModel", b =>
                {
                    b.HasOne("c___Api_Example.Models.CaixaModel", null)
                        .WithMany("Gastos")
                        .HasForeignKey("CaixaModelId");

                    b.HasOne("c___Api_Example.Models.CaixaModel", "Caixa")
                        .WithMany()
                        .HasForeignKey("IdCaixa")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Caixa");
                });

            modelBuilder.Entity("c___Api_Example.Models.CaixaModel", b =>
                {
                    b.Navigation("Contribuicoes");

                    b.Navigation("Gastos");
                });

            modelBuilder.Entity("c___Api_Example.Models.UsuarioModel", b =>
                {
                    b.Navigation("Contribuicao");
                });
#pragma warning restore 612, 618
        }
    }
}
