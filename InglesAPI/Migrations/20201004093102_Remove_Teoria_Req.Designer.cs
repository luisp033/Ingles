﻿// <auto-generated />
using InglesAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace InglesAPI.Migrations
{
    [DbContext(typeof(AppDBContext))]
    [Migration("20201004093102_Remove_Teoria_Req")]
    partial class Remove_Teoria_Req
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("InglesModels.Capitulo", b =>
                {
                    b.Property<int>("CapituloId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CapituloNome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CapituloNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CapituloTeoria")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CapituloId");

                    b.ToTable("Capitulos");
                });

            modelBuilder.Entity("InglesModels.Exercicio", b =>
                {
                    b.Property<int>("ExercicioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CapituloId")
                        .HasColumnType("int");

                    b.Property<string>("ExercicioImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ExercicioNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ExercicioTexto")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ExercicioId");

                    b.HasIndex("CapituloId");

                    b.ToTable("Exercicios");
                });

            modelBuilder.Entity("InglesModels.Questao", b =>
                {
                    b.Property<int>("QuestaoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ExercicioId")
                        .HasColumnType("int");

                    b.Property<string>("QuestaoNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("QuestaoTexto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("QuestaoId");

                    b.HasIndex("ExercicioId");

                    b.ToTable("Questoes");
                });

            modelBuilder.Entity("InglesModels.Exercicio", b =>
                {
                    b.HasOne("InglesModels.Capitulo", "Capitulo")
                        .WithMany()
                        .HasForeignKey("CapituloId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("InglesModels.Questao", b =>
                {
                    b.HasOne("InglesModels.Exercicio", "Exercicio")
                        .WithMany()
                        .HasForeignKey("ExercicioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
