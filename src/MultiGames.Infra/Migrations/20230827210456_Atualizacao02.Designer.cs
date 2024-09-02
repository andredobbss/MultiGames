﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MultiGames.Infra.DataBase.Context;

#nullable disable

namespace MultiGames.Infra.Migrations
{
    [DbContext(typeof(MultiGamesContext))]
    [Migration("20230827210456_Atualizacao02")]
    partial class Atualizacao02
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.21")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("MultiGames.Domain.Entities.AddressDomain", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CelPhone")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("City")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Country")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTimeOffset>("DateCriate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("PostalCode")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("State")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Street")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("StreetNumber")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("TelPhone")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("Id");

                    b.ToTable("Adresses");
                });

            modelBuilder.Entity("MultiGames.Domain.Entities.BrotherDomain", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AddressId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Cpf")
                        .HasMaxLength(14)
                        .HasColumnType("nvarchar(14)");

                    b.Property<DateTimeOffset>("DateCriate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Email")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.ToTable("Brothers");
                });

            modelBuilder.Entity("MultiGames.Domain.Entities.GameDomain", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("BrotherId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("DateCriate")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset>("DateOut")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Status")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("Title")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("VersionEdition")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("Id");

                    b.HasIndex("BrotherId");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("MultiGames.Domain.Entities.BrotherDomain", b =>
                {
                    b.HasOne("MultiGames.Domain.Entities.AddressDomain", "Address")
                        .WithMany("Brothers")
                        .HasForeignKey("AddressId");

                    b.Navigation("Address");
                });

            modelBuilder.Entity("MultiGames.Domain.Entities.GameDomain", b =>
                {
                    b.HasOne("MultiGames.Domain.Entities.BrotherDomain", "Brother")
                        .WithMany("Games")
                        .HasForeignKey("BrotherId");

                    b.Navigation("Brother");
                });

            modelBuilder.Entity("MultiGames.Domain.Entities.AddressDomain", b =>
                {
                    b.Navigation("Brothers");
                });

            modelBuilder.Entity("MultiGames.Domain.Entities.BrotherDomain", b =>
                {
                    b.Navigation("Games");
                });
#pragma warning restore 612, 618
        }
    }
}
