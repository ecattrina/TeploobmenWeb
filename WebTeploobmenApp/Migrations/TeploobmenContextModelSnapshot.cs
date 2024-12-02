﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebTeploobmenApp.Data;

#nullable disable

namespace WebTeploobmenApp.Migrations
{
    [DbContext(typeof(TeploobmenContext))]
    partial class TeploobmenContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.11");

            modelBuilder.Entity("WebTeploobmenApp.Data.InputData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double>("Diametrapparata")
                        .HasColumnType("REAL");

                    b.Property<double>("Kofteplo")
                        .HasColumnType("REAL");

                    b.Property<double>("Nachtempgas")
                        .HasColumnType("REAL");

                    b.Property<double>("Nachtempmaterial")
                        .HasColumnType("REAL");

                    b.Property<int>("OperationType")
                        .HasColumnType("INTEGER");

                    b.Property<double>("Rashodmaterial")
                        .HasColumnType("REAL");

                    b.Property<double>("Skorostgas")
                        .HasColumnType("REAL");

                    b.Property<double>("Sredtemplogas")
                        .HasColumnType("REAL");

                    b.Property<double>("Teploemmaterial")
                        .HasColumnType("REAL");

                    b.Property<double>("Visotasloy")
                        .HasColumnType("REAL");

                    b.Property<double>("Ycoordinate")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.ToTable("DataInput");
                });
#pragma warning restore 612, 618
        }
    }
}
