﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebExample.Data;

namespace WebExample.Migrations
{
    [DbContext(typeof(WebExampleContext))]
    partial class WebExampleContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("WebExample.Models.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("BirthDate");

                    b.Property<int>("Cpf");

                    b.Property<string>("Name");

                    b.Property<double>("Salary");

                    b.HasKey("Id");

                    b.ToTable("Person");
                });

            modelBuilder.Entity("WebExample.Models.Segment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Segments");
                });

            modelBuilder.Entity("WebExample.Models.SpendsRecord", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("Amount");

                    b.Property<DateTime>("Date");

                    b.Property<int?>("PersonId");

                    b.Property<int?>("SegmentId");

                    b.Property<int>("Status");

                    b.HasKey("Id");

                    b.HasIndex("PersonId");

                    b.HasIndex("SegmentId");

                    b.ToTable("SpendsRecord");
                });

            modelBuilder.Entity("WebExample.Models.SpendsRecord", b =>
                {
                    b.HasOne("WebExample.Models.Person", "Person")
                        .WithMany("Spends")
                        .HasForeignKey("PersonId");

                    b.HasOne("WebExample.Models.Segment", "Segment")
                        .WithMany("Spends")
                        .HasForeignKey("SegmentId");
                });
#pragma warning restore 612, 618
        }
    }
}
