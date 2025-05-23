﻿// <auto-generated />
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ModelPlaneAPI.Data;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ModelPlaneAPI.Persistence.Data.Migrations
{
    [DbContext(typeof(PlaneContext))]
    partial class PlaneContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Plane", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Airline")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Continent")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Engines")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<List<string>>("Images")
                        .IsRequired()
                        .HasColumnType("text[]");

                    b.Property<bool>("IncludesStand")
                        .HasColumnType("boolean");

                    b.Property<string>("Manufacturer")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Notes")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PartNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ProductionYears")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Registration")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("RollingGears")
                        .HasColumnType("boolean");

                    b.Property<string>("Scale")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("UnitsMade")
                        .HasColumnType("integer");

                    b.Property<int>("Wings900Id")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Planes", (string)null);
                });

            modelBuilder.Entity("User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
